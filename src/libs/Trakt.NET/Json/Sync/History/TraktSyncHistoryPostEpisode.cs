namespace TraktNET
{
    /// <summary>
    /// A Trakt history post episode, containing the required episode ids
    /// and an optional datetime or action date keyword, when the episode was watched.
    /// </summary>
    public record class TraktSyncHistoryPostEpisode : TraktSyncRemovePostEpisode
    {
        /// <summary>
        /// Gets or sets the optional datetime or action date keyword, when the Trakt episode was watched.
        /// See also <seealso cref="TraktWatchedAt" />.
        /// </summary>
        public TraktWatchedAt? WatchedAt { get; set; }
    }
}
