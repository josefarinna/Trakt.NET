#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Shows
{
    public sealed class ShowEpisodeReportPostRequestTests
    {
        private const string URIPath = "shows/123/seasons/1/episodes/2/report";

        [Fact]
        public void TestShowEpisodeReportPostRequestHasValidURIPath()
        {
            var showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest
            {
                ShowId = "123",
                SeasonNumber = 1,
                EpisodeNumber = 2,
                TraktReportPost = new TraktReportPost()
            };

            showEpisodeReportPostRequest.BuildUri();
            showEpisodeReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowEpisodeReportPostRequestHasValidOAuthRequirement()
        {
            var showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest { ShowId = default!, SeasonNumber = default!, EpisodeNumber = default!, TraktReportPost = default! };
            showEpisodeReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowEpisodeReportPostRequestIsPostRequest()
        {
            var showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest { ShowId = default!, SeasonNumber = default!, EpisodeNumber = default!, TraktReportPost = default! };
            showEpisodeReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestShowEpisodeReportPostRequestHasCorrectRequestObjectType()
        {
            var showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest { ShowId = default!, SeasonNumber = default!, EpisodeNumber = default!, TraktReportPost = default! };
            showEpisodeReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestShowEpisodeReportPostRequestValidate()
        {
            var showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest { ShowId = string.Empty, SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = default! };
            Action act = () => showEpisodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest { ShowId = "  ", SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = default! };
            act = () => showEpisodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest { ShowId = "id with spaces", SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = default! };
            act = () => showEpisodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest { ShowId = "id", SeasonNumber = 1, EpisodeNumber = 0, TraktReportPost = default! };
            act = () => showEpisodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest { ShowId = "id", SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = default! };
            act = () => showEpisodeReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest { ShowId = "id", SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = new TraktReportPost() };
            act = () => showEpisodeReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            showEpisodeReportPostRequest = new ShowEpisodeReportPostRequest { ShowId = "id", SeasonNumber = 1, EpisodeNumber = 2, TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => showEpisodeReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
