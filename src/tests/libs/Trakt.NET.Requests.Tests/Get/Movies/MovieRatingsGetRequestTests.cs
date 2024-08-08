namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieRatingsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieID;
        private const string URIPath = $"movies/{MovieID}/ratings";

        [Fact]
        public void TestMovieRatingsGetRequestHasValidURIPath()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };

            movieRatingsGetRequest.BuildUri();
            movieRatingsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieRatingsGetRequestHasValidOAuthRequirement()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };
            movieRatingsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieRatingsGetRequestIsGetRequest()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };
            movieRatingsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieRatingsGetRequestHasCorrectRequestObjectType()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };
            movieRatingsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieRatingsGetRequestValidate()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = string.Empty };

            Action act = () => movieRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieRatingsGetRequest = new MovieRatingsGetRequest { Id = "  " };

            act = () => movieRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieRatingsGetRequest = new MovieRatingsGetRequest { Id = "id with spaces" };

            act = () => movieRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
