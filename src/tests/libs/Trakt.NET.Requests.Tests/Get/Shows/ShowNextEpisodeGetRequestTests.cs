namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowNextEpisodeGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/next_episode";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestShowNextEpisodeGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest
            {
                Id = ShowID,
                ExtendedInfo = extendedInfo
            };

            showNextEpisodeGetRequest.BuildUri();
            showNextEpisodeGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowNextEpisodeGetRequestHasValidOAuthRequirement()
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = ShowID };
            showNextEpisodeGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowNextEpisodeGetRequestIsGetRequest()
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = ShowID };
            showNextEpisodeGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
