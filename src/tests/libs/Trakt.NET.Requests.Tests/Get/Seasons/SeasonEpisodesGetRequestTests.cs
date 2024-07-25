namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonEpisodesGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData("", null, URIPath)]
        [InlineData("en", null, $"{URIPath}?translations=en")]
        [InlineData(null, TraktExtendedInfo.None, URIPath)]
        [InlineData(null, TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        [InlineData("", TraktExtendedInfo.None, URIPath)]
        [InlineData("en", TraktExtendedInfo.None, $"{URIPath}?translations=en")]
        [InlineData("", TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        [InlineData("en", TraktExtendedInfo.Full, $"{URIPath}?translations=en&extended=full")]
        public void TestSeasonEpisodesGetRequestHasValidURIPath(string? translations, TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var seasonEpisodesGetRequest = new SeasonEpisodesGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                Translations = translations,
                ExtendedInfo = extendedInfo
            };

            seasonEpisodesGetRequest.BuildUri();
            seasonEpisodesGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonEpisodesGetRequestHasValidOAuthRequirement()
        {
            var seasonEpisodesGetRequest = new SeasonEpisodesGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonEpisodesGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonEpisodesGetRequestIsGetRequest()
        {
            var seasonEpisodesGetRequest = new SeasonEpisodesGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonEpisodesGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
