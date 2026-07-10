using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetMostWatchedShowsTests
    {
        private const string GetMostWatchedShowsUri = "shows/watched";
        private const uint ListItemCount = 2U;
        private const uint Page = 4U;
        private const uint Limit = 20U;
        private const TraktTimePeriod Period = TraktTimePeriod.Monthly;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetMostWatchedShows()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");

            TraktClient client = ModuleTestUtility.GetClient(GetMostWatchedShowsUri, responseContent, 1, 1, 10, ListItemCount);
            
            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithPeriod()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}/{Period.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(Period, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?genres=fantasy,drama&years=2011", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(filter: TestConstants.Shows.Filter, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page={Page}", responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(page: Page, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?extended={ExtendedInfo.ToURI()}&page={Page}", responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(null, ExtendedInfo, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(null, ExtendedInfo, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(null, ExtendedInfo, null, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithPeriodAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}/{Period.ToURI()}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(Period, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithPeriodAndFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}/{Period.ToURI()}?genres=fantasy,drama&years=2011", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(Period, null, TestConstants.Shows.Filter, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithPeriodAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}/{Period.ToURI()}?page={Page}", responseContent, Page, 1, 10, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(Period, null, null, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsWithPeriodAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}/{Period.ToURI()}?limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(Period, null, null, null, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}/{Period.ToURI()}?genres=fantasy,drama&years=2011&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(Period, ExtendedInfo, TestConstants.Shows.Filter, Page, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedShowsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(null, null, null, 2, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMostWatchedShowsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

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
        public async Task TestGetMostWatchedShowsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\mostpwcshows_minimal.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedShowsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktMostWatchedShow> response = await client.Shows.GetMostWatchedShowsAsync(null, null, null, 1, Limit, TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMostWatchedShowsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

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
        public async Task TestGetMostWatchedShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostWatchedShowsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktMostWatchedShow>>> act = () => client.Shows.GetMostWatchedShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
