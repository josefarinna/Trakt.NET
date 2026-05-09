using System.Net;

namespace TraktNET.ListsModule
{
    public sealed class GetListItemsTests
    {
        private const string GetListItemsUri = $"lists/{ListID}/items";
        private const string ListID = "1248149";
        private const uint TraktListID = 1248149U;
        private const string ListSlug = "incredible-thoughts";
        private const uint ListItemCount = 5;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktListItemType ListItemType = TraktListItemType.Movie;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetListItemsWithTraktIDPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListItemsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.Lists.GetListItemsAsync(TraktListID, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsWithListIDsTraktIDPageAndLimit()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListItemsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.Lists.GetListItemsAsync(listIDs, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsWithListIDsSlugPageAndLimit()
        {
            var listIDs = new TraktListIDs
            {
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}/items?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.Lists.GetListItemsAsync(listIDs, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsWithListIDsPageAndLimit()
        {
            var listIDs = new TraktListIDs
            {
                Trakt = TraktListID,
                Slug = ListSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}/items?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.Lists.GetListItemsAsync(listIDs, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsWithListPageAndLimit()
        {
            var list = new TraktList
            {
                IDs = new TraktListIDs
                {
                    Trakt = TraktListID,
                    Slug = ListSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient($"lists/{ListSlug}/items?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.Lists.GetListItemsAsync(list, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListItemsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response = await client.Lists.GetListItemsAsync(ListID, null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsWithTypePageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetListItemsUri}/{ListItemType.ToURI()}" +
                $"?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Lists.GetListItemsAsync(ListID, ListItemType, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsWithExtendedInfoPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListItemsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Lists.GetListItemsAsync(ListID, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Lists.GetListItemsAsync(ListID, ListItemType, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Lists.GetListItemsAsync(ListID, ListItemType, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Lists.GetListItemsAsync(ListID, ListItemType, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Lists.GetListItemsAsync(ListID, ListItemType, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Lists.GetListItemsAsync(ListID, ListItemType, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetListItemsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Lists.GetListItemsAsync(ListID, ListItemType, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client,
                $"{GetListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListItemCount);

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
        public async Task TestGetListItemsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitems.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktListItem> response =
                await client.Lists.GetListItemsAsync(ListID, ListItemType, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client,
                $"{GetListItemsUri}/{ListItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ListItemCount);

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
        public async Task TestGetListItemsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListItemsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktListItem>>> act = () => client.Lists.GetListItemsAsync(ListID, null, null, 1, 10, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetListItemsThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetListItemsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktListItem>>> act = () => client.Lists.GetListItemsAsync(default(TraktListIDs)!, page: 1, limit: 10, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListItemsAsync(default(TraktList)!, page: 1, limit: 10, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListItemsAsync(new TraktListIDs(), page: 1, limit: 10, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListItemsAsync(0);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListItemsAsync(ListID, null, null, null, 10, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListItemsAsync(ListID, null, null, 1, null, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
        }
    }
}
