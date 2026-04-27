using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetWatchlistTests
    {
        private const string GetWatchlistUri = $"users/{Username}/watchlist";
        private const string Username = "sean";
        private const uint Page = 2;
        private const uint WatchlistLimit = 4U;
        private const uint WatchlistItemCount = 4U;
        private const TraktSyncItemType WatchlistItemType = TraktSyncItemType.Movie;
        private const TraktSortBy SortBy = TraktSortBy.Rank;
        private const TraktSortHow SortHow = TraktSortHow.Ascending;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetWatchlist()
        {
			string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetWatchlistUri, responseContent, 1, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response = await client.Users.GetWatchlistAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchlistUri, responseContent, 1, 1, 10, WatchlistItemCount);

            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktWatchlistItem> response = await client.Users.GetWatchlistAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/watchlist", responseContent, 1, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response = await client.Users.GetWatchlistAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}",
                responseContent, 1, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithTypeAndSort()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}",
                responseContent, 1, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithTypeAndSortAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, SortHow, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithTypeAndSortAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}?page={Page}",
                responseContent, 1, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, SortHow, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithTypeAndSortAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}?limit={WatchlistLimit}",
                responseContent, 1, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, SortHow, null, null, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={WatchlistLimit}",
                responseContent, 1, 1, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, null, null, ExtendedInfo, null, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, null, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, null, null, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}?extended={ExtendedInfo.ToURI()}&limit={WatchlistLimit}",
                responseContent, 1, 1, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, null, null, null, ExtendedInfo, null, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={WatchlistLimit}",
                responseContent, Page, 1, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, null, null, null, ExtendedInfo, Page, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}?page={Page}",
                responseContent, Page, 1, 10, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, null, null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}?limit={WatchlistLimit}",
                responseContent, 1, 1, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, null, null, null, null, null, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}?page={Page}&limit={WatchlistLimit}",
                responseContent, Page, 1, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, null, null, null, null, Page, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page={Page}&limit={WatchlistLimit}",
                responseContent, Page, 1, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, SortHow, ExtendedInfo, Page, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetWatchlistPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={WatchlistLimit}",
                responseContent, 2, 5, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, SortHow, ExtendedInfo, 2, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchlistPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={WatchlistLimit}",
                responseContent, 2, 2, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, SortHow, ExtendedInfo, 2, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchlistPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={WatchlistLimit}",
                responseContent, 1, 2, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, SortHow, ExtendedInfo, 1, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchlistPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={WatchlistLimit}",
                responseContent, 1, 1, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, SortHow, ExtendedInfo, 1, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchlistPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={WatchlistLimit}",
                responseContent, 2, 2, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, SortHow, ExtendedInfo, 2, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={WatchlistLimit}",
                responseContent, 1, 2, WatchlistLimit, WatchlistItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchlistPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\watchlist.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=1&limit={WatchlistLimit}",
                responseContent, 1, 2, WatchlistLimit, WatchlistItemCount);

            TraktPagedResponse<TraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(Username, WatchlistItemType, SortBy, SortHow, ExtendedInfo, 1, WatchlistLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetWatchlistUri}/{WatchlistItemType.ToURI()}/{SortBy.ToURI()}/{SortHow.ToURI()}" +
                $"?extended={ExtendedInfo.ToURI()}&page=2&limit={WatchlistLimit}",
                responseContent, 2, 2, WatchlistLimit, WatchlistItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)WatchlistItemCount);
            response.ItemCount.ShouldBe(WatchlistItemCount);
            response.Limit.ShouldBe(WatchlistLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.SortBy.ShouldBeNull();
            response.SortHow.ShouldBeNull();
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
        public async Task TestGetWatchlistThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetWatchlistUri, statusCode);

            Func<Task<TraktPagedResponse<TraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
