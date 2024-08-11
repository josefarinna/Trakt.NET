#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class TrendingShowsGetRequestTests
    {
        private const string URIPath = $"shows/trending";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        public void TestTrendingShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var trendingShowsGetRequest = new TrendingShowsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            trendingShowsGetRequest.BuildUri();
            trendingShowsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTrendingShowsGetRequestHasValidOAuthRequirement()
        {
            var trendingShowsGetRequest = new TrendingShowsGetRequest();
            trendingShowsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestTrendingShowsGetRequestIsGetRequest()
        {
            var trendingShowsGetRequest = new TrendingShowsGetRequest();
            trendingShowsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestTrendingShowsGetRequestHasCorrectRequestObjectType()
        {
            var trendingShowsGetRequest = new TrendingShowsGetRequest();
            trendingShowsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
