#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

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
            seasonEpisodesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonEpisodesGetRequestHasValidOAuthRequirement()
        {
            var seasonEpisodesGetRequest = new SeasonEpisodesGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonEpisodesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonEpisodesGetRequestIsGetRequest()
        {
            var seasonEpisodesGetRequest = new SeasonEpisodesGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonEpisodesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonEpisodesGetRequestHasCorrectRequestObjectType()
        {
            var seasonEpisodesGetRequest = new SeasonEpisodesGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonEpisodesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonEpisodesGetRequestValidate()
        {
            var seasonEpisodesGetRequest = new SeasonEpisodesGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1
            };

            Action act = () => seasonEpisodesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonEpisodesGetRequest = new SeasonEpisodesGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1
            };

            act = () => seasonEpisodesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonEpisodesGetRequest = new SeasonEpisodesGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1
            };

            act = () => seasonEpisodesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonEpisodesGetRequest = new SeasonEpisodesGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0
            };

            act = () => seasonEpisodesGetRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
