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

        [Fact]
        public void TestMovieWatchingGetRequestHasCorrectRequestObjectType()
        {
            var movieWatchingGetRequest = new MovieWatchingGetRequest { Id = MovieID };
            movieWatchingGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieWatchingGetRequestValidate()
        {
            var movieWatchingGetRequest = new MovieWatchingGetRequest { Id = string.Empty };

            Action act = () => movieWatchingGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieWatchingGetRequest = new MovieWatchingGetRequest { Id = "  " };

            act = () => movieWatchingGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieWatchingGetRequest = new MovieWatchingGetRequest { Id = "id with spaces" };

            act = () => movieWatchingGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
