namespace TraktNET
{
    /// <summary>Represents a most watched movie in a review period.</summary>
    public record class TraktUserReviewMostWatchedMovie
    {
        /// <summary>Gets or sets the number of plays.</summary>
        public uint? Plays { get; set; }

        /// <summary>Gets or sets the watched minutes.</summary>
        public uint? Minutes { get; set; }

        /// <summary>Gets or sets the movie details. See also <seealso cref="TraktMovie" />.</summary>
        public TraktMovie? Movie { get; set; }
    }
}
