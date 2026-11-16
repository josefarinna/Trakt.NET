using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieStudiosTests
    {
        private const string GetMovieStudiosUriPrefix = "movies";
        private const string GetMovieStudiosUriSuffix = "studios";
        private static readonly string GetMovieStudiosUri = $"{GetMovieStudiosUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMovieStudiosUriSuffix}";
        private static readonly string GetMovieStudiosUriWithSlug = $"{GetMovieStudiosUriPrefix}/{TestConstants.Movies.MovieSlug}/{GetMovieStudiosUriSuffix}";

        [Fact]
        public async Task TestGetMovieStudiosWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStudiosUri, responseContent);

            TraktListResponse<TraktStudio> response = await client.Movies.GetMovieStudiosAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktStudio> movieStudios = response.Content;

            TraktStudio movieStudio = movieStudios[0];

            movieStudio.Name.ShouldBe("Marvel Studios");
            movieStudio.Country.ShouldBe("us");

            movieStudio = movieStudios[1];

            movieStudio.Name.ShouldBe("Kevin Feige Productions");
            movieStudio.Country.ShouldBe("us");
        }

        [Fact]
        public async Task TestGetMovieStudiosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStudiosUriWithSlug, responseContent);

            TraktListResponse<TraktStudio> response = await client.Movies.GetMovieStudiosAsync(TestConstants.Movies.MovieSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktStudio> movieStudios = response.Content;

            TraktStudio movieStudio = movieStudios[0];

            movieStudio.Name.ShouldBe("Marvel Studios");
            movieStudio.Country.ShouldBe("us");

            movieStudio = movieStudios[1];

            movieStudio.Name.ShouldBe("Kevin Feige Productions");
            movieStudio.Country.ShouldBe("us");
        }

        [Fact]
        public async Task TestGetMovieStudiosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStudiosUriWithSlug, responseContent);

            TraktListResponse<TraktStudio> response = await client.Movies.GetMovieStudiosAsync(TestConstants.Movies.MovieIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktStudio> movieStudios = response.Content;

            TraktStudio movieStudio = movieStudios[0];

            movieStudio.Name.ShouldBe("Marvel Studios");
            movieStudio.Country.ShouldBe("us");

            movieStudio = movieStudios[1];

            movieStudio.Name.ShouldBe("Kevin Feige Productions");
            movieStudio.Country.ShouldBe("us");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieStudiosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStudiosUri, statusCode);

            Func<Task<TraktListResponse<TraktStudio>>> act = () => client.Movies.GetMovieStudiosAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieStudiosWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestudios.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStudiosUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktStudio>>> act = () => client.Movies.GetMovieStudiosAsync(default(TraktMovieIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieStudiosAsync(movieIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
