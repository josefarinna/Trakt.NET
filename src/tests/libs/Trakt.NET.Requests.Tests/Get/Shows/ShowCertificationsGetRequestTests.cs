namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowCertificationsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/certifications";

        [Fact]
        public void TestShowCertificationsGetRequestHasValidURIPath()
        {
            var showCertificationsGetRequest = new ShowCertificationsGetRequest { Id = ShowID };

            showCertificationsGetRequest.BuildUri();
            showCertificationsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowCertificationsGetRequestHasValidOAuthRequirement()
        {
            var showCertificationsGetRequest = new ShowCertificationsGetRequest { Id = ShowID };
            showCertificationsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowCertificationsGetRequestIsGetRequest()
        {
            var showCertificationsGetRequest = new ShowCertificationsGetRequest { Id = ShowID };
            showCertificationsGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
