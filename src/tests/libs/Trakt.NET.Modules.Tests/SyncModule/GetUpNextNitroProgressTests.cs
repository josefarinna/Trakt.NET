using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetUpNextNitroProgressTests
    {
        private const string GetUpNextNitroProgressUri = "sync/progress/up_next_nitro";
        private const uint Page = 1U;
        private const uint Limit = 10U;
        private const uint ItemsCount = 1U;

        [Theory]
        [InlineData(null, null, null, null, $"{GetUpNextNitroProgressUri}?page=1&limit=10")]
        [InlineData(TraktSortBy.Title, null, null, null, $"{GetUpNextNitroProgressUri}?sort_by=title&page=1&limit=10")]
        [InlineData(null, TraktSortHow.Ascending, null, null, $"{GetUpNextNitroProgressUri}?sort_how=asc&page=1&limit=10")]
        [InlineData(null, null, TraktUpNextIntent.Continue, null, $"{GetUpNextNitroProgressUri}?intent=continue&page=1&limit=10")]
        [InlineData(null, null, null, "favorites", $"{GetUpNextNitroProgressUri}?watchnow=favorites&page=1&limit=10")]
        [InlineData(TraktSortBy.Title, TraktSortHow.Ascending, TraktUpNextIntent.Continue, "favorites", $"{GetUpNextNitroProgressUri}?sort_by=title&sort_how=asc&intent=continue&watchnow=favorites&page=1&limit=10")]
        public async Task TestGetUpNextNitroProgress(TraktSortBy? sortBy, TraktSortHow? sortHow, TraktUpNextIntent? intent, string? watchNow, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, Page, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetUpNextNitroProgressAsync(sortBy, sortHow, intent, watchNow, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetUpNextNitroProgressThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextNitroProgressUri}?page={Page}&limit={Limit}", statusCode);

            Func<Task<TraktPagedResponse<TraktSyncProgressWatchedItem>>> act = () => client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetUpNextNitroProgressThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetUpNextNitroProgressUri}?page={Page}&limit={Limit}", HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktSyncProgressWatchedItem>>> act = () => client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, null, 10, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Sync.GetUpNextNitroProgressAsync(null, null, null, null, null, 1, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
