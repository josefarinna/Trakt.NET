#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Comments
{
    public sealed class CommentReactionAddPostRequestTests
    {
        private const string URIPath = "comments/123/reactions/like";

        [Fact]
        public void TestCommentReactionAddPostRequestHasValidURIPath()
        {
            var request = new CommentReactionAddPostRequest
            {
                Id = "123",
                Type = TraktReactionType.Like
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentReactionAddPostRequestHasValidOAuthRequirement()
        {
            var request = new CommentReactionAddPostRequest { Id = default!, Type = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCommentReactionAddPostRequestIsPostRequest()
        {
            var request = new CommentReactionAddPostRequest { Id = default!, Type = default! };
            request.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestCommentReactionAddPostRequestHasCorrectRequestObjectType()
        {
            var request = new CommentReactionAddPostRequest { Id = default!, Type = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentReactionAddPostRequestValidate()
        {
            var request = new CommentReactionAddPostRequest { Id = string.Empty, Type = TraktReactionType.Like };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new CommentReactionAddPostRequest { Id = "123", Type = TraktReactionType.Unspecified };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
