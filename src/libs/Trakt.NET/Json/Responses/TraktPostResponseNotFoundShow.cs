using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt show, which was not found.</summary>
    public record class TraktPostResponseNotFoundShow
    {
        /// <summary>Gets or sets the ids of the not found show. See also <seealso cref="TraktShowIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktShowIDs? IDs { get; set; }
    }
}
