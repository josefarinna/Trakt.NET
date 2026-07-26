namespace TraktNET
{
    /// <summary>Contains information about a watched Trakt episode.</summary>
    public record class TraktWatchedEpisode
    {
        /// <summary>Gets or sets the number of plays for the watched episode.</summary>
        public uint? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the episode was last watched.</summary>
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the episode was last updated.</summary>
        public DateTime? LastUpdatedAt { get; set; }

        /// <summary>Gets or sets the watched episode details. See also <seealso cref="TraktEpisode" />.</summary>
        public TraktEpisode? Episode { get; set; }
    }
}
