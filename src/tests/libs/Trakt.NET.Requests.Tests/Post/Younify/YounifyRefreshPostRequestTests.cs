#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Younify
{
    public sealed class YounifyRefreshPostRequestTests
    {
        private const string ServiceId = "netflix";

        [Fact]
        public void TestYounifyRefreshPostRequestHasValidURIPath()
        {
            var request = new YounifyRefreshPostRequest { ServiceId = ServiceId };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"younify/users/refresh/{ServiceId}", UriKind.Relative));
        }

        [Fact]
        public void TestYounifyRefreshPostRequestHasValidOAuthRequirement()
        {
            var request = new YounifyRefreshPostRequest { ServiceId = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestYounifyRefreshPostRequestIsPostRequest()
        {
            var request = new YounifyRefreshPostRequest { ServiceId = default! };
            request.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestYounifyRefreshPostRequestHasCorrectRequestObjectType()
        {
            var request = new YounifyRefreshPostRequest { ServiceId = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestYounifyRefreshPostRequestValidate()
        {
            var request = new YounifyRefreshPostRequest { ServiceId = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new YounifyRefreshPostRequest { ServiceId = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new YounifyRefreshPostRequest { ServiceId = "id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
