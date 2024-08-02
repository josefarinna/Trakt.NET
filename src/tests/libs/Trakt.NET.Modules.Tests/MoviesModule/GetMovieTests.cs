namespace TraktNET.MoviesModule
{
    public sealed class GetMovieTests
    {
        private const string GetMovieUri = "movies/" + TestConstants.Movies.MovieID;

        [Theory]
        [InlineData(null, GetMovieUri, "Movies\\movie_minimal.json")]
        [InlineData(TraktExtendedInfo.None, GetMovieUri, "Movies\\movie_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetMovieUri}?extended=full", "Movies\\movie.json")]
        public async Task TestGetMovie(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktContext context = ModuleTestUtility.GetContext(requestUri, responseContent);

            TraktResponse<TraktMovie> response = await context.Movies.GetMovieAsync(TestConstants.Movies.MovieID, extendedInfo);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Headers.Should().NotBeNull();
            response.TraktHeaders.Should().NotBeNull();
            response.ContentHeaders.Should().NotBeNull();
        }
    }
}
