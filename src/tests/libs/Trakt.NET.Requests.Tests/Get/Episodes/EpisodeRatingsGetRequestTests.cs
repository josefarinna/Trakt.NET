#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeRatingsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/ratings";

        [Fact]
        public void TestEpisodeRatingsGetRequestHasValidURIPath()
        {
            var episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeRatingsGetRequest.BuildUri();
            episodeRatingsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeRatingsGetRequestHasValidOAuthRequirement()
        {
            var episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeRatingsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodeRatingsGetRequestIsGetRequest()
        {
            var episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeRatingsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestEpisodeRatingsGetRequestHasCorrectRequestObjectType()
        {
            var episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeRatingsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeRatingsGetRequestValidate()
        {
            var episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            Action act = () => episodeRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0,
                EpisodeNumber = 1
            };

            act = () => episodeRatingsGetRequest.Validate();
            act.Should().NotThrow();

            episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 0
            };

            act = () => episodeRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
