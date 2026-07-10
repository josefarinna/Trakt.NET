namespace TraktNET
{
    /// <summary>A Trakt trending search result.</summary>
    public record class TraktTrendingSearchResult
    {
        /// <summary>Gets or sets the search count.</summary>
        public uint? Count { get; set; }

        /// <summary>Gets or sets the Trakt ID of the item.</summary>
        public uint? Id { get; set; }

        /// <summary>Gets or sets the result type. See also <seealso cref="TraktSearchResultType" />.</summary>
        public TraktSearchResultType? Type { get; set; }

        /// <summary>
        /// Gets or sets the result movie, if <see cref="Type" /> is <see cref="TraktSearchResultType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the result show, if <see cref="Type" /> is <see cref="TraktSearchResultType.Show" />.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the result person, if <see cref="Type" /> is <see cref="TraktSearchResultType.Person" />.
        /// See also <seealso cref="TraktPerson" />.
        /// </summary>
        public TraktPerson? Person { get; set; }
    }
}
