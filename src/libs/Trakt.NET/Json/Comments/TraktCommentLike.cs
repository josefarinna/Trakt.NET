namespace TraktNET
{
    /// <summary>Represents a Trakt comment like.</summary>
    public record class TraktCommentLike
    {
        /// <summary>Gets or sets the UTC datetime, when the comment was liked.</summary>
        public DateTime? LikedAt { get; set; }

        /// <summary>Gets or sets the user, who liked the comment.</summary>
        public TraktUser? User { get; set; }
    }
}
