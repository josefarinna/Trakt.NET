#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

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
            movieStudiosGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieStudiosGetRequestHasValidOAuthRequirement()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = MovieID };
            movieStudiosGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieStudiosGetRequestIsGetRequest()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = MovieID };
            movieStudiosGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieStudiosGetRequestHasCorrectRequestObjectType()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = MovieID };
            movieStudiosGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieStudiosGetRequestValidate()
        {
            var movieStudiosGetRequest = new MovieStudiosGetRequest { Id = string.Empty };

            Action act = () => movieStudiosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieStudiosGetRequest = new MovieStudiosGetRequest { Id = "  " };

            act = () => movieStudiosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieStudiosGetRequest = new MovieStudiosGetRequest { Id = "id with spaces" };

            act = () => movieStudiosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
