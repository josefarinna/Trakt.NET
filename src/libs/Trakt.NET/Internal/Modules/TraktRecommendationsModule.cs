namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to recommendations.
    /// <para>This module contains all methods of the "Trakt API Documentation - Recommendations" section.</para>
    /// </summary>
    public sealed partial class TraktRecommendationsModule(TraktContext context) : BaseModule(context)
    {
        private Task<TraktPagedResponse<TraktRecommendedMovie>> GetMovieRecommendationsImplAsync(bool? ignoreCollected = null, bool? ignoreWatchlisted = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserMovieRecommendationsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                IgnoreCollected = ignoreCollected,
                IgnoreWatchlisted = ignoreWatchlisted
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktRecommendedMovie>(_context, request, (page, limit)
                => new UserMovieRecommendationsGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    IgnoreCollected = ignoreCollected,
                    IgnoreWatchlisted = ignoreWatchlisted
                }, cancellationToken);
        }

        private Task<TraktPagedResponse<TraktRecommendedShow>> GetShowRecommendationsImplAsync(bool? ignoreCollected = null, bool? ignoreWatchlisted = null,
            TraktExtendedInfo? extendedInfo = null, uint? page = null, uint? limit = null, CancellationToken cancellationToken = default)
        {
            var request = new UserShowRecommendationsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limit,
                IgnoreCollected = ignoreCollected,
                IgnoreWatchlisted = ignoreWatchlisted
            };

            return RequestHandler.ExecutePagedListRequestAsync<TraktRecommendedShow>(_context, request, (page, limit)
                => new UserShowRecommendationsGetRequest
                {
                    ExtendedInfo = extendedInfo,
                    Page = page,
                    Limit = limit,
                    IgnoreCollected = ignoreCollected,
                    IgnoreWatchlisted = ignoreWatchlisted
                }, cancellationToken);
        }

        private Task<TraktResponse> HideMovieRecommendationImplAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteNoContentRequestAsync(_context, new UserRecommendationHideMovieDeleteRequest
            {
                Id = movieIdOrSlug
            },
            cancellationToken);
        }

        private Task<TraktResponse> HideShowRecommendationImplAsync(string showIdOrSlug, CancellationToken cancellationToken = default)
        {
            return RequestHandler.ExecuteNoContentRequestAsync(_context, new UserRecommendationHideShowDeleteRequest
            {
                Id = showIdOrSlug
            },
            cancellationToken);
        }
    }
}
