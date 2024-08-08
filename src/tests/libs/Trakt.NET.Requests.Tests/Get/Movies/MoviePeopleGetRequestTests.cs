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

        [Fact]
        public void TestMoviePeopleGetRequestHasCorrectRequestObjectType()
        {
            var moviePeopleGetRequest = new MoviePeopleGetRequest { Id = MovieID };
            moviePeopleGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMoviePeopleGetRequestValidate()
        {
            var moviePeopleGetRequest = new MoviePeopleGetRequest { Id = string.Empty };

            Action act = () => moviePeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            moviePeopleGetRequest = new MoviePeopleGetRequest { Id = "  " };

            act = () => moviePeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            moviePeopleGetRequest = new MoviePeopleGetRequest { Id = "id with spaces" };

            act = () => moviePeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
