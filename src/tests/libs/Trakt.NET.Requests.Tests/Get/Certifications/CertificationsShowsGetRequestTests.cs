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
            certificationsShowsGetRequest.RequestUri.Should().Be(new Uri("certifications/shows", UriKind.Relative));
        }

        [Fact]
        public void TestCertificationsShowsGetRequestHasValidOAuthRequirement()
        {
            var certificationsShowsGetRequest = new CertificationsShowsGetRequest();
            certificationsShowsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCertificationsShowsGetRequestIsGetRequest()
        {
            var certificationsShowsGetRequest = new CertificationsShowsGetRequest();
            certificationsShowsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestCertificationsShowsGetRequestHasCorrectRequestObjectType()
        {
            var certificationsShowsGetRequest = new CertificationsShowsGetRequest();
            certificationsShowsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
