namespace TraktNET.SourceGeneration.Requests
{
    public sealed record RequestPayloadGenerationSpecification : RequestMemberGenerationSpecification
    {
        public required bool HasValidateMethod { get; init; }
    }
}
