using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A rated Trakt show, which was not found.</summary>
    public record class TraktSyncRatingsPostResponseNotFoundShow
    {
        /// <summary>Gets or sets the rating of the not found show.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the not found show. See also <seealso cref="TraktShowIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktShowIDs? IDs { get; set; }
    }
}
