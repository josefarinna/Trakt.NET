#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.SocialRecommendations
{
    public sealed class SocialMovieRecommendationsGetRequestTests
    {
        private const string URIPath = "social_recommendations/movies";

        [Theory]
        [InlineData(null, null, null, null, null, null, URIPath)]
        [InlineData(7u, null, null, null, null, null, $"{URIPath}?watch_window=7")]
        [InlineData(null, true, null, null, null, null, $"{URIPath}?ignore_watched=true")]
        [InlineData(null, null, true, null, null, null, $"{URIPath}?ignore_collected=true")]
        [InlineData(null, null, null, true, null, null, $"{URIPath}?ignore_watchlisted=true")]
        [InlineData(null, null, null, null, TraktExtendedInfo.Full, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, null, null, null, 10, $"{URIPath}?limit=10")]
        [InlineData(7u, true, true, true, TraktExtendedInfo.Full, 10, $"{URIPath}?watch_window=7&ignore_watched=true&ignore_collected=true&ignore_watchlisted=true&extended=full&limit=10")]
        public void TestSocialMovieRecommendationsGetRequestHasValidURIPath(uint? watchWindow, bool? ignoreWatched, bool? ignoreCollected,
            bool? ignoreWatchlisted, TraktExtendedInfo? extendedInfo, int? limit, string expectedURIPath)
        {
            var request = new SocialMovieRecommendationsGetRequest
            {
                WatchWindow = watchWindow,
                IgnoreWatched = ignoreWatched,
                IgnoreCollected = ignoreCollected,
                IgnoreWatchlisted = ignoreWatchlisted,
                ExtendedInfo = extendedInfo,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSocialMovieRecommendationsGetRequestHasValidOAuthRequirement()
        {
            var request = new SocialMovieRecommendationsGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSocialMovieRecommendationsGetRequestIsGetRequest()
        {
            var request = new SocialMovieRecommendationsGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSocialMovieRecommendationsGetRequestHasCorrectRequestObjectType()
        {
            var request = new SocialMovieRecommendationsGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
