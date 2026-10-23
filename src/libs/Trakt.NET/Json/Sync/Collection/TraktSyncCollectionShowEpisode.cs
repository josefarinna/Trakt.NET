namespace TraktNET
{
    public record class TraktSyncCollectionShowEpisode
    {
        /// <summary>The episode number.</summary>
        public uint? Number { get; set; }

        /// <summary>The collected date for the episode.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>The episode <see cref="TraktMetadata" />.</summary>
        public TraktMetadata? Metadata { get; set; }

        /// <summary>
        /// Gets or sets a list of sources where the collected item is available.
        /// See also <seealso cref="TraktSyncCollectionAvailableOn" />.
        /// </summary>
        public List<TraktSyncCollectionAvailableOn>? AvailableOn { get; set; }
    }
}

