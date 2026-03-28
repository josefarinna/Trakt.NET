namespace TraktNET
{
    /// <summary>A Trakt history remove post episode, containing the required episode number.</summary>
    public record class TraktSyncHistoryRemovePostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public int Number { get; set; }
    }
}
