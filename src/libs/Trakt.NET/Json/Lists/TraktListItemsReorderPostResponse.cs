using System.Text.Json.Serialization;

namespace TraktNET
{
    public record class TraktListItemsReorderPostResponse
    {
        /// <summary>The number of updated list items.</summary>
        public uint? Updated { get; set; }

        /// <summary>A list of of updated list item ids.</summary>
        [JsonPropertyName("skipped_ids")]
        public List<uint>? SkippedIDs { get; set; }

        /// <summary>Information about the updated list.</summary>
        public TraktPostResponseListData? List { get; set; }
    }
}
