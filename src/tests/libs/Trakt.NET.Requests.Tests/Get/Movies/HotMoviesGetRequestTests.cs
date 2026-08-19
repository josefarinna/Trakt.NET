#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class HotMoviesGetRequestTests
    {
        private const string URIPath = "movies/hot";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, null, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.Full, null, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, 10, null, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, null, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, null, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, null, "batman", $"{URIPath}?query=batman")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, null, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, "batman", $"{URIPath}?query=batman&extended=full&page=10&limit=20")]
        public void TestHotMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo,
            int? page, int? limit, string? query, string expectedURIPath)
        {
            var hotMoviesGetRequest = new HotMoviesGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit,
                Filter = query != null ? new TraktFilter { Query = query } : null
            };

            hotMoviesGetRequest.BuildUri();
            hotMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestHotMoviesGetRequestHasValidOAuthRequirement()
        {
            var hotMoviesGetRequest = new HotMoviesGetRequest();
            hotMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestHotMoviesGetRequestIsGetRequest()
        {
            var hotMoviesGetRequest = new HotMoviesGetRequest();
            hotMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestHotMoviesGetRequestHasCorrectRequestObjectType()
        {
            var hotMoviesGetRequest = new HotMoviesGetRequest();
            hotMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
