namespace TraktNET
{
    /// <summary>
    /// A Trakt history post season, containing the required season ids
    /// and an optional datetime or action date keyword, when the season was watched.
    /// </summary>
    public record class TraktSyncHistoryPostSeason : TraktSyncRemovePostSeason
    {
        /// <summary>
        /// Gets or sets the optional datetime or action date keyword, when the Trakt season was watched.
        /// See also <seealso cref="TraktWatchedAt" />.
        /// </summary>
        public TraktWatchedAt? WatchedAt { get; set; }
    }
}
