using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt collection post episode, containing the required episode ids,
    /// optional metadata and an optional datetime, when the episode was collected.
    /// </summary>
    public record class TraktSyncCollectionPostEpisode : TraktMetadata
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the required episode ids. See also <seealso cref="TraktEpisodeIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktEpisodeIDs? IDs { get; set; }
    }
}
