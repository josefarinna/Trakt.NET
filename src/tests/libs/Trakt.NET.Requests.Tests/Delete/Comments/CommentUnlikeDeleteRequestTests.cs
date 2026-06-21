#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Comments
{
    public sealed class CommentUnlikeDeleteRequestTests
    {
        private const string URIPath = "comments/123/like";

        [Fact]
        public void TestCommentUnlikeDeleteRequestHasValidURIPath()
        {
            var commentUnlikeDeleteRequest = new CommentUnlikeDeleteRequest
            {
                Id = "123"
            };

            commentUnlikeDeleteRequest.BuildUri();
            commentUnlikeDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentUnlikeDeleteRequestHasValidOAuthRequirement()
        {
            var commentUnlikeDeleteRequest = new CommentUnlikeDeleteRequest { Id = default! };
            commentUnlikeDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCommentUnlikeDeleteRequestIsDeleteRequest()
        {
            var commentUnlikeDeleteRequest = new CommentUnlikeDeleteRequest { Id = default! };
            commentUnlikeDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestCommentUnlikeDeleteRequestHasCorrectRequestObjectType()
        {
            var commentUnlikeDeleteRequest = new CommentUnlikeDeleteRequest { Id = default! };
            commentUnlikeDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentUnlikeDeleteRequestValidate()
        {
            var commentUnlikeDeleteRequest = new CommentUnlikeDeleteRequest { Id = string.Empty };
            Action act = () => commentUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentUnlikeDeleteRequest = new CommentUnlikeDeleteRequest { Id = "  " };
            act = () => commentUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentUnlikeDeleteRequest = new CommentUnlikeDeleteRequest { Id = "id with spaces" };
            act = () => commentUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
