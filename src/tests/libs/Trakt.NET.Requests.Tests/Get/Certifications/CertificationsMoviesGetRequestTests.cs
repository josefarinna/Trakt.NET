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
            certificationsMoviesGetRequest.RequestUri.ShouldBe(new Uri("certifications/movies", UriKind.Relative));
        }

        [Fact]
        public void TestCertificationsMoviesGetRequestHasValidOAuthRequirement()
        {
            var certificationsMoviesGetRequest = new CertificationsMoviesGetRequest();
            certificationsMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCertificationsMoviesGetRequestIsGetRequest()
        {
            var certificationsMoviesGetRequest = new CertificationsMoviesGetRequest();
            certificationsMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCertificationsMoviesGetRequestHasCorrectRequestObjectType()
        {
            var certificationsMoviesGetRequest = new CertificationsMoviesGetRequest();
            certificationsMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
