using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post season, containing the required season ids,
    /// a rating and an optional datetime, when the season was rated.
    /// </summary>
    public record class TraktSyncRatingsPostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="TraktSeasonIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktSeasonIDs? IDs { get; set; }

        /// <summary>Gets or sets the rating for the season.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was rated.</summary>
        public DateTime? RatedAt { get; set; }
    }
}
