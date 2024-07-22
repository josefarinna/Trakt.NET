namespace TraktNET.SourceGeneration.Requests
{
    public sealed record RequestGenerationSpecification
    {
        public required string Name { get; init; }

        public required string Namespace { get; init; }

        public required string HttpMethodValue { get; init; }

        public required string UriPath { get; init; }

        public required string OAuthRequirementValue { get; init; }

        public required bool SupportsExtendedInfo { get; init; }

        public required bool SupportsPagination { get; init; }

        public required bool HasOAuthRequirementDefined { get; init; }

        public required List<RequestParameterGenerationSpecification> RequestParameters { get; init; }

        public required List<RequestQueryGenerationSpecification> RequestQueries { get; init; }
    }
}
