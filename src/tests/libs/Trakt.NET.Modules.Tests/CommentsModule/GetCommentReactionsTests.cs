using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetCommentReactionsTests
    {
        private const uint CommentID = 190U;
        private static readonly string GetCommentReactionsUri = $"comments/{CommentID}/reactions";

        [Theory]
        [InlineData(null, null, null, "comments/190/reactions")]
        [InlineData(null, 2U, null, "comments/190/reactions?page=2")]
        [InlineData(null, null, 10U, "comments/190/reactions?limit=10")]
        [InlineData(null, 2U, 10U, "comments/190/reactions?page=2&limit=10")]
        [InlineData(TraktExtendedInfo.Full, null, null, "comments/190/reactions?extended=full")]
        [InlineData(TraktExtendedInfo.Full, 2U, 10U, "comments/190/reactions?extended=full&page=2&limit=10")]
        public async Task TestGetCommentReactions(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreactions.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktPagedResponse<TraktCommentUserReaction> response = await client.Comments.GetCommentReactionsAsync(CommentID, extendedInfo, page, limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetCommentReactionsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
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
