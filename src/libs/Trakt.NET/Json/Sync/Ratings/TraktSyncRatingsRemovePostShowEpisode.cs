namespace TraktNET
{
    /// <summary>A Trakt ratings remove post episode, containing the required episode number.</summary>
    public record class TraktSyncRatingsRemovePostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public uint? Number { get; set; }
    }
}
