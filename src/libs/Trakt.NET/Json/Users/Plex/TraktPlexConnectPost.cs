namespace TraktNET
{
    /// <summary>Represents the payload to connect Plex.</summary>
    public record class TraktPlexConnectPost
    {
        /// <summary>Gets or sets the return URL after authorization completes.</summary>
        public string ReturnUrl { get; set; } = string.Empty;

        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ReturnUrl, "ReturnUrl must not be null or empty.");
        }
    }
}
