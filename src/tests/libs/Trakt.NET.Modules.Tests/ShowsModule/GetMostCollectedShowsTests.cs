using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetMostCollectedShowsTests
    {
        private const string GetMostCollectedShowsUri = "shows/collected";
        private const uint ListItemCount = 2U;
        private const uint Page = 4U;
        private const uint Limit = 20U;
        private const TraktTimePeriod Period = TraktTimePeriod.Monthly;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetMostCollectedShows()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient(GetMostCollectedShowsUri, responseContent, 1, 1, 10, ListItemCount);
            
            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithPeriod()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}/{Period.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(Period, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?genres=fantasy,drama&years=2011", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(filter: TestConstants.Shows.Filter, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?page={Page}", responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(page: Page, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?extended={ExtendedInfo.ToURI()}&page={Page}", responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(null, ExtendedInfo, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(null, ExtendedInfo, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(null, ExtendedInfo, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithPeriodAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}/{Period.ToURI()}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(Period, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithPeriodAndFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}/{Period.ToURI()}?genres=fantasy,drama&years=2011", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(Period, null, TestConstants.Shows.Filter, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithPeriodAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}/{Period.ToURI()}?page={Page}", responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(Period, null, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsWithPeriodAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}/{Period.ToURI()}?limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(Period, null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}/{Period.ToURI()}?genres=fantasy,drama&years=2011&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(Period, ExtendedInfo, TestConstants.Shows.Filter, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostCollectedShowsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMostCollectedShowsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

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
        public async Task TestGetMostCollectedShowsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostCollectedShowsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktMostCollectedShow> response = await client.Shows.GetMostCollectedShowsAsync(null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMostCollectedShowsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

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
        public async Task TestGetMostCollectedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostCollectedShowsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktMostCollectedShow>>> act = () => client.Shows.GetMostCollectedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
