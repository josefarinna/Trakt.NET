#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Shows
{
    public sealed class ShowReportPostRequestTests
    {
        private const string URIPath = "shows/123/report";

        [Fact]
        public void TestShowReportPostRequestHasValidURIPath()
        {
            var showReportPostRequest = new ShowReportPostRequest
            {
                Id = "123",
                TraktReportPost = new TraktReportPost()
            };

            showReportPostRequest.BuildUri();
            showReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowReportPostRequestHasValidOAuthRequirement()
        {
            var showReportPostRequest = new ShowReportPostRequest { Id = default!, TraktReportPost = default! };
            showReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowReportPostRequestIsPostRequest()
        {
            var showReportPostRequest = new ShowReportPostRequest { Id = default!, TraktReportPost = default! };
            showReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestShowReportPostRequestHasCorrectRequestObjectType()
        {
            var showReportPostRequest = new ShowReportPostRequest { Id = default!, TraktReportPost = default! };
            showReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowReportPostRequestValidate()
        {
            var showReportPostRequest = new ShowReportPostRequest { Id = string.Empty, TraktReportPost = default! };
            Action act = () => showReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showReportPostRequest = new ShowReportPostRequest { Id = "  ", TraktReportPost = default! };
            act = () => showReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showReportPostRequest = new ShowReportPostRequest { Id = "id with spaces", TraktReportPost = default! };
            act = () => showReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showReportPostRequest = new ShowReportPostRequest { Id = "id", TraktReportPost = default! };
            act = () => showReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showReportPostRequest = new ShowReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost() };
            act = () => showReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            showReportPostRequest = new ShowReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => showReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
