namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to media (movies and shows).<para />
    /// This module contains all methods of the Trakt API Documentation - Media section.
    /// </summary>
    public sealed partial class TraktMediaModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktPagedResponse<TraktTrendingMedia>> GetTrendingMediaImplAsync(TraktExtendedInfo? extendedInfo = null,
            TraktFilter? filter = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new MediaTrendingGetRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktTrendingMedia>(_context, request, (page, limit)
                => new MediaTrendingGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Filter = filter,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktAnticipatedMedia>> GetAnticipatedMediaImplAsync(TraktExtendedInfo? extendedInfo = null,
            TraktFilter? filter = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new MediaAnticipatedGetRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktAnticipatedMedia>(_context, request, (page, limit)
                => new MediaAnticipatedGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Filter = filter,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }

        private Task<TraktPagedResponse<TraktPopularMedia>> GetPopularMediaImplAsync(TraktExtendedInfo? extendedInfo = null,
            TraktFilter? filter = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new MediaPopularGetRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktPopularMedia>(_context, request, (page, limit)
                => new MediaPopularGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Filter = filter,
                    Page = page,
                    Limit = limit
                },
                cancellationToken);
        }
    }
}
