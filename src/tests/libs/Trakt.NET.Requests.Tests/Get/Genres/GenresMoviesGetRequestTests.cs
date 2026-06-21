#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Genres
{
    public sealed class GenresMoviesGetRequestTests
    {
        private const string URIPath = "genres/movies";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestGenresMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var genresMoviesGetRequest = new GenresMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            genresMoviesGetRequest.BuildUri();
            genresMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestGenresMoviesGetRequestHasValidOAuthRequirement()
        {
            var genresMoviesGetRequest = new GenresMoviesGetRequest();
            genresMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestGenresMoviesGetRequestIsGetRequest()
        {
            var genresMoviesGetRequest = new GenresMoviesGetRequest();
            genresMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestGenresMoviesGetRequestHasCorrectRequestObjectType()
        {
            var genresMoviesGetRequest = new GenresMoviesGetRequest();
            genresMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
