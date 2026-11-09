namespace TraktNET
{
    /// <summary>Represents progress through curated top lists for shows and movies.</summary>
    public record class TraktUserReviewAllTimeListProgress
    {
        /// <summary>
        /// Gets or sets curated list progress for shows.
        /// <para>See also <seealso cref="TraktUserReviewListProgress" />.</para>
        /// </summary>
        public List<TraktUserReviewListProgress>? Shows { get; set; }

        /// <summary>
        /// Gets or sets curated list progress for movies.
        /// <para>See also <seealso cref="TraktUserReviewListProgress" />.</para>
        /// </summary>
        public List<TraktUserReviewListProgress>? Movies { get; set; }
    }
}
