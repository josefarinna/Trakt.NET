using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class UpdateCommentTests
    {
        private readonly string UpdateCommentUri = $"comments/{CommentID}";
        private const uint CommentID = 190U;
        private const string CommentText = "one two three four five reply";
        private const bool Spoiler = false;

        [Fact]
        public async Task TesteUpdateComment()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCommentUri, responseContent);

            TraktResponse<TraktCommentPostResponse> response = await client.Comments.UpdateCommentAsync(CommentID, CommentText, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktCommentPostResponse responseValue = response.Content;

            responseValue.ID.ShouldBe(76957U);
            responseValue.ParentID.ShouldBe(1234U);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-01T12:44:40Z"));
            responseValue.Comment.ShouldBe("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            responseValue.Spoiler.ShouldBe(false);
            responseValue.Review.ShouldBe(false);
            responseValue.Replies.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);

            responseValue.UserStats.ShouldNotBeNull();
            responseValue.UserStats.Rating.ShouldBe(8U);
            responseValue.UserStats.PlayCount.ShouldBe(1U);
            responseValue.UserStats.CompletedCount.ShouldBe(1U);

            responseValue.User.ShouldNotBeNull();
            responseValue.User.Username.ShouldBe("sean");
            responseValue.User.Private.ShouldBe(false);
            responseValue.User.Name.ShouldBe("Sean Rudford");
            responseValue.User.VIP.ShouldBe(true);
            responseValue.User.VIPEP.ShouldBe(true);

            responseValue.Sharing.ShouldNotBeNull();
            responseValue.Sharing.Twitter.ShouldBe(true);
            responseValue.Sharing.Tumblr.ShouldBe(true);
        }

        [Fact]
        public async Task TestUpdateCommentWithSpoiler()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCommentUri, responseContent);
            
            TraktResponse<TraktCommentPostResponse> response = await client.Comments.UpdateCommentAsync(CommentID, CommentText, Spoiler, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktCommentPostResponse responseValue = response.Content;

            responseValue.ID.ShouldBe(76957U);
            responseValue.ParentID.ShouldBe(1234U);
            responseValue.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-01T12:44:40Z"));
            responseValue.Comment.ShouldBe("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            responseValue.Spoiler.ShouldBe(false);
            responseValue.Review.ShouldBe(false);
            responseValue.Replies.ShouldBe(1U);
            responseValue.Likes.ShouldBe(2U);

            responseValue.UserStats.ShouldNotBeNull();
            responseValue.UserStats.Rating.ShouldBe(8U);
            responseValue.UserStats.PlayCount.ShouldBe(1U);
            responseValue.UserStats.CompletedCount.ShouldBe(1U);

            responseValue.User.ShouldNotBeNull();
            responseValue.User.Username.ShouldBe("sean");
            responseValue.User.Private.ShouldBe(false);
            responseValue.User.Name.ShouldBe("Sean Rudford");
            responseValue.User.VIP.ShouldBe(true);
            responseValue.User.VIPEP.ShouldBe(true);

            responseValue.Sharing.ShouldNotBeNull();
            responseValue.Sharing.Twitter.ShouldBe(true);
            responseValue.Sharing.Tumblr.ShouldBe(true);
        }

        [Fact]
        public async Task TestUpdateCommentWithGif()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCommentUri, responseContent);

            var gif = new TraktCommentGif
            {
                Url = "https://example.com/test.gif",
                Slug = "test-gif"
            };

            TraktResponse<TraktCommentPostResponse> response = await client.Comments.UpdateCommentAsync(CommentID, CommentText, Spoiler,
                gif, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdateCommentWithPostModel()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCommentUri, responseContent);

            var postModel = new TraktCommentUpdatePost
            {
                Comment = CommentText,
                Spoiler = Spoiler,
                Gif = new TraktCommentGif
                {
                    Url = "https://example.com/test.gif",
                    Slug = "test-gif"
                }
            };

            TraktResponse<TraktCommentPostResponse> response = await client.Comments.UpdateCommentAsync(CommentID, postModel, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestUpdateCommentThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCommentUri, statusCode);

            Func<Task<TraktResponse<TraktCommentPostResponse>>> act = () => client.Comments.UpdateCommentAsync(CommentID, CommentText, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
