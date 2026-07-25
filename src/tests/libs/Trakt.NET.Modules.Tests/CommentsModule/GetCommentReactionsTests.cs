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
        public async Task TestGetCommentReactionsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?page=2", responseContent);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, page: 2U, cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestGetCommentReactionsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?limit=10", responseContent);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestGetCommentReactionsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?page=2&limit=10", responseContent);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, page: 2U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestGetCommentReactionsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?extended=full", responseContent);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, extendedInfo: TraktExtendedInfo.Full, cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestGetCommentReactionsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?extended=full&page=2&limit=10", responseContent);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, extendedInfo: TraktExtendedInfo.Full, page: 2U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestGetCommentReactionsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?page=2&limit=10", responseContent, 2, 5, 10, 1);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, page: 2U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentReactionsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?page=2&limit=10", responseContent, 2, 2, 10, 1);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, page: 2U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCommentReactionsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?page=1&limit=10", responseContent, 1, 2, 10, 1);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentReactionsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?page=1&limit=10", responseContent, 1, 1, 10, 1);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCommentReactionsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?page=2&limit=10", responseContent, 2, 2, 10, 1);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, page: 2U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetCommentReactionsUri}?page=1&limit=10", responseContent, 1, 2, 10, 1);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentReactionsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentReactionsUri}?page=1&limit=10", responseContent, 1, 2, 10, 1);
            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetCommentReactionsUri}?page=2&limit=10", responseContent, 2, 2, 10, 1);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
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
        public async Task TestGetCommentReactionsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentReactionsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktCommentUserReaction>>> act = () => client.Comments.GetCommentReactionsAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetCommentReactionsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentReactionsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktCommentUserReaction>>> act = () => client.Comments.GetCommentReactionsAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
