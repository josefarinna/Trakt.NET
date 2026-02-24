#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowCertificationsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/certifications";

        [Fact]
        public void TestShowCertificationsGetRequestHasValidURIPath()
        {
            var showCertificationsGetRequest = new ShowCertificationsGetRequest { Id = ShowID };

            showCertificationsGetRequest.BuildUri();
            showCertificationsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowCertificationsGetRequestHasValidOAuthRequirement()
        {
            var showCertificationsGetRequest = new ShowCertificationsGetRequest { Id = ShowID };
            showCertificationsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowCertificationsGetRequestIsGetRequest()
        {
            var showCertificationsGetRequest = new ShowCertificationsGetRequest { Id = ShowID };
            showCertificationsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowCertificationsGetRequestHasCorrectRequestObjectType()
        {
            var showCertificationsGetRequest = new ShowCertificationsGetRequest { Id = ShowID };
            showCertificationsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowCertificationsGetRequestValidate()
        {
            var showCertificationsGetRequest = new ShowCertificationsGetRequest { Id = string.Empty };

            Action act = () => showCertificationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showCertificationsGetRequest = new ShowCertificationsGetRequest { Id = "  " };

            act = () => showCertificationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showCertificationsGetRequest = new ShowCertificationsGetRequest { Id = "id with spaces" };

            act = () => showCertificationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
