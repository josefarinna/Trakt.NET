using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed partial class GetCommentLikesTests
    {
        private const uint CommentID = 190U;
        private const string GetCommentLikesUri = "comments";

        [Theory]
        [InlineData(null, null, null, $"{GetCommentLikesUri}/190/likes", "Comments\\commentlikes.json")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{GetCommentLikesUri}/190/likes", "Comments\\commentlikes.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetCommentLikesUri}/190/likes?extended=full", "Comments\\commentlikes.json")]
        [InlineData(null, 1U, null, $"{GetCommentLikesUri}/190/likes?page=1", "Comments\\commentlikes.json")]
        [InlineData(null, null, 10U, $"{GetCommentLikesUri}/190/likes?limit=10", "Comments\\commentlikes.json")]
        [InlineData(TraktExtendedInfo.Full, 1U, 10U, $"{GetCommentLikesUri}/190/likes?extended=full&page=1&limit=10", "Comments\\commentlikes.json")]
        public async Task TestGetCommentLikes(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);

            List<TraktCommentLike> likes = [.. response.Content];

            likes[0].LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            likes[0].User.ShouldNotBeNull();
            likes[0].User!.Username.ShouldBe("sean");

            likes[1].LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            likes[1].User.ShouldNotBeNull();
            likes[1].User!.Username.ShouldBe("justin");
        }

        [Fact]
        public async Task TestGetCommentLikesPaging()
        {
            string requestUri = $"{GetCommentLikesUri}/{CommentID}/likes?page=1&limit=4";
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentlikes.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, 1, 2, 4, 2);

            TraktPagedResponse<TraktCommentLike> response = await client.Comments.GetCommentLikesAsync(CommentID, null, 1, 4, TestContext.Current.CancellationToken);

            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(4U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetCommentLikesUri}/{CommentID}/likes?page=2", responseContent, 2, 2, 4, 2);

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
        public async Task TestGetCommentLikesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentLikesUri}/{CommentID}/likes", statusCode);

            Func<Task<TraktPagedResponse<TraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
