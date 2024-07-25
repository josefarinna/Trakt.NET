namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestMovieGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var movieGetRequest = new MovieGetRequest
            {
                Id = MovieID,
                ExtendedInfo = extendedInfo
            };

            movieGetRequest.BuildUri();
            movieGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieGetRequestHasValidOAuthRequirement()
        {
            var movieGetRequest = new MovieGetRequest { Id = MovieID };
            movieGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieGetRequestIsGetRequest()
        {
            var movieGetRequest = new MovieGetRequest { Id = MovieID };
            movieGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
