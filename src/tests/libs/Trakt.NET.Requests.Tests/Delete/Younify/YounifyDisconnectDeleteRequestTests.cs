#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Younify
{
    public sealed class YounifyDisconnectDeleteRequestTests
    {
        private const string ServiceId = "netflix";

        [Fact]
        public void TestYounifyDisconnectDeleteRequestHasValidURIPath()
        {
            var request = new YounifyDisconnectDeleteRequest { ServiceId = ServiceId };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"younify/users/services/{ServiceId}", UriKind.Relative));
        }

        [Fact]
        public void TestYounifyDisconnectDeleteRequestHasValidOAuthRequirement()
        {
            var request = new YounifyDisconnectDeleteRequest { ServiceId = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestYounifyDisconnectDeleteRequestIsDeleteRequest()
        {
            var request = new YounifyDisconnectDeleteRequest { ServiceId = default! };
            request.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestYounifyDisconnectDeleteRequestHasCorrectRequestObjectType()
        {
            var request = new YounifyDisconnectDeleteRequest { ServiceId = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestYounifyDisconnectDeleteRequestValidate()
        {
            var request = new YounifyDisconnectDeleteRequest { ServiceId = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new YounifyDisconnectDeleteRequest { ServiceId = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new YounifyDisconnectDeleteRequest { ServiceId = "id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
