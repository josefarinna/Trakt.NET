namespace TraktNET
{
    /// <summary>A Trakt history post season, containing the required season number and optional episodes.</summary>
    public record class TraktSyncHistoryRemovePostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public int Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryRemovePostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the history.
        /// Otherwise, only the specified episodes will be added to the history.
        /// </para>
        /// </summary>
        public List<TraktSyncHistoryRemovePostShowEpisode>? Episodes { get; set; }
    }
}
