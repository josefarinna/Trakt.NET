namespace TraktNET.PostRequests.Movies
{
    public sealed class MovieRefreshPostRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}/refresh";

        [Fact]
        public void TestMovieRefreshPostRequestHasValidURIPath()
        {
            var movieRefreshPostRequest = new MovieRefreshPostRequest
            {
                Id = MovieID
            };

            movieRefreshPostRequest.BuildUri();
            movieRefreshPostRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieRefreshPostRequestHasValidOAuthRequirement()
        {
            var movieRefreshPostRequest = new MovieRefreshPostRequest { Id = MovieID };
            movieRefreshPostRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestMovieRefreshPostRequestIsPostRequest()
        {
            var movieRefreshPostRequest = new MovieRefreshPostRequest { Id = MovieID };
            movieRefreshPostRequest.Method.Should().Be(HttpMethod.Post);
        }
    }
}
