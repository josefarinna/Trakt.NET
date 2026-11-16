using System.Net;

namespace TraktNET.SearchModule
{
    public sealed class GetExactTextQueryResultsTests
    {
        private readonly string GetExactTextQueryUri = $"search/{TextQueryTypeMovie.ToURI()}/exact?query={TextQuery}";
        private readonly string GetExactTextQueryUriMultipleTypes = $"search/{TextQueryTypeMovie.ToURI()},{TextQueryTypeShow.ToURI()}/exact?query={TextQuery}";
        private const TraktSearchResultType TextQueryTypes = TraktSearchResultType.Movie | TraktSearchResultType.Show;
        private const string TextQuery = "batman";
        private const uint TextQueryItemCount = 10U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktSearchResultType TextQueryTypeMovie = TraktSearchResultType.Movie;
        private const TraktSearchResultType TextQueryTypeShow = TraktSearchResultType.Show;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, $"search/movie/exact?query={TextQuery}")]
        [InlineData(ExtendedInfo, null, null, $"search/movie/exact?query={TextQuery}&extended=full")]
        [InlineData(null, Page, null, $"search/movie/exact?query={TextQuery}&page=2")]
        [InlineData(null, null, Limit, $"search/movie/exact?query={TextQuery}&limit=4")]
        [InlineData(ExtendedInfo, Page, Limit, $"search/movie/exact?query={TextQuery}&extended=full&page=2&limit=4")]
        public async Task TestGetExactTextQueryResults(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response = await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsMultipleTypes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(GetExactTextQueryUriMultipleTypes, responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypes, TextQuery, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetExactTextQueryUri}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetExactTextQueryResultsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetExactTextQueryUri, statusCode);

            Func<Task<TraktPagedResponse<TraktSearchResult>>> act = () => client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetExactTextQueryResultsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetExactTextQueryUri, "{}");

            Func<Task<TraktPagedResponse<TraktSearchResult>>> act = () => client.Search.GetExactTextQueryResultsAsync(TraktSearchResultType.Unspecified, TextQuery, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, null!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetExactTextQueryResultsAsync(TextQueryTypeMovie, "  ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
