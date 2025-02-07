#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieWatchingGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/watching";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.VIP | TraktExtendedInfo.Full, $"{URIPath}?extended=full,vip")]
        public void TestMovieWatchingGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var movieWatchingGetRequest = new MovieWatchingGetRequest
            {
                Id = MovieID,
                ExtendedInfo = extendedInfo
            };

            movieWatchingGetRequest.BuildUri();
            movieWatchingGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieWatchingGetRequestHasValidOAuthRequirement()
        {
            var movieWatchingGetRequest = new MovieWatchingGetRequest { Id = MovieID };
            movieWatchingGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieWatchingGetRequestIsGetRequest()
        {
            var movieWatchingGetRequest = new MovieWatchingGetRequest { Id = MovieID };
            movieWatchingGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieWatchingGetRequestHasCorrectRequestObjectType()
        {
            var movieWatchingGetRequest = new MovieWatchingGetRequest { Id = MovieID };
            movieWatchingGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieWatchingGetRequestValidate()
        {
            var movieWatchingGetRequest = new MovieWatchingGetRequest { Id = string.Empty };

            Action act = () => movieWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieWatchingGetRequest = new MovieWatchingGetRequest { Id = "  " };

            act = () => movieWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieWatchingGetRequest = new MovieWatchingGetRequest { Id = "id with spaces" };

            act = () => movieWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
