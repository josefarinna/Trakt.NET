using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetPopularMoviesTests
    {
        private const string GetPopularMoviesUri = "movies/popular";

        [Theory]
        [InlineData(null, null, null, GetPopularMoviesUri, "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetPopularMoviesUri, "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetPopularMoviesUri}?extended=full", "Movies\\movies.json")]
        [InlineData(null, 4U, null, $"{GetPopularMoviesUri}?page=4", "Movies\\movies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetPopularMoviesUri}?limit=20", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetPopularMoviesUri}?page=4&limit=20", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetPopularMoviesUri}?extended=full&page=4&limit=20", "Movies\\movies.json")]
        public async Task TestGetPopularMovies(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktMovie> popularMovies = response.Content;

            TraktMovie popularMovie = popularMovies[0];

            popularMovie.Title.ShouldBe("Deadpool");
            popularMovie.Year.ShouldBe(2016U);
            popularMovie.IDs!.Slug.ShouldBe("deadpool-2016");

            popularMovie = popularMovies[1];

            popularMovie.Title.ShouldBe("Guardians of the Galaxy");
            popularMovie.Year.ShouldBe(2014U);
            popularMovie.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-2014");
        }

        [Theory]
        [InlineData(null, null, null, $"{GetPopularMoviesUri}?genres=action,drama&years=2024", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{GetPopularMoviesUri}?genres=action,drama&years=2024", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\movies.json")]
        [InlineData(null, 4U, null, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\movies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\movies.json")]
        public async Task TestGetPopularMoviesWithFilter(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(extendedInfo, TestConstants.Movies.Filter, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktMovie> popularMovies = response.Content;

            TraktMovie popularMovie = popularMovies[0];

            popularMovie.Title.ShouldBe("Deadpool");
            popularMovie.Year.ShouldBe(2016U);
            popularMovie.IDs!.Slug.ShouldBe("deadpool-2016");

            popularMovie = popularMovies[1];

            popularMovie.Title.ShouldBe("Guardians of the Galaxy");
            popularMovie.Year.ShouldBe(2014U);
            popularMovie.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-2014");
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(3U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetPopularMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetPopularMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetPopularMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPopularMoviesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktMovie>>> act = () => client.Movies.GetPopularMoviesAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }
    }
}
