namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieStudiosGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}/studios";

        [Fact]
        public void TestMovieStudiosGetRequestHasValidURIPath()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = MovieID };

            movieStudiosGetRequest.BuildUri();
            movieStudiosGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieStudiosGetRequestHasValidOAuthRequirement()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = MovieID };
            movieStudiosGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieStudiosGetRequestIsGetRequest()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = MovieID };
            movieStudiosGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
