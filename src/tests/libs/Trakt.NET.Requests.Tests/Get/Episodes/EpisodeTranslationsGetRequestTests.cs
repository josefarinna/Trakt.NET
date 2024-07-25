namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeTranslationsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/translations";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("", URIPath)]
        [InlineData(" ", URIPath)]
        [InlineData("en", $"{URIPath}/en")]
        public void TestEpisodeTranslationsGetRequestHasValidURIPath(string? language, string expectedURIPath)
        {
            var episodeTranslationsGetRequest = new EpisodeTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1,
                Language = language
            };

            episodeTranslationsGetRequest.BuildUri();
            episodeTranslationsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeTranslationsGetRequestHasValidOAuthRequirement()
        {
            var episodeTranslationsGetRequest = new EpisodeTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeTranslationsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodeTranslationsGetRequestIsGetRequest()
        {
            var episodeTranslationsGetRequest = new EpisodeTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeTranslationsGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
