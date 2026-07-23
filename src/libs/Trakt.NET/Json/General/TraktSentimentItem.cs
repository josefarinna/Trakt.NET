using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents a sentiment item for comments and reactions.</summary>
    public record class TraktSentimentItem
    {
        /// <summary>Gets or sets the sentiment string.</summary>
        public string? Sentiment { get; set; }

        /// <summary>Gets or sets the list of comment IDs associated with this sentiment.</summary>
        [JsonPropertyName("comment_ids")]
        public List<ulong>? CommentIDs { get; set; }
    }
}
