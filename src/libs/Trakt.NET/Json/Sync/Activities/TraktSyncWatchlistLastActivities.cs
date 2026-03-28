namespace TraktNET
{
    /// <summary>A collection of UTC datetimes of last activities for watchlists.</summary>
    public record class TraktSyncWatchlistLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a watchlist was lastly updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
