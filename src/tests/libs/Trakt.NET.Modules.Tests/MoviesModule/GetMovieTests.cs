using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieTests
    {
        private const string GetMovieUri = "movies";
        private const string GetMovieUriWithSlug = GetMovieUri + "/" + TestConstants.Movies.MovieSlug;

        [Theory]
        [InlineData(null, $"{GetMovieUri}/293990", "Movies\\movie_minimal.json")]
        [InlineData(TraktExtendedInfo.None, $"{GetMovieUri}/293990", "Movies\\movie_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetMovieUri}/293990?extended=full", "Movies\\movie_full.json")]
        [InlineData(TraktExtendedInfo.Full | TraktExtendedInfo.Images, $"{GetMovieUri}/293990?extended=full,images", "Movies\\movie_full_images.json")]
        public async Task TestGetMovieWithID(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktMovie> response = await client.Movies.GetMovieAsync(TestConstants.Movies.TraktMovieID, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktMovie movie = response.Content;

            movie.Title.ShouldBe("Guardians of the Galaxy Volume 3");
            movie.Year.ShouldBe(2023U);
            movie.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
        }

        [Theory]
        [InlineData(null, GetMovieUriWithSlug, "Movies\\movie_minimal.json")]
        public async Task TestGetMovieWithSlug(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktMovie> response = await client.Movies.GetMovieAsync(TestConstants.Movies.MovieSlug, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktMovie movie = response.Content;

            movie.Title.ShouldBe("Guardians of the Galaxy Volume 3");
            movie.Year.ShouldBe(2023U);
            movie.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
        }

        [Theory]
        [InlineData(null, GetMovieUriWithSlug, "Movies\\movie_minimal.json")]
        public async Task TestGetMovieWithIDs(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktMovie> response = await client.Movies.GetMovieAsync(TestConstants.Movies.MovieIDs, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktMovie movie = response.Content;

            movie.Title.ShouldBe("Guardians of the Galaxy Volume 3");
            movie.Year.ShouldBe(2023U);
            movie.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieUri}/293990", statusCode);

            Func<Task<TraktResponse<TraktMovie>>> act = () => client.Movies.GetMovieAsync(TestConstants.Movies.TraktMovieID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movie_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktMovie>>> act = () => client.Movies.GetMovieAsync(default(TraktMovieIDs));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieAsync(movieIDs);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
