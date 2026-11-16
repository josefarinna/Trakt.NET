using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMostWatchedMoviesTests
    {
        private const string GetMostWatchedMoviesUri = "movies/watched";

        [Theory]
        [InlineData(null, null, null, null, GetMostWatchedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMostWatchedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostWatchedMoviesUri}?extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMostWatchedMoviesUri}?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostWatchedMoviesUri}?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, GetMostWatchedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, null, $"{GetMostWatchedMoviesUri}/monthly", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMostWatchedMoviesUri}?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, 20U, $"{GetMostWatchedMoviesUri}/monthly?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedMoviesUri}?extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedMoviesUri}/monthly?extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        public async Task TestGetMostWatchedMovies(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

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

            IReadOnlyList<TraktMostWatchedMovie> watchedMovies = response.Content;

            TraktMostWatchedMovie watchedMovie = watchedMovies[0];

            watchedMovie.Title.ShouldBe("The Hunt for Red October");
            watchedMovie.Year.ShouldBe(1990U);
            watchedMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");

            watchedMovie = watchedMovies[1];

            watchedMovie.Title.ShouldBe("Rebel Ridge");
            watchedMovie.Year.ShouldBe(2024U);
            watchedMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, null, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, 20U, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        public async Task TestGetMostWatchedMoviesWithFilter(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, TestConstants.Movies.Filter, page, limit, TestContext.Current.CancellationToken);

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

            IReadOnlyList<TraktMostWatchedMovie> watchedMovies = response.Content;

            TraktMostWatchedMovie watchedMovie = watchedMovies[0];

            watchedMovie.Title.ShouldBe("The Hunt for Red October");
            watchedMovie.Year.ShouldBe(1990U);
            watchedMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");

            watchedMovie = watchedMovies[1];

            watchedMovie.Title.ShouldBe("Rebel Ridge");
            watchedMovie.Year.ShouldBe(2024U);
            watchedMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
        }

        [Fact]
        public async Task TestGetMostWatchedMoviesPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedMoviesPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostWatchedMoviesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMostWatchedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMostWatchedMoviesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMostWatchedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMostWatchedMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostWatchedMoviesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktMostWatchedMovie>>> act = () => client.Movies.GetMostWatchedMoviesAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }
    }
}
