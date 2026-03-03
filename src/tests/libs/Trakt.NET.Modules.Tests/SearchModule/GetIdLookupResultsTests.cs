using System.Net;

namespace TraktNET.SearchModule
{
    public sealed class GetIdLookupResultsTests
    {
        private const string LookupUri = "search";

        [Theory]
        [InlineData(TraktSearchIDType.Trakt, "191798", null, null, null, "search/trakt/191798", "Searchs\\searchresult.json")]
        [InlineData(TraktSearchIDType.ImDB, "tt4154796", TraktSearchResultType.Movie, 1U, 10U, "search/imdb/tt4154796?type=movie&page=1&limit=10", "Searchs\\searchresult.json")]
        [InlineData(TraktSearchIDType.TmDB, "299534", null, null, null, "search/tmdb/299534", "Searchs\\searchresult.json")]
        public async Task TestGetIdLookupResults(TraktSearchIDType searchIdType, string lookupId,
            TraktSearchResultType? searchResultTypes, uint? page, uint? limit,
            string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(searchIdType, lookupId,
                                                           searchResultTypes, null,
                                                           page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);

            TraktSearchResult firstResult = response.Content![0];
            firstResult.Movie.ShouldNotBeNull();
            firstResult.Movie!.Title.ShouldBe("Avengers: Endgame");
            firstResult.Movie.IDs!.Trakt.ShouldBe(191798U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithMultipleResultTypes()
        {
            TraktSearchIDType idType = TraktSearchIDType.Trakt;
            string lookupId = "191798";
            TraktSearchResultType resultTypes = TraktSearchResultType.Movie;
            string requestUri = $"search/trakt/{lookupId}?type=movie";

            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(idType, lookupId, resultTypes, cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBe(true);
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiException))]
        public async Task TestGetIdLookupResultsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient("search/trakt/123", statusCode);

            try
            {
                await client.Search.GetIdLookupResultsAsync(TraktSearchIDType.Trakt, "123", cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType || exception.GetType().IsSubclassOf(exceptionType)).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetIdLookupResultsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient("search/trakt/123", "{}");

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktSearchResult>>> act =
                () => client.Search.GetIdLookupResultsAsync(TraktSearchIDType.Trakt, null, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetIdLookupResultsAsync(TraktSearchIDType.Trakt, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetIdLookupResultsAsync(TraktSearchIDType.Trakt, "   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
