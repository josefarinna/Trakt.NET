namespace TraktNET
{
    /// <summary>Represents the payload to refresh a Younify streaming connection with the service specified in the body.</summary>
    public record class TraktYounifyRefreshServicePost : TraktYounifyRefreshPost
    {
        /// <summary>Gets or sets the streaming service to re-sync (e.g. "netflix").</summary>
        public string? ServiceId { get; set; }

        /// <summary>Validates the post data.</summary>
        public void Validate()
            => ArgumentValidator.ThrowIfNullOrWhiteSpace(ServiceId, "ServiceId must not be null or empty.");
    }
}
