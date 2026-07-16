namespace TraktNET
{
    /// <summary>Represents the payload to enqueue a Plex sync.</summary>
    public record class TraktPlexSyncPost
    {
        /// <summary>Gets or sets the Plex server machine identifier. Omit to sync every server.</summary>
        public string? ServerId { get; set; }

        /// <summary>Gets or sets whether to re-pull full history.</summary>
        public bool? AllData { get; set; }
    }
}
