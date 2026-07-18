#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Younify
{
    public sealed class YounifyConnectPostRequestTests
    {
        [Fact]
        public void TestYounifyConnectPostRequestHasValidURIPath()
        {
            var request = new YounifyConnectPostRequest
            {
                TraktYounifyConnectPost = new TraktYounifyConnectPost
                {
                    ServiceId = "netflix",
                    ReturnUrl = "https://trakt.tv/return"
                }
            };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("younify/connect", UriKind.Relative));
        }

        [Fact]
        public void TestYounifyConnectPostRequestHasValidOAuthRequirement()
        {
            var request = new YounifyConnectPostRequest { TraktYounifyConnectPost = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestYounifyConnectPostRequestIsPostRequest()
        {
            var request = new YounifyConnectPostRequest { TraktYounifyConnectPost = default! };
            request.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestYounifyConnectPostRequestHasCorrectRequestObjectType()
        {
            var request = new YounifyConnectPostRequest { TraktYounifyConnectPost = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestYounifyConnectPostRequestValidate()
        {
            var request = new YounifyConnectPostRequest { TraktYounifyConnectPost = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
