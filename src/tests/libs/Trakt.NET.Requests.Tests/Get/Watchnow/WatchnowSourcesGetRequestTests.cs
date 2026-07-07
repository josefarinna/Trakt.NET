#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Watchnow
{
    public sealed class WatchnowSourcesGetRequestTests
    {
        private const string URIPath = "watchnow/sources";

        [Fact]
        public void TestWatchnowSourcesGetRequestHasValidURIPath()
        {
            var request = new WatchnowSourcesGetRequest();

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestWatchnowSourcesGetRequestHasValidOAuthRequirement()
        {
            var request = new WatchnowSourcesGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestWatchnowSourcesGetRequestIsGetRequest()
        {
            var request = new WatchnowSourcesGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestWatchnowSourcesGetRequestValidate()
        {
            var request = new WatchnowSourcesGetRequest();
            Action act = () => request.Validate();
            act.ShouldNotThrow();
        }
    }
}
