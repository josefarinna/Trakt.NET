using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A rated Trakt season, which was not found.</summary>
    public record class TraktSyncRatingsPostResponseNotFoundSeason
    {
        /// <summary>Gets or sets the rating of the not found season.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the not found season. See also <seealso cref="TraktSeasonIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktSeasonIDs? IDs { get; set; }
    }
}
