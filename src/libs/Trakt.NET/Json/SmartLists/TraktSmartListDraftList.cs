using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Information about a list in a smart list draft.</summary>
    public record class TraktSmartListDraftList
    {
        /// <summary>
        /// The collection of IDs for the list.
        /// See also <seealso cref="TraktListIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktListIDs? IDs { get; set; }
    }
}
