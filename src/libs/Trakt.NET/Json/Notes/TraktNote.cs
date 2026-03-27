using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt user note.</summary>
    public record class TraktNote
    {
        /// <summary>Gets or sets the ID of the note.</summary>
        [JsonPropertyName("id")]
        public ulong? ID { get; set; }

        /// <summary>Gets or sets the content of the note.</summary>
        public string? Notes { get; set; }

        /// <summary>Gets or sets the privacy setting of the note.</summary>
        public TraktListPrivacy? Privacy { get; set; }

        /// <summary>Gets or sets whether the note contains any spoilers.</summary>
        public bool? Spoiler { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the note was created.</summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the note was updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the user, who wrote the note. See also <seealso cref="TraktUser" />.
        /// </summary>
        public TraktUser? User { get; set; }
    }
}
