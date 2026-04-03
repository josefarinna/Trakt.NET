namespace TraktNET
{
    /// <summary>A Trakt ratings post season, containing the required season number and optional episodes.</summary>
    public record class TraktSyncRatingsRemovePostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public uint? Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsRemovePostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season ratings will be removed.
        /// Otherwise, only the specified episodes ratings will be removed.
        /// </para>
        /// </summary>
        public List<TraktSyncRatingsRemovePostShowEpisode>? Episodes { get; set; }
    }
}
