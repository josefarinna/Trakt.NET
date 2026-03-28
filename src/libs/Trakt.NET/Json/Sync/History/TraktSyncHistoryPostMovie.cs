namespace TraktNET
{
    /// <summary>
    /// A Trakt history post movie, containing the required movie ids
    /// and an optional datetime, when the movie was watched.
    /// </summary>
    public record class TraktSyncHistoryPostMovie : TraktSyncHistoryRemovePostMovie
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was watched.</summary>
        public DateTime? WatchedAt { get; set; }
    }
}
