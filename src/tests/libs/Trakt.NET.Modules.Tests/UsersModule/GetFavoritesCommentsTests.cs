using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetFavoritesCommentsTests
    {
        private const string GetFavoritesCommentsUri = $"users/{Username}/favorites/comments";
        private const string Username = "sean";
        private const uint CommentsCount = 1U;
        private const uint Page = 2U;
        private const uint CommentsLimit = 6U;
        private const TraktCommentSortOrder CommentSortOrder = TraktCommentSortOrder.Likes;

        [Theory]
        [InlineData(null, null, null, GetFavoritesCommentsUri)]
        [InlineData(CommentSortOrder, null, null, $"{GetFavoritesCommentsUri}/likes")]
        [InlineData(CommentSortOrder, Page, null, $"{GetFavoritesCommentsUri}/likes?page=2")]
        [InlineData(CommentSortOrder, null, CommentsLimit, $"{GetFavoritesCommentsUri}/likes?limit=6")]
        [InlineData(null, Page, null, $"{GetFavoritesCommentsUri}?page=2")]
        [InlineData(null, null, CommentsLimit, $"{GetFavoritesCommentsUri}?limit=6")]
        [InlineData(null, Page, CommentsLimit, $"{GetFavoritesCommentsUri}?page=2&limit=6")]
        [InlineData(CommentSortOrder, Page, CommentsLimit, $"{GetFavoritesCommentsUri}/likes?page=2&limit=6")]
        public async Task TestGetFavoritesComments(TraktCommentSortOrder? sortOrder, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, CommentsCount);

            TraktPagedResponse<TraktComment> response = await client.Users.GetFavoritesCommentsAsync(Username, sortOrder, page, limit, TestContext.Current.CancellationToken);

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
        public async Task TestGetFavoritesCommentsWithOAuthEnforced()
        {
			string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetFavoritesCommentsUri, responseContent, 1, 1, 10, CommentsCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktComment> response = await client.Users.GetFavoritesCommentsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesCommentsWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/favorites/comments",
                responseContent, 1, 1, 10, CommentsCount);

            TraktPagedResponse<TraktComment> response = await client.Users.GetFavoritesCommentsAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesCommentsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={CommentsLimit}",
                responseContent, 2, 5, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, CommentSortOrder, 2, CommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetFavoritesCommentsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={CommentsLimit}",
                responseContent, 2, 2, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, CommentSortOrder, 2, CommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetFavoritesCommentsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={CommentsLimit}",
                responseContent, 1, 2, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, CommentSortOrder, 1, CommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetFavoritesCommentsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, CommentSortOrder, 1, CommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetFavoritesCommentsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={CommentsLimit}",
                responseContent, 2, 2, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, CommentSortOrder, 2, CommentsLimit, TestContext.Current.CancellationToken);

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
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={CommentsLimit}",
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
        public async Task TestGetFavoritesCommentsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?page=1&limit={CommentsLimit}",
                responseContent, 1, 2, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, CommentSortOrder, 1, CommentsLimit, TestContext.Current.CancellationToken);

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
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?page=2&limit={CommentsLimit}",
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
        public async Task TestGetFavoritesCommentsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetFavoritesCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Users.GetFavoritesCommentsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
