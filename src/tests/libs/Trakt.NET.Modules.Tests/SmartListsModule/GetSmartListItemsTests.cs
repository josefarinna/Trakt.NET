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
        private const string GetSmartListItemsUri = $"smart-lists/{ListID}/items";
        private const string GetSmartListItemsUriWithSlug = $"smart-lists/{ListSlug}/items";

        [Theory]
        [InlineData(null, null, null, null, null, null, null, null, GetSmartListItemsUri)]
        [InlineData(TraktSmartListItemType.Movies, TraktSortBy.Rank, TraktSortHow.Descending, null, null, null, null, null, $"{GetSmartListItemsUri}/movies/rank/desc")]
        [InlineData(null, null, null, "netflix", "us", null, null, null, $"{GetSmartListItemsUri}?watchnow=netflix&watchnow_country=us")]
        [InlineData(null, null, null, null, null, ExtendedInfo, null, null, $"{GetSmartListItemsUri}?extended=full")]
        [InlineData(null, null, null, null, null, null, Page, null, $"{GetSmartListItemsUri}?page=2")]
        [InlineData(null, null, null, null, null, null, null, Limit, $"{GetSmartListItemsUri}?limit=4")]
        [InlineData(TraktSmartListItemType.Movies, TraktSortBy.Rank, TraktSortHow.Descending, "netflix", "us", ExtendedInfo, Page, Limit,
                    $"{GetSmartListItemsUri}/movies/rank/desc?watchnow=netflix&watchnow_country=us&extended=full&page=2&limit=4")]
        public async Task TestGetSmartListItemsWithID(TraktSmartListItemType? itemType, TraktSortBy? sortBy, TraktSortHow? sortHow, string? watchnow, string? watchnowCountry,
                                                      TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page ?? 1U, 1, limit ?? 10U, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                TraktListID, itemType, sortBy, sortHow, null, watchnow, watchnowCountry, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
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
                TraktListID, filter: filter, watchnow: "netflix", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListItemsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUriWithSlug}?page={Page}&limit={Limit}";

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
        public async Task TestGetSmartListItemsWithIDs()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUriWithSlug}?page={Page}&limit={Limit}";

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
        public async Task TestGetSmartListItemsWithList()
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

            string expectedUri = $"{GetSmartListItemsUriWithSlug}?page={Page}&limit={Limit}";

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
        public async Task TestGetSmartListItemsWithParentalFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            var filter = new TraktFilter
            {
                ParentalNudity = new Range<uint>(0, 1),
                ParentalIncludeUnrated = true
            };

            string expectedUri = $"{GetSmartListItemsUri}?parental_nudity=0-1&parental_include_unrated=true";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                TraktListID, filter: filter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListItemsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            var filter = new TraktFilter
            {
                Genres = ["science-fiction"],
                IgnoreWatched = true,
                ParentalViolence = new Range<uint>(1, 2)
            };

            string expectedUri = $"{GetSmartListItemsUri}/movies/rank/desc?genres=science-fiction&ignore_watched=true&parental_violence=1-2&watchnow=netflix&watchnow_country=us&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                TraktListID, TraktSmartListItemType.Movies, TraktSortBy.Rank, TraktSortHow.Descending,
                filter, "netflix", "us", ExtendedInfo, Page, Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetSmartListItemsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 2, 5, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                TraktListID, extendedInfo: ExtendedInfo, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetSmartListItemsWithIDPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                TraktListID, extendedInfo: ExtendedInfo, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetSmartListItemsWithIDPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                TraktListID, extendedInfo: ExtendedInfo, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetSmartListItemsWithIDPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                TraktListID, extendedInfo: ExtendedInfo, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetSmartListItemsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                TraktListID, extendedInfo: ExtendedInfo, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetSmartListItemsWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            string expectedUri = $"{GetSmartListItemsUri}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}";

            TraktClient client = ModuleTestUtility.GetClient(expectedUri, responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.SmartLists.GetSmartListItemsAsync(
                TraktListID, extendedInfo: ExtendedInfo, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetSmartListItemsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListItemsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListItem>>> act = () => client.SmartLists.GetSmartListItemsAsync(
                TraktListID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSmartListItemsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSmartListItemsUriWithSlug, HttpStatusCode.OK);

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
