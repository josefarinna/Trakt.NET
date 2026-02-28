using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt comment or reply.</summary>
    public record class TraktComment
    {
        /// <summary>The Trakt ID of the comment.</summary>
        [JsonPropertyName("id")]
        public uint? ID { get; set; }

        /// <summary>The parent comment ID, if this comment is a reply.</summary>
        [JsonPropertyName("parent_id")]
        public uint? ParentID { get; set; }

        /// <summary>The comment's content.</summary>
        public string? Comment { get; set; }

        /// <summary>THe flag, whether the comment contains spoiler.</summary>
        public bool? Spoiler { get; set; }

        /// <summary>The flag, whether the comment is a review.</summary>
        public bool? Review { get; set; }

        /// <summary>The UTC datetime, when this comment was created.</summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>The UTC datetime, when this comment was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>The number of replies for the comment.</summary>
        public uint? Replies { get; set; }

        /// <summary>The number of likes for the comment.</summary>
        public uint? Likes { get; set; }

        /// <summary>The user rating for the comment.</summary>
        public uint? UserRating { get; set; }

        /// <summary>The comment's language.</summary>
        public string? Language { get; set; }

        /// <summary>
        /// The user statistics for the comment.
        /// See also <seealso cref="TraktCommentUserStats" />.
        /// </summary>
        public TraktCommentUserStats? UserStats { get; set; }

        /// <summary>
        /// The user, who has written the comment.
        /// See also <seealso cref="TraktUser" />.
        /// </summary>
        public TraktUser? User { get; set; }
    }
}
