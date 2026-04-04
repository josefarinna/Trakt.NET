using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetWatchlistTests
    {
        private const string GetWatchlistUri = "sync/watchlist";

        [Theory]
        [InlineData(null, null, null, null, null, null, GetWatchlistUri)]
        [InlineData(TraktSyncItemType.Movie, null, null, null, null, null, $"{GetWatchlistUri}/movies")]
        [InlineData(null, TraktSortBy.Rank, null, null, null, null, $"{GetWatchlistUri}/rank")]
        [InlineData(null, TraktSortBy.Added, TraktSortHow.Ascending, null, null, null, $"{GetWatchlistUri}/added/asc")]
        [InlineData(null, null, null, TraktExtendedInfo.Full, null, null, $"{GetWatchlistUri}?extended=full")]
        [InlineData(null, null, null, null, 2U, null, $"{GetWatchlistUri}?page=2")]
        [InlineData(null, null, null, null, null, 5U, $"{GetWatchlistUri}?limit=5")]
        [InlineData(TraktSyncItemType.Show, TraktSortBy.Rank, null, null, 2U, null, $"{GetWatchlistUri}/shows/rank?page=2")]
        [InlineData(TraktSyncItemType.Movie, TraktSortBy.Added, TraktSortHow.Descending, TraktExtendedInfo.Full, 3U, 10U, $"{GetWatchlistUri}/movies/added/desc?extended=full&page=3&limit=10")]
        public async Task TestGetWatchlist(TraktSyncItemType? type, TraktSortBy? sortBy, TraktSortHow? sortHow,
            TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string expectedUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Watchlist\\syncwatchlist.json");
            uint expectedPage = page ?? 1U;
            uint expectedLimit = limit ?? 10U;

            TraktClient client = ModuleTestUtility.GetOAuthClient(expectedUri, responseContent, expectedPage, 1, expectedLimit, 10);

            TraktPagedResponse<TraktWatchlistItem> response = await client.Sync.GetWatchlistAsync(
                type, sortBy, sortHow, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(4);
            response.ItemCount.ShouldBe(10U);
            response.Page.ShouldBe(expectedPage);
            response.Limit.ShouldBe(expectedLimit);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetWatchlistThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchlistUri, statusCode);

            Func<Task<TraktPagedResponse<TraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
