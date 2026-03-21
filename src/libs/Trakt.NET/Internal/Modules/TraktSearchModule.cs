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
    }
}
