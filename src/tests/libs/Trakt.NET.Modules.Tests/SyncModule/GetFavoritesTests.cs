using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetFavoritesTests
    {
        private const string GetFavoritesUri = "sync/favorites";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemCount = 2U;
        private const TraktFavoriteObjectType FavoriteType = TraktFavoriteObjectType.Movie;
        private const TraktSortBy SortBy = TraktSortBy.Rank;
        private const TraktSortHow SortHow = TraktSortHow.Ascending;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, Page, Limit, $"{GetFavoritesUri}?page=2&limit=4")]
        [InlineData(FavoriteType, null, null, null, Page, Limit, $"{GetFavoritesUri}/movies?page=2&limit=4")]
        [InlineData(null, SortBy, null, null, Page, Limit, $"{GetFavoritesUri}/rank?page=2&limit=4")]
        [InlineData(null, SortBy, SortHow, null, Page, Limit, $"{GetFavoritesUri}/rank/asc?page=2&limit=4")]
        [InlineData(null, null, null, ExtendedInfo, Page, Limit, $"{GetFavoritesUri}?extended=full&page=2&limit=4")]
        [InlineData(TraktFavoriteObjectType.Show, SortBy, null, null, Page, Limit, $"{GetFavoritesUri}/shows/rank?page=2&limit=4")]
        [InlineData(TraktFavoriteObjectType.Movie, TraktSortBy.Added, TraktSortHow.Descending, TraktExtendedInfo.Full, 3U, 10U, $"{GetFavoritesUri}/movies/added/desc?extended=full&page=3&limit=10")]
        public async Task TestGetFavorites(TraktFavoriteObjectType? favoriteObjectType, TraktSortBy? sortBy, TraktSortHow? sortHow, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Favorites\\syncfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, ItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Sync.GetFavoritesAsync(favoriteObjectType, sortBy, sortHow, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(limit ?? Limit);
            response.Page.ShouldBe(page ?? Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Favorites\\syncfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Sync.GetFavoritesAsync(null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetFavoritesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Favorites\\syncfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Sync.GetFavoritesAsync(null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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

        [Fact]
        public async Task TestGetFavoritesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Favorites\\syncfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Sync.GetFavoritesAsync(null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetFavoritesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Favorites\\syncfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Sync.GetFavoritesAsync(null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetFavoritesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Favorites\\syncfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Sync.GetFavoritesAsync(null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

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
        public async Task TestGetFavoritesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Favorites\\syncfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Sync.GetFavoritesAsync(null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

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
        public async Task TestGetFavoritesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit=10", statusCode);

            Func<Task<TraktPagedResponse<TraktFavorite>>> act = () => client.Sync.GetFavoritesAsync(page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetFavoritesThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFavoritesUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktFavorite>>> act = () => client.Sync.GetFavoritesAsync(page: null, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Sync.GetFavoritesAsync(page: 1U, limit: null, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
