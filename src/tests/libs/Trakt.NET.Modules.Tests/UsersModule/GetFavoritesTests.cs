using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetFavoritesTests
    {
        private const string GetFavoritesUri = $"users/{Username}/favorites";
        private const string Username = "sean";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint FavoritesItemCount = 2U;
        private const TraktFavoriteObjectType FavoriteType = TraktFavoriteObjectType.Movie;
        private const TraktSortBy SortBy = TraktSortBy.Rank;
        private const TraktSortHow SortHow = TraktSortHow.Ascending;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, $"{GetFavoritesUri}?page=2&limit=4")]
        [InlineData(FavoriteType, null, null, null, $"{GetFavoritesUri}/movies?page=2&limit=4")]
        [InlineData(TraktFavoriteObjectType.Media, null, null, null, $"{GetFavoritesUri}/media?page=2&limit=4")]
        [InlineData(FavoriteType, SortBy, SortHow, ExtendedInfo, $"{GetFavoritesUri}/movies/rank/asc?extended=full&page=2&limit=4")]
        [InlineData(null, null, null, ExtendedInfo, $"{GetFavoritesUri}?extended=full&page=2&limit=4")]
        public async Task TestGetFavorites(TraktFavoriteObjectType? favoriteObjectType, TraktSortBy? sortBy, TraktSortHow? sortHow, TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, Page, 1, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, favoriteObjectType, sortBy, sortHow, extendedInfo, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, FavoritesItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/me/favorites?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync("me", null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetFavoritesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetFavoritesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetFavoritesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetFavoritesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, FavoritesItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetFavoritesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, null, null, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetFavoritesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, FavoritesItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
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
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFavoritesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktFavorite>>> act = () => client.Users.GetFavoritesAsync(Username, null, null, null, null, Page, Limit, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetFavoritesThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFavoritesUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktFavorite>>> act = () => client.Users.GetFavoritesAsync(Username, null, null, null, null, null, Limit, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetFavoritesAsync(Username, null, null, null, null, Page, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
