#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Seasons
{
    public sealed class SeasonReportPostRequestTests
    {
        private const string URIPath = "shows/123/seasons/1/report";

        [Fact]
        public void TestSeasonReportPostRequestHasValidURIPath()
        {
            var seasonReportPostRequest = new SeasonReportPostRequest
            {
                ShowId = "123",
                SeasonNumber = 1,
                TraktReportPost = new TraktReportPost()
            };

            seasonReportPostRequest.BuildUri();
            seasonReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonReportPostRequestHasValidOAuthRequirement()
        {
            var seasonReportPostRequest = new SeasonReportPostRequest { ShowId = default!, SeasonNumber = default!, TraktReportPost = default! };
            seasonReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSeasonReportPostRequestIsPostRequest()
        {
            var seasonReportPostRequest = new SeasonReportPostRequest { ShowId = default!, SeasonNumber = default!, TraktReportPost = default! };
            seasonReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSeasonReportPostRequestHasCorrectRequestObjectType()
        {
            var seasonReportPostRequest = new SeasonReportPostRequest { ShowId = default!, SeasonNumber = default!, TraktReportPost = default! };
            seasonReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonReportPostRequestValidate()
        {
            var seasonReportPostRequest = new SeasonReportPostRequest { ShowId = string.Empty, SeasonNumber = 1, TraktReportPost = default! };
            Action act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonReportPostRequest = new SeasonReportPostRequest { ShowId = "  ", SeasonNumber = 1, TraktReportPost = default! };
            act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonReportPostRequest = new SeasonReportPostRequest { ShowId = "id with spaces", SeasonNumber = 1, TraktReportPost = default! };
            act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonReportPostRequest = new SeasonReportPostRequest { ShowId = "id", SeasonNumber = 1, TraktReportPost = default! };
            act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonReportPostRequest = new SeasonReportPostRequest { ShowId = "id", SeasonNumber = 1, TraktReportPost = new TraktReportPost() };
            act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            seasonReportPostRequest = new SeasonReportPostRequest { ShowId = "id", SeasonNumber = 1, TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
