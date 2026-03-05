namespace TraktNET
{
    /// <summary>A Trakt calendar movie.</summary>
    public record class TraktCalendarMovie
    {
        // <summary>The UTC datetime when the movie was released.</summary>
        public DateTime? Released { get; set; }

        /// <summary>
        /// Gets or sets the result movie.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }
    }
}
