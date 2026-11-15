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

        [Theory]
        [InlineData(null, null, null, null, "search/recent_by_id/global/movies")]
        [InlineData(Query, null, null, null, $"search/recent_by_id/global/movies?query={Query}")]
        [InlineData(null, ExtendedInfo, null, null, "search/recent_by_id/global/movies?extended=full")]
        [InlineData(null, null, Page, null, "search/recent_by_id/global/movies?page=2")]
        [InlineData(null, null, null, Limit, "search/recent_by_id/global/movies?limit=4")]
        [InlineData(Query, ExtendedInfo, Page, Limit, $"search/recent_by_id/global/movies?query={Query}&extended=full&page=2&limit=4")]
        public async Task TestGetTrendingSearchResults(string? searchQuery, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\trendingsearchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, SearchResultItemCount);

            TraktPagedResponse<TraktTrendingSearchResult> response = await client.Search.GetTrendingSearchResultsAsync(SearchType, searchQuery, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)SearchResultItemCount);
            var firstResult = response.Content[0];
            firstResult.ShouldNotBeNull();
            firstResult.ID.ShouldBe(1U);
            firstResult.Count.ShouldBe(120U);
            firstResult.Type.ShouldBe(TraktSearchResultType.Movie);
            firstResult.Movie.ShouldNotBeNull();
            firstResult.Movie!.Title.ShouldBe("Batman Begins");
            response.ItemCount.ShouldBe(SearchResultItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
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
