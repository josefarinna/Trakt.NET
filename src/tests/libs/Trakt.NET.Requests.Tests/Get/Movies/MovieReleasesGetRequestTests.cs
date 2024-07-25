namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieReleasesGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}/releases";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("", URIPath)]
        [InlineData(" ", URIPath)]
        [InlineData("us", $"{URIPath}/us")]
        public void TestMovieReleasesGetRequestHasValidURIPath(string? country, string expectedURIPath)
        {
            var movieReleasesGetRequest = new MovieReleasesGetRequest
            {
                Id = MovieID,
                Country = country
            };

            movieReleasesGetRequest.BuildUri();
            movieReleasesGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieReleasesGetRequestHasValidOAuthRequirement()
        {
            var movieReleasesGetRequest = new MovieReleasesGetRequest { Id = MovieID };
            movieReleasesGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieReleasesGetRequestIsGetRequest()
        {
            var movieReleasesGetRequest = new MovieReleasesGetRequest { Id = MovieID };
            movieReleasesGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
