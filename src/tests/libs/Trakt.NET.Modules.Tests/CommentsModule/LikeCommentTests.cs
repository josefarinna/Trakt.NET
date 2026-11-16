using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class LikeCommentTests
    {
        private const uint CommentID = 190U;
        private static readonly string LikeCommentUri = $"comments/{CommentID}/like";

        [Fact]
        public async Task TestLikeComment()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(LikeCommentUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Comments.LikeCommentAsync(CommentID, TestContext.Current.CancellationToken);
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestLikeCommentThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(LikeCommentUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Comments.LikeCommentAsync(CommentID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
