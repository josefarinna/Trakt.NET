using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Enums
{
    public sealed class KnownEnumSymbols(Compilation compilation) : KnownSymbols(compilation)
    {
        private OptionalValue<INamedTypeSymbol?> _traktEnumAttributeType;
        private OptionalValue<INamedTypeSymbol?> _traktEnumMemberAttributeType;

        public INamedTypeSymbol? TraktEnumAttributeType
            => GetOrResolveType(EnumConstants.FullTraktEnumAttributeName, ref _traktEnumAttributeType);

        public INamedTypeSymbol? TraktEnumMemberAttributeType
            => GetOrResolveType(EnumConstants.FullTraktEnumMemberAttributeName, ref _traktEnumMemberAttributeType);
    }
}
