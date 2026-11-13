#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class AnticipatedShowRecommendationsGetRequestTests
    {
        private const string URIPath = "shows/recommendations/anticipated";

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
        public void TestAnticipatedShowRecommendationsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var request = new AnticipatedShowRecommendationsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestAnticipatedShowRecommendationsGetRequestHasValidOAuthRequirement()
        {
            var request = new AnticipatedShowRecommendationsGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestAnticipatedShowRecommendationsGetRequestIsGetRequest()
        {
            var request = new AnticipatedShowRecommendationsGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestAnticipatedShowRecommendationsGetRequestHasCorrectRequestObjectType()
        {
            var request = new AnticipatedShowRecommendationsGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
