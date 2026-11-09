namespace TraktNET
{
    /// <summary>
    /// A Trakt history post movie, containing the required movie ids
    /// and an optional datetime or action date keyword, when the movie was watched.
    /// </summary>
    public record class TraktSyncHistoryPostMovie : TraktSyncRemovePostMovie
    {
        /// <summary>
        /// Gets or sets the optional datetime or action date keyword, when the Trakt movie was watched.
        /// See also <seealso cref="TraktWatchedAt" />.
        /// </summary>
        public TraktWatchedAt? WatchedAt { get; set; }
    }
}
