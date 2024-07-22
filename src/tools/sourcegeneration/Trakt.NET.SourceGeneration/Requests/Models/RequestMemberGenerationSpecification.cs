using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Requests
{
    public abstract record RequestMemberGenerationSpecification
    {
        public required string Name { get; init; }

        public required bool IsRequired { get; init; }

        public required bool IsTraktEnum { get; init; }

        public required string TraktEnumTypeName { get; init; }

        public required string TraktEnumDefaultValue { get; init; }

        public required SpecialType SpecialType { get; init; }

        public required bool UseCacheEfficientDateTime { get; init; }
    }
}
