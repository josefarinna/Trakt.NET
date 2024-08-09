namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieAliasesGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
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

        [Fact]
        public void TestMovieAliasesGetRequestHasCorrectRequestObjectType()
        {
            var movieAliasesGetRequest = new MovieAliasesGetRequest { Id = MovieID };
            movieAliasesGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieAliasesGetRequestValidate()
        {
            var movieAliasesGetRequest = new MovieAliasesGetRequest { Id = string.Empty };

            Action act = () => movieAliasesGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieAliasesGetRequest = new MovieAliasesGetRequest { Id = "  " };

            act = () => movieAliasesGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieAliasesGetRequest = new MovieAliasesGetRequest { Id = "id with spaces" };

            act = () => movieAliasesGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
