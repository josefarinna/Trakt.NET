#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Shows
{
    public sealed class ShowSeasonReportPostRequestTests
    {
        private const string URIPath = "shows/123/seasons/1/report";

        [Fact]
        public void TestShowSeasonReportPostRequestHasValidURIPath()
        {
            var showSeasonReportPostRequest = new ShowSeasonReportPostRequest
            {
                ShowId = "123",
                SeasonNumber = 1,
                TraktReportPost = new TraktReportPost()
            };

            showSeasonReportPostRequest.BuildUri();
            showSeasonReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowSeasonReportPostRequestHasValidOAuthRequirement()
        {
            var showSeasonReportPostRequest = new ShowSeasonReportPostRequest { ShowId = default!, SeasonNumber = default!, TraktReportPost = default! };
            showSeasonReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowSeasonReportPostRequestIsPostRequest()
        {
            var showSeasonReportPostRequest = new ShowSeasonReportPostRequest { ShowId = default!, SeasonNumber = default!, TraktReportPost = default! };
            showSeasonReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestShowSeasonReportPostRequestHasCorrectRequestObjectType()
        {
            var showSeasonReportPostRequest = new ShowSeasonReportPostRequest { ShowId = default!, SeasonNumber = default!, TraktReportPost = default! };
            showSeasonReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestShowSeasonReportPostRequestValidate()
        {
            var showSeasonReportPostRequest = new ShowSeasonReportPostRequest { ShowId = string.Empty, SeasonNumber = 1, TraktReportPost = default! };
            Action act = () => showSeasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showSeasonReportPostRequest = new ShowSeasonReportPostRequest { ShowId = "  ", SeasonNumber = 1, TraktReportPost = default! };
            act = () => showSeasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showSeasonReportPostRequest = new ShowSeasonReportPostRequest { ShowId = "id with spaces", SeasonNumber = 1, TraktReportPost = default! };
            act = () => showSeasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showSeasonReportPostRequest = new ShowSeasonReportPostRequest { ShowId = "id", SeasonNumber = 1, TraktReportPost = default! };
            act = () => showSeasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showSeasonReportPostRequest = new ShowSeasonReportPostRequest { ShowId = "id", SeasonNumber = 1, TraktReportPost = new TraktReportPost() };
            act = () => showSeasonReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            showSeasonReportPostRequest = new ShowSeasonReportPostRequest { ShowId = "id", SeasonNumber = 1, TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => showSeasonReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
