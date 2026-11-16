using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class ReportCommentTests
    {
        private const uint CommentID = 190U;
        private static readonly string ReportCommentUri = $"comments/{CommentID}/report";

        [Fact]
        public async Task TestReportComment()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportCommentUri, HttpStatusCode.Created);

            TraktResponse response = await client.Comments.ReportCommentAsync(CommentID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestReportCommentThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportCommentUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Comments.ReportCommentAsync(CommentID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportCommentThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportCommentUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Comments.ReportCommentAsync(0, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task TestReportCommentThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportCommentUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Comments.ReportCommentAsync(CommentID, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Comments.ReportCommentAsync(CommentID, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Comments.ReportCommentAsync(CommentID, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
