namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to search.<para />
    /// This module contains all methods of the <a href="https://trakt.docs.apiary.io/#reference/search">"Trakt API Documentation - Search"</a> section.
    /// </summary>
    public sealed partial class TraktSearchModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktPagedResponse<TraktSearchResult>> GetTextQueryResultsImplAsync(TraktSearchResultType searchResultTypes, string searchQuery,
            TraktSearchField? searchFields = null, TraktFilter? filter = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new SearchTextQueryGetRequest
            {
                Type = searchResultTypes,
                Query = searchQuery,
                Filter = filter,
                ExtendedInfo = extendedInfo,
                SearchField = searchFields,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktSearchResult>(_context, request, (page, limit)
                => new SearchTextQueryGetRequest
                {
                    Type = searchResultTypes,
                    Query = searchQuery,
                    Filter = filter,
                    ExtendedInfo = extendedInfo,
                    SearchField = searchFields,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktSearchResult>> GetIdLookupResultsImplAsync(TraktSearchIDType searchIdType, string lookupId,
            TraktSearchResultType? searchResultTypes = null, TraktExtendedInfo? extendedInfo = null,
            uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new SearchIDLookupGetRequest
            {
                IdType = searchIdType,
                LookupId = lookupId,
                ResultTypes = searchResultTypes,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktSearchResult>(_context, request, (page, limit)
                => new SearchIDLookupGetRequest
                {
                    IdType = searchIdType,
                    LookupId = lookupId,
                    ResultTypes = searchResultTypes,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktResponse> AddRecentSearchImplAsync(string searchQuery, uint itemId, TraktSearchRecentType type,
            CancellationToken cancellationToken = default)
        {
            var request = new SearchRecentAddPostRequest
            {
                TraktSearchRecentPost = new TraktSearchRecentPost
                {
                    Query = searchQuery,
                    Id = itemId,
                    Type = type
                }
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktResponse> RemoveRecentSearchImplAsync(string searchQuery, uint itemId, TraktSearchRecentType type,
            CancellationToken cancellationToken = default)
        {
            var request = new SearchRecentRemovePostRequest
            {
                TraktSearchRecentPost = new TraktSearchRecentPost
                {
                    Query = searchQuery,
                    Id = itemId,
                    Type = type
                }
            };

            return RequestHandler.ExecuteNoContentRequestAsync(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktSearchResult>> GetExactTextQueryResultsImplAsync(TraktSearchResultType searchResultTypes, string searchQuery,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new SearchExactTextQueryGetRequest
            {
                Type = searchResultTypes,
                Query = searchQuery,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktSearchResult>(_context, request, (page, limit)
                => new SearchExactTextQueryGetRequest
                {
                    Type = searchResultTypes,
                    Query = searchQuery,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktTrendingSearchResult>> GetTrendingSearchResultsImplAsync(TraktSearchRecentType type, string? searchQuery = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            if (type == TraktSearchRecentType.Unspecified || type == TraktSearchRecentType.List)
            {
                throw new TraktRequestValidationException(nameof(type), "type is not valid");
            }

            var request = new SearchTrendingGetRequest
            {
                Type = type,
                Query = searchQuery,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktTrendingSearchResult>(_context, request, (page, limit)
                => new SearchTrendingGetRequest
                {
                    Type = type,
                    Query = searchQuery,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }
    }
}
