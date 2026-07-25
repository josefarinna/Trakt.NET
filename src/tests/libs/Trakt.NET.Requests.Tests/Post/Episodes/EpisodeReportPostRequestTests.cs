#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Episodes
{
    public sealed class EpisodeReportPostRequestTests
    {
        private const string URIPath = "episodes/123/report";

        [Fact]
        public void TestEpisodeReportPostRequestHasValidURIPath()
        {
            var episodeReportPostRequest = new EpisodeReportPostRequest
            {
                Id = "123",
                TraktReportPost = new TraktReportPost()
            };

            episodeReportPostRequest.BuildUri();
            episodeReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeReportPostRequestHasValidOAuthRequirement()
        {
            var episodeReportPostRequest = new EpisodeReportPostRequest { Id = default!, TraktReportPost = default! };
            episodeReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestEpisodeReportPostRequestIsPostRequest()
        {
            var episodeReportPostRequest = new EpisodeReportPostRequest { Id = default!, TraktReportPost = default! };
            episodeReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestEpisodeReportPostRequestHasCorrectRequestObjectType()
        {
            var episodeReportPostRequest = new EpisodeReportPostRequest { Id = default!, TraktReportPost = default! };
            episodeReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeReportPostRequestValidate()
        {
            var episodeReportPostRequest = new EpisodeReportPostRequest { Id = string.Empty, TraktReportPost = default! };
            Action act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeReportPostRequest = new EpisodeReportPostRequest { Id = "  ", TraktReportPost = default! };
            act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeReportPostRequest = new EpisodeReportPostRequest { Id = "id with spaces", TraktReportPost = default! };
            act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeReportPostRequest = new EpisodeReportPostRequest { Id = "id", TraktReportPost = default! };
            act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            episodeReportPostRequest = new EpisodeReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost() };
            act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            episodeReportPostRequest = new EpisodeReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => episodeReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
