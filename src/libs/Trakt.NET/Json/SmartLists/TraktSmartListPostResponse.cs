using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents the response of a smart list creation post.</summary>
    public record class TraktSmartListPostResponse
    {
        /// <summary>Gets or sets the collection of IDs for the created smart list.</summary>
        [JsonPropertyName("ids")]
        public TraktListIDs? IDs { get; set; }
    }
}
