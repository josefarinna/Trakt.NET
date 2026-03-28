using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt season, which was not found.</summary>
    public record class TraktPostResponseNotFoundSeason
    {
        /// <summary>Gets or sets the ids of the not found season. See also <seealso cref="TraktSeasonIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktSeasonIDs? IDs { get; set; }
    }
}
