using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetWatchlistTests
    {
        private const string GetWatchlistUri = "sync/watchlist";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemCount = 10U;
        private const uint ResponseCount = 4U;
        private const TraktSyncItemType WatchlistType = TraktSyncItemType.Movie;
        private const TraktSortBy SortBy = TraktSortBy.Rank;
        private const TraktSortHow SortHow = TraktSortHow.Ascending;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, Page, Limit, null, $"{GetWatchlistUri}?page=2&limit=4")]
        [InlineData(WatchlistType, null, null, null, Page, Limit, null, $"{GetWatchlistUri}/movies?page=2&limit=4")]
        [InlineData(null, SortBy, null, null, Page, Limit, null, $"{GetWatchlistUri}/rank?page=2&limit=4")]
        [InlineData(null, SortBy, SortHow, null, Page, Limit, null, $"{GetWatchlistUri}/rank/asc?page=2&limit=4")]
        [InlineData(null, null, null, null, Page, Limit, TraktFilterHide.Unwatched, $"{GetWatchlistUri}?hide=unwatched&page=2&limit=4")]
        [InlineData(null, null, null, ExtendedInfo, Page, Limit, null, $"{GetWatchlistUri}?extended=full&page=2&limit=4")]
        [InlineData(TraktSyncItemType.Show, SortBy, null, null, Page, Limit, null, $"{GetWatchlistUri}/shows/rank?page=2&limit=4")]
        [InlineData(TraktSyncItemType.Movie, TraktSortBy.Added, TraktSortHow.Descending, TraktExtendedInfo.Full, 3U, 10U, TraktFilterHide.NoReleaseDate, $"{GetWatchlistUri}/movies/added/desc?hide=noreleasedate&extended=full&page=3&limit=10")]
        [InlineData(TraktSyncItemType.Movie, TraktSortBy.Added, TraktSortHow.Descending, TraktExtendedInfo.Full, 3U, 10U, null, $"{GetWatchlistUri}/movies/added/desc?extended=full&page=3&limit=10")]
        public async Task TestGetWatchlist(TraktSyncItemType? watchlistItemType, TraktSortBy? sortBy, TraktSortHow? sortHow, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, TraktFilterHide? hide, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Watchlist\\syncwatchlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, ItemCount);

            TraktFilter? filter = hide is not null ? new TraktFilter { Hide = hide.Value } : null;

            TraktPagedResponse<TraktWatchlistItem> response = await client.Sync.GetWatchlistAsync(watchlistItemType, sortBy, sortHow, filter, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(limit ?? Limit);
            response.Page.ShouldBe(page ?? Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchlistPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Watchlist\\syncwatchlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchlistUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ItemCount);

            TraktPagedResponse<TraktWatchlistItem> response = await client.Sync.GetWatchlistAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchlistPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Watchlist\\syncwatchlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchlistUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktWatchlistItem> response = await client.Sync.GetWatchlistAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchlistPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Watchlist\\syncwatchlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchlistUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktWatchlistItem> response = await client.Sync.GetWatchlistAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchlistPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Watchlist\\syncwatchlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchlistUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktWatchlistItem> response = await client.Sync.GetWatchlistAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchlistPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Watchlist\\syncwatchlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchlistUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktWatchlistItem> response = await client.Sync.GetWatchlistAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetWatchlistUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchlistPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Watchlist\\syncwatchlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchlistUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktWatchlistItem> response = await client.Sync.GetWatchlistAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetWatchlistUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetWatchlistThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchlistUri}?page=1&limit=10", statusCode);

            Func<Task<TraktPagedResponse<TraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync(page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchlistUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync(page: null, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Sync.GetWatchlistAsync(page: 1U, limit: null, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
