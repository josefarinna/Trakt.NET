namespace TraktNET
{
    /// <summary>Represents the watched progress of a Trakt episode.</summary>
    public record class TraktEpisodeWatchedProgress : TraktEpisodeProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last watch occured.</summary>
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the stats about a Trakt episode.</summary>
        public TraktEpisodeStats? Stats { get; set; }
    }
}
