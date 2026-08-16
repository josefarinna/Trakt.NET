using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Diagnostics;
using TraktNET.SourceGeneration.Common;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Enums
{
    internal sealed class TraktEnumDeclarationParser
    {
        private readonly KnownEnumSymbols _knownEnumSymbols;
        private readonly bool _compilationContainsTraktEnumTypes;
        private INamedTypeSymbol? _enumDeclarationSymbol;
        private Location? _enumDeclarationLocation;
        private bool _hasFlagsAttribute;
        private string _queryName = string.Empty;
        private bool _hasPathSupport;
        private bool _hasQuerySupport;
        private bool _supportNumberDeserialization;
        private readonly List<EnumMemberGenerationSpecification> _enumMembers = [];
        private string _customJsonSeparator = "_";

        public List<DiagnosticInfo> Diagnostics { get; } = [];

        public TraktEnumDeclarationParser(KnownEnumSymbols knownEnumSymbols)
        {
            _knownEnumSymbols = knownEnumSymbols;
            _compilationContainsTraktEnumTypes = _knownEnumSymbols.TraktEnumAttributeType != null;
        }

        public EnumGenerationSpecification? ParseTraktEnumDeclaration(EnumDeclarationSyntax enumDeclaration,
            SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (!_compilationContainsTraktEnumTypes)
            {
                return null;
            }

            cancellationToken.ThrowIfCancellationRequested();

            GetEnumSymbolAndLocation(enumDeclaration, semanticModel, cancellationToken);

            if (!ParseEnumAttributes(_enumDeclarationSymbol!, cancellationToken))
            {
                return null;
            }

            if (!ParseEnumMembers(_enumDeclarationSymbol!, cancellationToken))
            {
                return null;
            }

            return new EnumGenerationSpecification
            {
                Name = _enumDeclarationSymbol!.Name,
                Namespace = _enumDeclarationSymbol!.ContainingNamespace.ToDisplayString(),
                HasFlagsAttribute = _hasFlagsAttribute,
                QueryName = _queryName,
                HasPathSupport = _hasPathSupport,
                HasQuerySupport = _hasQuerySupport,
                SupportNumberDeserialization = _supportNumberDeserialization,
                Members = _enumMembers.ToImmutableEquatableArray()
            };
        }

        private void GetEnumSymbolAndLocation(EnumDeclarationSyntax enumDeclaration, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            _enumDeclarationSymbol = (INamedTypeSymbol?)semanticModel.GetDeclaredSymbol(enumDeclaration, cancellationToken);
            Debug.Assert(_enumDeclarationSymbol != null);

            if (_enumDeclarationSymbol?.Locations.Length > 0)
            {
                _enumDeclarationLocation = _enumDeclarationSymbol.Locations[0];
            }

            Debug.Assert(_enumDeclarationLocation != null);
        }

        private bool ParseEnumAttributes(INamedTypeSymbol enumTypeSymbol, CancellationToken cancellationToken)
        {
            foreach (AttributeData attributeData in enumTypeSymbol.GetAttributes())
            {
                cancellationToken.ThrowIfCancellationRequested();

                INamedTypeSymbol? attributeClass = attributeData.AttributeClass;

                if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownEnumSymbols.SystemFlagsAttributeType))
                {
                    _hasFlagsAttribute = true;
                }
                else if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownEnumSymbols.TraktEnumAttributeType))
                {
                    var namedArguments = attributeData.NamedArguments.ToImmutableDictionary();

                    if (namedArguments.TryGetValue(EnumConstants.TraktEnumPropertyJsonSeparator, out TypedConstant jsonSeparatorConstant)
                        && jsonSeparatorConstant.Value is string jsonSeparator)
                    {
                        if (string.IsNullOrEmpty(jsonSeparator))
                        {
                            ReportDiagnostic(DiagnosticDescriptors.InvalidCustomJsonSeparator);
                            return false;
                        }
                        else
                        {
                            _customJsonSeparator = jsonSeparator;
                        }
                    }

                    if (namedArguments.TryGetValue(EnumConstants.TraktEnumPropertyQueryName, out TypedConstant queryNameConstant)
                        && queryNameConstant.Value is string queryName)
                    {
                        if (string.IsNullOrEmpty(queryName))
                        {
                            ReportDiagnostic(DiagnosticDescriptors.InvalidQueryNameValue);
                            return false;
                        }

                        _queryName = queryName;
                    }

                    if (namedArguments.TryGetValue(EnumConstants.TraktEnumPropertyHasPathSupport, out TypedConstant hasPathSupportConstant)
                        && hasPathSupportConstant.Value is bool hasPathSupport)
                    {
                        _hasPathSupport = hasPathSupport;
                    }

                    if (namedArguments.TryGetValue(EnumConstants.TraktEnumPropertyHasQuerySupport, out TypedConstant hasQuerySupportConstant)
                        && hasQuerySupportConstant.Value is bool hasQuerySupport)
                    {
                        _hasQuerySupport = hasQuerySupport;
                    }

                    if (namedArguments.TryGetValue(EnumConstants.TraktEnumPropertySupportNumberDeserialization, out TypedConstant supportNumberDeserializationConstant)
                        && supportNumberDeserializationConstant.Value is bool supportNumberDeserialization)
                    {
                        _supportNumberDeserialization = supportNumberDeserialization;
                    }
                }
            }

            if (_hasQuerySupport && string.IsNullOrWhiteSpace(_queryName))
            {
                ReportDiagnostic(DiagnosticDescriptors.InvalidQuerySupportAndQueryNameCombination);
                return false;
            }

            return true;
        }

        private bool ParseEnumMembers(INamedTypeSymbol enumTypeSymbol, CancellationToken cancellationToken)
        {
            foreach (ISymbol enumMember in enumTypeSymbol.GetMembers())
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (enumMember is not IFieldSymbol enumField || enumField.ConstantValue == null)
                {
                    continue;
                }

                string enumMemberName = enumField.Name;
                string displayName = enumMemberName.ToDisplayName();
                string jsonValue = enumMemberName.ToLowercaseNamingConvention(_customJsonSeparator);
                string uriValue = jsonValue;
                bool hasTraktEnumMemberAttribute = false;
                bool hasCustomJsonValue = false;
                bool hasCustomUriValue = false;

                foreach (AttributeData attributeData in enumField.GetAttributes())
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    INamedTypeSymbol? attributeClass = attributeData.AttributeClass;

                    if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownEnumSymbols.TraktEnumMemberAttributeType))
                    {
                        hasTraktEnumMemberAttribute = true;
                        bool hasAnyCustomValueSet = false;

                        var namedArguments = attributeData.NamedArguments.ToImmutableDictionary();

                        if (namedArguments.TryGetValue(EnumConstants.TraktEnumMemberPropertyJsonValue, out TypedConstant jsonValueConstant))
                        {
                            if (jsonValueConstant.Value is not string constantJsonValue)
                            {
                                ReportDiagnostic(DiagnosticDescriptors.InvalidJsonValue);
                                return false;
                            }
                            else
                            {
                                hasAnyCustomValueSet = true;
                                hasCustomJsonValue = true;
                                jsonValue = constantJsonValue;
                            }
                        }

                        if (namedArguments.TryGetValue(EnumConstants.TraktEnumMemberPropertyUriValue, out TypedConstant uriValueConstant))
                        {
                            if (uriValueConstant.Value is not string constantUriValue)
                            {
                                ReportDiagnostic(DiagnosticDescriptors.InvalidUriValue);
                                return false;
                            }
                            else
                            {
                                hasAnyCustomValueSet = true;
                                hasCustomUriValue = true;
                                uriValue = constantUriValue;
                            }
                        }

                        if (namedArguments.TryGetValue(EnumConstants.TraktEnumMemberPropertyDisplayName, out TypedConstant displayNameConstant))
                        {
                            if (displayNameConstant.Value is not string displayNameValue)
                            {
                                ReportDiagnostic(DiagnosticDescriptors.InvalidDisplayNameValue);
                                return false;
                            }
                            else
                            {
                                hasAnyCustomValueSet = true;
                                displayName = displayNameValue!;
                            }
                        }

                        if (!hasAnyCustomValueSet)
                        {
                            ReportDiagnostic(DiagnosticDescriptors.NoCustomValuesProvidedForEnumMemberAttribute);
                        }
                    }
                }

                if (hasCustomJsonValue && !hasCustomUriValue)
                {
                    uriValue = jsonValue;
                }

                _enumMembers.Add(new EnumMemberGenerationSpecification
                {
                    Name = enumMemberName,
                    HasTraktEnumMemberAttribute = hasTraktEnumMemberAttribute,
                    JsonValue = jsonValue,
                    UriValue = uriValue,
                    DisplayName = displayName
                });
            }

            return true;
        }

        private void ReportDiagnostic(DiagnosticDescriptor descriptor)
        {
            Debug.Assert(_enumDeclarationLocation != null);
            Diagnostics.Add(DiagnosticInfo.Create(descriptor, _enumDeclarationLocation));
        }
    }
}
