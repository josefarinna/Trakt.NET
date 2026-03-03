using System.Net;

namespace TraktNET.SearchModule
{
    public sealed class SearchTests
    {
        private const string SearchTextQueryUri = "search/movie";

        [Theory]
        [InlineData(null, null, null, null, null, "search/movie?query=avengers", "Searchs\\searchresult.json")]
        [InlineData(TraktSearchField.Title, null, null, null, null, "search/movie?query=avengers&fields=title", "Searchs\\searchresult.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, 1U, 10U, "search/movie?query=avengers&extended=full&page=1&limit=10", "Searchs\\searchresult.json")]
        public async Task TestGetTextQueryResults(TraktSearchField? searchFields, TraktFilter? filter,
            TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string searchQuery = "avengers";
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Movie, searchQuery,
                                                             searchFields, filter, extendedInfo,
                                                             page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            List<TraktSearchResult> results = [.. response.Content!];
            results.Count.ShouldBe(10);

            // Validar el primer resultado (Avengers: Endgame)
            TraktSearchResult firstResult = results[0];
            firstResult.Type.ShouldBe(TraktSearchResultType.Movie);
            firstResult.Score.ShouldBe(578730123365189800f);

            firstResult.Movie.ShouldNotBeNull();
            firstResult.Movie!.Title.ShouldBe("Avengers: Endgame");
            firstResult.Movie.Year.ShouldBe(2019U);
            firstResult.Movie.IDs!.Trakt.ShouldBe(191798U);
            firstResult.Movie.IDs!.IMDB.ShouldBe("tt4154796");
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithMultipleTypes()
        {
            // Ejemplo combinando tipos: Movie | Show
            TraktSearchResultType types = TraktSearchResultType.Movie;
            string requestUri = "search/movie?query=avengers";

            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(types, "avengers", cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBe(true);
            response.Content![0].Movie!.Title.ShouldBe("Avengers: Endgame");
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetTextQueryResultsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient("search/movie?query=avengers", statusCode);

            try
            {
                await client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Movie, "avengers", cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
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
