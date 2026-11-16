using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieReleasesTests
    {
        private const string GetMovieReleasesUriPrefix = "movies";
        private const string GetMovieReleasesUriSuffix = "releases";
        private const string GetMovieReleasesUri = GetMovieReleasesUriPrefix + "/293990/" + GetMovieReleasesUriSuffix;
        private const string GetMovieReleasesUriWithSlug = GetMovieReleasesUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMovieReleasesUriSuffix;

        [Theory]
        [InlineData(null, GetMovieReleasesUri, "Movies\\moviereleases.json")]
        [InlineData("", GetMovieReleasesUri, "Movies\\moviereleases.json")]
        [InlineData("fr", $"{GetMovieReleasesUri}/fr", "Movies\\moviereleases.json")]
        public async Task TestGetMovieReleasesWithID(string? country, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktMovieRelease> response = await client.Movies.GetMovieReleasesAsync(TestConstants.Movies.TraktMovieID, country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktMovieRelease> movieReleases = response.Content;

            TraktMovieRelease movieRelease = movieReleases[0];

            movieRelease.Country.ShouldBe("fr");
            movieRelease.ReleaseType.ShouldBe(TraktReleaseType.Premiere);

            movieRelease = movieReleases[1];

            movieRelease.Country.ShouldBe("us");
            movieRelease.ReleaseType.ShouldBe(TraktReleaseType.Premiere);
        }

        [Theory]
        [InlineData(null, GetMovieReleasesUriWithSlug, "Movies\\moviereleases.json")]
        public async Task TestGetMovieReleasesWithSlug(string? country, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktMovieRelease> response = await client.Movies.GetMovieReleasesAsync(TestConstants.Movies.MovieSlug, country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktMovieRelease> movieReleases = response.Content;

            TraktMovieRelease movieRelease = movieReleases[0];

            movieRelease.Country.ShouldBe("fr");
            movieRelease.ReleaseType.ShouldBe(TraktReleaseType.Premiere);

            movieRelease = movieReleases[1];

            movieRelease.Country.ShouldBe("us");
            movieRelease.ReleaseType.ShouldBe(TraktReleaseType.Premiere);
        }

        [Theory]
        [InlineData(null, GetMovieReleasesUriWithSlug, "Movies\\moviereleases.json")]
        public async Task TestGetMovieReleasesWithIDs(string? country, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktMovieRelease> response = await client.Movies.GetMovieReleasesAsync(TestConstants.Movies.MovieIDs, country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktMovieRelease> movieReleases = response.Content;

            TraktMovieRelease movieRelease = movieReleases[0];

            movieRelease.Country.ShouldBe("fr");
            movieRelease.ReleaseType.ShouldBe(TraktReleaseType.Premiere);

            movieRelease = movieReleases[1];

            movieRelease.Country.ShouldBe("us");
            movieRelease.ReleaseType.ShouldBe(TraktReleaseType.Premiere);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieReleasesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieReleasesUri, statusCode);

            Func<Task<TraktListResponse<TraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(TestConstants.Movies.TraktMovieID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieReleasesWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviereleases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieReleasesUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(default(TraktMovieIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieReleasesAsync(movieIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
