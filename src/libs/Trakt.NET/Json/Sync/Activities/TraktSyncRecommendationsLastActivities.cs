namespace TraktNET
{
    /// <summary>A collection of UTC datetimes of last activities for recommendations.</summary>
    public record class TraktSyncRecommendationsLastActivities
    {
        /// <summary>Gets or sets the UTC datetime, when recommendations were lastly updated.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
