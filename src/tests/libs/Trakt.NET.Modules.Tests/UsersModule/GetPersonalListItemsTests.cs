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

        [Fact]
        public async Task TestGetPersonalListItems()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonalListItemsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonalListItemsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);
            
            TraktPagedResponse<TraktListItem> response = await client.Users.GetPersonalListItemsAsync(Username, TraktListID, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithListIdsTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonalListItemsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);
            
            TraktPagedResponse<TraktListItem> response = await client.Users.GetPersonalListItemsAsync(Username, listIds, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithListIdsSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            var listIds = new TraktListIDs
            {
                Slug = ListSlug
            };

            TraktClient client = ModuleTestUtility.GetClient($"users/{Username}/lists/{ListSlug}/items?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktListItem> response = await client.Users.GetPersonalListItemsAsync(Username, listIds, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithListIds()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            var listIds = new TraktListIDs
            {
                Trakt = TraktListID
            };

            TraktClient client = ModuleTestUtility.GetClient($"{GetPersonalListItemsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktListItem> response = await client.Users.GetPersonalListItemsAsync(Username, listIds, null, null, Page, Limit, TestContext.Current.CancellationToken);

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

            TraktPagedResponse<TraktListItem> response = await client.Users.GetPersonalListItemsAsync(Username, list, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
            //client.Configuration.ForceAuthorization = true;

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
                await client.Users.GetPersonalListItemsAsync("me", ListID, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, ListItemType, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, ListItemType, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(5);
        }

        [Fact]
        public async Task TestGetPersonalListItemsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, ListItemType, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetPersonalListItemsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, ListItemType, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetPersonalListItemsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, ListItemType, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetPersonalListItemsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, ListItemType, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetPersonalListItemsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, ListItemType, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetPersonalListItemsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetPersonalListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListItemsCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Users.GetPersonalListItemsAsync(Username, ListID, ListItemType, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetPersonalListItemsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPersonalListItemsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListItem>>> act = () => client.Users.GetPersonalListItemsAsync(Username, ListID, null, null, Page, Limit, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetPersonalListItemsThrowsArgumentExceptions()
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
        }
    }
}
