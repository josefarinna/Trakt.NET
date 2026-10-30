#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Younify
{
    public sealed class YounifyRefreshServicePostRequestTests
    {
        [Fact]
        public void TestYounifyRefreshServicePostRequestHasValidURIPath()
        {
            var request = new YounifyRefreshServicePostRequest
            {
                TraktYounifyRefreshServicePost = new TraktYounifyRefreshServicePost
                {
                    ServiceId = "netflix",
                    SkipSync = true
                }
            };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("younify/users/refresh", UriKind.Relative));
        }

        [Fact]
        public void TestYounifyRefreshServicePostRequestHasValidOAuthRequirement()
        {
            var request = new YounifyRefreshServicePostRequest { TraktYounifyRefreshServicePost = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestYounifyRefreshServicePostRequestIsPostRequest()
        {
            var request = new YounifyRefreshServicePostRequest { TraktYounifyRefreshServicePost = default! };
            request.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestYounifyRefreshServicePostRequestHasCorrectRequestObjectType()
        {
            var request = new YounifyRefreshServicePostRequest { TraktYounifyRefreshServicePost = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestYounifyRefreshServicePostRequestValidate()
        {
            var request = new YounifyRefreshServicePostRequest { TraktYounifyRefreshServicePost = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
