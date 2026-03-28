using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt person, which was not found.</summary>
    public record class TraktPostResponseNotFoundPerson
    {
        /// <summary>Gets or sets the ids of the not found person. See also <seealso cref="TraktPersonIDs" />.</summary>
        [JsonPropertyName("ids")]
        public TraktPersonIDs? IDs { get; set; }
    }
}
