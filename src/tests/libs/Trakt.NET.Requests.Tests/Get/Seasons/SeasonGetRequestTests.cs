namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/info";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSeasonGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var seasonGetRequest = new SeasonGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                ExtendedInfo = extendedInfo
            };

            seasonGetRequest.BuildUri();
            seasonGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonGetRequestHasValidOAuthRequirement()
        {
            var seasonGetRequest = new SeasonGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonGetRequestIsGetRequest()
        {
            var seasonGetRequest = new SeasonGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
