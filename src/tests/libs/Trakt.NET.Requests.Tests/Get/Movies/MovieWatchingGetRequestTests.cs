namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieWatchingGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}/watching";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.VIP | TraktExtendedInfo.Full, $"{URIPath}?extended=full,vip")]
        public void TestMovieWatchingGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var movieWatchingGetRequest = new MovieWatchingGetRequest
            {
                Id = MovieID,
                ExtendedInfo = extendedInfo
            };

            movieWatchingGetRequest.BuildUri();
            movieWatchingGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieWatchingGetRequestHasValidOAuthRequirement()
        {
            var movieWatchingGetRequest = new MovieWatchingGetRequest { Id = MovieID };
            movieWatchingGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieWatchingGetRequestIsGetRequest()
        {
            var movieWatchingGetRequest = new MovieWatchingGetRequest { Id = MovieID };
            movieWatchingGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
