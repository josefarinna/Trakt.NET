using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMostAnticipatedMoviesTests
    {
        private const string GetMostAnticipatedMoviesUri = "movies/anticipated";

        [Theory]
        [InlineData(null, null, null, GetMostAnticipatedMoviesUri, "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetMostAnticipatedMoviesUri, "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetMostAnticipatedMoviesUri}?extended=full", "Movies\\mostanticipatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetMostAnticipatedMoviesUri}?page=4", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetMostAnticipatedMoviesUri}?limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetMostAnticipatedMoviesUri}?page=4&limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetMostAnticipatedMoviesUri}?extended=full&page=4&limit=20", "Movies\\mostanticipatedmovies.json")]
        public async Task TestGetMostAnticipatedMovies(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, null, page, limit, TestContext.Current.CancellationToken);

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

            IReadOnlyList<TraktMostAnticipatedMovie> anticipatedMovies = response.Content;

            TraktMostAnticipatedMovie anticipatedMovie = anticipatedMovies[0];

            anticipatedMovie.Title.ShouldBe("Avatar: Fire and Ash");
            anticipatedMovie.Year.ShouldBe(2025U);
            anticipatedMovie.IDs!.Slug.ShouldBe("avatar-fire-and-ash-2025");

            anticipatedMovie = anticipatedMovies[1];

            anticipatedMovie.Title.ShouldBe("Blade");
            anticipatedMovie.Year.ShouldBe(2025U);
            anticipatedMovie.IDs!.Slug.ShouldBe("blade-2025");
        }

        [Theory]
        [InlineData(null, null, null, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\mostanticipatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostanticipatedmovies.json")]
        public async Task TestGetMostAnticipatedMoviesWithFilter(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, TestConstants.Movies.Filter, page, limit, TestContext.Current.CancellationToken);

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

            IReadOnlyList<TraktMostAnticipatedMovie> anticipatedMovies = response.Content;

            TraktMostAnticipatedMovie anticipatedMovie = anticipatedMovies[0];

            anticipatedMovie.Title.ShouldBe("Avatar: Fire and Ash");
            anticipatedMovie.Year.ShouldBe(2025U);
            anticipatedMovie.IDs!.Slug.ShouldBe("avatar-fire-and-ash-2025");

            anticipatedMovie = anticipatedMovies[1];

            anticipatedMovie.Title.ShouldBe("Blade");
            anticipatedMovie.Year.ShouldBe(2025U);
            anticipatedMovie.IDs!.Slug.ShouldBe("blade-2025");
        }

        [Fact]
        public async Task TestGetMostAnticipatedMoviesPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostAnticipatedMoviesPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostAnticipatedMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostAnticipatedMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMostAnticipatedMoviesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 2, cancellationToken: TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMostAnticipatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMostAnticipatedMoviesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 1, cancellationToken: TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMostAnticipatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMostAnticipatedMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostAnticipatedMoviesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktMostAnticipatedMovie>>> act = () => client.Movies.GetMostAnticipatedMoviesAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }
    }
}
