namespace TraktNET
{
    /// <summary>A Trakt watchlist post episode, containing the required episode number.</summary>
    public record class TraktSyncWatchlistPostShowEpisode : TraktSyncRemovePostShowEpisode
    {
        /// <summary>Gets or sets the episode notes.</summary>
        public string? Notes { get; set; }
    }
}
