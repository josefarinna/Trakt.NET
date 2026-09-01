using System.Net;

namespace TraktNET.SmartListsModule
{
    public sealed class GetSmartListItemsTests
    {
        private const string ListSlug = "sci-fi-movies";
        private const uint TraktListID = 123456U;
        private const string ListID = "123456";
        private const uint ListItemCount = 5;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private readonly string GetSmartListItemsUri = $"smart-lists/{ListSlug}/items";

        [Fact]
        public async Task TestGetSmartListItems()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSmartListItemsUri, responseContent);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListItemsWithFilterAndQuery()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            var filter = new TraktFilter
            {
                Genres = ["science-fiction"],
                IgnoreWatched = true
            };

            string expectedUri = $"{GetSmartListItemsUri}?genres=science-fiction&ignore_watched=true&watchnow=netflix";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, filter, watchnow: "netflix", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListItemsWithTraktIDPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"smart-lists/{ListID}/items?page={Page}&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                TraktListID, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSmartListItemsWithListIDsTraktIDPageAndLimit()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"smart-lists/{ListID}/items?page={Page}&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                listIDs, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSmartListItemsWithListIDsSlugPageAndLimit()
        {
            var listIDs = new TraktListIDs
            {
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?page={Page}&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                listIDs, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSmartListItemsWithListIDsPageAndLimit()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?page={Page}&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                listIDs, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSmartListItemsWithListPageAndLimit()
        {
            var list = new TraktSmartList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?page={Page}&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                list, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSmartListItemsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?page={Page}&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSmartListItemsWithExtendedInfoPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, extendedInfo: ExtendedInfo, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSmartListItemsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            var filter = new TraktFilter
            {
                Genres = ["science-fiction"],
                IgnoreWatched = true
            };

            string expectedUri = $"{GetSmartListItemsUri}?genres=science-fiction&ignore_watched=true&watchnow=netflix&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, filter, watchnow: "netflix", extendedInfo: ExtendedInfo, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSmartListItemsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 2, 5, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, extendedInfo: ExtendedInfo, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSmartListItemsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, extendedInfo: ExtendedInfo, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSmartListItemsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, extendedInfo: ExtendedInfo, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSmartListItemsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, extendedInfo: ExtendedInfo, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSmartListItemsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, extendedInfo: ExtendedInfo, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            string prevExpectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}";
            ModuleTestUtility.SetClient(client, prevExpectedUri, responseContent, 1, 2, Limit, ListItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSmartListItemsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                ListSlug, extendedInfo: ExtendedInfo, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            string nextExpectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}";
            ModuleTestUtility.SetClient(client, nextExpectedUri, responseContent, 2, 2, Limit, ListItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiListNotFoundException))]
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
        public async Task TestGetSmartListItemsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListItemsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListItem>>> act = () => client.SmartLists.GetSmartListItemsAsync(
                ListSlug, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListItemsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListItemsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktListItem>>> act = () => client.SmartLists.GetSmartListItemsAsync(
                default(TraktListIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.SmartLists.GetSmartListItemsAsync(
                default(TraktSmartList)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.SmartLists.GetSmartListItemsAsync(
                new TraktListIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.SmartLists.GetSmartListItemsAsync(
                0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.SmartLists.GetSmartListItemsAsync(
                string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.SmartLists.GetSmartListItemsAsync(
                "sci fi movies", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
