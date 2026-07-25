#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Comments
{
    public sealed class CommentDeleteRequestTests
    {
        private const string URIPath = "comments/123";

        [Fact]
        public void TestCommentDeleteRequestHasValidURIPath()
        {
            var commentDeleteRequest = new CommentDeleteRequest
            {
                Id = 123
            };

            commentDeleteRequest.BuildUri();
            commentDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentDeleteRequestHasValidOAuthRequirement()
        {
            var commentDeleteRequest = new CommentDeleteRequest { Id = default! };
            commentDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCommentDeleteRequestIsDeleteRequest()
        {
            var commentDeleteRequest = new CommentDeleteRequest { Id = default! };
            commentDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestCommentDeleteRequestHasCorrectRequestObjectType()
        {
            var commentDeleteRequest = new CommentDeleteRequest { Id = default! };
            commentDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentDeleteRequestValidate()
        {
            var commentDeleteRequest = new CommentDeleteRequest { Id = 0 };
            Action act = () => commentDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
