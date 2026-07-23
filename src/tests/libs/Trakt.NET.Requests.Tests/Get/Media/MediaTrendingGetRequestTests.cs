#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Media
{
    public sealed class MediaTrendingGetRequestTests
    {
        private const string URIPath = "media/trending";

        [Fact]
        public void TestMediaTrendingGetRequestHasValidURIPath()
        {
            var mediaTrendingGetRequest = new MediaTrendingGetRequest();

            mediaTrendingGetRequest.BuildUri();
            mediaTrendingGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMediaTrendingGetRequestHasValidOAuthRequirement()
        {
            var mediaTrendingGetRequest = new MediaTrendingGetRequest();
            mediaTrendingGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMediaTrendingGetRequestIsGetRequest()
        {
            var mediaTrendingGetRequest = new MediaTrendingGetRequest();
            mediaTrendingGetRequest.Method.ShouldBe(HttpMethod.Get);
        }
    }
}
