using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetPersonalListItemsTests
    {
        private readonly string GetPersonalListItemsUri = $"users/{Username}/lists/{ListID}/items";
        private const string Username = "sean";
        private const string ListID = "55";
        private const uint TraktListID = 55;
        private const string ListSlug = "incredible-thoughts";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ListItemsCount = 5U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const TraktListItemType ListItemType = TraktListItemType.Movie;

        [Theory]
        [InlineData(null, null, null, $"users/{Username}/lists/{ListID}/items?page=2&limit=4")]
        [InlineData(ListItemType, null, null, $"users/{Username}/lists/{ListID}/items/movie?page=2&limit=4")]
        [InlineData(null, "batman", null, $"users/{Username}/lists/{ListID}/items?query=batman&page=2&limit=4")]
        [InlineData(null, null, ExtendedInfo, $"users/{Username}/lists/{ListID}/items?extended=full&page=2&limit=4")]
        [InlineData(ListItemType, "batman", ExtendedInfo, $"users/{Username}/lists/{ListID}/items/movie?query=batman&extended=full&page=2&limit=4")]
        public async Task TestGetPersonalListItemsWithID(TraktListItemType? listItemType, string? query, TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, Page, 1, Limit, 10);

            TraktFilter? filter = query is not null ? new TraktFilter { Query = query } : null;

            TraktPagedResponse<TraktListItem> response = await client.Users.GetPersonalListItemsAsync(Username, TraktListID, listItemType, filter, extendedInfo, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{ListSlug}/items?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktListItem> response = await client.Users.GetPersonalListItemsAsync(Username, ListSlug, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonalListItemsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktListItem> response = await client.Users.GetPersonalListItemsAsync(Username, listIds, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithList()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID
                }
            };

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonalListItemsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktListItem> response = await client.Users.GetPersonalListItemsAsync(Username, list, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPersonalListItemsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, TraktListID, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"users/me/lists/{ListID}/items?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync("me", TraktListID, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, TraktListID, ListItemType, extendedInfo: ExtendedInfo, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemsCount);
            response.ItemCount.ShouldBe(ListItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithIDPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, TraktListID, ListItemType, extendedInfo: ExtendedInfo, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemsCount);
            response.ItemCount.ShouldBe(ListItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithIDPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, TraktListID, ListItemType, extendedInfo: ExtendedInfo, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemsCount);
            response.ItemCount.ShouldBe(ListItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithIDPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, TraktListID, ListItemType, extendedInfo: ExtendedInfo, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemsCount);
            response.ItemCount.ShouldBe(ListItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, TraktListID, ListItemType, extendedInfo: ExtendedInfo, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemsCount);
            response.ItemCount.ShouldBe(ListItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListItemsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemsCount);
            response.ItemCount.ShouldBe(ListItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, TraktListID, ListItemType, extendedInfo: ExtendedInfo, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemsCount);
            response.ItemCount.ShouldBe(ListItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListItemsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemsCount);
            response.ItemCount.ShouldBe(ListItemsCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetPersonalListItemsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonalListItemsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListItem>>> act = () => client.Users.GetPersonalListItemsAsync(Username, TraktListID, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonalListItemsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktListItem>>> act = () => client.Users.GetPersonalListItemsAsync(Username, default(TraktListIDs)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetPersonalListItemsAsync(Username, default(TraktList)!);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetPersonalListItemsAsync(Username, new TraktListIDs());
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetPersonalListItemsAsync(Username, 0);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetPersonalListItemsAsync(Username, ListID, page: null, limit: 10, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetPersonalListItemsAsync(Username, ListID, page: 1, limit: null, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
