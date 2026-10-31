using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetCollectionMoviesTests
    {
        private const string GetCollectionMoviesUri = "sync/collection/movies";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemCount = 2U;
        private const TraktAvailableOn AvailableOn = TraktAvailableOn.Digital;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetCollectionMoviesWithoutParameters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetCollectionMoviesUri, responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?page={Page}", responseContent, Page, 1, 10, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesWithAvailableOn()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?available_on={AvailableOn.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(availableOn: AvailableOn, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(ExtendedInfo, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesWithAvailableOnAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?available_on={AvailableOn.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(ExtendedInfo, AvailableOn, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktSyncCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMoviesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(page: 2U, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetCollectionMoviesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCollectionMoviesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(page: 1U, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetCollectionMoviesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetCollectionMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMoviesUri}?page=1&limit=10", statusCode);

            Func<Task<TraktPagedResponse<TraktSyncCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync(page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}

