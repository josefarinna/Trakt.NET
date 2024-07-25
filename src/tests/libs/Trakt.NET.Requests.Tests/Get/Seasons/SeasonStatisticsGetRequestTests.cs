namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonStatisticsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/stats";

        [Fact]
        public void TestSeasonStatisticsGetRequestHasValidURIPath()
        {
            var seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonStatisticsGetRequest.BuildUri();
            seasonStatisticsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonStatisticsGetRequestHasValidOAuthRequirement()
        {
            var seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonStatisticsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonStatisticsGetRequestIsGetRequest()
        {
            var seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonStatisticsGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
