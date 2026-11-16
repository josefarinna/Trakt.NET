using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieStatisticsTests
    {
        private const string GetMovieStatisticsUriPrefix = "movies";
        private const string GetMovieStatisticsUriSuffix = "stats";
        private static readonly string GetMovieStatisticsUri = $"{GetMovieStatisticsUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMovieStatisticsUriSuffix}";
        private static readonly string GetMovieStatisticsUriWithSlug = $"{GetMovieStatisticsUriPrefix}/{TestConstants.Movies.MovieSlug}/{GetMovieStatisticsUriSuffix}";

        [Fact]
        public async Task TestGetMovieStatisticsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUri, responseContent);

            TraktResponse<TraktMovieStatistics> response = await client.Movies.GetMovieStatisticsAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktMovieStatistics movieStatistics = response.Content;

            movieStatistics.Watchers.ShouldBe(164943U);
            movieStatistics.Plays.ShouldBe(219925U);
        }

        [Fact]
        public async Task TestGetMovieStatisticsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUriWithSlug, responseContent);

            TraktResponse<TraktMovieStatistics> response = await client.Movies.GetMovieStatisticsAsync(TestConstants.Movies.MovieSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktMovieStatistics movieStatistics = response.Content;

            movieStatistics.Watchers.ShouldBe(164943U);
            movieStatistics.Plays.ShouldBe(219925U);
        }

        [Fact]
        public async Task TestGetMovieStatisticsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUriWithSlug, responseContent);

            TraktResponse<TraktMovieStatistics> response = await client.Movies.GetMovieStatisticsAsync(TestConstants.Movies.MovieIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktMovieStatistics movieStatistics = response.Content;

            movieStatistics.Watchers.ShouldBe(164943U);
            movieStatistics.Plays.ShouldBe(219925U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieStatisticsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUri, statusCode);

            Func<Task<TraktResponse<TraktMovieStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(TestConstants.Movies.TraktMovieID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieStatisticsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\moviestatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieStatisticsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktResponse<TraktMovieStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(default(TraktMovieIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieStatisticsAsync(movieIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
