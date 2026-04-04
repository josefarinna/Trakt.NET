using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt watchlist post movie, containing the required movie ids.</summary>
    public record class TraktSyncWatchlistPostMovie : TraktSyncRemovePostMovie
    {
        /// <summary>Gets or sets the movie notes.</summary>
        public string? Notes { get; set; }
    }
}
