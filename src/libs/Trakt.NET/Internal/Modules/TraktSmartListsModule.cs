namespace TraktNET
{
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
            string listIdOrSlug, TraktSmartListMediaType type, TraktSortBy sortBy, TraktSortHow sortHow,
            TraktFilter? filter = null, string? watchnow = null,
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
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }
    }
}
