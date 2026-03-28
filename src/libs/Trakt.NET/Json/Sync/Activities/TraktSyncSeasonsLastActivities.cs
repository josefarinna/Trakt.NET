namespace TraktNET
{
    /// <summary>A collection of UTC datetimes of last activities for seasons.</summary>
    public record class TraktSyncSeasonsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a season was lastly rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a season was lastly added to the watchlist.</summary>
        public DateTime? WatchlistedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a season was lastly commented.</summary>
        public DateTime? CommentedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when a season was lastly hidden.</summary>
        public DateTime? HiddenAt { get; set; }
    }
}
