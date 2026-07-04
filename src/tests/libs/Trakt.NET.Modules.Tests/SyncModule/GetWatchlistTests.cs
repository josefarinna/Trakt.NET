using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetWatchlistTests
    {
        private const string GetWatchlistUri = "sync/watchlist";

        [Theory]
        [InlineData(null, null, null, null, 1U, 10U, $"{GetWatchlistUri}?page=1&limit=10")]
        [InlineData(TraktSyncItemType.Movie, null, null, null, 1U, 10U, $"{GetWatchlistUri}/movies?page=1&limit=10")]
        [InlineData(null, TraktSortBy.Rank, null, null, 1U, 10U, $"{GetWatchlistUri}/rank?page=1&limit=10")]
        [InlineData(null, TraktSortBy.Added, TraktSortHow.Ascending, null, 1U, 10U, $"{GetWatchlistUri}/added/asc?page=1&limit=10")]
        [InlineData(null, null, null, TraktExtendedInfo.Full, 1U, 10U, $"{GetWatchlistUri}?extended=full&page=1&limit=10")]
        [InlineData(null, null, null, null, 2U, 10U, $"{GetWatchlistUri}?page=2&limit=10")]
        [InlineData(null, null, null, null, 1U, 5U, $"{GetWatchlistUri}?page=1&limit=5")]
        [InlineData(TraktSyncItemType.Show, TraktSortBy.Rank, null, null, 2U, 10U, $"{GetWatchlistUri}/shows/rank?page=2&limit=10")]
        [InlineData(TraktSyncItemType.Movie, TraktSortBy.Added, TraktSortHow.Descending, TraktExtendedInfo.Full, 3U, 10U, $"{GetWatchlistUri}/movies/added/desc?extended=full&page=3&limit=10")]
        public async Task TestGetWatchlist(TraktSyncItemType? type, TraktSortBy? sortBy, TraktSortHow? sortHow,
            TraktExtendedInfo? extendedInfo, uint page, uint limit, string expectedUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Watchlist\\syncwatchlist.json");
            uint expectedPage = page;
            uint expectedLimit = limit;

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
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchlistUri}?page=1&limit=10", statusCode);

            Func<Task<TraktPagedResponse<TraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync(page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchlistUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync(page: null, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Sync.GetWatchlistAsync(page: 1U, limit: null, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
