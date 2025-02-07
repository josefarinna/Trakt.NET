#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestMovieGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var movieGetRequest = new MovieGetRequest
            {
                Id = MovieID,
                ExtendedInfo = extendedInfo
            };

            movieGetRequest.BuildUri();
            movieGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieGetRequestHasValidOAuthRequirement()
        {
            var movieGetRequest = new MovieGetRequest { Id = MovieID };
            movieGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieGetRequestIsGetRequest()
        {
            var movieGetRequest = new MovieGetRequest { Id = MovieID };
            movieGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieGetRequestHasCorrectRequestObjectType()
        {
            var movieGetRequest = new MovieGetRequest { Id = MovieID };
            movieGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieGetRequestValidate()
        {
            var movieGetRequest = new MovieGetRequest { Id = string.Empty };

            Action act = () => movieGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieGetRequest = new MovieGetRequest { Id = "  " };

            act = () => movieGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieGetRequest = new MovieGetRequest { Id = "id with spaces" };

            act = () => movieGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
