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
                Namespace = _enumDeclarationSymbol.ContainingNamespace.ToDisplayString(),
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

            // A null symbol results in a null location, which is asserted below.
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
                    _hasFlagsAttribute = true;
                else if (SymbolEqualityComparer.Default.Equals(attributeClass, _knownEnumSymbols.TraktEnumAttributeType) && !ParseTraktEnumAttribute(attributeData))
                    return false;
            }

            if (_hasQuerySupport && string.IsNullOrWhiteSpace(_queryName))
            {
                ReportDiagnostic(DiagnosticDescriptors.InvalidQuerySupportAndQueryNameCombination);
                return false;
            }

            return true;
        }

        private bool ParseTraktEnumAttribute(AttributeData attributeData)
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

                _customJsonSeparator = jsonSeparator;
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

            return true;
        }

        private bool ParseEnumMembers(INamedTypeSymbol enumTypeSymbol, CancellationToken cancellationToken)
        {
            foreach (ISymbol enumMember in enumTypeSymbol.GetMembers())
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (enumMember is not IFieldSymbol enumField || enumField.ConstantValue == null)
                    continue;

                if (!TryParseEnumMember(enumField, cancellationToken, out EnumMemberGenerationSpecification? memberSpecification))
                    return false;

                _enumMembers.Add(memberSpecification!);
            }

            return true;
        }

        private bool TryParseEnumMember(IFieldSymbol enumField, CancellationToken cancellationToken, out EnumMemberGenerationSpecification? memberSpecification)
        {
            memberSpecification = null;

            string enumMemberName = enumField.Name;
            string displayName = enumMemberName.ToDisplayName();
            string jsonValue = enumMemberName.ToLowercaseNamingConvention(_customJsonSeparator);
            string? customUriValue = null;
            bool hasTraktEnumMemberAttribute = false;

            foreach (AttributeData attributeData in enumField.GetAttributes())
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (!SymbolEqualityComparer.Default.Equals(attributeData.AttributeClass, _knownEnumSymbols.TraktEnumMemberAttributeType))
                    continue;

                hasTraktEnumMemberAttribute = true;

                if (!TryParseEnumMemberAttribute(attributeData, out string? customJsonValue, out string? attributeUriValue, out string? customDisplayName))
                    return false;

                jsonValue = customJsonValue ?? jsonValue;
                customUriValue = attributeUriValue ?? customUriValue;
                displayName = customDisplayName ?? displayName;
            }

            memberSpecification = new EnumMemberGenerationSpecification
            {
                Name = enumMemberName,
                HasTraktEnumMemberAttribute = hasTraktEnumMemberAttribute,
                JsonValue = jsonValue,
                // Without a custom URI value, the URI value is the same as the (possibly custom) JSON value.
                UriValue = customUriValue ?? jsonValue,
                DisplayName = displayName
            };

            return true;
        }

        private bool TryParseEnumMemberAttribute(AttributeData attributeData, out string? jsonValue, out string? uriValue, out string? displayName)
        {
            var namedArguments = attributeData.NamedArguments.ToImmutableDictionary();

            uriValue = null;
            displayName = null;

            if (!TryGetOptionalStringArgument(namedArguments, EnumConstants.TraktEnumMemberPropertyJsonValue, DiagnosticDescriptors.InvalidJsonValue, out jsonValue)
                || !TryGetOptionalStringArgument(namedArguments, EnumConstants.TraktEnumMemberPropertyUriValue, DiagnosticDescriptors.InvalidUriValue, out uriValue)
                || !TryGetOptionalStringArgument(namedArguments, EnumConstants.TraktEnumMemberPropertyDisplayName, DiagnosticDescriptors.InvalidDisplayNameValue, out displayName))
            {
                return false;
            }

            if (jsonValue == null && uriValue == null && displayName == null)
                ReportDiagnostic(DiagnosticDescriptors.NoCustomValuesProvidedForEnumMemberAttribute);

            return true;
        }

        /// <summary>
        /// Gets the string value of an optional named attribute argument.
        /// Returns <see langword="false" /> and reports the given diagnostic, if the argument is set, but is not a string.
        /// </summary>
        private bool TryGetOptionalStringArgument(ImmutableDictionary<string, TypedConstant> namedArguments, string argumentName,
            DiagnosticDescriptor invalidValueDescriptor, out string? value)
        {
            value = null;

            if (!namedArguments.TryGetValue(argumentName, out TypedConstant constant))
                return true;

            if (constant.Value is not string stringValue)
            {
                ReportDiagnostic(invalidValueDescriptor);
                return false;
            }

            value = stringValue;
            return true;
        }

        private void ReportDiagnostic(DiagnosticDescriptor descriptor)
        {
            Debug.Assert(_enumDeclarationLocation != null);
            Diagnostics.Add(DiagnosticInfo.Create(descriptor, _enumDeclarationLocation));
        }
    }
}
