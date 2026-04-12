using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt user post season, containing the required season ids.</summary>
    public record class TraktUserRemovePostSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets the required season ids. See also <seealso cref="TraktSeasonIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktSeasonIDs? IDs { get; set; }
    }
}
