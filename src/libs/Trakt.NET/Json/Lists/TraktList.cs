using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt list.</summary>
    public record class TraktList
    {
        /// <summary>The list name.</summary>
        public string? Name { get; set; }

        /// <summary>The list description.</summary>
        public string? Description { get; set; }

        /// <summary>The list's visibility status. See also <seealso cref="TraktListPrivacy" />.</summary>
        public TraktListPrivacy? Privacy { get; set; }

        /// <summary>The list's share link.</summary>
        public string? ShareLink { get; set; }

        /// <summary>The list type. See also <seealso cref="TraktListType" />.</summary>
        public TraktListType? Type { get; set; }

        /// <summary>The flag, whether the list displays ranking numbers.</summary>
        public bool? DisplayNumbers { get; set; }

        /// <summary>The flag, whether the list allows comments.</summary>
        public bool? AllowComments { get; set; }

        /// <summary>The property, by which the list is sorted. See also <seealso cref="TraktSortBy" />.</summary>
        public TraktSortBy? SortBy { get; set; }

        /// <summary>The sort order of the list. See also <seealso cref="TraktSortHow" />.</summary>
        public TraktSortHow? SortHow { get; set; }

        /// <summary>The UTC datetime when the list was created.</summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>The UTC datetime when the list was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>The list's item count.</summary>
        public uint? ItemCount { get; set; }

        /// <summary>The list's comment count.</summary>
        public uint? CommentCount { get; set; }

        /// <summary>The count of likes of the list.</summary>
        public uint? Likes { get; set; }

        /// <summary>
        /// The collection of IDs for the list for various web services.
        /// See also <seealso cref="TraktListIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktListIDs? IDs { get; set; }

        /// <summary>
        /// The user, who created this list.
        /// See also <seealso cref="TraktUser" />.
        /// </summary>
        public TraktUser? User { get; set; }
    }
}
