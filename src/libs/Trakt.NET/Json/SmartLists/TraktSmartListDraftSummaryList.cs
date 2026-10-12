using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Information about a list in a smart list drafts summary.</summary>
    public record class TraktSmartListDraftSummaryList
    {
        /// <summary>
        /// The collection of IDs for the list.
        /// See also <seealso cref="TraktListIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktListIDs? IDs { get; set; }

        /// <summary>The name of the list.</summary>
        public string? Name { get; set; }

        /// <summary>The number of items in the list.</summary>
        public uint? ItemCount { get; set; }

        /// <summary>The confidence of the draft setup.</summary>
        public float? Confidence { get; set; }
    }
}
