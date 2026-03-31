namespace TraktNET
{
    /// <summary>A Trakt rating item, containing a movie, show, season and / or episode and information about it.</summary>
    public record class TraktRatingsItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie, show, season and / or episode was rated.</summary>
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets the rating of the movie, show, season and / or episode.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the object type, which this rating item contains. See also <seealso cref="TraktRatingsItemType" />.</summary>
        public TraktRatingsItemType? Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Show" />.
        /// May also be set, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Episode" /> or
        /// <see cref="TraktRatingsItemType.Season" />.
        /// <para>See also <seealso cref="TraktShow" />.</para>
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Season" />.
        /// See also <seealso cref="TraktSeason" />.
        /// </summary>
        public TraktSeason? Season { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktRatingsItemType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }
    }
}
