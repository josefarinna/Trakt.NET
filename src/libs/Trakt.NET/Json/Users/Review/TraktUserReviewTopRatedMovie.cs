namespace TraktNET
{
    /// <summary>Represents a top rated movie in a review period.</summary>
    public record class TraktUserReviewTopRatedMovie
    {
        /// <summary>Gets or sets the rating assigned to the movie.</summary>
        public uint? Rating { get; set; }

        /// <summary>Gets or sets the movie details. See also <seealso cref="TraktMovie" />.</summary>
        public TraktMovie? Movie { get; set; }
    }
}
