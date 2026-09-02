#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeRatingsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/ratings";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.All, $"{URIPath}?extended=all")]
        public void TestEpisodeRatingsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedUri)
        {
            var episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1,
                ExtendedInfo = extendedInfo,
            };

            episodeRatingsGetRequest.BuildUri();
            episodeRatingsGetRequest.RequestUri.ShouldBe(new Uri(expectedUri, UriKind.Relative));
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

            episodeRatingsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
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

            episodeRatingsGetRequest.Method.ShouldBe(HttpMethod.Get);
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

            episodeRatingsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
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
            act.ShouldThrow<TraktRequestValidationException>();

            episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0,
                EpisodeNumber = 1
            };

            act = () => episodeRatingsGetRequest.Validate();
            act.ShouldNotThrow();

            episodeRatingsGetRequest = new EpisodeRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 0
            };

            act = () => episodeRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
