namespace TraktNET
{
    /// <summary>Represents a Trakt user list item.</summary>
    public class TraktListItem
    {
        /// <summary>Gets or sets the ranking number of the list item.</summary>
        public int? Rank { get; set; }

        /// <summary>Gets or sets the id of the list item.</summary>
        public uint? Id { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the list item was added to a list.</summary>
        public DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the list item notes.</summary>
        public string? Notes { get; set; }

        /// <summary>Gets or sets the list item type. See also <seealso cref="TraktListItemType" />.</summary>
        public TraktListItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the list item movie, if <see cref="Type" /> is <see cref="TraktListItemType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the list item show, if <see cref="Type" /> is <see cref="TraktListItemType.Show" />.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the list item season, if <see cref="Type" /> is <see cref="TraktListItemType.Season" />.
        /// See also <seealso cref="TraktSeason" />.
        /// </summary>
        public TraktSeason? Season { get; set; }

        /// <summary>
        /// Gets or sets the list item episode, if <see cref="Type" /> is <see cref="TraktListItemType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>
        /// Gets or sets the list item person, if <see cref="Type" /> is <see cref="TraktListItemType.Person" />.
        /// See also <seealso cref="TraktPerson" />.
        /// </summary>
        public TraktPerson? Person { get; set; }
    }
}
