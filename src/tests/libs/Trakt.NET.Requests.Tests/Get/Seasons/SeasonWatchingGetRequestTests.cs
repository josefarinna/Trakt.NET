namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonWatchingGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/watching";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.VIP | TraktExtendedInfo.Full, $"{URIPath}?extended=full,vip")]
        public void TestSeasonWatchingGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                ExtendedInfo = extendedInfo
            };

            seasonWatchingGetRequest.BuildUri();
            seasonWatchingGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonWatchingGetRequestHasValidOAuthRequirement()
        {
            var seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonWatchingGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonWatchingGetRequestIsGetRequest()
        {
            var seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonWatchingGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
