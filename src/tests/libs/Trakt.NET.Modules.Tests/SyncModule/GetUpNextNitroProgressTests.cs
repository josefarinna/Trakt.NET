using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetUpNextNitroProgressTests
    {
        private const string GetUpNextNitroProgressUri = "sync/progress/up_next_nitro";
        private const uint Page = 1U;
        private const uint Limit = 10U;
        private const uint ItemsCount = 1U;

        [Fact]
        public async Task TestGetUpNextNitroProgress()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextNitroProgressUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetUpNextNitroProgressWithSortBy()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextNitroProgressUri}?sort_by=title&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextNitroProgressAsync(TraktSortBy.Title, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUpNextNitroProgressWithSortHow()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextNitroProgressUri}?sort_how=asc&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextNitroProgressAsync(null, TraktSortHow.Ascending, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUpNextNitroProgressWithIntent()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextNitroProgressUri}?intent=continue&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextNitroProgressAsync(null, null, TraktUpNextIntent.Continue, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUpNextNitroProgressWithWatchNow()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextNitroProgressUri}?watchnow=favorites&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemsCount);
            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextNitroProgressAsync(null, null, null, "favorites", null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetUpNextNitroProgressWithAllParameters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextNitroProgressUri}?sort_by=title&sort_how=asc&intent=continue&watchnow=favorites&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextNitroProgressAsync(
                TraktSortBy.Title, TraktSortHow.Ascending, TraktUpNextIntent.Continue, "favorites", null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetUpNextNitroProgressPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextNitroProgressUri}?page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetUpNextNitroProgressPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextNitroProgressUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetUpNextNitroProgressPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextNitroProgressUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetUpNextNitroProgressPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextNitroProgressUri}?page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetUpNextNitroProgressPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextNitroProgressUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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
                $"{GetUpNextNitroProgressUri}?page=1&limit={Limit}",
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
        public async Task TestGetUpNextNitroProgressPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetUpNextNitroProgressUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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
                $"{GetUpNextNitroProgressUri}?page=2&limit={Limit}",
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
        public async Task TestGetUpNextNitroProgressThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextNitroProgressUri}?page={Page}&limit={Limit}", statusCode);

            Func<Task<TraktPagedResponse<TraktSyncProgressWatchedItem>>> act = () => client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetUpNextNitroProgressThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextNitroProgressUri}?page={Page}&limit={Limit}", HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktSyncProgressWatchedItem>>> act = () => client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, null, 10, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, 1, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
