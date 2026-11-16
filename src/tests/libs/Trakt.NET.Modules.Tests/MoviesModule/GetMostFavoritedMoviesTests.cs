using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMostFavoritedMoviesTests
    {
        private const string GetMostFavoritedMoviesUri = "movies/favorited";

        [Theory]
        [InlineData(null, null, null, null, GetMostFavoritedMoviesUri, "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMostFavoritedMoviesUri, "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostFavoritedMoviesUri}?extended=full", "Movies\\mostfavoritedmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMostFavoritedMoviesUri}?page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostFavoritedMoviesUri}?limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, GetMostFavoritedMoviesUri, "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, null, $"{GetMostFavoritedMoviesUri}/monthly", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMostFavoritedMoviesUri}?page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, 20U, $"{GetMostFavoritedMoviesUri}/monthly?page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedMoviesUri}?extended=full&page=4&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedMoviesUri}/monthly?extended=full&page=4&limit=20", "Movies\\mostfavoritedmovies.json")]
        public async Task TestGetMostFavoritedMovies(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(period, extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

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

            IReadOnlyList<TraktMostFavoritedMovie> favoritedMovies = response.Content;

            TraktMostFavoritedMovie favoritedMovie = favoritedMovies[0];

            favoritedMovie.Title.ShouldBe("Deadpool & Wolverine");
            favoritedMovie.Year.ShouldBe(2024U);
            favoritedMovie.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");

            favoritedMovie = favoritedMovies[1];

            favoritedMovie.Title.ShouldBe("A Quiet Place: Day One");
            favoritedMovie.Year.ShouldBe(2024U);
            favoritedMovie.IDs!.Slug.ShouldBe("a-quiet-place-day-one-2024");
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\mostfavoritedmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, null, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, 20U, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostfavoritedmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostfavoritedmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostFavoritedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostfavoritedmovies.json")]
        public async Task TestGetMostFavoritedMoviesWithFilter(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(period, extendedInfo, TestConstants.Movies.Filter, page, limit, TestContext.Current.CancellationToken);

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

            IReadOnlyList<TraktMostFavoritedMovie> favoritedMovies = response.Content;

            TraktMostFavoritedMovie favoritedMovie = favoritedMovies[0];

            favoritedMovie.Title.ShouldBe("Deadpool & Wolverine");
            favoritedMovie.Year.ShouldBe(2024U);
            favoritedMovie.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");

            favoritedMovie = favoritedMovies[1];

            favoritedMovie.Title.ShouldBe("A Quiet Place: Day One");
            favoritedMovie.Year.ShouldBe(2024U);
            favoritedMovie.IDs!.Slug.ShouldBe("a-quiet-place-day-one-2024");
        }

        [Fact]
        public async Task TestGetMostFavoritedMoviesPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostFavoritedMoviesPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostFavoritedMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostFavoritedMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostFavoritedMoviesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMostFavoritedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMostFavoritedMoviesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostfavoritedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostFavoritedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostFavoritedMovie> response = await client.Movies.GetMostFavoritedMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMostFavoritedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMostFavoritedMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostFavoritedMoviesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktMostFavoritedMovie>>> act = () => client.Movies.GetMostFavoritedMoviesAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }
    }
}
