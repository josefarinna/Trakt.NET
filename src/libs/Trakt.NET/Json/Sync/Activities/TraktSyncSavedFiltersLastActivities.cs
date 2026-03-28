namespace TraktNET
{
    /// <summary>A collection of UTC datetimes of last activities for saved filters.</summary>
    public record class TraktSyncSavedFiltersLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when a saved filter was lastly updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
