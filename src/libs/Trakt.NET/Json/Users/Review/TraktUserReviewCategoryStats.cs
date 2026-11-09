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

        /// <summary>Gets or sets the total number of items.</summary>
        public uint? ItemsCount { get; set; }

        /// <summary>
        /// Gets or sets play count distributions per time slot.
        /// <para>See also <seealso cref="TraktUserReviewDistributions" />.</para>
        /// </summary>
        public TraktUserReviewDistributions? Distributions { get; set; }

        /// <summary>
        /// Gets or sets rating counts per star rating (All-time Review only).
        /// <para>See also <seealso cref="TraktUserReviewRatingCount" />.</para>
        /// </summary>
        public List<TraktUserReviewRatingCount>? RatingsDistribution { get; set; }
    }
}
