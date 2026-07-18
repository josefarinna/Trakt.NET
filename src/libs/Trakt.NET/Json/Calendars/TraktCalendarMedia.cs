namespace TraktNET
{
    /// <summary>A Trakt calendar media item, containing movie, show and episode information.</summary>
    public record class TraktCalendarMedia
    {
        /// <summary>The UTC datetime when the movie was released.</summary>
        public DateTime? Released { get; set; }

        /// <summary>
        /// Gets or sets the result movie.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>The UTC datetime when the episode was first aired.</summary>
        public DateTime? FirstAired { get; set; }

        /// <summary>
        /// Gets or sets the result episode.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>
        /// Gets or sets the result show.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }
    }
}
