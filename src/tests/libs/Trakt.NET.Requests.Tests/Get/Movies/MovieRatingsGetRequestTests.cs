namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieRatingsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}/ratings";

        [Fact]
        public void TestMovieRatingsGetRequestHasValidURIPath()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };

            movieRatingsGetRequest.BuildUri();
            movieRatingsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieRatingsGetRequestHasValidOAuthRequirement()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };
            movieRatingsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieRatingsGetRequestIsGetRequest()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };
            movieRatingsGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
