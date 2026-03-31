using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A rated Trakt episode, which was not found.</summary>
    public record class TraktSyncRatingsPostResponseNotFoundEpisode
    {
        /// <summary>Gets or sets the rating of the not found episode.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the not found episode. See also <seealso cref="TraktEpisodeIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktEpisodeIDs? IDs { get; set; }
    }
}
