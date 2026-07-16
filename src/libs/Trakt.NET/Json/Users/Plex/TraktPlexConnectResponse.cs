namespace TraktNET
{
    /// <summary>Represents the response containing the Plex web-auth URL.</summary>
    public record class TraktPlexConnectResponse
    {
        /// <summary>Gets or sets the Plex web-auth URL.</summary>
        public string? Url { get; set; }
    }
}
