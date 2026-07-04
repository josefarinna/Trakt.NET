using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetFavoritesTests
    {
        private const string GetFavoritesUri = "sync/favorites";

        [Theory]
        [InlineData(null, null, null, null, 1U, 10U, $"{GetFavoritesUri}?page=1&limit=10")]
        [InlineData(TraktFavoriteObjectType.Movie, null, null, null, 1U, 10U, $"{GetFavoritesUri}/movies?page=1&limit=10")]
        [InlineData(null, TraktSortBy.Rank, null, null, 1U, 10U, $"{GetFavoritesUri}/rank?page=1&limit=10")]
        [InlineData(null, TraktSortBy.Added, TraktSortHow.Ascending, null, 1U, 10U, $"{GetFavoritesUri}/added/asc?page=1&limit=10")]
        [InlineData(null, null, null, TraktExtendedInfo.Full, 1U, 10U, $"{GetFavoritesUri}?extended=full&page=1&limit=10")]
        [InlineData(null, null, null, null, 2U, 10U, $"{GetFavoritesUri}?page=2&limit=10")]
        [InlineData(null, null, null, null, 1U, 5U, $"{GetFavoritesUri}?page=1&limit=5")]
        [InlineData(TraktFavoriteObjectType.Show, TraktSortBy.Rank, null, null, 2U, 10U, $"{GetFavoritesUri}/shows/rank?page=2&limit=10")]
        [InlineData(TraktFavoriteObjectType.Movie, TraktSortBy.Added, TraktSortHow.Descending, TraktExtendedInfo.Full, 3U, 10U, $"{GetFavoritesUri}/movies/added/desc?extended=full&page=3&limit=10")]
        public async Task TestGetFavoritesParametrized(TraktFavoriteObjectType? type, TraktSortBy? sortBy, TraktSortHow? sortHow,
            TraktExtendedInfo? extendedInfo, uint page, uint limit, string expectedUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Favorites\\syncfavorites.json");
            uint expectedPage = page;
            uint expectedLimit = limit;

            TraktClient client = ModuleTestUtility.GetOAuthClient(expectedUri, responseContent, expectedPage, 1, expectedLimit, 10);

            TraktPagedResponse<TraktFavorite> response = await client.Sync.GetFavoritesAsync(
                type, sortBy, sortHow, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
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
        public async Task TestGetFavoritesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit=10", statusCode);

            Func<Task<TraktPagedResponse<TraktFavorite>>> act = () => client.Sync.GetFavoritesAsync(page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetFavoritesThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFavoritesUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktFavorite>>> act = () => client.Sync.GetFavoritesAsync(page: null, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Sync.GetFavoritesAsync(page: 1U, limit: null, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
