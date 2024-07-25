namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowLastEpisodeGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/last_episode";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestShowLastEpisodeGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var showLastEpisodeGetRequest = new ShowLastEpisodeGetRequest
            {
                Id = ShowID,
                ExtendedInfo = extendedInfo
            };

            showLastEpisodeGetRequest.BuildUri();
            showLastEpisodeGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowLastEpisodeGetRequestHasValidOAuthRequirement()
        {
            var showLastEpisodeGetRequest = new ShowLastEpisodeGetRequest { Id = ShowID };
            showLastEpisodeGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowLastEpisodeGetRequestIsGetRequest()
        {
            var showLastEpisodeGetRequest = new ShowLastEpisodeGetRequest { Id = ShowID };
            showLastEpisodeGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
