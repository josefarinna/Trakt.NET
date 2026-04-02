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
    }
}
