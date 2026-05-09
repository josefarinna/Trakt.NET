using System.Net;

namespace TraktNET.ListsModule
{
    public sealed class GetTrendingListsTests
    {
        private const string GetTrendingListsUri = "lists/trending";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemCount = 2U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetTrendingLists()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient(GetTrendingListsUri, responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingListsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingListsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?page={Page}", responseContent, Page, 1, 10, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingListsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingListsWithExtendedInfoPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?extended={ExtendedInfo.ToURI()}&page={Page}", responseContent, Page, 1, 10, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingListsWithExtendedInfoLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingListsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingListsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTrendingListsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingListsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetTrendingListsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetTrendingListsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetTrendingListsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetTrendingListsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(null, 2, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetTrendingListsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

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
        public async Task TestGetTrendingListsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listpopularortrending.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingListsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktTrendingList> response = await client.Lists.GetTrendingListsAsync(null, 1, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetTrendingListsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemCount);

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
        public async Task TestGetTrendingListsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetTrendingListsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktTrendingList>>> act = () => client.Lists.GetTrendingListsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
