namespace TraktNET
{
    public record class TraktTrendingOrPopularList
    {
        /// <summary>Gets or sets the list like count.</summary>
        public int? LikeCount { get; set; }

        /// <summary>Gets or sets the list comment count.</summary>
        public int? CommentCount { get; set; }

        /// <summary>Gets or sets the actual list. See also <seealso cref="TraktList" />.</summary>
        public TraktList? List { get; set; }
    }
}
