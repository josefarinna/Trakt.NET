namespace TraktNET
{
    /// <summary>Represents a movie trend entry for a month in a review period.</summary>
    public record class TraktUserReviewMovieTrend
    {
        /// <summary>Gets or sets the month number (1-12).</summary>
        public uint? Month { get; set; }

        /// <summary>Gets or sets the month name.</summary>
        public string? MonthName { get; set; }

        /// <summary>Gets or sets the global watcher count.</summary>
        public uint? Watchers { get; set; }

        /// <summary>Gets or sets whether this user watched the movie.</summary>
        public bool? Watched { get; set; }

        /// <summary>
        /// Gets or sets the movie.
        /// <para>See also <seealso cref="TraktMovie" />.</para>
        /// </summary>
        public TraktMovie? Movie { get; set; }
    }
}
