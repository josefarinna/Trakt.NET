namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeRatingsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/ratings";

        [Fact]
        public void TestEpisodeRatingsGetRequestHasValidURIPath()
        {
            var episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeRatingsGetRequest.BuildUri();
            episodeRatingsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeRatingsGetRequestHasValidOAuthRequirement()
        {
            var episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeRatingsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodeRatingsGetRequestIsGetRequest()
        {
            var episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeRatingsGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
