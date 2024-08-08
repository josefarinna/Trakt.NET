namespace TraktNET.GetRequests.Movies
{
    public sealed class BoxOfficeMoviesGetRequestTests
    {
        private const string URIPath = $"movies/boxoffice";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestBoxOfficeMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var boxOfficeMoviesGetRequest = new BoxOfficeMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            boxOfficeMoviesGetRequest.BuildUri();
            boxOfficeMoviesGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestBoxOfficeMoviesGetRequestHasValidOAuthRequirement()
        {
            var boxOfficeMoviesGetRequest = new BoxOfficeMoviesGetRequest();
            boxOfficeMoviesGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestBoxOfficeMoviesGetRequestIsGetRequest()
        {
            var boxOfficeMoviesGetRequest = new BoxOfficeMoviesGetRequest();
            boxOfficeMoviesGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestBoxOfficeMoviesGetRequestHasCorrectRequestObjectType()
        {
            var boxOfficeMoviesGetRequest = new BoxOfficeMoviesGetRequest();
            boxOfficeMoviesGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
