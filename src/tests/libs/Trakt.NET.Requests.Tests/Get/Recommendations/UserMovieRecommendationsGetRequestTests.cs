#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Recommendations
{
    public sealed class UserMovieRecommendationsGetRequestTests
    {
        private const string URIPath = "recommendations/movies";

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
        public void TestUserMovieRecommendationsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userMovieRecommendationsGetRequest = new UserMovieRecommendationsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userMovieRecommendationsGetRequest.BuildUri();
            userMovieRecommendationsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserMovieRecommendationsGetRequestHasValidOAuthRequirement()
        {
            var userMovieRecommendationsGetRequest = new UserMovieRecommendationsGetRequest();
            userMovieRecommendationsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserMovieRecommendationsGetRequestIsGetRequest()
        {
            var userMovieRecommendationsGetRequest = new UserMovieRecommendationsGetRequest();
            userMovieRecommendationsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserMovieRecommendationsGetRequestHasCorrectRequestObjectType()
        {
            var userMovieRecommendationsGetRequest = new UserMovieRecommendationsGetRequest();
            userMovieRecommendationsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
