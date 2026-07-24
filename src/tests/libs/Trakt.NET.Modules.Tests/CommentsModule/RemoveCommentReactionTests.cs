using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class RemoveCommentReactionTests
    {
        private const uint CommentID = 190U;
        private static readonly string RemoveCommentReactionUri = $"comments/{CommentID}/reactions/like";

        [Fact]
        public async Task TestRemoveCommentReaction()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveCommentReactionUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Comments.RemoveCommentReactionAsync(CommentID, TraktReactionType.Like, TestContext.Current.CancellationToken);
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestRemoveCommentReactionThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveCommentReactionUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Comments.RemoveCommentReactionAsync(0, TraktReactionType.Like, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Comments.RemoveCommentReactionAsync(CommentID, TraktReactionType.Unspecified, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
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
        public async Task TestRemoveCommentReactionThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RemoveCommentReactionUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Comments.RemoveCommentReactionAsync(CommentID, TraktReactionType.Like, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
