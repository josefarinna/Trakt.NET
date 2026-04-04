namespace TraktNET
{
    /// <summary>
    /// A Trakt history post episode, containing the required episode number
    /// and an optional datetime, when the episode was watched.
    /// </summary>
    public record class TraktSyncHistoryPostShowEpisode : TraktSyncRemovePostShowEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was watched.</summary>
        public DateTime? WatchedAt { get; set; }
    }
}
