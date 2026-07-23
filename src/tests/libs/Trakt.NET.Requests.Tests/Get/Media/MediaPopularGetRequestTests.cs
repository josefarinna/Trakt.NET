#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Media
{
    public sealed class MediaPopularGetRequestTests
    {
        private const string URIPath = "media/popular";

        [Fact]
        public void TestMediaPopularGetRequestHasValidURIPath()
        {
            var mediaPopularGetRequest = new MediaPopularGetRequest();

            mediaPopularGetRequest.BuildUri();
            mediaPopularGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMediaPopularGetRequestHasValidOAuthRequirement()
        {
            var mediaPopularGetRequest = new MediaPopularGetRequest();
            mediaPopularGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMediaPopularGetRequestIsGetRequest()
        {
            var mediaPopularGetRequest = new MediaPopularGetRequest();
            mediaPopularGetRequest.Method.ShouldBe(HttpMethod.Get);
        }
    }
}
