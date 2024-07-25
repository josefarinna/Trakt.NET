namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowAliasesGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/aliases";

        [Fact]
        public void TestShowAliasesGetRequestHasValidURIPath()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };

            showAliasesGetRequest.BuildUri();
            showAliasesGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowAliasesGetRequestHasValidOAuthRequirement()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };
            showAliasesGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowAliasesGetRequestIsGetRequest()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };
            showAliasesGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
