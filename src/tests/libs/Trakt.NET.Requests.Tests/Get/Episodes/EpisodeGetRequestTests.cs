#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestEpisodeGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var episodeGetRequest = new EpisodeGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1,
                ExtendedInfo = extendedInfo
            };

            episodeGetRequest.BuildUri();
            episodeGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeGetRequestHasValidOAuthRequirement()
        {
            var episodeGetRequest = new EpisodeGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodeGetRequestIsGetRequest()
        {
            var episodeGetRequest = new EpisodeGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestEpisodeGetRequestHasCorrectRequestObjectType()
        {
            var episodeGetRequest = new EpisodeGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeGetRequestValidate()
        {
            var episodeGetRequest = new EpisodeGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            Action act = () => episodeGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeGetRequest = new EpisodeGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeGetRequest = new EpisodeGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeGetRequest = new EpisodeGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0,
                EpisodeNumber = 1
            };

            act = () => episodeGetRequest.Validate();
            act.ShouldNotThrow();

            episodeGetRequest = new EpisodeGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 0
            };

            act = () => episodeGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
