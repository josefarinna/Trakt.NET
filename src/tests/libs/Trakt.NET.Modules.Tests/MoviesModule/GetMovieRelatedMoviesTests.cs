using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieRelatedMoviesTests
    {
        private const string GetMovieRelatedMoviesUriPrefix = "movies";
        private const string GetMovieRelatedMoviesUriSuffix = "related";
        private const string GetMovieRelatedMoviesUriWithSlug = GetMovieRelatedMoviesUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMovieRelatedMoviesUriSuffix;
        private static readonly string GetMovieRelatedMoviesUri = $"{GetMovieRelatedMoviesUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMovieRelatedMoviesUriSuffix}";

        [Theory]
        [InlineData(null, null, null, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, null, null, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?extended=full", "Movies\\movierelatedmovies.json")]
        [InlineData(null, true, null, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?personalized=true", "Movies\\movierelatedmovies.json")]
        [InlineData(null, false, null, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?personalized=false", "Movies\\movierelatedmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?page=4", "Movies\\movierelatedmovies.json")]
        [InlineData(null, null, null, 20U, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, true, 4U, 20U, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?personalized=true&extended=full&page=4&limit=20", "Movies\\movierelatedmovies.json")]
        public async Task TestGetMovieRelatedMoviesWithID(TraktExtendedInfo? extendedInfo, bool? personalized, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.TraktMovieID, extendedInfo, personalized, page, limit, TestContext.Current.CancellationToken);

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

            IReadOnlyList<TraktMovie> relatedMovies = response.Content;

            TraktMovie relatedMovie = relatedMovies[0];

            relatedMovie.Title.ShouldBe("Avengers: Endgame");
            relatedMovie.Year.ShouldBe(2019U);
            relatedMovie.IDs!.Slug.ShouldBe("avengers-endgame-2019");

            relatedMovie = relatedMovies[1];

            relatedMovie.Title.ShouldBe("Thor: Ragnarok");
            relatedMovie.Year.ShouldBe(2017U);
            relatedMovie.IDs!.Slug.ShouldBe("thor-ragnarok-2017");
        }

        [Theory]
        [InlineData(null, null, null, null, GetMovieRelatedMoviesUriWithSlug, "Movies\\movierelatedmovies.json")]
        public async Task TestGetMovieRelatedMoviesWithSlug(TraktExtendedInfo? extendedInfo, bool? personalized, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieSlug, extendedInfo, personalized, page, limit, TestContext.Current.CancellationToken);

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

            IReadOnlyList<TraktMovie> relatedMovies = response.Content;

            TraktMovie relatedMovie = relatedMovies[0];

            relatedMovie.Title.ShouldBe("Avengers: Endgame");
            relatedMovie.Year.ShouldBe(2019U);
            relatedMovie.IDs!.Slug.ShouldBe("avengers-endgame-2019");

            relatedMovie = relatedMovies[1];

            relatedMovie.Title.ShouldBe("Thor: Ragnarok");
            relatedMovie.Year.ShouldBe(2017U);
            relatedMovie.IDs!.Slug.ShouldBe("thor-ragnarok-2017");
        }

        [Theory]
        [InlineData(null, null, null, null, GetMovieRelatedMoviesUriWithSlug, "Movies\\movierelatedmovies.json")]
        public async Task TestGetMovieRelatedMoviesWithIDs(TraktExtendedInfo? extendedInfo, bool? personalized, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieIDs, extendedInfo, personalized, page, limit, TestContext.Current.CancellationToken);

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

            IReadOnlyList<TraktMovie> relatedMovies = response.Content;

            TraktMovie relatedMovie = relatedMovies[0];

            relatedMovie.Title.ShouldBe("Avengers: Endgame");
            relatedMovie.Year.ShouldBe(2019U);
            relatedMovie.IDs!.Slug.ShouldBe("avengers-endgame-2019");

            relatedMovie = relatedMovies[1];

            relatedMovie.Title.ShouldBe("Thor: Ragnarok");
            relatedMovie.Year.ShouldBe(2017U);
            relatedMovie.IDs!.Slug.ShouldBe("thor-ragnarok-2017");
        }

        [Fact]
        public async Task TestGetMovieRelatedMoviesWithIDPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.TraktMovieID, page: 2, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMovieRelatedMoviesWithIDPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.TraktMovieID, page: 1, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMovieRelatedMoviesWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.TraktMovieID, page: 2, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMovieRelatedMoviesWithIDPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.TraktMovieID, page: 1, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetMovieRelatedMoviesWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.TraktMovieID, page: 2, cancellationToken: TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieRelatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMovieRelatedMoviesWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.TraktMovieID, page: 1, cancellationToken: TestContext.Current.CancellationToken);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieRelatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieRelatedMoviesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRelatedMoviesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktMovie>>> act = () => client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.TraktMovieID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieRelatedMoviesWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRelatedMoviesUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktPagedResponse<TraktMovie>>> act = () => client.Movies.GetMovieRelatedMoviesAsync(default(TraktMovieIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieRelatedMoviesAsync(movieIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
