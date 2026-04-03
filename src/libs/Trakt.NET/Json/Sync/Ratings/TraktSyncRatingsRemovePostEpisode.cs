using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt ratings remove post episode, containing the required episode ids.</summary>
    public record class TraktSyncRatingsRemovePostEpisode
    {
        /// <summary>Gets or sets the required episode ids. See also <seealso cref="TraktEpisodeIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktEpisodeIDs? IDs { get; set; }
    }
}
