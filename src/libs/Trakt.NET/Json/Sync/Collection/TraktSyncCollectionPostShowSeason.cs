namespace TraktNET
{
    /// <summary>A Trakt collection post season, containing the required season number and optional episodes.</summary>
    public record class TraktSyncCollectionPostShowSeason : TraktMetadata
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the optional UTC datetime or special option (<c>"released"</c>, <c>"unknown"</c>, <c>"now"</c>) when the Trakt season was collected.</summary>
        public TraktCollectedAt? CollectedAt { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncCollectionPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the collection.
        /// Otherwise, only the specified episodes will be added to the collection.
        /// </para>
        /// </summary>
        public List<TraktSyncCollectionPostShowEpisode>? Episodes { get; set; }
    }
}
