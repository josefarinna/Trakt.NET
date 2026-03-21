namespace TraktNET
{
    /// <summary>A comment post.</summary>
    public record class TraktCommentPost
    {
        /// <summary>Gets or sets the required comment's content.</summary>
        public required string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        public bool? Spoiler { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the comment post.
        /// See also <seealso cref="TraktConnections" />.
        /// </summary>
        public TraktConnections? Sharing { get; set; }

        public virtual void Validate()
        {
            if (Comment == null)
                throw new TraktPostValidationException(nameof(Comment), "comment must not be null");

            if (Comment.WordCount() < 5)
                throw new TraktPostValidationException(nameof(Comment), "comment has too few words - at least five words are required");
        }
    }
}
