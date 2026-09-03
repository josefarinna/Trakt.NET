namespace TraktNET
{
    /// <summary>Represents a user's Month in Review data.</summary>
    public record class TraktUserMonthInReview : TraktUserYearInReview
    {
        /// <summary>
        /// Gets or sets streaming services statistics for the month.
        /// <para>See also <seealso cref="TraktUserReviewStreamingServices" />.</para>
        /// </summary>
        public TraktUserReviewStreamingServices? StreamingServices { get; set; }
    }
}
