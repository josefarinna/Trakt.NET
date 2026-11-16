using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieVideosTests
    {
        private const string GetMovieVideosUriPrefix = "movies";
        private const string GetMovieVideosUriSuffix = "videos";
        private static readonly string GetMovieVideosUri = $"{GetMovieVideosUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMovieVideosUriSuffix}";
        private static readonly string GetMovieVideosUriWithSlug = $"{GetMovieVideosUriPrefix}/{TestConstants.Movies.MovieSlug}/{GetMovieVideosUriSuffix}";

        [Fact]
        public async Task TestGetMovieVideosWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movievideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieVideosUri, responseContent);

            TraktListResponse<TraktVideo> response = await client.Movies.GetMovieVideosAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktVideo> movieVideos = response.Content!;

            TraktVideo movieVideo = movieVideos[0];

            movieVideo.Title.ShouldBe("Disney+ Promo");
            movieVideo.Url.ShouldBe("https://youtube.com/watch?v=3RLT34SwtQc");

            movieVideo = movieVideos[1];

            movieVideo.Title.ShouldBe("Now Streaming on Disney+");
            movieVideo.Url.ShouldBe("https://youtube.com/watch?v=D3NpwOB69Ys");
        }

        [Fact]
        public async Task TestGetMovieVideosWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movievideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieVideosUriWithSlug, responseContent);

            TraktListResponse<TraktVideo> response = await client.Movies.GetMovieVideosAsync(TestConstants.Movies.MovieSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktVideo> movieVideos = response.Content!;

            TraktVideo movieVideo = movieVideos[0];

            movieVideo.Title.ShouldBe("Disney+ Promo");
            movieVideo.Url.ShouldBe("https://youtube.com/watch?v=3RLT34SwtQc");

            movieVideo = movieVideos[1];

            movieVideo.Title.ShouldBe("Now Streaming on Disney+");
            movieVideo.Url.ShouldBe("https://youtube.com/watch?v=D3NpwOB69Ys");
        }

        [Fact]
        public async Task TestGetMovieVideosWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movievideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieVideosUriWithSlug, responseContent);

            TraktListResponse<TraktVideo> response = await client.Movies.GetMovieVideosAsync(TestConstants.Movies.MovieIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktVideo> movieVideos = response.Content!;

            TraktVideo movieVideo = movieVideos[0];

            movieVideo.Title.ShouldBe("Disney+ Promo");
            movieVideo.Url.ShouldBe("https://youtube.com/watch?v=3RLT34SwtQc");

            movieVideo = movieVideos[1];

            movieVideo.Title.ShouldBe("Now Streaming on Disney+");
            movieVideo.Url.ShouldBe("https://youtube.com/watch?v=D3NpwOB69Ys");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieVideosWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieVideosUri, statusCode);

            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Movies.GetMovieVideosAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieVideosWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movievideos.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieVideosUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktListResponse<TraktVideo>>> act = () => client.Movies.GetMovieVideosAsync(default(TraktMovieIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieVideosAsync(movieIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
