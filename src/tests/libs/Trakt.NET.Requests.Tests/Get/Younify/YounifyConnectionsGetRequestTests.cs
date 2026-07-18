#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Younify
{
    public sealed class YounifyConnectionsGetRequestTests
    {
        [Fact]
        public void TestYounifyConnectionsGetRequestHasValidURIPath()
        {
            var request = new YounifyConnectionsGetRequest();
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("younify/connections", UriKind.Relative));
        }

        [Fact]
        public void TestYounifyConnectionsGetRequestHasValidOAuthRequirement()
        {
            var request = new YounifyConnectionsGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestYounifyConnectionsGetRequestIsGetRequest()
        {
            var request = new YounifyConnectionsGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestYounifyConnectionsGetRequestHasCorrectRequestObjectType()
        {
            var request = new YounifyConnectionsGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
