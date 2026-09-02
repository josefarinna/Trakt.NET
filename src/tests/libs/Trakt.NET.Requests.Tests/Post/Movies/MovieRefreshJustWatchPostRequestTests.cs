#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Movies
{
    public sealed class MovieRefreshJustWatchPostRequestTests
    {
        private const string URIPath = "movies/123/refresh/justwatch";

        [Fact]
        public void TestMovieRefreshJustWatchPostRequestHasValidURIPath()
        {
            var movieRefreshJustWatchPostRequest = new MovieRefreshJustWatchPostRequest
            {
                Id = "123"
            };

            movieRefreshJustWatchPostRequest.BuildUri();
            movieRefreshJustWatchPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieRefreshJustWatchPostRequestHasValidOAuthRequirement()
        {
            var movieRefreshJustWatchPostRequest = new MovieRefreshJustWatchPostRequest { Id = default! };
            movieRefreshJustWatchPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestMovieRefreshJustWatchPostRequestIsPostRequest()
        {
            var movieRefreshJustWatchPostRequest = new MovieRefreshJustWatchPostRequest { Id = default! };
            movieRefreshJustWatchPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestMovieRefreshJustWatchPostRequestHasCorrectRequestObjectType()
        {
            var movieRefreshJustWatchPostRequest = new MovieRefreshJustWatchPostRequest { Id = default! };
            movieRefreshJustWatchPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieRefreshJustWatchPostRequestValidate()
        {
            var movieRefreshJustWatchPostRequest = new MovieRefreshJustWatchPostRequest { Id = string.Empty };
            Action act = () => movieRefreshJustWatchPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieRefreshJustWatchPostRequest = new MovieRefreshJustWatchPostRequest { Id = "  " };
            act = () => movieRefreshJustWatchPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieRefreshJustWatchPostRequest = new MovieRefreshJustWatchPostRequest { Id = "id with spaces" };
            act = () => movieRefreshJustWatchPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
