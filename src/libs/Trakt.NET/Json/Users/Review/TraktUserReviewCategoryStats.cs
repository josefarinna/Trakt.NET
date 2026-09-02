namespace TraktNET
{
    /// <summary>Represents category statistics for a review period.</summary>
    public record class TraktUserReviewCategoryStats
    {
        /// <summary>
        /// Gets or sets the minutes statistics.
        /// <para>See also <seealso cref="TraktUserReviewStatItem" />.</para>
        /// </summary>
        public TraktUserReviewStatItem? Minutes { get; set; }

        /// <summary>
        /// Gets or sets the play counts statistics.
        /// <para>See also <seealso cref="TraktUserReviewStatItem" />.</para>
        /// </summary>
        public TraktUserReviewStatItem? PlayCounts { get; set; }

        /// <summary>
        /// Gets or sets the collected counts statistics.
        /// <para>See also <seealso cref="TraktUserReviewStatItem" />.</para>
        /// </summary>
        public TraktUserReviewStatItem? CollectedCounts { get; set; }

        /// <summary>
        /// Gets or sets the ratings counts statistics.
        /// <para>See also <seealso cref="TraktUserReviewStatItem" />.</para>
        /// </summary>
        public TraktUserReviewStatItem? RatingsCounts { get; set; }

        /// <summary>
        /// Gets or sets the comments counts statistics.
        /// <para>See also <seealso cref="TraktUserReviewStatItem" />.</para>
        /// </summary>
        public TraktUserReviewStatItem? CommentsCounts { get; set; }
    }
}
