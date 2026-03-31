namespace TraktNET
{
    /// <summary>A Trakt favorite.</summary>
    public record class TraktFavorite
    {
        /// <summary>Gets or sets the id of this favorite item.</summary>
        public ulong? Id { get; set; }

        /// <summary>Gets or sets the favorite rank.</summary>
        public int? Rank { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the favorite was listed.</summary>
        public DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the favorite item type. See also <seealso cref="TraktFavoriteObjectType" />.</summary>
        public TraktFavoriteObjectType? Type { get; set; }

        /// <summary>Gets or sets the favorite notes.</summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktFavoriteObjectType.Movie" />.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktFavoriteObjectType.Show" />.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }
    }
}
