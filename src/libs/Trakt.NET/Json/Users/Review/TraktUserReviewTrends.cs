namespace TraktNET
{
    /// <summary>Represents monthly trends for shows and movies in a review period.</summary>
    public record class TraktUserReviewTrends
    {
        /// <summary>
        /// Gets or sets the monthly show trends.
        /// <para>See also <seealso cref="TraktUserReviewShowTrend" />.</para>
        /// </summary>
        public IReadOnlyList<TraktUserReviewShowTrend>? Shows { get; set; }

        /// <summary>
        /// Gets or sets the monthly movie trends.
        /// <para>See also <seealso cref="TraktUserReviewMovieTrend" />.</para>
        /// </summary>
        public IReadOnlyList<TraktUserReviewMovieTrend>? Movies { get; set; }
    }
}
