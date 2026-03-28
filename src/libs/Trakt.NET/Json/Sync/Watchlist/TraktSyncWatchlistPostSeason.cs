using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt watchlist post season, containing the required season ids.</summary>
    public record class TraktSyncWatchlistPostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="TraktSeasonIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktSeasonIDs? IDs { get; set; }

        /// <summary>Gets or sets the season notes.</summary>
        public string? Notes { get; set; }
    }
}
