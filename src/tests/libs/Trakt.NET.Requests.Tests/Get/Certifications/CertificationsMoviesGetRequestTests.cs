#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Certifications
{
    public sealed class CertificationsMoviesGetRequestTests
    {
        [Fact]
        public void TestCertificationsMoviesGetRequestHasValidURIPath()
        {
            var certificationsMoviesGetRequest = new CertificationsMoviesGetRequest();

            certificationsMoviesGetRequest.BuildUri();
            certificationsMoviesGetRequest.RequestUri.Should().Be(new Uri("certifications/movies", UriKind.Relative));
        }

        [Fact]
        public void TestCertificationsMoviesGetRequestHasValidOAuthRequirement()
        {
            var certificationsMoviesGetRequest = new CertificationsMoviesGetRequest();
            certificationsMoviesGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCertificationsMoviesGetRequestIsGetRequest()
        {
            var certificationsMoviesGetRequest = new CertificationsMoviesGetRequest();
            certificationsMoviesGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestCertificationsMoviesGetRequestHasCorrectRequestObjectType()
        {
            var certificationsMoviesGetRequest = new CertificationsMoviesGetRequest();
            certificationsMoviesGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
