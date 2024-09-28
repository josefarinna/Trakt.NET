#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieVideosGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/videos";

        [Fact]
        public void TestMovieVideosGetRequestHasValidURIPath()
        {
            var movieVideosGetRequest = new MovieVideosGetRequest { Id = MovieID };

            movieVideosGetRequest.BuildUri();
            movieVideosGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieVideosGetRequestHasValidOAuthRequirement()
        {
            var movieVideosGetRequest = new MovieVideosGetRequest { Id = MovieID };
            movieVideosGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieVideosGetRequestIsGetRequest()
        {
            var movieVideosGetRequest = new MovieVideosGetRequest { Id = MovieID };
            movieVideosGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieVideosGetRequestHasCorrectRequestObjectType()
        {
            var movieVideosGetRequest = new MovieVideosGetRequest { Id = MovieID };
            movieVideosGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieVideosGetRequestValidate()
        {
            var movieVideosGetRequest = new MovieVideosGetRequest { Id = string.Empty };

            Action act = () => movieVideosGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieVideosGetRequest = new MovieVideosGetRequest { Id = "  " };

            act = () => movieVideosGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieVideosGetRequest = new MovieVideosGetRequest { Id = "id with spaces" };

            act = () => movieVideosGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
