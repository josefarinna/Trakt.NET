using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt watchlist post episode, containing the required episode ids.</summary>
    public record class TraktSyncWatchlistPostEpisode : TraktSyncRemovePostEpisode
    {
        /// <summary>Gets or sets the episode notes.</summary>
        public string? Notes { get; set; }
    }
}
