#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Seasons
{
    public sealed class SeasonReportPostRequestTests
    {
        private const string URIPath = "seasons/123/report";

        [Fact]
        public void TestSeasonReportPostRequestHasValidURIPath()
        {
            var seasonReportPostRequest = new SeasonReportPostRequest
            {
                Id = "123",
                TraktReportPost = new TraktReportPost()
            };

            seasonReportPostRequest.BuildUri();
            seasonReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonReportPostRequestHasValidOAuthRequirement()
        {
            var seasonReportPostRequest = new SeasonReportPostRequest { Id = default!, TraktReportPost = default! };
            seasonReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSeasonReportPostRequestIsPostRequest()
        {
            var seasonReportPostRequest = new SeasonReportPostRequest { Id = default!, TraktReportPost = default! };
            seasonReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSeasonReportPostRequestHasCorrectRequestObjectType()
        {
            var seasonReportPostRequest = new SeasonReportPostRequest { Id = default!, TraktReportPost = default! };
            seasonReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonReportPostRequestValidate()
        {
            var seasonReportPostRequest = new SeasonReportPostRequest { Id = string.Empty, TraktReportPost = default! };
            Action act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonReportPostRequest = new SeasonReportPostRequest { Id = "  ", TraktReportPost = default! };
            act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonReportPostRequest = new SeasonReportPostRequest { Id = "id with spaces", TraktReportPost = default! };
            act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonReportPostRequest = new SeasonReportPostRequest { Id = "id", TraktReportPost = default! };
            act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonReportPostRequest = new SeasonReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost() };
            act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            seasonReportPostRequest = new SeasonReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => seasonReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
