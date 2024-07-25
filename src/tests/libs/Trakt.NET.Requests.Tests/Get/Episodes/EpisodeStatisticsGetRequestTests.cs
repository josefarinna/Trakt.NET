namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeStatisticsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/stats";

        [Fact]
        public void TestEpisodeStatisticsGetRequestHasValidURIPath()
        {
            var episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeStatisticsGetRequest.BuildUri();
            episodeStatisticsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeStatisticsGetRequestHasValidOAuthRequirement()
        {
            var episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeStatisticsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodeStatisticsGetRequestIsGetRequest()
        {
            var episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeStatisticsGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
