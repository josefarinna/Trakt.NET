using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt episode, which was not found.</summary>
    public record class TraktPostResponseNotFoundEpisode
    {
        /// <summary>Gets or sets the ids of the not found episode. See also <seealso cref="TraktEpisodeIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktEpisodeIDs? IDs { get; set; }
    }
}
