#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Comments
{
    public sealed class CommentReactionRemoveDeleteRequestTests
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
        public void TestCommentReactionRemoveDeleteRequestHasValidURIPath(TraktReactionType type, string expectedURIPath)
        {
            var request = new CommentReactionRemoveDeleteRequest
            {
                Id = 123,
                Type = type
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
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
            var request = new CommentReactionRemoveDeleteRequest { Id = 0, Type = TraktReactionType.Like };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new CommentReactionRemoveDeleteRequest { Id = 123, Type = TraktReactionType.Unspecified };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
