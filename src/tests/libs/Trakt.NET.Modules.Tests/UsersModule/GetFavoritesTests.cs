using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetFavoritesTests
    {
        private const string GetFavoritesUri = $"users/{Username}/favorites";
        private const string Username = "sean";
        private const uint Page = 2U;
        private const uint FavoritesItemCount = 2U;
        private const uint FavoritesLimit = 6U;
        private const TraktFavoriteObjectType FavoriteType = TraktFavoriteObjectType.Movie;
        private const TraktSortBy SortBy = TraktSortBy.Rank;
        private const TraktSortHow SortHow = TraktSortHow.Ascending;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetFavorites()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFavoritesUri, responseContent, 1, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response = await client.Users.GetFavoritesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetFavoritesUri}/{FavoriteType.ToURI()}", responseContent, 1, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndSortOrder()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}",
                responseContent, 1, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndSortOrderAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndSortOrderAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndSortOrderAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}?limit={FavoritesLimit}",
                responseContent, 1, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, null, null, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndSortOrderAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}?page={Page}&limit={FavoritesLimit}",
                responseContent, Page, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, null, Page, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={FavoritesLimit}",
                responseContent, 1, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, null, null, ExtendedInfo, null, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={FavoritesLimit}",
                responseContent, Page, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, null, null, ExtendedInfo, Page, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}?limit={FavoritesLimit}",
                responseContent, 1, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, null, null, null, null, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithFavoriteTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}?page={Page}&limit={FavoritesLimit}",
                responseContent, Page, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, null, null, null, Page, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, null, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, null, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}?extended={ExtendedInfo.ToURI()}&limit={FavoritesLimit}",
                responseContent, 1, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, null, null, null, ExtendedInfo, null, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={FavoritesLimit}",
                responseContent, Page, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, null, null, null, ExtendedInfo, Page, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}?page={Page}",
                responseContent, Page, 1, 10, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, null, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}?limit={FavoritesLimit}",
                responseContent, 1, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, null, null, null, null, null, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}?page={Page}&limit={FavoritesLimit}",
                responseContent, Page, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, null, null, null, null, Page, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page={Page}&limit={FavoritesLimit}",
                responseContent, Page, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, ExtendedInfo, Page, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={FavoritesLimit}",
                responseContent, 2, 5, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, ExtendedInfo, 2, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetFavoritesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={FavoritesLimit}",
                responseContent, 2, 2, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, ExtendedInfo, 2, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetFavoritesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={FavoritesLimit}",
                responseContent, 1, 2, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, ExtendedInfo, 1, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetFavoritesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={FavoritesLimit}",
                responseContent, 1, 1, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, ExtendedInfo, 1, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetFavoritesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={FavoritesLimit}",
                responseContent, 2, 2, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, ExtendedInfo, 2, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={FavoritesLimit}",
                responseContent, 1, 2, FavoritesLimit, FavoritesItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetFavoritesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\userfavorites.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={FavoritesLimit}",
                responseContent, 1, 2, FavoritesLimit, FavoritesItemCount);

            TraktPagedResponse<TraktFavorite> response =
                await client.Users.GetFavoritesAsync(Username, FavoriteType, SortBy, SortHow, ExtendedInfo, 1, FavoritesLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetFavoritesUri}/{FavoriteType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={FavoritesLimit}",
                responseContent, 2, 2, FavoritesLimit, FavoritesItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)FavoritesItemCount);
            response.ItemCount.ShouldBe(FavoritesItemCount);
            response.Limit.ShouldBe(FavoritesLimit);
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
        public async Task TestGetFavoritesThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFavoritesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktFavorite>>> act = () => client.Users.GetFavoritesAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
