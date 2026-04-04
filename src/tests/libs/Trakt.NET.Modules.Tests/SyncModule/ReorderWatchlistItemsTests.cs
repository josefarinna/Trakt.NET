using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class ReorderWatchlistItemsTests
    {
        private const string ReorderWatchlistItemsUri = "sync/watchlist/reorder";
        private readonly List<uint> ReorderedItems = [923, 324, 98768, 456456, 345, 2, 990];

        [Fact]
        public async Task TestReorderWatchlistItems()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitemsreorderpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderWatchlistItemsUri, responseContent, null, null, null, null);
            TraktResponse<TraktListItemsReorderPostResponse> response = await client.Sync.ReorderWatchlistItemsAsync(ReorderedItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktListItemsReorderPostResponse responseValue = response.Content;

            responseValue.Updated.ShouldBe(6U);
            responseValue.SkippedIDs.ShouldNotBeNull();
            responseValue.SkippedIDs.Count.ShouldBe(1);
            responseValue.SkippedIDs.ShouldBeEquivalentTo(new List<uint> { 2 });
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
        public async Task TestReorderWatchlistItemsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderWatchlistItemsUri, statusCode);

            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act = () => client.Sync.ReorderWatchlistItemsAsync(ReorderedItems, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderWatchlistItemsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderWatchlistItemsUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act = () => client.Sync.ReorderWatchlistItemsAsync(null, TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
