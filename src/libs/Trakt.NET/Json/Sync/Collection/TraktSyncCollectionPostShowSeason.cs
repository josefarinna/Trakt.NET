namespace TraktNET
{
    /// <summary>A Trakt collection post season, containing the required season number and optional episodes.</summary>
    public record class TraktSyncCollectionPostShowSeason : TraktMetadata
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the collected at UTC datetime of the Trakt episode.</summary>
        public DateTime? CollectedAt { get; set; }

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
