using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetRecentlyUpdatedShowsTests
    {
        private const string GetRecentlyUpdatedShowsUri = "shows/updates";
        private static readonly DateTime StartDate = new(2026, 2, 22, 0, 0, 0, DateTimeKind.Utc);
        private const string StartDateValue = "2026-02-22T00:00:00Z";
        private const uint ListItemCount = 2U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetRecentlyUpdatedShows()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedShowsUri, responseContent, 1, 1, 10, ListItemCount);
            
            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsWithStartDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}/{StartDateValue}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, StartDate, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?page={Page}", responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?extended={ExtendedInfo.ToURI()}&page={Page}", responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(ExtendedInfo, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(ExtendedInfo, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(ExtendedInfo, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}/{StartDateValue}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(ExtendedInfo, StartDate, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetRecentlyUpdatedShowsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, 2, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetRecentlyUpdatedShowsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

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
        public async Task TestGetRecentlyUpdatedShowsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\updatedshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedShowsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktUpdatedShow> response = await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, 1, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetRecentlyUpdatedShowsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

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
        public async Task TestGetRecentlyUpdatedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedShowsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
