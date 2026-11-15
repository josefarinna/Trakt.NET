using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetWatchlistCommentsTests
    {
        private const string GetWatchlistCommentsUri = $"users/{Username}/watchlist/comments";
        private const string Username = "sean";
        private const uint CommentsCount = 1U;
        private const uint Page = 2U;
        private const uint CommentsLimit = 6U;
        private const TraktCommentSortOrder CommentSortOrder = TraktCommentSortOrder.Likes;

        [Theory]
        [InlineData(null, null, null, GetWatchlistCommentsUri)]
        [InlineData(CommentSortOrder, null, null, $"{GetWatchlistCommentsUri}/likes")]
        [InlineData(CommentSortOrder, Page, null, $"{GetWatchlistCommentsUri}/likes?page=2")]
        [InlineData(CommentSortOrder, null, CommentsLimit, $"{GetWatchlistCommentsUri}/likes?limit=6")]
        [InlineData(null, Page, null, $"{GetWatchlistCommentsUri}?page=2")]
        [InlineData(null, null, CommentsLimit, $"{GetWatchlistCommentsUri}?limit=6")]
        [InlineData(null, Page, CommentsLimit, $"{GetWatchlistCommentsUri}?page=2&limit=6")]
        [InlineData(CommentSortOrder, Page, CommentsLimit, $"{GetWatchlistCommentsUri}/likes?page=2&limit=6")]
        public async Task TestGetWatchlistComments(TraktCommentSortOrder? sortOrder, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, CommentsCount);

            TraktPagedResponse<TraktComment> response = await client.Users.GetWatchlistCommentsAsync(Username, sortOrder, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchlistCommentsWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchlistCommentsUri, responseContent, 1, 1, 10, CommentsCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktComment> response = await client.Users.GetWatchlistCommentsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchlistCommentsWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/watchlist/comments",
                responseContent, 1, 1, 10, CommentsCount);

            TraktPagedResponse<TraktComment> response = await client.Users.GetWatchlistCommentsAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchlistCommentsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={CommentsLimit}",
                responseContent, 2, 5, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, CommentSortOrder, 2, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchlistCommentsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={CommentsLimit}",
                responseContent, 2, 2, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, CommentSortOrder, 2, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchlistCommentsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={CommentsLimit}",
                responseContent, 1, 2, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, CommentSortOrder, 1, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchlistCommentsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, CommentSortOrder, 1, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchlistCommentsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={CommentsLimit}",
                responseContent, 2, 2, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, CommentSortOrder, 2, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={CommentsLimit}",
                responseContent, 1, 2, CommentsLimit, CommentsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchlistCommentsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={CommentsLimit}",
                responseContent, 1, 2, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, CommentSortOrder, 1, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={CommentsLimit}",
                responseContent, 2, 2, CommentsLimit, CommentsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetWatchlistCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetWatchlistCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Users.GetWatchlistCommentsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
