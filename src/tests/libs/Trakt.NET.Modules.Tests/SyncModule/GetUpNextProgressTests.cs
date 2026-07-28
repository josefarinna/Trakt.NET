using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetUpNextProgressTests
    {
        private const string GetUpNextProgressUri = "sync/progress/up_next";
        private const uint Page = 1U;
        private const uint Limit = 10U;
        private const uint ItemsCount = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetUpNextProgress()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextProgressUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextProgressAsync(null, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUpNextProgressWithSortBy()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextProgressUri}?sort_by=title&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextProgressAsync(TraktSortBy.Title, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetUpNextProgressWithSortHow()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextProgressUri}?sort_how=asc&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextProgressAsync(null, TraktSortHow.Ascending, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUpNextProgressWithIncludeStats()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextProgressUri}?include_stats=true&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextProgressAsync(null, null, true, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUpNextProgressWithLifetimeStats()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextProgressUri}?lifetime_stats=true&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextProgressAsync(null, null, null, true, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUpNextProgressWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextProgressUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextProgressAsync(null, null, null, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetUpNextProgressWithAllParameters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextProgressUri}?sort_by=title&sort_how=asc&include_stats=true&lifetime_stats=true&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextProgressAsync(
                TraktSortBy.Title, TraktSortHow.Ascending, true, true, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetUpNextProgressPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextProgressUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextProgressAsync(null, null, null, null, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUpNextProgressPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextProgressUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextProgressAsync(null, null, null, null, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetUpNextProgressPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextProgressUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextProgressAsync(null, null, null, null, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUpNextProgressPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextProgressUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextProgressAsync(null, null, null, null, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetUpNextProgressPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextProgressUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextProgressAsync(null, null, null, null, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetOAuthClient(client,
                $"{GetUpNextProgressUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUpNextProgressPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextProgressUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextProgressAsync(null, null, null, null, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetOAuthClient(client,
                $"{GetUpNextProgressUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemsCount);
            response.ItemCount.ShouldBe(ItemsCount);
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetUpNextProgressThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextProgressUri}?page={Page}&limit={Limit}", statusCode);

            Func<Task<TraktPagedResponse<TraktSyncProgressWatchedItem>>> act = () => client.Sync.GetUpNextProgressAsync(null, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetUpNextProgressThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextProgressUri}?page={Page}&limit={Limit}", HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktSyncProgressWatchedItem>>> act = () => client.Sync.GetUpNextProgressAsync(null, null, null, null, null, null, 10, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Sync.GetUpNextProgressAsync(null, null, null, null, null, 1, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
