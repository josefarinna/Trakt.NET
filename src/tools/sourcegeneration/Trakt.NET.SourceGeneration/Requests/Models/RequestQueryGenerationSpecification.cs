namespace TraktNET.SourceGeneration.Requests
{
    public sealed record RequestQueryGenerationSpecification : RequestMemberGenerationSpecification
    {
        public required string QueryName { get; init; }
    }
}
