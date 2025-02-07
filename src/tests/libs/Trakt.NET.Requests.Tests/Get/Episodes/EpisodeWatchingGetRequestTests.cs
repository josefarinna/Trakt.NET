#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeWatchingGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/watching";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.VIP | TraktExtendedInfo.Full, $"{URIPath}?extended=full,vip")]
        public void TestEpisodeWatchingGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var episodeWatchingGetRequest = new EpisodeWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1,
                ExtendedInfo = extendedInfo
            };

            episodeWatchingGetRequest.BuildUri();
            episodeWatchingGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeWatchingGetRequestHasValidOAuthRequirement()
        {
            var episodeWatchingGetRequest = new EpisodeWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeWatchingGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodeWatchingGetRequestIsGetRequest()
        {
            var episodeWatchingGetRequest = new EpisodeWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeWatchingGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestEpisodeWatchingGetRequestHasCorrectRequestObjectType()
        {
            var episodeWatchingGetRequest = new EpisodeWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeWatchingGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeWatchingGetRequestValidate()
        {
            var episodeWatchingGetRequest = new EpisodeWatchingGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            Action act = () => episodeWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeWatchingGetRequest = new EpisodeWatchingGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeWatchingGetRequest = new EpisodeWatchingGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeWatchingGetRequest = new EpisodeWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0,
                EpisodeNumber = 1
            };

            act = () => episodeWatchingGetRequest.Validate();
            act.ShouldNotThrow();

            episodeWatchingGetRequest = new EpisodeWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 0
            };

            act = () => episodeWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
