#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class StreamingShowsGetRequestTests
    {
        private const string URIPath = "shows/streaming";

        [Theory]
        [InlineData(null, null, null, null, null, URIPath)]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, null, URIPath)]
        [InlineData(TraktTimePeriod.Daily, null, null, null, null, $"{URIPath}/daily")]
        [InlineData(null, TraktExtendedInfo.None, null, null, null, URIPath)]
        [InlineData(null, TraktExtendedInfo.Full, null, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, 10, null, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, null, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, null, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, null, null, "game of thrones", $"{URIPath}?query=game of thrones")]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.Full, 10, 20, null, $"{URIPath}/daily?extended=full&page=10&limit=20")]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.Full, 10, 20, "game of thrones", $"{URIPath}/daily?query=game of thrones&extended=full&page=10&limit=20")]
        public void TestStreamingShowsGetRequestHasValidURIPath(TraktTimePeriod? timePeriod, TraktExtendedInfo? extendedInfo,
            int? page, int? limit, string? query, string expectedURIPath)
        {
            var streamingShowsGetRequest = new StreamingShowsGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit,
                Filter = query != null ? new TraktFilter { Query = query } : null
            };

            streamingShowsGetRequest.BuildUri();
            streamingShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestStreamingShowsGetRequestHasValidOAuthRequirement()
        {
            var streamingShowsGetRequest = new StreamingShowsGetRequest();
            streamingShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestStreamingShowsGetRequestIsGetRequest()
        {
            var streamingShowsGetRequest = new StreamingShowsGetRequest();
            streamingShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestStreamingShowsGetRequestHasCorrectRequestObjectType()
        {
            var streamingShowsGetRequest = new StreamingShowsGetRequest();
            streamingShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
