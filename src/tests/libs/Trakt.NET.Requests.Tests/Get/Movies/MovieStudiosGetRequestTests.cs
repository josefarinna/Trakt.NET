namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieStudiosGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/studios";

        [Fact]
        public void TestMovieStudiosGetRequestHasValidURIPath()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = MovieID };

            movieStudiosGetRequest.BuildUri();
            movieStudiosGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieStudiosGetRequestHasValidOAuthRequirement()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = MovieID };
            movieStudiosGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieStudiosGetRequestIsGetRequest()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = MovieID };
            movieStudiosGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieStudiosGetRequestHasCorrectRequestObjectType()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = MovieID };
            movieStudiosGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieStudiosGetRequestValidate()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = string.Empty };

            Action act = () => movieStudiosGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieStudiosGetRequest = new MovieStudiosGetRequest { Id = "  " };

            act = () => movieStudiosGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieStudiosGetRequest = new MovieStudiosGetRequest { Id = "id with spaces" };

            act = () => movieStudiosGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
