namespace TraktNET
{
    /// <summary>
    /// A Trakt history post season, containing the required season number and optional episodes
    /// and an optional datetime or action date keyword, when the season was watched.
    /// </summary>
    public record class TraktSyncHistoryPostShowSeason : TraktSyncRemovePostShowSeason
    {
        /// <summary>
        /// Gets or sets the optional datetime or action date keyword, when the Trakt season was watched.
        /// See also <seealso cref="TraktWatchedAt" />.
        /// </summary>
        public TraktWatchedAt? WatchedAt { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the history.
        /// Otherwise, only the specified episodes will be added to the history.
        /// </para>
        /// </summary>
        public new List<TraktSyncHistoryPostShowEpisode>? Episodes { get; set; }
    }
}
