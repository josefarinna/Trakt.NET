namespace TraktNET
{
    /// <summary>A collection of UTC datetimes of last activities for favorites.</summary>
    public record class TraktSyncFavoritesLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a user's favorites were lastly updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
