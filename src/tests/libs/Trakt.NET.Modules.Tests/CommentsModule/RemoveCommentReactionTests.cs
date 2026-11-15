using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class RemoveCommentReactionTests
    {
        private const uint CommentID = 190U;
        private static readonly string RemoveCommentReactionUri = $"comments/{CommentID}/reactions/like";

        [Fact]
        public async Task TestRemoveCommentReaction()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveCommentReactionUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Comments.RemoveCommentReactionAsync(CommentID, TraktReactionType.Like, TestContext.Current.CancellationToken);
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestRemoveCommentReactionThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveCommentReactionUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Comments.RemoveCommentReactionAsync(0, TraktReactionType.Like, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Comments.RemoveCommentReactionAsync(CommentID, TraktReactionType.Unspecified, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestRemoveCommentReactionThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveCommentReactionUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Comments.RemoveCommentReactionAsync(CommentID, TraktReactionType.Like, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
