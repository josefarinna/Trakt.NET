using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt smart list definition.</summary>
    public record class TraktSmartList
    {
        /// <summary>The smart list name.</summary>
        public string? Name { get; set; }

        /// <summary>The smart list's visibility status. See also <seealso cref="TraktListPrivacy" />.</summary>
        public TraktListPrivacy? Privacy { get; set; }

        /// <summary>The UTC datetime when the smart list was created.</summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>The UTC datetime when the smart list was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// The collection of IDs for the smart list.
        /// See also <seealso cref="TraktListIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktListIDs? IDs { get; set; }

        /// <summary>
        /// The collection of image URLs for the smart list.
        /// See also <seealso cref="TraktSmartListImages" />.
        /// </summary>
        public TraktSmartListImages? Images { get; set; }

        /// <summary>
        /// The source of the smart list.
        /// See also <seealso cref="TraktSmartListSource" />.
        /// </summary>
        public TraktSmartListSource? Source { get; set; }

        /// <summary>
        /// The media type of the smart list.
        /// See also <seealso cref="TraktSmartListMediaType" />.
        /// </summary>
        public TraktSmartListMediaType? MediaType { get; set; }

        /// <summary>
        /// The filter constraints applied to the source of the smart list.
        /// See also <seealso cref="TraktSmartListFilters" />.
        /// </summary>
        public TraktSmartListFilters? Filters { get; set; }
    }
}
