namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to search.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/search">"Trakt API Documentation - Search"</a> section.
    /// </summary>
    public sealed partial class TraktSearchModule
    {
        /// <summary>Searches for movies, shows, episodes, people and / or lists with the given search query.</summary>
        /// <param name="searchResultTypes">
        /// The object type(s), for which will be searched. See also <seealso cref="TraktSearchResultType" />.
        /// Multiple <see cref="TraktSearchResultType" /> values can be combined with a binary operator, like this: TraktSearchResultType.Movie | TraktSearchResultType.Show.
        /// </param>
        /// <param name="searchQuery">The query, for which will be searched.</param>
        /// <param name="searchFields">Determines the text fields, which will be searched. See also <seealso cref="TraktSearchField" />.</param>
        /// <param name="filter">
        /// Specifies optional filter for genres, languages, year, runtimes, ratings, etc.
        /// <para>See also <seealso cref="TraktFilter" />.</para>
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies, shows, episodes, people and / or lists should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the search results.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktSearchResult" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getsearchquery">
        /// Trakt API Documentation: Search: Text Query.
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktPagedResponse<TraktSearchResult>> GetTextQueryResultsAsync(TraktSearchResultType searchResultTypes, string searchQuery,
            TraktSearchField? searchFields = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetTextQueryResultsImplAsync(searchResultTypes, searchQuery, searchFields, filter, extendedInfo, page, limit, cancellationToken);

        /// <summary>Looks up items by their Trakt-, IMDB-, TMDB-, TVDB- or TVRage-Id.</summary>
        /// <param name="searchIdType">The id type, which should be looked up. See also <seealso cref="TraktSearchIDType" />.</param>
        /// <param name="lookupId">The Trakt-, IMDB-, TMDB-, TVDB- or TVRage-Id, which will be looked up.</param>
        /// <param name="searchResultTypes">The object type(s), which will be looked up. See also <seealso cref="TraktSearchResultType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies, shows, episodes, people and / or lists should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the search results.
        /// <para />
        /// The response also contains information about the queried page number, the page's item count, maximum page count
        /// and maximum item count.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktSearchResult" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getsearchlookup">
        /// Trakt API Documentation: Search: ID Lookup.
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktPagedResponse<TraktSearchResult>> GetIdLookupResultsAsync(TraktSearchIDType searchIdType, string lookupId,
            TraktSearchResultType? searchResultTypes = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetIdLookupResultsImplAsync(searchIdType, lookupId, searchResultTypes, extendedInfo, page, limit, cancellationToken);

        /// <summary>Adds a recent search query to the history of the authenticated user.</summary>
        /// <param name="searchQuery">The search query to add.</param>
        /// <param name="itemId">The Trakt ID of the item.</param>
        /// <param name="type">The type of the search item. See also <seealso cref="TraktSearchRecentType" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />.
        /// <para />
        /// See also <seealso cref="TraktResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsearchrecentadd">
        /// Trakt API Documentation: Search: Add recent search
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktResponse> AddRecentSearchAsync(string searchQuery, uint itemId, TraktSearchRecentType type,
            CancellationToken cancellationToken = default)
            => AddRecentSearchImplAsync(searchQuery, itemId, type, cancellationToken);

        /// <summary>Removes a recent search query from the history of the authenticated user.</summary>
        /// <param name="searchQuery">The search query to remove.</param>
        /// <param name="itemId">The Trakt ID of the item.</param>
        /// <param name="type">The type of the search item. See also <seealso cref="TraktSearchRecentType" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktResponse" />.
        /// <para />
        /// See also <seealso cref="TraktResponse" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is required.
        /// <para><see href="https://docs.trakt.tv/reference/postsearchrecentremove">
        /// Trakt API Documentation: Search: Remove recent search
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktResponse> RemoveRecentSearchAsync(string searchQuery, uint itemId, TraktSearchRecentType type,
            CancellationToken cancellationToken = default)
            => RemoveRecentSearchImplAsync(searchQuery, itemId, type, cancellationToken);

        /// <summary>Searches for exact movie or show matches with the given search query.</summary>
        /// <param name="searchResultTypes">
        /// The object type(s), for which will be searched. See also <seealso cref="TraktSearchResultType" />.
        /// Multiple <see cref="TraktSearchResultType" /> values can be combined with a binary operator, like this: TraktSearchResultType.Movie | TraktSearchResultType.Show.
        /// </param>
        /// <param name="searchQuery">The query, for which will be searched.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies or shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the search results.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktSearchResult" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getsearchexact">
        /// Trakt API Documentation: Search: Exact Text Query.
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktPagedResponse<TraktSearchResult>> GetExactTextQueryResultsAsync(TraktSearchResultType searchResultTypes, string searchQuery,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetExactTextQueryResultsImplAsync(searchResultTypes, searchQuery, extendedInfo, page, limit, cancellationToken);

        /// <summary>Returns globally trending recent searches by type.</summary>
        /// <param name="type">The search recent type. See also <seealso cref="TraktSearchRecentType" />.</param>
        /// <param name="searchQuery">Optional search query to narrow the search text.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies, shows or people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">Specifies the page which should be queried. Defaults to the first page.</param>
        /// <param name="limit">Specifies the number of items which should be queried per page. Defaults to 10.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A paged response of type <see cref="TraktPagedResponse{TResponseContentType}" /> containing the trending search results.
        /// <para />
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <seealso cref="TraktTrendingSearchResult" />.
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getsearchtrending">
        /// Trakt API Documentation: Search: Trending.
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown if the validation of the request fails.</exception>
        public Task<TraktPagedResponse<TraktTrendingSearchResult>> GetTrendingSearchResultsAsync(TraktSearchRecentType type, string? searchQuery = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
            => GetTrendingSearchResultsImplAsync(type, searchQuery, extendedInfo, page, limit, cancellationToken);
    }
}
