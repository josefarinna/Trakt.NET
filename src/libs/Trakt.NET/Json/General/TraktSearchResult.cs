namespace TraktNET
{
    /// <summary>A Trakt search result.</summary>
    public record class TraktSearchResult
    {
        /// <summary>Gets or sets the result type. See also <seealso cref="TraktSearchResultType" />.<para>Nullable</para></summary>
        public TraktSearchResultType Type { get; set; }

        /// <summary>Gets or sets the result score.</summary>
        public float? Score { get; set; }

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
        /// Gets or sets the result episode, if <see cref="Type" /> is <see cref="TraktSearchResultType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>
        /// Gets or sets the result person, if <see cref="Type" /> is <see cref="TraktSearchResultType.Person" />.
        /// See also <seealso cref="TraktPerson" />.
        /// </summary>
        public TraktPerson? Person { get; set; }

        /// <summary>
        /// Gets or sets the result list, if <see cref="Type" /> is <see cref="TraktSearchResultType.List" />.
        /// See also <seealso cref="TraktList" />.
        /// </summary>
        public TraktList? List { get; set; }
    }
}
