namespace TraktNET.PostRequests.Shows
{
    public sealed class ShowRefreshPostRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/refresh";

        [Fact]
        public void TestShowRefreshPostRequestHasValidURIPath()
        {
            var showRefreshPostRequest = new ShowRefreshPostRequest
            {
                Id = ShowID
            };

            showRefreshPostRequest.BuildUri();
            showRefreshPostRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowRefreshPostRequestHasValidOAuthRequirement()
        {
            var showRefreshPostRequest = new ShowRefreshPostRequest { Id = ShowID };
            showRefreshPostRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowRefreshPostRequestIsPostRequest()
        {
            var showRefreshPostRequest = new ShowRefreshPostRequest { Id = ShowID };
            showRefreshPostRequest.Method.Should().Be(HttpMethod.Post);
        }
    }
}
