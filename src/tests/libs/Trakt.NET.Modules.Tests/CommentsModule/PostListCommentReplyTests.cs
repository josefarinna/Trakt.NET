using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class PostListCommentReplyTests
    {
        private const string PostListCommentUri = $"comments";
        private const string CommentText = "one two three four five reply";
        private readonly TraktListCommentPost listCommentPost = new()
        {
            List = new TraktList { IDs = new TraktListIDs { Trakt = 73640U } },
            Comment = CommentText
        };

        [Fact]
        public async Task TestPostListComment()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(PostListCommentUri, responseContent);

            TraktResponse<TraktCommentPostResponse> response = await client.Comments.PostListCommentAsync(listCommentPost, TestContext.Current.CancellationToken);

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
        public async Task TestPostListCommentWithSpoiler()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(PostListCommentUri, responseContent);

            TraktResponse<TraktCommentPostResponse> response = await client.Comments.PostListCommentAsync(listCommentPost, TestContext.Current.CancellationToken);

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
        public async Task TestPostListCommentWithSharing()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(PostListCommentUri, responseContent);

            TraktResponse<TraktCommentPostResponse> response = await client.Comments.PostListCommentAsync(listCommentPost, TestContext.Current.CancellationToken);

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
        public async Task TestPostListCommentComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(PostListCommentUri, responseContent);

            TraktResponse<TraktCommentPostResponse> response = await client.Comments.PostListCommentAsync(listCommentPost, TestContext.Current.CancellationToken);

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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestPostListCommentThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(PostListCommentUri, statusCode);

            Func<Task<TraktResponse<TraktCommentPostResponse>>> act = () => client.Comments.PostListCommentAsync(listCommentPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
