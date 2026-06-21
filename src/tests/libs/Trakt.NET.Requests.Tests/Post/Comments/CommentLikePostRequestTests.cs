#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Comments
{
    public sealed class CommentLikePostRequestTests
    {
        private const string URIPath = "comments/123/like";

        [Fact]
        public void TestCommentLikePostRequestHasValidURIPath()
        {
            var commentLikePostRequest = new CommentLikePostRequest
            {
                Id = "123"
            };

            commentLikePostRequest.BuildUri();
            commentLikePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentLikePostRequestHasValidOAuthRequirement()
        {
            var commentLikePostRequest = new CommentLikePostRequest { Id = default! };
            commentLikePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCommentLikePostRequestIsPostRequest()
        {
            var commentLikePostRequest = new CommentLikePostRequest { Id = default! };
            commentLikePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestCommentLikePostRequestHasCorrectRequestObjectType()
        {
            var commentLikePostRequest = new CommentLikePostRequest { Id = default! };
            commentLikePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentLikePostRequestValidate()
        {
            var commentLikePostRequest = new CommentLikePostRequest { Id = string.Empty };
            Action act = () => commentLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentLikePostRequest = new CommentLikePostRequest { Id = "  " };
            act = () => commentLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentLikePostRequest = new CommentLikePostRequest { Id = "id with spaces" };
            act = () => commentLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
