namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieTranslationsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}/translations";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("", URIPath)]
        [InlineData(" ", URIPath)]
        [InlineData("en", $"{URIPath}/en")]
        public void TestMovieTranslationsGetRequestHasValidURIPath(string? language, string expectedURIPath)
        {
            var movieTranslationsGetRequest = new MovieTranslationsGetRequest
            {
                Id = MovieID,
                Language = language
            };

            movieTranslationsGetRequest.BuildUri();
            movieTranslationsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieTranslationsGetRequestHasValidOAuthRequirement()
        {
            var movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = MovieID };
            movieTranslationsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieTranslationsGetRequestIsGetRequest()
        {
            var movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = MovieID };
            movieTranslationsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieTranslationsGetRequestHasCorrectRequestObjectType()
        {
            var movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = MovieID };
            movieTranslationsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieTranslationsGetRequestValidate()
        {
            var movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = string.Empty };

            Action act = () => movieTranslationsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = "  " };

            act = () => movieTranslationsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = "id with spaces" };

            act = () => movieTranslationsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
