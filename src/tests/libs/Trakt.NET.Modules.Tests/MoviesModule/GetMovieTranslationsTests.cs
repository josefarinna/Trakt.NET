using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieTranslationsTests
    {
        private const string GetMovieTranslationsUriPrefix = "movies";
        private const string GetMovieTranslationsUriSuffix = "translations";
        private const string GetMovieTranslationsUri = GetMovieTranslationsUriPrefix + "/293990/" + GetMovieTranslationsUriSuffix;
        private const string GetMovieTranslationsUriWithSlug = GetMovieTranslationsUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMovieTranslationsUriSuffix;

        [Theory]
        [InlineData(null, GetMovieTranslationsUri, "Movies\\movietranslations.json")]
        [InlineData("", GetMovieTranslationsUri, "Movies\\movietranslations.json")]
        [InlineData("en", $"{GetMovieTranslationsUri}?language=en", "Movies\\movietranslations.json")]
        public async Task TestGetMovieTranslationsWithID(string? language, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktMovieTranslation> response = await client.Movies.GetMovieTranslationsAsync(TestConstants.Movies.TraktMovieID, language, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktMovieTranslation> movieTranslations = response.Content!;

            TraktMovieTranslation movieTranslation = movieTranslations[0];

            movieTranslation.Title.ShouldBe("Guardians of the Galaxy Vol. 3");
            movieTranslation.Tagline.ShouldBe("Ho donaran tot.");

            movieTranslation = movieTranslations[1];

            movieTranslation.Title.ShouldBe("Strážci Galaxie: Volume 3");
            movieTranslation.Tagline.ShouldBe("Ještě jednou a s citem");
        }

        [Theory]
        [InlineData(null, GetMovieTranslationsUriWithSlug, "Movies\\movietranslations.json")]
        public async Task TestGetMovieTranslationsWithSlug(string? language, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktMovieTranslation> response = await client.Movies.GetMovieTranslationsAsync(TestConstants.Movies.MovieSlug, language, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktMovieTranslation> movieTranslations = response.Content!;

            TraktMovieTranslation movieTranslation = movieTranslations[0];

            movieTranslation.Title.ShouldBe("Guardians of the Galaxy Vol. 3");
            movieTranslation.Tagline.ShouldBe("Ho donaran tot.");

            movieTranslation = movieTranslations[1];

            movieTranslation.Title.ShouldBe("Strážci Galaxie: Volume 3");
            movieTranslation.Tagline.ShouldBe("Ještě jednou a s citem");
        }

        [Theory]
        [InlineData(null, GetMovieTranslationsUriWithSlug, "Movies\\movietranslations.json")]
        public async Task TestGetMovieTranslationsWithIDs(string? language, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktMovieTranslation> response = await client.Movies.GetMovieTranslationsAsync(TestConstants.Movies.MovieIDs, language, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktMovieTranslation> movieTranslations = response.Content!;

            TraktMovieTranslation movieTranslation = movieTranslations[0];

            movieTranslation.Title.ShouldBe("Guardians of the Galaxy Vol. 3");
            movieTranslation.Tagline.ShouldBe("Ho donaran tot.");

            movieTranslation = movieTranslations[1];

            movieTranslation.Title.ShouldBe("Strážci Galaxie: Volume 3");
            movieTranslation.Tagline.ShouldBe("Ještě jednou a s citem");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieTranslationsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieTranslationsUri, statusCode);

            Func<Task<TraktListResponse<TraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(TestConstants.Movies.TraktMovieID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieTranslationsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movietranslations.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieTranslationsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(default(TraktMovieIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieTranslationsAsync(movieIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
