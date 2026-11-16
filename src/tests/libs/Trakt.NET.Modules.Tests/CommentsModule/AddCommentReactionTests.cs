using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class AddCommentReactionTests
    {
        private const uint CommentID = 190U;
        private static readonly string AddCommentReactionUri = $"comments/{CommentID}/reactions/like";

        [Fact]
        public async Task TestAddCommentReaction()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddCommentReactionUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Comments.AddCommentReactionAsync(CommentID, TraktReactionType.Like, TestContext.Current.CancellationToken);
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestAddCommentReactionThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddCommentReactionUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Comments.AddCommentReactionAsync(0, TraktReactionType.Like, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Comments.AddCommentReactionAsync(CommentID, TraktReactionType.Unspecified, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestAddCommentReactionThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddCommentReactionUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Comments.AddCommentReactionAsync(CommentID, TraktReactionType.Like, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
