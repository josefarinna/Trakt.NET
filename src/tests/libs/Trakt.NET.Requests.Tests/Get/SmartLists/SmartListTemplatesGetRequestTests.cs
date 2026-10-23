#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.SmartLists
{
    public sealed class SmartListTemplatesGetRequestTests
    {
        private const string URIPath = "smart-lists/templates";

        [Fact]
        public void TestSmartListTemplatesGetRequestHasValidURIPath()
        {
            var request = new SmartListTemplatesGetRequest();

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSmartListTemplatesGetRequestHasValidURIPathWithExtendedInfo()
        {
            var request = new SmartListTemplatesGetRequest
            {
                ExtendedInfo = TraktExtendedInfo.Full
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}?extended=full", UriKind.Relative));
        }

        [Fact]
        public void TestSmartListTemplatesGetRequestHasValidOAuthRequirement()
        {
            var request = new SmartListTemplatesGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Optional);
        }

        [Fact]
        public void TestSmartListTemplatesGetRequestIsGetRequest()
        {
            var request = new SmartListTemplatesGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }
    }
}
