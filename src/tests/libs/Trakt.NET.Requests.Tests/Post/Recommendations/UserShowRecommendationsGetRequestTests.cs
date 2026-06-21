#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Recommendations
{
    public sealed class UserShowRecommendationsGetRequestTests
    {
        private const string URIPath = "recommendations/shows";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        public void TestUserShowRecommendationsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userShowRecommendationsGetRequest = new UserShowRecommendationsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userShowRecommendationsGetRequest.BuildUri();
            userShowRecommendationsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserShowRecommendationsGetRequestHasValidOAuthRequirement()
        {
            var userShowRecommendationsGetRequest = new UserShowRecommendationsGetRequest();
            userShowRecommendationsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserShowRecommendationsGetRequestIsPostRequest()
        {
            var userShowRecommendationsGetRequest = new UserShowRecommendationsGetRequest();
            userShowRecommendationsGetRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserShowRecommendationsGetRequestHasCorrectRequestObjectType()
        {
            var userShowRecommendationsGetRequest = new UserShowRecommendationsGetRequest();
            userShowRecommendationsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
