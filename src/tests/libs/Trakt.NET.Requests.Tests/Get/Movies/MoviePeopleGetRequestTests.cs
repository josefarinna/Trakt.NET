namespace TraktNET.GetRequests.Movies
{
    public sealed class MoviePeopleGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}/people";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestMoviePeopleGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var moviePeopleGetRequest = new MoviePeopleGetRequest
            {
                Id = MovieID,
                ExtendedInfo = extendedInfo
            };

            moviePeopleGetRequest.BuildUri();
            moviePeopleGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMoviePeopleGetRequestHasValidOAuthRequirement()
        {
            var moviePeopleGetRequest = new MoviePeopleGetRequest { Id = MovieID };
            moviePeopleGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMoviePeopleGetRequestIsGetRequest()
        {
            var moviePeopleGetRequest = new MoviePeopleGetRequest { Id = MovieID };
            moviePeopleGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
