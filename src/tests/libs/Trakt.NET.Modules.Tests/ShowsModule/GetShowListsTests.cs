using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowListsTests
    {
        private const string GetShowListsUri = $"shows/{TestConstants.Shows.ShowID}/lists";
        private const string GetShowListsUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/lists";
        private const uint ListItemCount = 2U;
        private const uint Page = 4U;
        private const uint Limit = 20U;
        private const TraktListType ListType = TraktListType.Personal;
        private const TraktListSortOrder SortOrder = TraktListSortOrder.Popular;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetShowLists()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowListsUriWithSlug, responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowListsWithType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}/{ListType.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, listType: ListType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowListsWithSortOrder()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}/{SortOrder.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, listSortOrder: SortOrder, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowListsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowListsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}?page={Page}", responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowListsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}?limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowListsWithTypeAndSortOrder()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}/{ListType.ToURI()}/{SortOrder.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, ListType, SortOrder, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetShowListsWithAllParameters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}/{ListType.ToURI()}/{SortOrder.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, ListType, SortOrder, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetShowListsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowListsUri, responseContent);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowListsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowListsUriWithSlug, responseContent);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowListsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetShowListsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetShowListsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetShowListsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetShowListsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetShowListsUriWithSlug}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

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
        public async Task TestGetShowListsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetShowListsUriWithSlug}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Shows.GetShowListsAsync(TestConstants.Shows.ShowSlug, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetShowListsUriWithSlug}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

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
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
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
        public async Task TestGetShowListsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowListsUriWithSlug, statusCode);

            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Shows.GetShowListsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowListsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showlists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowListsUriWithSlug, responseContent);

            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Shows.GetShowListsAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowListsAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
