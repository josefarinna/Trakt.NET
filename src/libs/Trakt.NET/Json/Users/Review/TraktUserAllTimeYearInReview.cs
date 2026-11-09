namespace TraktNET
{
    /// <summary>Represents a user's all-time Year in Review data.</summary>
    public record class TraktUserAllTimeYearInReview : TraktUserYearInReview
    {
        /// <summary>
        /// Gets or sets watched titles per release year and decade for shows and movies.
        /// <para>See also <seealso cref="TraktUserReviewAllTimeReleaseYears" />.</para>
        /// </summary>
        public TraktUserReviewAllTimeReleaseYears? ReleaseYears { get; set; }

        /// <summary>
        /// Gets or sets progress through curated top lists for shows and movies.
        /// <para>See also <seealso cref="TraktUserReviewAllTimeListProgress" />.</para>
        /// </summary>
        public TraktUserReviewAllTimeListProgress? ListProgress { get; set; }

        /// <summary>
        /// Gets or sets globally most played titles on Trakt.
        /// <para>See also <seealso cref="TraktUserReviewAllTimeGlobalTop" />.</para>
        /// </summary>
        public TraktUserReviewAllTimeGlobalTop? GlobalTop { get; set; }
    }
}
