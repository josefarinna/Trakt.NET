namespace TraktNET
{
    /// <summary>A Trakt collection post episode, containing the required episode number.</summary>
    public record class TraktSyncCollectionPostShowEpisode : TraktMetadata
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the collected at UTC datetime of the Trakt episode.</summary>
        public DateTime? CollectedAt { get; set; }
    }
}
