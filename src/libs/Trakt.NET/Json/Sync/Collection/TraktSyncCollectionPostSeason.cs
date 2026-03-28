using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt collection post season, containing the required season ids,
    /// optional metadata and an optional datetime, when the season was collected.
    /// </summary>
    public record class TraktSyncCollectionPostSeason : TraktMetadata
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the required season ids. See also <seealso cref="TraktSeasonIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktSeasonIDs? IDs { get; set; }
    }
}
