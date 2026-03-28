using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// A Trakt collection post movie, containing the required movie ids,
    /// optional metadata and an optional datetime, when the movie was collected.
    /// </summary>
    public record class TraktSyncCollectionPostMovie : TraktMetadata
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt movie.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="TraktMovieIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktMovieIDs? IDs { get; set; }
    }
}
