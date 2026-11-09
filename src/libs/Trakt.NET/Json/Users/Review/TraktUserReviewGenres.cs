namespace TraktNET
{
    /// <summary>Represents genre counts for shows and movies in a review period.</summary>
    public record class TraktUserReviewGenres
    {
        /// <summary>
        /// Gets or sets the genre counts for shows.
        /// <para>See also <seealso cref="TraktUserReviewGenreCount" />.</para>
        /// </summary>
        public TraktUserReviewGenreCount? Shows { get; set; }

        /// <summary>
        /// Gets or sets the genre counts for movies.
        /// <para>See also <seealso cref="TraktUserReviewGenreCount" />.</para>
        /// </summary>
        public TraktUserReviewGenreCount? Movies { get; set; }
    }
}
