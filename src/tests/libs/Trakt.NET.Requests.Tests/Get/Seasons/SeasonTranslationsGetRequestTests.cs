namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonTranslationsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/translations";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("", URIPath)]
        [InlineData(" ", URIPath)]
        [InlineData("en", $"{URIPath}/en")]
        public void TestSeasonTranslationsGetRequestHasValidURIPath(string? language, string expectedURIPath)
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                Language = language
            };

            seasonTranslationsGetRequest.BuildUri();
            seasonTranslationsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonTranslationsGetRequestHasValidOAuthRequirement()
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonTranslationsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonTranslationsGetRequestIsGetRequest()
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonTranslationsGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
