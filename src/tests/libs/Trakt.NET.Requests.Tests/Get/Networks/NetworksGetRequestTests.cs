#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Networks
{
    public sealed class NetworksGetRequestTests
    {
        private const string URIPath = "networks";

        [Fact]
        public void TestNetworksGetRequestHasValidURIPath()
        {
            var networksGetRequest = new NetworksGetRequest();

            networksGetRequest.BuildUri();
            networksGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestNetworksGetRequestHasValidOAuthRequirement()
        {
            var networksGetRequest = new NetworksGetRequest();
            networksGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestNetworksGetRequestIsGetRequest()
        {
            var networksGetRequest = new NetworksGetRequest();
            networksGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestNetworksGetRequestHasCorrectRequestObjectType()
        {
            var networksGetRequest = new NetworksGetRequest();
            networksGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
