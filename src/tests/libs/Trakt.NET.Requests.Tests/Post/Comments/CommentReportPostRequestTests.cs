#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Comments
{
    public sealed class CommentReportPostRequestTests
    {
        private const string URIPath = "comments/123/report";

        [Fact]
        public void TestCommentReportPostRequestHasValidURIPath()
        {
            var commentReportPostRequest = new CommentReportPostRequest
            {
                Id = "123",
                TraktReportPost = new TraktReportPost()
            };

            commentReportPostRequest.BuildUri();
            commentReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentReportPostRequestHasValidOAuthRequirement()
        {
            var commentReportPostRequest = new CommentReportPostRequest { Id = default!, TraktReportPost = default! };
            commentReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCommentReportPostRequestIsPostRequest()
        {
            var commentReportPostRequest = new CommentReportPostRequest { Id = default!, TraktReportPost = default! };
            commentReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestCommentReportPostRequestHasCorrectRequestObjectType()
        {
            var commentReportPostRequest = new CommentReportPostRequest { Id = default!, TraktReportPost = default! };
            commentReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentReportPostRequestValidate()
        {
            var commentReportPostRequest = new CommentReportPostRequest { Id = string.Empty, TraktReportPost = default! };
            Action act = () => commentReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentReportPostRequest = new CommentReportPostRequest { Id = "  ", TraktReportPost = default! };
            act = () => commentReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentReportPostRequest = new CommentReportPostRequest { Id = "id with spaces", TraktReportPost = default! };
            act = () => commentReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentReportPostRequest = new CommentReportPostRequest { Id = "id", TraktReportPost = default! };
            act = () => commentReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentReportPostRequest = new CommentReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost() };
            act = () => commentReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            commentReportPostRequest = new CommentReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => commentReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
