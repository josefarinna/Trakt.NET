namespace TraktNET
{
    /// <summary>Represents statistical review data for shows, movies and overall.</summary>
    public record class TraktUserReviewStats
    {
        /// <summary>
        /// Gets or sets overall review statistics.
        /// <para>See also <seealso cref="TraktUserReviewAllStats" />.</para>
        /// </summary>
        public TraktUserReviewAllStats? All { get; set; }

        /// <summary>
        /// Gets or sets show review statistics.
        /// <para>See also <seealso cref="TraktUserReviewCategoryStats" />.</para>
        /// </summary>
        public TraktUserReviewCategoryStats? Shows { get; set; }

        /// <summary>
        /// Gets or sets movie review statistics.
        /// <para>See also <seealso cref="TraktUserReviewCategoryStats" />.</para>
        /// </summary>
        public TraktUserReviewCategoryStats? Movies { get; set; }
    }
}
