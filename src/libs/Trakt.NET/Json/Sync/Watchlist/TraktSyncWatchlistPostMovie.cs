using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt watchlist post movie, containing the required movie ids.</summary>
    public record class TraktSyncWatchlistPostMovie
    {
        /// <summary>Gets or sets the optional title of the Trakt movie.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="TraktMovieIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktMovieIDs? IDs { get; set; }

        /// <summary>Gets or sets the movie notes.</summary>
        public string? Notes { get; set; }
    }
}
