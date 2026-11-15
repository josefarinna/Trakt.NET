using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetCommentReactionSummaryTests
    {
        private const uint CommentID = 190U;
        private static readonly string GetCommentReactionSummaryUri = $"comments/{CommentID}/reactions/summary";

        [Fact]
        public async Task TestGetCommentReactionSummary()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactionsummary.json");

            TraktClient client = ModuleTestUtility.GetClient(GetCommentReactionSummaryUri, responseContent);
            TraktResponse<TraktCommentReactionSummary> response = await client.Comments.GetCommentReactionSummaryAsync(CommentID, TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktCommentReactionSummary summary = response.Content;
            summary.ReactionCount.ShouldBe(15);
            summary.UserCount.ShouldBe(12);
            summary.Distribution.ShouldNotBeNull();
            summary.Distribution.Count.ShouldBe(2);
            summary.Distribution["like"].ShouldBe(10);
            summary.Distribution["heart"].ShouldBe(5);
        }

        [Fact]
        public async Task TestGetCommentReactionSummaryThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactionsummary.json");

            TraktClient client = ModuleTestUtility.GetClient(GetCommentReactionSummaryUri, responseContent);

            Func<Task<TraktResponse<TraktCommentReactionSummary>>> act = () => client.Comments.GetCommentReactionSummaryAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestGetCommentReactionSummaryThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentReactionSummaryUri, statusCode);

            Func<Task<TraktResponse<TraktCommentReactionSummary>>> act = () => client.Comments.GetCommentReactionSummaryAsync(CommentID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
