#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Movies
{
    public sealed class MovieRefreshPostRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/refresh";

        [Fact]
        public void TestMovieRefreshPostRequestHasValidURIPath()
        {
            var movieRefreshPostRequest = new MovieRefreshPostRequest
            {
                Id = MovieID
            };

            movieRefreshPostRequest.BuildUri();
            movieRefreshPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieRefreshPostRequestHasValidOAuthRequirement()
        {
            var movieRefreshPostRequest = new MovieRefreshPostRequest { Id = MovieID };
            movieRefreshPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestMovieRefreshPostRequestIsPostRequest()
        {
            var movieRefreshPostRequest = new MovieRefreshPostRequest { Id = MovieID };
            movieRefreshPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestMovieRefreshPostRequestHasCorrectRequestObjectType()
        {
            var movieRefreshPostRequest = new MovieRefreshPostRequest { Id = MovieID };
            movieRefreshPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieRefreshPostRequestValidate()
        {
            var movieRefreshPostRequest = new MovieRefreshPostRequest { Id = string.Empty };
            Action act = () => movieRefreshPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieRefreshPostRequest = new MovieRefreshPostRequest { Id = "  " };
            act = () => movieRefreshPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieRefreshPostRequest = new MovieRefreshPostRequest { Id = "id with spaces" };
            act = () => movieRefreshPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
