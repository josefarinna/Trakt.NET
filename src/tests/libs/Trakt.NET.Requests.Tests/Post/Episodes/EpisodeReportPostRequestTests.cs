#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Episodes
{
    public sealed class EpisodeReportPostRequestTests
    {
        private const string URIPath = "shows/123/seasons/1/episodes/2/report";

        [Fact]
        public void TestEpisodeReportPostRequestHasValidURIPath()
        {
            var episodeReportPostRequest = new EpisodeReportPostRequest
            {
                ShowId = "123",
                SeasonNumber = 1,
                EpisodeNumber = 2,
                TraktReportPost = new TraktReportPost()
            };

            episodeReportPostRequest.BuildUri();
            episodeReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeReportPostRequestHasValidOAuthRequirement()
        {
            var episodeReportPostRequest = new EpisodeReportPostRequest { ShowId = default!, SeasonNumber = default!, EpisodeNumber = default!, TraktReportPost = default! };
            episodeReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestEpisodeReportPostRequestIsPostRequest()
        {
            var episodeReportPostRequest = new EpisodeReportPostRequest { ShowId = default!, SeasonNumber = default!, EpisodeNumber = default!, TraktReportPost = default! };
            episodeReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestEpisodeReportPostRequestHasCorrectRequestObjectType()
        {
            var episodeReportPostRequest = new EpisodeReportPostRequest { ShowId = default!, SeasonNumber = default!, EpisodeNumber = default!, TraktReportPost = default! };
            episodeReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeReportPostRequestValidate()
        {
            var episodeReportPostRequest = new EpisodeReportPostRequest { ShowId = string.Empty, SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = default! };
            Action act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeReportPostRequest = new EpisodeReportPostRequest { ShowId = "  ", SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = default! };
            act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeReportPostRequest = new EpisodeReportPostRequest { ShowId = "id with spaces", SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = default! };
            act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeReportPostRequest = new EpisodeReportPostRequest { ShowId = "id", SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = default! };
            act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeReportPostRequest = new EpisodeReportPostRequest { ShowId = "id", SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = new TraktReportPost() };
            act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            episodeReportPostRequest = new EpisodeReportPostRequest { ShowId = "id", SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
