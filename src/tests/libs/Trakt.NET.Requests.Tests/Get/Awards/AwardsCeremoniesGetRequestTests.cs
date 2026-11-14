#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Awards
{
    public sealed class AwardsCeremoniesGetRequestTests
    {
        private const string URIPath = "awards/ceremonies";

        [Fact]
        public void TestAwardsCeremoniesGetRequestHasValidURIPath()
        {
            var request = new AwardsCeremoniesGetRequest();

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestAwardsCeremoniesGetRequestHasValidOAuthRequirement()
        {
            var request = new AwardsCeremoniesGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestAwardsCeremoniesGetRequestIsGetRequest()
        {
            var request = new AwardsCeremoniesGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestAwardsCeremoniesGetRequestHasCorrectRequestObjectType()
        {
            var request = new AwardsCeremoniesGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
