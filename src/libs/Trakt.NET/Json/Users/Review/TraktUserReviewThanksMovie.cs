namespace TraktNET
{
    /// <summary>Represents a recommended popular unwatched movie in a review period.</summary>
    public record class TraktUserReviewThanksMovie
    {
        /// <summary>
        /// Gets or sets the movie.
        /// <para>See also <seealso cref="TraktMovie" />.</para>
        /// </summary>
        public TraktMovie? Movie { get; set; }
    }
}
