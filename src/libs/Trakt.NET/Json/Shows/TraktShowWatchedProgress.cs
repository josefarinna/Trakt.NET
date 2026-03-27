namespace TraktNET
{
    /// <summary>Represents the watched progress of a Trakt show.</summary>
    public record class TraktShowWatchedProgress : TraktShowProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last watch occured.</summary>
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the watched progress has been reset.</summary>
        public DateTime? ResetAt { get; set; }

        /// <summary>Gets or sets the stats about a Trakt show.</summary>
        public TraktShowStats? Stats { get; set; }

        /// <summary>
        /// Gets or sets the watched seasons. See also <seealso cref="TraktSeasonWatchedProgress" />.
        /// </summary>
        public List<TraktSeasonWatchedProgress>? Seasons { get; set; }
    }
}
