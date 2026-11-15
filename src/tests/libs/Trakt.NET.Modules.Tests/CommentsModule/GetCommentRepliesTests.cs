using System.Net;

namespace TraktNET.CommentsModule
{
    public sealed class GetCommentRepliesTests
    {
        private readonly string GetCommentRepliesUri = $"comments/{CommentID}/replies";
        private const uint CommentID = 190U;
        private const uint CommentRepliesItemCount = 2U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, "comments/190/replies")]
        [InlineData(ExtendedInfo, null, null, "comments/190/replies?extended=full")]
        [InlineData(null, Page, null, "comments/190/replies?page=2")]
        [InlineData(null, null, Limit, "comments/190/replies?limit=4")]
        [InlineData(null, Page, Limit, "comments/190/replies?page=2&limit=4")]
        [InlineData(ExtendedInfo, Page, null, "comments/190/replies?extended=full&page=2")]
        [InlineData(ExtendedInfo, null, Limit, "comments/190/replies?extended=full&limit=4")]
        [InlineData(ExtendedInfo, Page, Limit, "comments/190/replies?extended=full&page=2&limit=4")]
        public async Task TestGetCommentReplies(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetCommentRepliesUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, CommentRepliesItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCommentRepliesPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Comments\\commentreplies.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetCommentRepliesUri}?page=1&limit={Limit}",
                                                           responseContent, 1, 2, Limit, CommentRepliesItemCount);

            TraktPagedResponse<TraktComment> response = await client.Comments.GetCommentRepliesAsync(CommentID, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetCommentRepliesUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, CommentRepliesItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentRepliesItemCount);
            response.ItemCount.ShouldBe(CommentRepliesItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiCommentNotFoundException))]
        public async Task TestGetCommentRepliesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetCommentRepliesUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(CommentID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
