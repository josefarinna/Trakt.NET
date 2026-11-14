#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Awards
{
    public sealed class AwardsCatalogGetRequestTests
    {
        private const string URIPath = "awards";

        [Fact]
        public void TestAwardsCatalogGetRequestHasValidURIPath()
        {
            var request = new AwardsCatalogGetRequest();

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestAwardsCatalogGetRequestHasValidOAuthRequirement()
        {
            var request = new AwardsCatalogGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestAwardsCatalogGetRequestIsGetRequest()
        {
            var request = new AwardsCatalogGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestAwardsCatalogGetRequestHasCorrectRequestObjectType()
        {
            var request = new AwardsCatalogGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
