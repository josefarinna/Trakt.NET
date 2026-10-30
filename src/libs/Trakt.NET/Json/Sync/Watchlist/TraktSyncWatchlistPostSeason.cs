namespace TraktNET
{
    /// <summary>A Trakt watchlist post season, containing the required season ids.</summary>
    public record class TraktSyncWatchlistPostSeason : TraktSyncRemovePostSeason
    {
        /// <summary>Gets or sets the season notes.</summary>
        public string? Notes { get; set; }
    }
}
