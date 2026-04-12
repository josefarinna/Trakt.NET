namespace TraktNET
{
    /// <summary>Contains information about a Trakt user's hidden item, including the corresponding movie, show or season.</summary>
    public record class TraktUserHiddenItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie, show or season was hidden.</summary>
        public DateTime? HiddenAt { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this hidden item contains.
        /// See also <seealso cref="TraktHiddenItemType" />.
        /// </summary>
        public TraktHiddenItemType? Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Show" />.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Season" />.
        /// See also <seealso cref="TraktSeason" />.
        /// </summary>
        public TraktSeason? Season { get; set; }

        /// <summary>
        /// Gets or sets the user, if <see cref="Type" /> is <see cref="TraktHiddenItemType.User" />.
        /// See also <seealso cref="TraktUser" />.
        /// </summary>
        public TraktUser? User { get; set; }
    }
}
