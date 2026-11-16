using System.Net;

namespace TraktNET.RecommendationsModule
{
    public sealed class HideUserMovieRecommendationTests
    {
        private readonly string HideMovieRecommendationUri = $"recommendations/movies/{TestConstants.Movies.TraktMovieID}";

        [Fact]
        public async Task TestHideMovieRecommendationWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideMovieRecommendationUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideMovieRecommendationAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideMovieRecommendationWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/movies/{TestConstants.Movies.MovieSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideMovieRecommendationAsync(TestConstants.Movies.MovieSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideMovieRecommendationWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/movies/{TestConstants.Movies.MovieSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideMovieRecommendationAsync(TestConstants.Movies.MovieIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestHideMovieRecommendationWithMovie()
        {
            var movie = new TraktMovie
            {
                IDs = TestConstants.Movies.MovieIDs
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient($"recommendations/movies/{TestConstants.Movies.MovieSlug}", HttpStatusCode.NoContent);
            TraktResponse response = await client.Recommendations.HideMovieRecommendationAsync(movie, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestHideMovieRecommendationWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideMovieRecommendationUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Recommendations.HideMovieRecommendationAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestHideMovieRecommendationWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(HideMovieRecommendationUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Recommendations.HideMovieRecommendationAsync(default(TraktMovieIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Recommendations.HideMovieRecommendationAsync(default(TraktMovie)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Recommendations.HideMovieRecommendationAsync(new TraktMovieIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Recommendations.HideMovieRecommendationAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
