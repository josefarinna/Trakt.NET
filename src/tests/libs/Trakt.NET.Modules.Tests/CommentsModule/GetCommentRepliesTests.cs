using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed partial class GetCommentRepliesTests
    {
        private const uint CommentID = 190U;
        private const string GetCommentRepliesUri = "comments";

        [Theory]
        [InlineData(null, null, null, $"{GetCommentRepliesUri}/190/replies", "Comments\\commentreplies.json")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{GetCommentRepliesUri}/190/replies", "Comments\\commentreplies.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetCommentRepliesUri}/190/replies?extended=full", "Comments\\commentreplies.json")]
        [InlineData(null, 1U, null, $"{GetCommentRepliesUri}/190/replies?page=1", "Comments\\commentreplies.json")]
        [InlineData(null, null, 10U, $"{GetCommentRepliesUri}/190/replies?limit=10", "Comments\\commentreplies.json")]
        [InlineData(TraktExtendedInfo.Full, 1U, 10U, $"{GetCommentRepliesUri}/190/replies?extended=full&page=1&limit=10", "Comments\\commentreplies.json")]
        public async Task TestGetCommentReplies(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);

            List<TraktComment> replies = [.. response.Content];

            for (int i = 0; i < 2; i++)
            {
                replies[i].ID.ShouldBe(76957U);
                replies[i].Comment.ShouldBe("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                replies[i].ParentID.ShouldBe(0U);
                replies[i].CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-01T12:44:40Z"));
                replies[i].Replies.ShouldBe(1U);
                replies[i].Likes.ShouldBe(2U);

                replies[i].UserStats.ShouldNotBeNull();
                replies[i].UserStats!.Rating.ShouldBe(8U);
                replies[i].UserStats!.PlayCount.ShouldBe(1U);
                replies[i].UserStats!.CompletedCount.ShouldBe(1U);

                replies[i].User.ShouldNotBeNull();
                replies[i].User!.Username.ShouldBe("WalterBishopj");
                replies[i].User!.Name.ShouldBe("Walter");
                replies[i].User!.Private.ShouldBe(false);
            }
        }

        [Fact]
        public async Task TestGetCommentRepliesPaging()
        {
            string requestUri = $"{GetCommentRepliesUri}/{CommentID}/replies?page=1&limit=4";
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, 1, 2, 4, 2);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 1, 4, TestContext.Current.CancellationToken);

            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(4U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetCommentRepliesUri}/{CommentID}/replies?page=2", responseContent, 2, 2, 4, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.ItemCount.ShouldBe(2U);
            response.Limit.ShouldBe(4U);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
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
        public async Task TestGetCommentRepliesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}/{CommentID}/replies", statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
