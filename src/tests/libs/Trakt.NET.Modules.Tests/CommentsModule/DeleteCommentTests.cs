using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class DeleteCommentTests
    {
        private const uint CommentID = 190U;
        private static readonly string DeleteCommentUri = $"comments/{CommentID}";

        [Fact]
        public async Task TestDeleteComment()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DeleteCommentUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Comments.DeleteCommentAsync(CommentID, TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestDeleteCommentThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DeleteCommentUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Comments.DeleteCommentAsync(CommentID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
