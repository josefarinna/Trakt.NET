namespace TraktNET
{
    /// <summary>A Trakt watchlist post episode, containing the required episode number.</summary>
    public record class TraktSyncWatchlistPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        public int Number { get; set; }
    }
}
