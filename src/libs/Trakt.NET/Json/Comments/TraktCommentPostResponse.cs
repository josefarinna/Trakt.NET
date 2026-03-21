namespace TraktNET
{
    /// <summary>Represents a comment post response.</summary>
    public record class TraktCommentPostResponse : TraktComment
    {
        /// <summary>
        /// Gets or sets the sharing options of the comment post response.
        /// See also <seealso cref="TraktConnections" />.
        /// </summary>
        public TraktConnections? Sharing { get; set; }
    }
}
