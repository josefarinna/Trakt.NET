#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class StreamingMoviesGetRequestTests
    {
        private const string URIPath = "movies/streaming";

        [Theory]
        [InlineData(null, null, null, null, null, URIPath)]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, null, URIPath)]
        [InlineData(TraktTimePeriod.Daily, null, null, null, null, $"{URIPath}/daily")]
        [InlineData(null, TraktExtendedInfo.None, null, null, null, URIPath)]
        [InlineData(null, TraktExtendedInfo.Full, null, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, 10, null, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, null, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, null, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, null, null, "batman", $"{URIPath}?query=batman")]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.Full, 10, 20, null, $"{URIPath}/daily?extended=full&page=10&limit=20")]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.Full, 10, 20, "batman", $"{URIPath}/daily?query=batman&extended=full&page=10&limit=20")]
        public void TestStreamingMoviesGetRequestHasValidURIPath(TraktTimePeriod? timePeriod, TraktExtendedInfo? extendedInfo,
            int? page, int? limit, string? query, string expectedURIPath)
        {
            var streamingMoviesGetRequest = new StreamingMoviesGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit,
                Filter = query != null ? new TraktFilter { Query = query } : null
            };

            streamingMoviesGetRequest.BuildUri();
            streamingMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestStreamingMoviesGetRequestHasValidOAuthRequirement()
        {
            var streamingMoviesGetRequest = new StreamingMoviesGetRequest();
            streamingMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestStreamingMoviesGetRequestIsGetRequest()
        {
            var streamingMoviesGetRequest = new StreamingMoviesGetRequest();
            streamingMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestStreamingMoviesGetRequestHasCorrectRequestObjectType()
        {
            var streamingMoviesGetRequest = new StreamingMoviesGetRequest();
            streamingMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
