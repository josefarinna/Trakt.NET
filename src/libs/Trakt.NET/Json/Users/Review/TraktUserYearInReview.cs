namespace TraktNET
{
    /// <summary>Represents a user's Year in Review data.</summary>
    public record class TraktUserYearInReview
    {
        /// <summary>
        /// Gets or sets statistical review data.
        /// <para>See also <seealso cref="TraktUserReviewStats" />.</para>
        /// </summary>
        public TraktUserReviewStats? Stats { get; set; }

        /// <summary>
        /// Gets or sets images associated with the review.
        /// <para>See also <seealso cref="TraktUserReviewImages" />.</para>
        /// </summary>
        public TraktUserReviewImages? Images { get; set; }

        /// <summary>
        /// Gets or sets the first watched item of the review period.
        /// <para>See also <seealso cref="TraktUserReviewWatchedItem" />.</para>
        /// </summary>
        public TraktUserReviewWatchedItem? FirstWatched { get; set; }

        /// <summary>
        /// Gets or sets the last watched item of the review period.
        /// <para>See also <seealso cref="TraktUserReviewWatchedItem" />.</para>
        /// </summary>
        public TraktUserReviewWatchedItem? LastWatched { get; set; }

        /// <summary>
        /// Gets or sets the country breakdown for shows and movies.
        /// <para>See also <seealso cref="TraktUserReviewCountries" />.</para>
        /// </summary>
        public TraktUserReviewCountries? Countries { get; set; }

        /// <summary>
        /// Gets or sets monthly trends for shows and movies.
        /// <para>See also <seealso cref="TraktUserReviewTrends" />.</para>
        /// </summary>
        public TraktUserReviewTrends? Trends { get; set; }

        /// <summary>
        /// Gets or sets recommended popular unwatched titles.
        /// <para>See also <seealso cref="TraktUserReviewThanks" />.</para>
        /// </summary>
        public TraktUserReviewThanks? Thanks { get; set; }
    }
}
