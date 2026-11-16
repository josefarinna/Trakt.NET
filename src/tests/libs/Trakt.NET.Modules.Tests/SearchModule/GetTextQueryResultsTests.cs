using System.Net;

namespace TraktNET.SearchModule
{
    public sealed class GetTextQueryResultsTests
    {
        private const string GetTextQueryUri = $"search/movie?query={TextQuery}";
        private const string FilterQuery = "years=2011&genres=action,thriller&languages=en,de&countries=us&runtimes=70-140&ratings=70-95";
        private const string GetTextQueryUriMulitpleTypes = $"search/movie,show?query={TextQuery}";
        private const TraktSearchResultType TextQueryTypes = TraktSearchResultType.Movie | TraktSearchResultType.Show;
        private const string TextQuery = "batman";
        private const uint TextQueryItemCount = 10U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktSearchResultType TextQueryTypeMovie = TraktSearchResultType.Movie;
        private const TraktSearchResultType TextQueryTypeShow = TraktSearchResultType.Show;
        private const TraktSearchFields TextQuerySearchFieldTitle = TraktSearchFields.Title;
        private const TraktSearchFields TextQuerySearchFieldOverview = TraktSearchFields.Overview;
        private const TraktSearchFields TextQuerySearchFields = TextQuerySearchFieldTitle | TextQuerySearchFieldOverview;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private readonly TraktFilter Filter = new()
        {
            Year = 2011U,
            Genres = ["action", "thriller"],
            Languages = ["en", "de"],
            Countries = ["us"],
            Runtimes = new Range<uint>(70, 140),
            Ratings = new Range<uint>(70, 95)
        };

        [Theory]
        [InlineData(TextQueryTypeMovie, null, null, null, null, GetTextQueryUri)]
        [InlineData(TextQueryTypes, null, null, null, null, GetTextQueryUriMulitpleTypes)]
        [InlineData(TextQueryTypeMovie, TextQuerySearchFieldTitle, null, null, null, $"{GetTextQueryUri}&fields=title")]
        [InlineData(TextQueryTypeMovie, TextQuerySearchFields, null, null, null, $"{GetTextQueryUri}&fields=title,overview")]
        [InlineData(TextQueryTypeMovie, null, ExtendedInfo, null, null, $"{GetTextQueryUri}&extended=full")]
        [InlineData(TextQueryTypeMovie, null, null, Page, null, $"{GetTextQueryUri}&page=2")]
        [InlineData(TextQueryTypeMovie, null, null, null, Limit, $"{GetTextQueryUri}&limit=4")]
        [InlineData(TextQueryTypes, TextQuerySearchFields, ExtendedInfo, Page, Limit, $"{GetTextQueryUriMulitpleTypes}&fields=title,overview&extended=full&page=2&limit=4")]
        public async Task TestGetTextQueryResults(TraktSearchResultType searchResultTypes, TraktSearchFields? searchFields, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page ?? 1U, 1, limit ?? 10U, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(searchResultTypes, TextQuery, searchFields, null, extendedInfo, page, limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetTextQueryResultsWithFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTextQueryUri}&{Filter}",
                                                           responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null, Filter, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetTextQueryResultsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetTextQueryResultsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetTextQueryResultsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetTextQueryResultsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetTextQueryResultsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

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
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
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
        public async Task TestGetTextQueryResultsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

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
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
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
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetTextQueryResultsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient("search/movie?query=avengers", statusCode);

            Func<Task<TraktPagedResponse<TraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Movie, "avengers", cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetTextQueryResultsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient("search/movie?query=avengers", "{}");

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktSearchResult>>> act =
                () => client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Movie, null, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Movie, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
