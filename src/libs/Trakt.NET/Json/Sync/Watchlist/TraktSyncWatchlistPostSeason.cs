using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt watchlist post season, containing the required season ids.</summary>
    public record class TraktSyncWatchlistPostSeason : TraktSyncRemovePostShowSeason
    {
        /// <summary>Gets or sets the season notes.</summary>
        public string? Notes { get; set; }
    }
}
