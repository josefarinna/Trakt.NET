namespace TraktNET
{
    /// <summary>Represents a trending media item (movie or show) on Trakt.</summary>
    public record class TraktTrendingMedia
    {
        /// <summary>Gets or sets the number of watchers for the media item.</summary>
        public uint? Watchers { get; set; }

        /// <summary>Gets or sets the media item type. See also <seealso cref="TraktSearchResultType" />.</summary>
        public TraktSearchResultType? Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSearchResultType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSearchResultType.Show" />.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }
    }
}
