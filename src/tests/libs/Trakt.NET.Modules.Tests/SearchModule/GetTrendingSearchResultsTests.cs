using System.Net;

namespace TraktNET.SearchModule
{
    public sealed class GetTrendingSearchResultsTests
    {
        private readonly string GetTrendingSearchUri = $"search/recent_by_id/global/{SearchType.ToURI()}";
        private const TraktSearchRecentType SearchType = TraktSearchRecentType.Movie;
        private const string Query = "batman";
        private const uint SearchResultItemCount = 2U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetTrendingSearchResults()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(GetTrendingSearchUri, responseContent, 1, 1, 10, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            
            var firstResult = response.Content[0];
            firstResult.ShouldNotBeNull();
            firstResult.Id.ShouldBe(1U);
            firstResult.Count.ShouldBe(120U);
            firstResult.Type.ShouldBe(TraktSearchResultType.Movie);
            firstResult.Movie.ShouldNotBeNull();
            firstResult.Movie!.Title.ShouldBe("Batman Begins");

            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsWithQuery()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingSearchUri}?query={Query}", responseContent, 1, 1, 10, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, Query, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingSearchUri}?extended={ExtendedInfo.ToURI()}", responseContent, 1, 1, 10, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingSearchUri}?page={Page}", responseContent, Page, 1, 10, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingSearchUri}?limit={Limit}", responseContent, 1, 1, Limit, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsWithAllParameters()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTrendingSearchUri}?query={Query}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, Query, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTrendingSearchUri}?query={Query}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, Query, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTrendingSearchUri}?query={Query}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, Query, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTrendingSearchUri}?query={Query}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, Query, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTrendingSearchUri}?query={Query}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, Query, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTrendingSearchUri}?query={Query}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, Query, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetTrendingSearchUri}?query={Query}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, SearchResultItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTrendingSearchUri}?query={Query}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response =
                await client.Search.GetTrendingSearchResultsAsync(SearchType, Query, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetTrendingSearchUri}?query={Query}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, SearchResultItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            response.ItemCount.ShouldBe(SearchResultItemCount);
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
        public async Task TestGetTrendingSearchResultsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetTrendingSearchUri, statusCode);

            Func<Task<TraktPagedResponse<TraktTrendingSearchResult>>> act = () => client.Search.GetTrendingSearchResultsAsync(SearchType, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetTrendingSearchResultsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetTrendingSearchUri, "{}");

            Func<Task<TraktPagedResponse<TraktTrendingSearchResult>>> act = () => client.Search.GetTrendingSearchResultsAsync(TraktSearchRecentType.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetTrendingSearchResultsAsync(TraktSearchRecentType.List, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
