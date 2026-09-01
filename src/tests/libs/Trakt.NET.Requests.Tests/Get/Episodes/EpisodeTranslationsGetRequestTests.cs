#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeTranslationsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/translations";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("", URIPath)]
        [InlineData(" ", URIPath)]
        [InlineData("en", $"{URIPath}?language=en")]
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
            episodeTranslationsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
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

            episodeTranslationsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
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

            episodeTranslationsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestEpisodeTranslationsGetRequestHasCorrectRequestObjectType()
        {
            var episodeTranslationsGetRequest = new EpisodeTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodeTranslationsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeTranslationsGetRequestValidate()
        {
            var episodeTranslationsGetRequest = new EpisodeTranslationsGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            Action act = () => episodeTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeTranslationsGetRequest = new EpisodeTranslationsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeTranslationsGetRequest = new EpisodeTranslationsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodeTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeTranslationsGetRequest = new EpisodeTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0,
                EpisodeNumber = 1
            };

            act = () => episodeTranslationsGetRequest.Validate();
            act.ShouldNotThrow();

            episodeTranslationsGetRequest = new EpisodeTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 0
            };

            act = () => episodeTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
