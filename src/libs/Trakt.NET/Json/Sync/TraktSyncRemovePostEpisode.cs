using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt sync post episode, containing the required episode ids.</summary>
    public record class TraktSyncRemovePostEpisode
    {
        /// <summary>Gets or sets the required episode ids. See also <seealso cref="TraktEpisodeIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktEpisodeIDs? IDs { get; set; }
    }
}
