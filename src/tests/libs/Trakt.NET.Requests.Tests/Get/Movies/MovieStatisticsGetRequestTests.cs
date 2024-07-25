namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieStatisticsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}/stats";

        [Fact]
        public void TestMovieStatisticsGetRequestHasValidURIPath()
        {
            var movieStatisticsGetRequest = new MovieStatisticsGetRequest { Id = MovieID };

            movieStatisticsGetRequest.BuildUri();
            movieStatisticsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieStatisticsGetRequestHasValidOAuthRequirement()
        {
            var movieStatisticsGetRequest = new MovieStatisticsGetRequest { Id = MovieID };
            movieStatisticsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieStatisticsGetRequestIsGetRequest()
        {
            var movieStatisticsGetRequest = new MovieStatisticsGetRequest { Id = MovieID };
            movieStatisticsGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
