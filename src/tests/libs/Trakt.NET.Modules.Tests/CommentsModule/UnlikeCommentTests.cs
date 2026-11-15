using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class UnlikeCommentTests
    {
        private readonly string UnlikeCommentUri = $"comments/{CommentID}/like";
        private const uint CommentID = 190U;

        [Fact]
        public async Task TestUnlikeComment()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UnlikeCommentUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Comments.UnlikeCommentAsync(CommentID, TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestUnlikeCommentThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UnlikeCommentUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Comments.UnlikeCommentAsync(CommentID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
