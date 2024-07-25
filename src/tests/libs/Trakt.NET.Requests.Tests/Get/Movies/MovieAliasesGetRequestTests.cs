namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieAliasesGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}/aliases";

        [Fact]
        public void TestMovieAliasesGetRequestHasValidURIPath()
        {
            var movieAliasesGetRequest = new MovieAliasesGetRequest { Id = MovieID };

            movieAliasesGetRequest.BuildUri();
            movieAliasesGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieAliasesGetRequestHasValidOAuthRequirement()
        {
            var movieAliasesGetRequest = new MovieAliasesGetRequest { Id = MovieID };
            movieAliasesGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieAliasesGetRequestIsGetRequest()
        {
            var movieAliasesGetRequest = new MovieAliasesGetRequest { Id = MovieID };
            movieAliasesGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
