namespace TraktNET
{
    /// <summary>Contains information about a watched Trakt episode.</summary>
    public record class TraktWatchedShowEpisode
    {
        /// <summary>Gets or sets the number of the watched episode.</summary>
        public uint? Number { get; set; }

        /// <summary>Gets or sets the number of plays for the watched episode.</summary>
        public uint? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the episode was last watched.</summary>
        public DateTime? LastWatchedAt { get; set; }
    }
}
