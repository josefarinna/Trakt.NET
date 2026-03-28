using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt watchlist post episode, containing the required episode ids.</summary>
    public record class TraktSyncWatchlistPostEpisode
    {
        /// <summary>Gets or sets the required episode ids. See also <seealso cref="TraktEpisodeIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktEpisodeIDs? IDs { get; set; }

        /// <summary>Gets or sets the episode notes.</summary>
        public string? Notes { get; set; }
    }
}
