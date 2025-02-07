#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieRatingsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/ratings";

        [Fact]
        public void TestMovieRatingsGetRequestHasValidURIPath()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };

            movieRatingsGetRequest.BuildUri();
            movieRatingsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieRatingsGetRequestHasValidOAuthRequirement()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };
            movieRatingsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieRatingsGetRequestIsGetRequest()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };
            movieRatingsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieRatingsGetRequestHasCorrectRequestObjectType()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = MovieID };
            movieRatingsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieRatingsGetRequestValidate()
        {
            var movieRatingsGetRequest = new MovieRatingsGetRequest { Id = string.Empty };

            Action act = () => movieRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieRatingsGetRequest = new MovieRatingsGetRequest { Id = "  " };

            act = () => movieRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieRatingsGetRequest = new MovieRatingsGetRequest { Id = "id with spaces" };

            act = () => movieRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
