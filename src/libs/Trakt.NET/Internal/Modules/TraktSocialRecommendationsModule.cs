namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to social recommendations.
    /// <para>This module contains all methods of the "Trakt API Documentation - Social Recommendations" section.</para>
    /// </summary>
    public sealed partial class TraktSocialRecommendationsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktPagedResponse<TraktSocialMovieRecommendation>> GetMovieRecommendationsImplAsync(uint? watchWindow = null,
            bool? ignoreWatched = null, bool? ignoreCollected = null, bool? ignoreWatchlisted = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new SocialMovieRecommendationsGetRequest
            {
                WatchWindow = watchWindow,
                IgnoreWatched = ignoreWatched,
                IgnoreCollected = ignoreCollected,
                IgnoreWatchlisted = ignoreWatchlisted,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktSocialMovieRecommendation>(_context, request, (page, limit)
                => new SocialMovieRecommendationsGetRequest
                {
                    WatchWindow = watchWindow,
                    IgnoreWatched = ignoreWatched,
                    IgnoreCollected = ignoreCollected,
                    IgnoreWatchlisted = ignoreWatchlisted,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktSocialShowRecommendation>> GetShowRecommendationsImplAsync(uint? watchWindow = null,
            bool? ignoreWatched = null, bool? ignoreCollected = null, bool? ignoreWatchlisted = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new SocialShowRecommendationsGetRequest
            {
                WatchWindow = watchWindow,
                IgnoreWatched = ignoreWatched,
                IgnoreCollected = ignoreCollected,
                IgnoreWatchlisted = ignoreWatchlisted,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktSocialShowRecommendation>(_context, request, (page, limit)
                => new SocialShowRecommendationsGetRequest
                {
                    WatchWindow = watchWindow,
                    IgnoreWatched = ignoreWatched,
                    IgnoreCollected = ignoreCollected,
                    IgnoreWatchlisted = ignoreWatchlisted,
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit
                }, cancellationToken);
        }
    }
}
