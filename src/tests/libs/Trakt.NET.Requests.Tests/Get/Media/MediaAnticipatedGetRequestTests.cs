#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Media
{
    public sealed class MediaAnticipatedGetRequestTests
    {
        private const string URIPath = "media/anticipated";

        [Fact]
        public void TestMediaAnticipatedGetRequestHasValidURIPath()
        {
            var mediaAnticipatedGetRequest = new MediaAnticipatedGetRequest();

            mediaAnticipatedGetRequest.BuildUri();
            mediaAnticipatedGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMediaAnticipatedGetRequestHasValidOAuthRequirement()
        {
            var mediaAnticipatedGetRequest = new MediaAnticipatedGetRequest();
            mediaAnticipatedGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMediaAnticipatedGetRequestIsGetRequest()
        {
            var mediaAnticipatedGetRequest = new MediaAnticipatedGetRequest();
            mediaAnticipatedGetRequest.Method.ShouldBe(HttpMethod.Get);
        }
    }
}
