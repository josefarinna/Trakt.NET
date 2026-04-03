using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt ratings remove post season, containing the required season ids.</summary>
    public record class TraktSyncRatingsRemovePostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="TraktSeasonIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktSeasonIDs? IDs { get; set; }
    }
}
