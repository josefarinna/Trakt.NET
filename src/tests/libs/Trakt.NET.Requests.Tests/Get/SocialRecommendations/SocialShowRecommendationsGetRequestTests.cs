#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Recommendations
{
    public sealed class SocialShowRecommendationsGetRequestTests
    {
        private const string URIPath = "social_recommendations/shows";

        [Theory]
        [InlineData(null, null, null, null, null, null, null, URIPath)]
        [InlineData(0u, null, null, null, null, null, null, URIPath)]
        [InlineData(7u, null, null, null, null, null, null, $"{URIPath}?watch_window=7")]
        [InlineData(null, true, null, null, null, null, null, $"{URIPath}?ignore_watched=true")]
        [InlineData(null, false, null, null, null, null, null, $"{URIPath}?ignore_watched=false")]
        [InlineData(null, null, true, null, null, null, null, $"{URIPath}?ignore_collected=true")]
        [InlineData(null, null, false, null, null, null, null, $"{URIPath}?ignore_collected=false")]
        [InlineData(null, null, null, true, null, null, null, $"{URIPath}?ignore_watchlisted=true")]
        [InlineData(null, null, null, false, null, null, null, $"{URIPath}?ignore_watchlisted=false")]
        [InlineData(null, null, null, null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, null, null, null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, null, null, null, 0, null, URIPath)]
        [InlineData(null, null, null, null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, null, null, null, 0, URIPath)]
        [InlineData(null, null, null, null, null, null, 10, $"{URIPath}?limit=10")]
        [InlineData(null, null, null, null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(7u, true, true, true, TraktExtendedInfo.Full, 2, 10, $"{URIPath}?watch_window=7&ignore_watched=true&ignore_collected=true&ignore_watchlisted=true&extended=full&page=2&limit=10")]
        public void TestSocialShowRecommendationsGetRequestHasValidURIPath(uint? watchWindow, bool? ignoreWatched, bool? ignoreCollected,
            bool? ignoreWatchlisted, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var request = new SocialShowRecommendationsGetRequest
            {
                WatchWindow = watchWindow,
                IgnoreWatched = ignoreWatched,
                IgnoreCollected = ignoreCollected,
                IgnoreWatchlisted = ignoreWatchlisted,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSocialShowRecommendationsGetRequestHasValidOAuthRequirement()
        {
            var request = new SocialShowRecommendationsGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSocialShowRecommendationsGetRequestIsGetRequest()
        {
            var request = new SocialShowRecommendationsGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSocialShowRecommendationsGetRequestHasCorrectRequestObjectType()
        {
            var request = new SocialShowRecommendationsGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
