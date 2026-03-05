namespace TraktNET
{
    /// <summary>A Trakt calendar show, containing episode and show information.</summary>
    public record class TraktCalendarShow
    {
        // <summary>The UTC datetime when the episode was first aired.</summary>
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
