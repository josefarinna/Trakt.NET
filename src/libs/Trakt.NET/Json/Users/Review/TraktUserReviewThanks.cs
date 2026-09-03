namespace TraktNET
{
    /// <summary>Represents recommended popular unwatched shows and movies in a review period.</summary>
    public record class TraktUserReviewThanks
    {
        /// <summary>
        /// Gets or sets the list of unwatched popular shows.
        /// <para>See also <seealso cref="TraktUserReviewThanksShow" />.</para>
        /// </summary>
        public IReadOnlyList<TraktUserReviewThanksShow>? Shows { get; set; }

        /// <summary>
        /// Gets or sets the list of unwatched popular movies.
        /// <para>See also <seealso cref="TraktUserReviewThanksMovie" />.</para>
        /// </summary>
        public IReadOnlyList<TraktUserReviewThanksMovie>? Movies { get; set; }
    }
}
