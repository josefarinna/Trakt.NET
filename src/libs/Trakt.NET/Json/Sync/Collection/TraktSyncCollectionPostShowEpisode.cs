namespace TraktNET
{
    /// <summary>A Trakt collection post episode, containing the required episode number.</summary>
    public record class TraktSyncCollectionPostShowEpisode : TraktMetadata
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the optional UTC datetime or special option (<c>"released"</c>, <c>"unknown"</c>, <c>"now"</c>) when the Trakt episode was collected.</summary>
        public TraktCollectedAt? CollectedAt { get; set; }
    }
}
