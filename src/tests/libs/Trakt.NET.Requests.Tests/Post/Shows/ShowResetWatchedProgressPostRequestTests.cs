namespace TraktNET.PostRequests.Shows
{
    public sealed class ShowResetWatchedProgressPostRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/progress/watched/reset";

        [Fact]
        public void TestShowResetWatchedProgressPostRequestHasValidURIPath()
        {
            var showResetWatchedProgressPostRequest = new ShowResetWatchedProgressPostRequest
            {
                Id = ShowID
            };

            showResetWatchedProgressPostRequest.BuildUri();
            showResetWatchedProgressPostRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowResetWatchedProgressPostRequestHasValidOAuthRequirement()
        {
            var showResetWatchedProgressPostRequest = new ShowResetWatchedProgressPostRequest { Id = ShowID };
            showResetWatchedProgressPostRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowResetWatchedProgressPostRequestIsPostRequest()
        {
            var showResetWatchedProgressPostRequest = new ShowResetWatchedProgressPostRequest { Id = ShowID };
            showResetWatchedProgressPostRequest.Method.Should().Be(HttpMethod.Post);
        }
    }
}
