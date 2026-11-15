using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetWatchedProgressTests
    {
        private const string GetWatchedProgressUri = "sync/progress/watched";
        private const uint Page = 1U;
        private const uint Limit = 10U;
        private const uint ItemsCount = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, null, null, null, $"{GetWatchedProgressUri}?page=1&limit=10")]
        [InlineData(TraktSortBy.Title, null, null, null, null, null, null, $"{GetWatchedProgressUri}?sort_by=title&page=1&limit=10")]
        [InlineData(null, TraktSortHow.Ascending, null, null, null, null, null, $"{GetWatchedProgressUri}?sort_how=asc&page=1&limit=10")]
        [InlineData(null, null, true, null, null, null, null, $"{GetWatchedProgressUri}?lifetime_stats=true&page=1&limit=10")]
        [InlineData(null, null, null, true, null, null, null, $"{GetWatchedProgressUri}?hide_completed=true&page=1&limit=10")]
        [InlineData(null, null, null, null, true, null, null, $"{GetWatchedProgressUri}?hide_not_completed=true&page=1&limit=10")]
        [InlineData(null, null, null, null, null, true, null, $"{GetWatchedProgressUri}?only_rewatching=true&page=1&limit=10")]
        [InlineData(null, null, null, null, null, null, ExtendedInfo, $"{GetWatchedProgressUri}?extended=full&page=1&limit=10")]
        [InlineData(TraktSortBy.Title, TraktSortHow.Ascending, true, true, false, true, ExtendedInfo, $"{GetWatchedProgressUri}?sort_by=title&sort_how=asc&lifetime_stats=true&hide_completed=true&hide_not_completed=false&only_rewatching=true&extended=full&page=1&limit=10")]
        public async Task TestGetWatchedProgress(TraktSortBy? sortBy, TraktSortHow? sortHow, bool? lifetimeStats, bool? hideCompleted, bool? hideNotCompleted, bool? onlyRewatching, TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, Page, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response = await client.Sync.GetWatchedProgressAsync(sortBy, sortHow, lifetimeStats, hideCompleted, hideNotCompleted, onlyRewatching, extendedInfo, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetWatchedProgressPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedProgressUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetWatchedProgressAsync(null, null, null, null, null, null, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetWatchedProgressPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedProgressUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetWatchedProgressAsync(null, null, null, null, null, null, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetWatchedProgressPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedProgressUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetWatchedProgressAsync(null, null, null, null, null, null, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetWatchedProgressPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedProgressUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetWatchedProgressAsync(null, null, null, null, null, null, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetWatchedProgressPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedProgressUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetWatchedProgressAsync(null, null, null, null, null, null, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
                $"{GetWatchedProgressUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
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
        public async Task TestGetWatchedProgressPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Progress\\syncprogresswatched.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetWatchedProgressUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemsCount);

            TraktPagedResponse<TraktSyncProgressWatchedItem> response =
                await client.Sync.GetWatchedProgressAsync(null, null, null, null, null, null, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
                $"{GetWatchedProgressUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
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
        public async Task TestGetWatchedProgressThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedProgressUri}?page={Page}&limit={Limit}", statusCode);

            Func<Task<TraktPagedResponse<TraktSyncProgressWatchedItem>>> act = () => client.Sync.GetWatchedProgressAsync(null, null, null, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetWatchedProgressThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedProgressUri}?page={Page}&limit={Limit}", HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktSyncProgressWatchedItem>>> act = () => client.Sync.GetWatchedProgressAsync(null, null, null, null, null, null, null, null, 10, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Sync.GetWatchedProgressAsync(null, null, null, null, null, null, null, 1, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
