using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Diagnostics;
using TraktNET.SourceGeneration.Common;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Requests
{
    internal sealed class TraktRequestParser
    {
        private readonly KnownRequestSymbols _knownRequestSymbols;
        private readonly bool _compilationContainsRequestType;
        private readonly bool _compilationContainsRequestPropertyAttributeType;
        private INamedTypeSymbol? _requestClassDeclarationSymbol;
        private Location? _requestClassDeclarationLocation;

        private string _httpMethodValue = string.Empty;
        private string _uriPath = string.Empty;
        private bool _requestSupportsExtendedInfo;
        private bool _requestSupportsPagination;
        private bool _requestHasOAuthRequirementDefined;
        private string _requestOAuthRequirementValue = string.Empty;
        private readonly List<RequestParameterGenerationSpecification> _requestParameters = [];
        private readonly List<RequestQueryGenerationSpecification> _requestQueries = [];
        private RequestPayloadGenerationSpecification? _requestPayload;

        internal List<DiagnosticInfo> Diagnostics { get; } = [];

        internal TraktRequestParser(KnownRequestSymbols knownRequestSymbols)
        {
            _knownRequestSymbols = knownRequestSymbols;

            _compilationContainsRequestType = _knownRequestSymbols.TraktGetRequestAttributeType != null
                || _knownRequestSymbols.TraktPostRequestAttributeType != null || _knownRequestSymbols.TraktPutRequestAttributeType != null
                || _knownRequestSymbols.TraktDeleteRequestAttributeType != null;

            _compilationContainsRequestPropertyAttributeType = _knownRequestSymbols.TraktRequestParameterAttributeType != null
                || _knownRequestSymbols.TraktRequestQueryAttributeType != null
                || _knownRequestSymbols.TraktRequestPayloadAttributeType != null;
        }

        internal RequestGenerationSpecification? Parse(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (!_compilationContainsRequestType)
            {
                return null;
            }

            cancellationToken.ThrowIfCancellationRequested();
            GetClassSymbolAndLocation(classDeclaration, semanticModel, cancellationToken);

            if (!ParseAttributes(cancellationToken))
            {
                return null;
            }

            if (!ParseProperties(cancellationToken))
            {
                return null;
            }

            return CreateSpecification();
        }

        private bool ParseAttributes(CancellationToken cancellationToken)
        {
            Debug.Assert(_requestClassDeclarationSymbol != null);

            foreach (AttributeData attributeData in _requestClassDeclarationSymbol!.GetAttributes())
            {
                cancellationToken.ThrowIfCancellationRequested();

                INamedTypeSymbol? attributeClass = attributeData.AttributeClass;

                Location? attributeLocation = null;

                if (attributeClass!.Locations.Length > 0)
                {
                    attributeLocation = attributeClass.Locations[0];
                }

                bool isTraktRequestAttribute =
                    SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktGetRequestAttributeType)
                    || SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktPostRequestAttributeType)
                    || SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktPutRequestAttributeType)
                    || SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktDeleteRequestAttributeType);

                if (isTraktRequestAttribute)
                {
                    return ParseRequestAttribute(attributeData, attributeLocation, cancellationToken);
                }
            }

            return true;
        }

        private bool ParseProperties(CancellationToken cancellationToken)
        {
            if (!_compilationContainsRequestPropertyAttributeType)
            {
                return true;
            }

            Debug.Assert(_requestClassDeclarationSymbol != null);
            var classProperties = _requestClassDeclarationSymbol!.GetMembers().Where(s => s.Kind == SymbolKind.Property).ToImmutableArray();

            foreach (ISymbol member in classProperties)
            {
                cancellationToken.ThrowIfCancellationRequested();

                ImmutableArray<AttributeData> attributes = member.GetAttributes();

                if (attributes.Length == 0)
                {
                    // Ignore properties without any attributes.
                    continue;
                }

                if (member is not IPropertySymbol propertySymbol)
                {
                    continue;
                }

                if (!ParseRequestProperty(propertySymbol, attributes, cancellationToken))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ParseRequestProperty(IPropertySymbol propertySymbol, ImmutableArray<AttributeData> attributes, CancellationToken cancellationToken)
        {
            if (!TryParsePropertyAttributes(attributes, cancellationToken, out PropertyAttributeInfo attributeInfo))
                return false;

            bool isRequired = propertySymbol.Type.NullableAnnotation != NullableAnnotation.Annotated;
            PropertyTypeInfo typeInfo = isRequired ? ClassifyPropertyType(propertySymbol.Type) : ClassifyNullablePropertyType(propertySymbol.Type);
            Location? propertyLocation = GetFirstLocation(propertySymbol);

            switch (attributeInfo.Kind)
            {
                case RequestPropertyKind.Parameter:
                    _requestParameters.Add(new RequestParameterGenerationSpecification
                    {
                        Name = propertySymbol.Name,
                        IsRequired = isRequired,
                        IsTraktEnum = typeInfo.IsTraktEnum,
                        TraktEnumTypeName = typeInfo.TraktEnumTypeName,
                        TraktEnumDefaultValue = typeInfo.TraktEnumDefaultValue,
                        SpecialType = typeInfo.SpecialType,
                        UseCacheEfficientDateTime = attributeInfo.UseCacheEfficientDateTime
                    });

                    return true;

                case RequestPropertyKind.Query:
                    return TryAddRequestQuery(propertySymbol.Name, isRequired, typeInfo, attributeInfo, propertyLocation);

                case RequestPropertyKind.Payload:
                    return TrySetRequestPayload(propertySymbol, typeInfo, attributeInfo, propertyLocation);

                default:
                    return true;
            }
        }

        private bool TryAddRequestQuery(string name, bool isRequired, PropertyTypeInfo typeInfo, PropertyAttributeInfo attributeInfo, Location? propertyLocation)
        {
            if (!typeInfo.IsTraktEnum && string.IsNullOrEmpty(attributeInfo.QueryName))
            {
                // Query Name is only optional if property type is not a Trakt enum
                ReportDiagnostic(DiagnosticDescriptors.QueryNameIsRequired, propertyLocation);
                return false;
            }

            _requestQueries.Add(new RequestQueryGenerationSpecification
            {
                Name = name,
                IsRequired = isRequired,
                IsTraktEnum = typeInfo.IsTraktEnum,
                TraktEnumTypeName = typeInfo.TraktEnumTypeName,
                TraktEnumDefaultValue = typeInfo.TraktEnumDefaultValue,
                QueryName = attributeInfo.QueryName,
                SpecialType = typeInfo.SpecialType,
                UseCacheEfficientDateTime = attributeInfo.UseCacheEfficientDateTime
            });

            return true;
        }

        private bool TrySetRequestPayload(IPropertySymbol propertySymbol, PropertyTypeInfo typeInfo, PropertyAttributeInfo attributeInfo, Location? propertyLocation)
        {
            if (_requestPayload != null)
            {
                ReportDiagnostic(DiagnosticDescriptors.RequestPayloadAlreadyDeclared, propertyLocation);
                return false;
            }

            _requestPayload = new RequestPayloadGenerationSpecification
            {
                Name = propertySymbol.Name,
                // A payload is required, if its property is declared with the "required" modifier.
                IsRequired = propertySymbol.IsRequired,
                IsTraktEnum = typeInfo.IsTraktEnum,
                TraktEnumTypeName = typeInfo.TraktEnumTypeName,
                TraktEnumDefaultValue = typeInfo.TraktEnumDefaultValue,
                SpecialType = typeInfo.SpecialType,
                UseCacheEfficientDateTime = attributeInfo.UseCacheEfficientDateTime,
                HasValidateMethod = HasParameterlessValidateMethod(propertySymbol.Type)
            };

            return true;
        }

        /// <summary>Determines whether the type or one of its base types declares a parameterless, non-generic instance Validate method.</summary>
        private static bool HasParameterlessValidateMethod(ITypeSymbol type)
        {
            for (ITypeSymbol? currentType = type; currentType != null; currentType = currentType.BaseType)
            {
                if (currentType.GetMembers("Validate").OfType<IMethodSymbol>().Any(m => m.Parameters.Length == 0 && m.Arity == 0 && !m.IsStatic))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether a property is a request parameter, query or payload.
        /// Returns <see langword="false" /> and reports a diagnostic, if the property has conflicting attributes.
        /// </summary>
        private bool TryParsePropertyAttributes(ImmutableArray<AttributeData> attributes, CancellationToken cancellationToken, out PropertyAttributeInfo attributeInfo)
        {
            attributeInfo = new PropertyAttributeInfo();

            foreach (AttributeData attributeData in attributes)
            {
                cancellationToken.ThrowIfCancellationRequested();

                RequestPropertyKind attributeKind = GetRequestPropertyKind(attributeData.AttributeClass);

                if (attributeKind == RequestPropertyKind.None)
                    continue;

                DiagnosticDescriptor? conflict = GetAttributeConflict(attributeInfo.Kind, attributeKind);

                if (conflict != null)
                {
                    ReportDiagnostic(conflict, GetFirstLocation(attributeData.AttributeClass!));
                    return false;
                }

                attributeInfo.Kind = attributeKind;

                if (attributeKind == RequestPropertyKind.Query)
                    attributeInfo.QueryName = GetQueryName(attributeData) ?? attributeInfo.QueryName;

                if (attributeKind != RequestPropertyKind.Payload)
                    attributeInfo.UseCacheEfficientDateTime = GetUseCacheEfficientDateTime(attributeData) ?? attributeInfo.UseCacheEfficientDateTime;
            }

            return true;
        }

        private RequestPropertyKind GetRequestPropertyKind(INamedTypeSymbol? attributeClass)
        {
            if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktRequestParameterAttributeType))
                return RequestPropertyKind.Parameter;

            if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktRequestQueryAttributeType))
                return RequestPropertyKind.Query;

            if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktRequestPayloadAttributeType))
                return RequestPropertyKind.Payload;

            return RequestPropertyKind.None;
        }

        /// <summary>A property can be either a parameter, a query or a payload. Repeating the same attribute is no conflict.</summary>
        private static DiagnosticDescriptor? GetAttributeConflict(RequestPropertyKind currentKind, RequestPropertyKind attributeKind)
        {
            if (currentKind == RequestPropertyKind.None || currentKind == attributeKind)
                return null;

            if (currentKind == RequestPropertyKind.Payload || attributeKind == RequestPropertyKind.Payload)
                return DiagnosticDescriptors.RequestPayloadConflict;

            return DiagnosticDescriptors.RequestAndQueryBothDeclared;
        }

        private static string? GetQueryName(AttributeData attributeData)
        {
            ImmutableArray<TypedConstant> arguments = attributeData.ConstructorArguments;
            string? queryName = arguments.Length > 0 ? arguments[0].Value as string : null;
            return string.IsNullOrWhiteSpace(queryName) ? null : queryName;
        }

        private static bool? GetUseCacheEfficientDateTime(AttributeData attributeData)
        {
            var namedArguments = attributeData.NamedArguments.ToImmutableDictionary();

            if (namedArguments.TryGetValue(RequestConstants.TraktRequestParameterOrQueryUseCacheEfficientDateTimeName, out TypedConstant constant)
                && constant.Value is bool useCacheEfficientDateTime)
            {
                return useCacheEfficientDateTime;
            }

            return null;
        }

        /// <summary>
        /// Classifies the type of an optional property.
        /// Only <see langword="string" />? and <see cref="Nullable{T}" /> types are supported, other nullable types are not classified.
        /// </summary>
        private static PropertyTypeInfo ClassifyNullablePropertyType(ITypeSymbol type)
        {
            if (type is not INamedTypeSymbol namedType)
                return PropertyTypeInfo.Unclassified;

            if (namedType.ConstructedFrom.SpecialType == SpecialType.System_String)
                return new PropertyTypeInfo { SpecialType = SpecialType.System_String };

            if (namedType.ConstructedFrom.SpecialType == SpecialType.System_Nullable_T && namedType.TypeArguments.Length > 0)
                return ClassifyPropertyType(namedType.TypeArguments[0]);

            return PropertyTypeInfo.Unclassified;
        }

        /// <summary>
        /// Classifies a property type as Trakt enum or special type. Special types get handled in the RequestSourceEmitter.
        /// Enums that are not Trakt enums are not classified.
        /// </summary>
        private static PropertyTypeInfo ClassifyPropertyType(ITypeSymbol type)
        {
            if (type.TypeKind == TypeKind.Enum)
            {
                return type.Name.StartsWith("Trakt", StringComparison.InvariantCulture)
                    ? new PropertyTypeInfo { IsTraktEnum = true, TraktEnumTypeName = type.Name, TraktEnumDefaultValue = type.GetMembers()[0].Name }
                    : PropertyTypeInfo.Unclassified;
            }

            if (type.SpecialType != SpecialType.None && type.TypeKind != TypeKind.Error)
                return new PropertyTypeInfo { SpecialType = type.SpecialType };

            return PropertyTypeInfo.Unclassified;
        }

        private static Location? GetFirstLocation(ISymbol symbol)
            => symbol.Locations.Length > 0 ? symbol.Locations[0] : null;

        private enum RequestPropertyKind
        {
            None,
            Parameter,
            Query,
            Payload
        }

        private sealed class PropertyAttributeInfo
        {
            internal RequestPropertyKind Kind { get; set; }

            internal string QueryName { get; set; } = string.Empty;

            internal bool UseCacheEfficientDateTime { get; set; }
        }

        private readonly record struct PropertyTypeInfo
        {
            internal static PropertyTypeInfo Unclassified => new();

            internal bool IsTraktEnum { get; init; }

            internal string TraktEnumTypeName { get; init; }

            internal string TraktEnumDefaultValue { get; init; }

            internal SpecialType SpecialType { get; init; }

            public PropertyTypeInfo()
            {
                TraktEnumTypeName = string.Empty;
                TraktEnumDefaultValue = string.Empty;
                SpecialType = SpecialType.None;
            }
        }

        private RequestGenerationSpecification? CreateSpecification()
            => new()
            {
                Name = _requestClassDeclarationSymbol!.Name,
                Namespace = _requestClassDeclarationSymbol.ContainingNamespace.ToDisplayString(),
                HttpMethodValue = _httpMethodValue,
                UriPath = _uriPath,
                OAuthRequirementValue = _requestOAuthRequirementValue,
                SupportsExtendedInfo = _requestSupportsExtendedInfo,
                SupportsPagination = _requestSupportsPagination,
                HasOAuthRequirementDefined = _requestHasOAuthRequirementDefined,
                RequestParameters = _requestParameters.ToImmutableEquatableArray(),
                RequestQueries = _requestQueries.ToImmutableEquatableArray(),
                RequestPayload = _requestPayload
            };

        private void ReportDiagnostic(DiagnosticDescriptor descriptor, Location? location)
        {
            Debug.Assert(_requestClassDeclarationLocation != null);

            if (location == null || (location.SourceTree != null && !_knownRequestSymbols.Compilation.ContainsSyntaxTree(location.SourceTree)))
            {
                location = _requestClassDeclarationLocation;
            }

            Diagnostics.Add(DiagnosticInfo.Create(descriptor, location));
        }

        private void GetClassSymbolAndLocation(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            _requestClassDeclarationSymbol = semanticModel.GetDeclaredSymbol(classDeclaration, cancellationToken);

            // A null symbol results in a null location, which is asserted below.
            if (_requestClassDeclarationSymbol?.Locations.Length > 0)
            {
                _requestClassDeclarationLocation = _requestClassDeclarationSymbol.Locations[0];
            }

            Debug.Assert(_requestClassDeclarationLocation != null);
        }

        private bool ParseRequestAttribute(AttributeData attributeData, Location? attributeLocation, CancellationToken cancellationToken)
        {
            GetHttpMethodValue(attributeData, cancellationToken);

            ImmutableArray<TypedConstant> constructorArguments = attributeData.ConstructorArguments;
            string? uriPathValue = constructorArguments[0].Value as string;

            if (string.IsNullOrEmpty(uriPathValue))
            {
                ReportDiagnostic(DiagnosticDescriptors.InvalidRequestUriPathValue, attributeLocation);
                return false;
            }
            else
            {
                _uriPath = uriPathValue!;
            }

            var namedArguments = attributeData.NamedArguments.ToImmutableDictionary();

            if (_knownRequestSymbols.TraktExtendedInfoEnumType != null
                && namedArguments.TryGetValue(RequestConstants.TraktRequestPropertySupportsExtendedInfoName, out TypedConstant supportsExtendedInfoConstant)
                && supportsExtendedInfoConstant.Value is bool supportsExtendedInfo)
            {
                _requestSupportsExtendedInfo = supportsExtendedInfo;
            }

            if (namedArguments.TryGetValue(RequestConstants.TraktRequestPropertySupportsPaginationName, out TypedConstant supportsPaginationConstant)
                && supportsPaginationConstant.Value is bool supportsPagination)
            {
                _requestSupportsPagination = supportsPagination;
            }

            if (_knownRequestSymbols.TraktOAuthRequirementEnumType != null)
                ParseOAuthRequirement(namedArguments);

            return true;
        }

        private void ParseOAuthRequirement(ImmutableDictionary<string, TypedConstant> namedArguments)
        {
            if (!namedArguments.TryGetValue(RequestConstants.TraktRequestPropertyOAuthRequirementName, out TypedConstant oauthRequirementConstant))
            {
                // If not defined, use first value ("NotRequired") as default.
                _requestHasOAuthRequirementDefined = _knownRequestSymbols.TraktOAuthRequirementValues.Count > 0;
                IFieldSymbol? defaultEnumField = _knownRequestSymbols.TraktOAuthRequirementValues[0];
                _requestOAuthRequirementValue = defaultEnumField.Name;
                return;
            }

            if (!SymbolEqualityComparer.Default.Equals(oauthRequirementConstant.Type, _knownRequestSymbols.TraktOAuthRequirementEnumType)
                || oauthRequirementConstant.Value is not int requirementValue)
            {
                return;
            }

            _requestHasOAuthRequirementDefined = _knownRequestSymbols.TraktOAuthRequirementValues.Count > 0;

            IFieldSymbol? enumField = _knownRequestSymbols.TraktOAuthRequirementValues
                .FirstOrDefault(x => x.ConstantValue is int enumValue && enumValue == requirementValue);

            if (enumField != null)
                _requestOAuthRequirementValue = enumField.Name;
        }

        private void GetHttpMethodValue(AttributeData attributeData, CancellationToken cancellationToken)
        {
            SyntaxReference declaredSyntaxReference = attributeData.AttributeClass!.DeclaringSyntaxReferences[0];
            SyntaxNode rootNode = declaredSyntaxReference.SyntaxTree.GetRoot(cancellationToken);

            var attributeVisitor = new AttributeHttpMethodCollector();
            attributeVisitor.Visit(rootNode);
            _httpMethodValue = attributeVisitor.HttpMethod;
        }

        private sealed class AttributeHttpMethodCollector : CSharpSyntaxWalker
        {
            public string HttpMethod { get; private set; } = string.Empty;

            public override void VisitPrimaryConstructorBaseType(PrimaryConstructorBaseTypeSyntax node)
            {
                if (node.Type.ToString() == RequestConstants.TraktRequestAttributeName
                    && node.ArgumentList.Arguments[0].Expression is MemberAccessExpressionSyntax httpMethodArgument)
                {
                    HttpMethod = httpMethodArgument.Name.ToString();
                }
            }
        }
    }
}
