namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to smart lists.
    /// <para>This module contains all methods of the "Trakt API Documentation - Smart Lists" section.</para>
    /// </summary>
    public sealed partial class TraktSmartListsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktResponse<TraktSmartList>> GetSmartListImplAsync(string listIdOrSlug, TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
        {
            var request = new SmartListGetRequest
            {
                Id = listIdOrSlug,
                ExtendedInfo = extendedInfo
            };

            return RequestHandler.ExecuteSingleItemRequestAsync<TraktSmartList>(_context, request, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktListItem>> GetSmartListItemsImplAsync(
            string listIdOrSlug, TraktSmartListItemType? type = null, TraktSortBy? sortBy = null, TraktSortHow? sortHow = null,
            TraktFilter? filter = null, string? watchnow = null, string? watchnowCountry = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new SmartListItemsGetRequest
            {
                ListId = listIdOrSlug,
                Type = type,
                SortBy = sortBy,
                SortHow = sortHow,
                Filter = filter,
                Watchnow = watchnow,
                WatchnowCountry = watchnowCountry,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktListItem>(_context, request, (page, limit)
                => new SmartListItemsGetRequest
                {
                    ListId = listIdOrSlug,
                    Type = type,
                    SortBy = sortBy,
                    SortHow = sortHow,
                    Filter = filter,
                    Watchnow = watchnow,
                    WatchnowCountry = watchnowCountry,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }
    }
}
