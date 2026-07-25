#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Comments
{
    public sealed class CommentReactionAddPostRequestTests
    {
        private const string BaseURIPath = "comments/123/reactions";

        [Theory]
        [InlineData(TraktReactionType.Like, $"{BaseURIPath}/like")]
        [InlineData(TraktReactionType.Dislike, $"{BaseURIPath}/dislike")]
        [InlineData(TraktReactionType.Love, $"{BaseURIPath}/love")]
        [InlineData(TraktReactionType.Laugh, $"{BaseURIPath}/laugh")]
        [InlineData(TraktReactionType.Shocked, $"{BaseURIPath}/shocked")]
        [InlineData(TraktReactionType.Bravo, $"{BaseURIPath}/bravo")]
        [InlineData(TraktReactionType.Spoiler, $"{BaseURIPath}/spoiler")]
        public void TestCommentReactionAddPostRequestHasValidURIPath(TraktReactionType type, string expectedURIPath)
        {
            var request = new CommentReactionAddPostRequest
            {
                Id = 123,
                Type = type
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
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
            var request = new CommentReactionAddPostRequest { Id = 0, Type = TraktReactionType.Like };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new CommentReactionAddPostRequest { Id = 123, Type = TraktReactionType.Unspecified };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
