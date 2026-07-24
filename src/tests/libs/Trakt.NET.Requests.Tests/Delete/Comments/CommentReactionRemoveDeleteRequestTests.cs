#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Comments
{
    public sealed class CommentReactionRemoveDeleteRequestTests
    {
        private const string URIPath = "comments/123/reactions/like";

        [Fact]
        public void TestCommentReactionRemoveDeleteRequestHasValidURIPath()
        {
            var request = new CommentReactionRemoveDeleteRequest
            {
                Id = "123",
                Type = TraktReactionType.Like
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentReactionRemoveDeleteRequestHasValidOAuthRequirement()
        {
            var request = new CommentReactionRemoveDeleteRequest { Id = default!, Type = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCommentReactionRemoveDeleteRequestIsDeleteRequest()
        {
            var request = new CommentReactionRemoveDeleteRequest { Id = default!, Type = default! };
            request.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestCommentReactionRemoveDeleteRequestHasCorrectRequestObjectType()
        {
            var request = new CommentReactionRemoveDeleteRequest { Id = default!, Type = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentReactionRemoveDeleteRequestValidate()
        {
            var request = new CommentReactionRemoveDeleteRequest { Id = string.Empty, Type = TraktReactionType.Like };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new CommentReactionRemoveDeleteRequest { Id = "123", Type = TraktReactionType.Unspecified };
            Action act2 = () => request.Validate();
            act2.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
