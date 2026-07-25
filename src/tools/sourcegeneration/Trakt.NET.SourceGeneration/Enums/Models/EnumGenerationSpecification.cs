namespace TraktNET.SourceGeneration.Enums
{
    public sealed record EnumGenerationSpecification
    {
        public required string Name { get; init; }

        public required string Namespace { get; init; }

        public required bool HasFlagsAttribute { get; init; }

        public required string QueryName { get; init; }

        public required bool HasPathSupport { get; init; }

        public required bool HasQuerySupport { get; init; }

        public required bool SupportNumberDeserialization { get; init; }

        public required List<EnumMemberGenerationSpecification> Members { get; init; }
    }
}
