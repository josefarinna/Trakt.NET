using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetStreamingShowsTests
    {
        private const string GetStreamingShowsUri = "shows/streaming";

        [Theory]
        [InlineData(null, null, null, null, GetStreamingShowsUri, "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(TraktTimePeriod.Daily, null, null, null, $"{GetStreamingShowsUri}/daily", "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetStreamingShowsUri}?extended=full", "Shows\\mostanticipatedshows.json")]
        [InlineData(null, null, 4U, null, $"{GetStreamingShowsUri}?page=4", "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetStreamingShowsUri}?limit=20", "Shows\\mostanticipatedshows_minimal.json")]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.Full, 4U, 20U, $"{GetStreamingShowsUri}/daily?extended=full&page=4&limit=20", "Shows\\mostanticipatedshows.json")]
        public async Task TestGetStreamingShows(TraktTimePeriod? timePeriod, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktStreamingShow> response = await client.Shows.GetStreamingShowsAsync(timePeriod, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);
        }

        [Fact]
        public async Task TestGetStreamingShowsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostanticipatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetStreamingShowsUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktStreamingShow> response = await client.Shows.GetStreamingShowsAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(3U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetStreamingShowsPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostanticipatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetStreamingShowsUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktStreamingShow> response = await client.Shows.GetStreamingShowsAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(false);
        }

        [Fact]
        public async Task TestGetStreamingShowsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostanticipatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetStreamingShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktStreamingShow> response = await client.Shows.GetStreamingShowsAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);

            ModuleTestUtility.SetClient(client, $"{GetStreamingShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetStreamingShowsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostanticipatedshows_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetStreamingShowsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktStreamingShow> response = await client.Shows.GetStreamingShowsAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);

            ModuleTestUtility.SetClient(client, $"{GetStreamingShowsUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);
        }

        [Theory]
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
        public async Task TestGetStreamingShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetStreamingShowsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktStreamingShow>>> act = () => client.Shows.GetStreamingShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
