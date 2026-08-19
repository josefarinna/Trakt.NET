#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class HotShowsGetRequestTests
    {
        private const string URIPath = "shows/hot";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, null, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.Full, null, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, 10, null, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, null, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, null, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, null, "game of thrones", $"{URIPath}?query=game of thrones")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, null, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, "game of thrones", $"{URIPath}?query=game of thrones&extended=full&page=10&limit=20")]
        public void TestHotShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo,
            int? page, int? limit, string? query, string expectedURIPath)
        {
            var hotShowsGetRequest = new HotShowsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit,
                Filter = query != null ? new TraktFilter { Query = query } : null
            };

            hotShowsGetRequest.BuildUri();
            hotShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestHotShowsGetRequestHasValidOAuthRequirement()
        {
            var hotShowsGetRequest = new HotShowsGetRequest();
            hotShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestHotShowsGetRequestIsGetRequest()
        {
            var hotShowsGetRequest = new HotShowsGetRequest();
            hotShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestHotShowsGetRequestHasCorrectRequestObjectType()
        {
            var hotShowsGetRequest = new HotShowsGetRequest();
            hotShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
