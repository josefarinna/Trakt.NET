using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetCommentReactionsTests
    {
        private const uint CommentID = 190U;
        private static readonly string GetCommentReactionsUri = $"comments/{CommentID}/reactions";

        [Fact]
        public async Task TestGetCommentReactions()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient(GetCommentReactionsUri, responseContent);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);

            TraktCommentUserReaction reactionItem = response.Content[0];
            reactionItem.ReactedAt.ShouldNotBeNull();
            reactionItem.Reaction.ShouldNotBeNull();
            reactionItem.Reaction.Type.ShouldBe(TraktReactionType.Like);
            reactionItem.User.ShouldNotBeNull();
            reactionItem.User.Username.ShouldBe("sean");
        }

        [Fact]
        public async Task TestGetCommentReactionsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient(GetCommentReactionsUri, responseContent);

            Func<Task<TraktPagedResponse<TraktCommentUserReaction>>> act = () => client.Comments.GetCommentReactionsAsync(0, cancellationToken: TestContext.Current.CancellationToken);
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
        public async Task TestGetCommentReactionsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentReactionsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktCommentUserReaction>>> act = () => client.Comments.GetCommentReactionsAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
