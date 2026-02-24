#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeStatisticsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/stats";

        [Fact]
        public void TestEpisodeStatisticsGetRequestHasValidURIPath()
        {
            var episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeStatisticsGetRequest.BuildUri();
            episodeStatisticsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeStatisticsGetRequestHasValidOAuthRequirement()
        {
            var episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeStatisticsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodeStatisticsGetRequestIsGetRequest()
        {
            var episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeStatisticsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestEpisodeStatisticsGetRequestHasCorrectRequestObjectType()
        {
            var episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeStatisticsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeStatisticsGetRequestValidate()
        {
            var episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            Action act = () => episodeStatisticsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeStatisticsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeStatisticsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0,
                EpisodeNumber = 1
            };

            act = () => episodeStatisticsGetRequest.Validate();
            act.ShouldNotThrow();

            episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 0
            };

            act = () => episodeStatisticsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
