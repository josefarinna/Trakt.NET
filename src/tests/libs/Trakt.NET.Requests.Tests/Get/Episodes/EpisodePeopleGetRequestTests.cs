namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodePeopleGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/people";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestEpisodePeopleGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1,
                ExtendedInfo = extendedInfo
            };

            episodePeopleGetRequest.BuildUri();
            episodePeopleGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodePeopleGetRequestHasValidOAuthRequirement()
        {
            var episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodePeopleGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodePeopleGetRequestIsGetRequest()
        {
            var episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodePeopleGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
