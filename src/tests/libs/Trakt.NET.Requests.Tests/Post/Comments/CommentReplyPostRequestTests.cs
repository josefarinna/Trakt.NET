#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Comments
{
    public sealed class CommentReplyPostRequestTests
    {
        private const string URIPath = "comments/123/replies";

        [Fact]
        public void TestCommentReplyPostRequestHasValidURIPath()
        {
            var commentReplyPostRequest = new CommentReplyPostRequest
            {
                TraktCommentReplyPost = new TraktCommentReplyPost { Comment = default! },
                Id = 123
            };

            commentReplyPostRequest.BuildUri();
            commentReplyPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentReplyPostRequestHasValidOAuthRequirement()
        {
            var commentReplyPostRequest = new CommentReplyPostRequest { TraktCommentReplyPost = default!, Id = default! };
            commentReplyPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCommentReplyPostRequestIsPostRequest()
        {
            var commentReplyPostRequest = new CommentReplyPostRequest { TraktCommentReplyPost = default!, Id = default! };
            commentReplyPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestCommentReplyPostRequestHasCorrectRequestObjectType()
        {
            var commentReplyPostRequest = new CommentReplyPostRequest { TraktCommentReplyPost = default!, Id = default! };
            commentReplyPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentReplyPostRequestValidate()
        {
            var commentReplyPostRequest = new CommentReplyPostRequest { TraktCommentReplyPost = default!, Id = 0 };
            Action act = () => commentReplyPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentReplyPostRequest = new CommentReplyPostRequest { TraktCommentReplyPost = default!, Id = 123 };
            act = () => commentReplyPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentReplyPostRequest = new CommentReplyPostRequest { TraktCommentReplyPost = new TraktCommentReplyPost { Comment = default! }, Id = 123 };
            act = () => commentReplyPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
