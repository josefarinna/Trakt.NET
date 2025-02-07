#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Certifications
{
    public sealed class CertificationsShowsGetRequestTests
    {
        [Fact]
        public void TestCertificationsShowsGetRequestHasValidURIPath()
        {
            var certificationsShowsGetRequest = new CertificationsShowsGetRequest();

            certificationsShowsGetRequest.BuildUri();
            certificationsShowsGetRequest.RequestUri.ShouldBe(new Uri("certifications/shows", UriKind.Relative));
        }

        [Fact]
        public void TestCertificationsShowsGetRequestHasValidOAuthRequirement()
        {
            var certificationsShowsGetRequest = new CertificationsShowsGetRequest();
            certificationsShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCertificationsShowsGetRequestIsGetRequest()
        {
            var certificationsShowsGetRequest = new CertificationsShowsGetRequest();
            certificationsShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCertificationsShowsGetRequestHasCorrectRequestObjectType()
        {
            var certificationsShowsGetRequest = new CertificationsShowsGetRequest();
            certificationsShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
