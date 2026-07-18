namespace TraktNET
{
    /// <summary>Represents the payload to create a Younify streaming connection.</summary>
    public record class TraktYounifyConnectPost
    {
        /// <summary>Gets or sets the streaming service to connect (e.g. "netflix").</summary>
        public string? ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the return URL after the Younify web-auth flow completes.
        /// Must be a trakt-owned destination (<c>trakt://…</c> or <c>https://*.trakt.tv</c>).
        /// </summary>
        public string? ReturnUrl { get; set; }

        /// <summary>Validates the post data.</summary>
        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ServiceId, "ServiceId must not be null or empty.");
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ReturnUrl, "ReturnUrl must not be null or empty.");
        }
    }
}
