namespace TraktNET
{
    /// <summary>A Trakt watchlist item, containing a movie, show, season and / or episode and information about it.</summary>
    public record class TraktWatchlistItem
    {
        /// <summary>Gets or sets the id of the watchlist item.</summary>
        public uint? Id { get; set; }

        /// <summary>Gets or sets the ranking number of the watchlist item.</summary>
        public int? Rank { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie, show, season and / or episode was listed.</summary>
        public DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the watchlist item notes.</summary>
        public string? Notes { get; set; }

        /// <summary>Gets or sets the object type, which this watchlist item contains. See also <seealso cref="TraktSyncItemType" />.</summary>
        public TraktSyncItemType? Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSyncItemType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSyncItemType.Show" />.
        /// May also be set, if <see cref="Type" /> is <see cref="TraktSyncItemType.Episode" /> or
        /// <see cref="TraktSyncItemType.Season" />.
        /// <para>See also <seealso cref="TraktShow" />.</para>
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktSyncItemType.Season" />.
        /// See also <seealso cref="TraktSeason" />.
        /// </summary>
        public TraktSeason? Season { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktSyncItemType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }
    }
}
