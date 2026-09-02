namespace TraktNET
{
    /// <summary>Represents overall review statistics across all media types.</summary>
    public record class TraktUserReviewAllStats : TraktUserReviewCategoryStats
    {
        /// <summary>
        /// Gets or sets the lists counts statistics.
        /// <para>See also <seealso cref="TraktUserReviewStatItem" />.</para>
        /// </summary>
        public TraktUserReviewStatItem? ListsCounts { get; set; }
    }
}
