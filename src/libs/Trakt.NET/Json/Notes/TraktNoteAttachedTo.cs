using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Contains information about to which media a Trakt user note is attached.</summary>
    public record class TraktNoteAttachedTo
    {
        /// <summary>Gets or sets the media type to which a note is attached. See also <seealso cref="TraktNotesObjectType" />.</summary>
        public TraktNotesObjectType? Type { get; set; }

        /// <summary>
        /// Gets or sets the history ID of the history item,
        /// if <see cref="Type" /> is set to <see cref="TraktNotesObjectType.History" />
        /// and a note is attached to an history item.
        /// </summary>
        [JsonPropertyName("id")]
        public ulong? ID { get; set; }

        /// <summary>Gets or sets the UTC datetime when the item was watched, if attached to a history item.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime when the item was collected, if attached to a collection item.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime when the item was rated, if attached to a rating.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the rating value, if attached to a rating.</summary>
        public int? Rating { get; set; }
    }
}
