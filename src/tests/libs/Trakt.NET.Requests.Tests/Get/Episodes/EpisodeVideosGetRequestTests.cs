#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeVideosGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/videos";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestEpisodeVideosGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var episodeVideosGetRequest = new EpisodeVideosGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1,
                ExtendedInfo = extendedInfo
            };

            episodeVideosGetRequest.BuildUri();
            episodeVideosGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeVideosGetRequestHasValidOAuthRequirement()
        {
            var episodeVideosGetRequest = new EpisodeVideosGetRequest { ShowId = default!, SeasonNumber = default!, EpisodeNumber = default! };
            episodeVideosGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodeVideosGetRequestIsGetRequest()
        {
            var episodeVideosGetRequest = new EpisodeVideosGetRequest { ShowId = default!, SeasonNumber = default!, EpisodeNumber = default! };
            episodeVideosGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestEpisodeVideosGetRequestHasCorrectRequestObjectType()
        {
            var episodeVideosGetRequest = new EpisodeVideosGetRequest { ShowId = default!, SeasonNumber = default!, EpisodeNumber = default! };
            episodeVideosGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeVideosGetRequestValidate()
        { 
            var episodeVideosGetRequest = new EpisodeVideosGetRequest { ShowId = string.Empty, SeasonNumber = default!, EpisodeNumber = default! };
            Action act = () => episodeVideosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeVideosGetRequest = new EpisodeVideosGetRequest { ShowId = "  ", SeasonNumber = default!, EpisodeNumber = default! };
            act = () => episodeVideosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeVideosGetRequest = new EpisodeVideosGetRequest { ShowId = "id with spaces", SeasonNumber = default!, EpisodeNumber = default! };
            act = () => episodeVideosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeVideosGetRequest = new EpisodeVideosGetRequest { ShowId = default!, SeasonNumber = default!, EpisodeNumber = 0 };
            act = () => episodeVideosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
