#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Lists
{
    public sealed class ListReportPostRequestTests
    {
        private const string URIPath = "lists/123/report";

        [Fact]
        public void TestListReportPostRequestHasValidURIPath()
        {
            var listReportPostRequest = new ListReportPostRequest
            {
                Id = "123",
                TraktReportPost = new TraktReportPost()
            };

            listReportPostRequest.BuildUri();
            listReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestListReportPostRequestHasValidOAuthRequirement()
        {
            var listReportPostRequest = new ListReportPostRequest { Id = default!, TraktReportPost = default! };
            listReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestListReportPostRequestIsPostRequest()
        {
            var listReportPostRequest = new ListReportPostRequest { Id = default!, TraktReportPost = default! };
            listReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestListReportPostRequestHasCorrectRequestObjectType()
        {
            var listReportPostRequest = new ListReportPostRequest { Id = default!, TraktReportPost = default! };
            listReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestListReportPostRequestValidate()
        {
            var listReportPostRequest = new ListReportPostRequest { Id = string.Empty, TraktReportPost = default! };
            Action act = () => listReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listReportPostRequest = new ListReportPostRequest { Id = "  ", TraktReportPost = default! };
            act = () => listReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listReportPostRequest = new ListReportPostRequest { Id = "id with spaces", TraktReportPost = default! };
            act = () => listReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listReportPostRequest = new ListReportPostRequest { Id = "id", TraktReportPost = default! };
            act = () => listReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            listReportPostRequest = new ListReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost() };
            act = () => listReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            listReportPostRequest = new ListReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => listReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
