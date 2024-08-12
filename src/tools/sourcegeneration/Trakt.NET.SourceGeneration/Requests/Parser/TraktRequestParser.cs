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

        internal List<DiagnosticInfo> Diagnostics { get; } = [];

        internal TraktRequestParser(KnownRequestSymbols knownRequestSymbols)
        {
            _knownRequestSymbols = knownRequestSymbols;

            _compilationContainsRequestType = _knownRequestSymbols.TraktGetRequestAttributeType != null
                || _knownRequestSymbols.TraktPostRequestAttributeType != null || _knownRequestSymbols.TraktPutRequestAttributeType != null
                || _knownRequestSymbols.TraktDeleteRequestAttributeType != null;

            _compilationContainsRequestPropertyAttributeType = _knownRequestSymbols.TraktRequestParameterAttributeType != null
                || _knownRequestSymbols.TraktRequestQueryAttributeType != null;
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
                    attributeLocation = attributeClass!.Locations[0];
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
            bool isRequired = false;
            bool isTraktEnum = false;
            string traktEnumTypeName = string.Empty;
            string traktEnumDefaultValue = string.Empty;
            bool hasParameterAttribute = false;
            bool hasQueryAttribute = false;
            SpecialType specialType = SpecialType.None;
            string queryName = string.Empty;
            bool useCacheEfficientDateTime = false;

            foreach (AttributeData attributeData in attributes)
            {
                cancellationToken.ThrowIfCancellationRequested();

                INamedTypeSymbol? attributeClass = attributeData.AttributeClass;

                Location? attributeLocation = null;

                if (attributeClass!.Locations.Length > 0)
                {
                    attributeLocation = attributeClass!.Locations[0];
                }

                if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktRequestParameterAttributeType))
                {
                    if (hasQueryAttribute)
                    {
                        ReportDiagnostic(DiagnosticDescriptors.RequestAndQueryBothDeclared, attributeLocation);
                        return false;
                    }

                    hasParameterAttribute = true;

                    var namedArguments = attributeData.NamedArguments.ToImmutableDictionary();

                    if (namedArguments.TryGetValue(RequestConstants.TraktRequestParameterOrQueryUseCacheEfficientDateTimeName, out TypedConstant useCacheEfficientDateTimeConstant)
                        && useCacheEfficientDateTimeConstant.Value is bool useCacheEfficientDateTimeValue)
                    {
                        useCacheEfficientDateTime = useCacheEfficientDateTimeValue;
                    }
                }
                else if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownRequestSymbols.TraktRequestQueryAttributeType))
                {
                    if (hasParameterAttribute)
                    {
                        ReportDiagnostic(DiagnosticDescriptors.RequestAndQueryBothDeclared, attributeLocation);
                        return false;
                    }

                    hasQueryAttribute = true;

                    ImmutableArray<TypedConstant> arguments = attributeData.ConstructorArguments;

                    if (arguments.Length > 0)
                    {
                        string? queryNameValue = arguments[0].Value as string;

                        if (!string.IsNullOrWhiteSpace(queryNameValue))
                        {
                            queryName = queryNameValue!;
                        }
                    }

                    var namedArguments = attributeData.NamedArguments.ToImmutableDictionary();

                    if (namedArguments.TryGetValue(RequestConstants.TraktRequestParameterOrQueryUseCacheEfficientDateTimeName, out TypedConstant useCacheEfficientDateTimeConstant)
                        && useCacheEfficientDateTimeConstant.Value is bool useCacheEfficientDateTimeValue)
                    {
                        useCacheEfficientDateTime = useCacheEfficientDateTimeValue;
                    }
                }
            }

            string name = propertySymbol.Name;
            Location? propertyLocation = null;

            if (propertySymbol.Locations.Length > 0)
            {
                propertyLocation = propertySymbol.Locations[0];
            }

            if (propertySymbol.Type.NullableAnnotation == NullableAnnotation.Annotated)
            {
                // Property type is a nullable type => optional

                if (propertySymbol.Type is INamedTypeSymbol propertyTypeSymbol)
                {
                    if (propertyTypeSymbol.ConstructedFrom.SpecialType == SpecialType.System_String)
                    {
                        // string is a special nullable type
                        // Special types get handled in the RequestSourceEmitter
                        specialType = propertyTypeSymbol.ConstructedFrom.SpecialType;
                    }
                    else if (propertyTypeSymbol.ConstructedFrom.SpecialType == SpecialType.System_Nullable_T && propertyTypeSymbol.TypeArguments.Length > 0)
                    {
                        ITypeSymbol underlyingType = propertyTypeSymbol.TypeArguments[0];

                        if (underlyingType.TypeKind == TypeKind.Enum)
                        {
                            if (underlyingType.Name.StartsWith("Trakt", StringComparison.InvariantCulture))
                            {
                                // Property type as a Trakt enum
                                isTraktEnum = true;
                                traktEnumTypeName = underlyingType.Name;
                                traktEnumDefaultValue = underlyingType.GetMembers()[0].Name;
                            }
                        }
                        else if (underlyingType.SpecialType != SpecialType.None && underlyingType.TypeKind != TypeKind.Error)
                        {
                            // Special types get handled in the RequestSourceEmitter
                            specialType = underlyingType.SpecialType;
                        }
                    }
                }
            }
            else
            {
                isRequired = true;

                if (propertySymbol.Type.TypeKind == TypeKind.Enum)
                {
                    if (propertySymbol.Type.Name.StartsWith("Trakt", StringComparison.InvariantCulture))
                    {
                        // Property type as a Trakt enum
                        isTraktEnum = true;
                        traktEnumTypeName = propertySymbol.Type.Name;
                        traktEnumDefaultValue = propertySymbol.Type.GetMembers()[0].Name;
                    }
                }
                else if (propertySymbol.Type.SpecialType != SpecialType.None && propertySymbol.Type.TypeKind != TypeKind.Error)
                {
                    // Special types get handled in the RequestSourceEmitter
                    specialType = propertySymbol.Type.SpecialType;
                }
            }

            if (hasParameterAttribute)
            {
                _requestParameters.Add(new RequestParameterGenerationSpecification
                {
                    Name = name,
                    IsRequired = isRequired,
                    IsTraktEnum = isTraktEnum,
                    TraktEnumTypeName = traktEnumTypeName,
                    TraktEnumDefaultValue = traktEnumDefaultValue,
                    SpecialType = specialType,
                    UseCacheEfficientDateTime = useCacheEfficientDateTime
                });
            }
            else if (hasQueryAttribute)
            {
                if (!isTraktEnum && string.IsNullOrEmpty(queryName))
                {
                    // Query Name is only optional if property type is not a Trakt enum
                    ReportDiagnostic(DiagnosticDescriptors.QueryNameIsRequired, propertyLocation);
                    return false;
                }

                _requestQueries.Add(new RequestQueryGenerationSpecification
                {
                    Name = name,
                    IsRequired = isRequired,
                    IsTraktEnum = isTraktEnum,
                    TraktEnumTypeName = traktEnumTypeName,
                    TraktEnumDefaultValue = traktEnumDefaultValue,
                    QueryName = queryName,
                    SpecialType = specialType,
                    UseCacheEfficientDateTime = useCacheEfficientDateTime
                });
            }

            return true;
        }

        private RequestGenerationSpecification? CreateSpecification()
            => new()
            {
                Name = _requestClassDeclarationSymbol!.Name,
                Namespace = _requestClassDeclarationSymbol!.ContainingNamespace.ToDisplayString(),
                HttpMethodValue = _httpMethodValue,
                UriPath = _uriPath,
                OAuthRequirementValue = _requestOAuthRequirementValue,
                SupportsExtendedInfo = _requestSupportsExtendedInfo,
                SupportsPagination = _requestSupportsPagination,
                HasOAuthRequirementDefined = _requestHasOAuthRequirementDefined,
                RequestParameters = _requestParameters,
                RequestQueries = _requestQueries
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
            Debug.Assert(_requestClassDeclarationSymbol != null);

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
            {
                if (namedArguments.TryGetValue(RequestConstants.TraktRequestPropertyOAuthRequirementName, out TypedConstant oauthRequirementConstant))
                {
                    if (SymbolEqualityComparer.Default.Equals(oauthRequirementConstant.Type, _knownRequestSymbols.TraktOAuthRequirementEnumType)
                        && oauthRequirementConstant.Value is int requirementValue)
                    {
                        _requestHasOAuthRequirementDefined = _knownRequestSymbols.TraktOAuthRequirementValues.Count > 0;

                        IFieldSymbol? enumField = _knownRequestSymbols.TraktOAuthRequirementValues
                            .FirstOrDefault(x => x.ConstantValue is int enumValue && enumValue == requirementValue);

                        if (enumField != null)
                        {
                            _requestOAuthRequirementValue = enumField.Name;
                        }
                    }
                }
                else
                {
                    // If not defined, use first value ("NotRequired") as default.
                    _requestHasOAuthRequirementDefined = _knownRequestSymbols.TraktOAuthRequirementValues.Count > 0;
                    IFieldSymbol? enumField = _knownRequestSymbols.TraktOAuthRequirementValues.First();
                    _requestOAuthRequirementValue = enumField.Name;
                }
            }

            return true;
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
