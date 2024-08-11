#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeStatisticsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
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
            episodeStatisticsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
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

            episodeStatisticsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
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

            episodeStatisticsGetRequest.Method.Should().Be(HttpMethod.Get);
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

            episodeStatisticsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Episode);
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
            act.Should().Throw<TraktRequestValidationException>();

            episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeStatisticsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeStatisticsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0,
                EpisodeNumber = 1
            };

            act = () => episodeStatisticsGetRequest.Validate();
            act.Should().NotThrow();

            episodeStatisticsGetRequest = new EpisodeStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 0
            };

            act = () => episodeStatisticsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
