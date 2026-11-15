using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetCommentTests
    {
        private readonly string GetCommentUri = $"comments/{CommentID}";
        private const uint CommentID = 7149524U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetCommentWithoutExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comment.json");
            
            TraktClient client = ModuleTestUtility.GetClient(GetCommentUri, responseContent);
            
            TraktResponse<TraktComment> response = await client.Comments.GetCommentAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktComment responseValue = response.Content;

            responseValue.ID.ShouldBe(CommentID);
            responseValue.ParentID.ShouldBe(0U);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-04T16:25:36.000Z"));
            responseValue.Comment.ShouldBe("Comment content.");
            responseValue.Spoiler.ShouldBe(false);
            responseValue.Review.ShouldBe(false);
            responseValue.Replies.ShouldBe(0U);
            responseValue.Likes.ShouldBe(0U);
            responseValue.UserStats.ShouldNotBeNull();
            responseValue.UserStats.Rating.ShouldBe(9U);
            responseValue.UserStats.PlayCount.ShouldBe(3U);
            responseValue.UserStats.CompletedCount.ShouldBe(1U);
            responseValue.User.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetCommentComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\comment.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentUri}?extended={ExtendedInfo.ToURI()}", responseContent);

            TraktResponse<TraktComment> response = await client.Comments.GetCommentAsync(CommentID, ExtendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktComment responseValue = response.Content;

            responseValue.ID.ShouldBe(CommentID);
            responseValue.ParentID.ShouldBe(0U);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-04T16:25:36.000Z"));
            responseValue.Comment.ShouldBe("Comment content.");
            responseValue.Spoiler.ShouldBe(false);
            responseValue.Review.ShouldBe(false);
            responseValue.Replies.ShouldBe(0U);
            responseValue.Likes.ShouldBe(0U);
            responseValue.UserStats.ShouldNotBeNull();
            responseValue.UserStats.Rating.ShouldBe(9U);
            responseValue.UserStats.PlayCount.ShouldBe(3U);
            responseValue.UserStats.CompletedCount.ShouldBe(1U);
            responseValue.User.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestGetCommentThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentUri, statusCode);

            Func<Task<TraktResponse<TraktComment>>> act = () => client.Comments.GetCommentAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
