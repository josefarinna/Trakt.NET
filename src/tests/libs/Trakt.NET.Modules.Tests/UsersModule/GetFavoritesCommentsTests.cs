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

        [Fact]
        public async Task TestGetFavoritesComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                GetFavoritesCommentsUri,
                responseContent, 1, 1, 10, CommentsCount);

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
        public async Task TestGetFavoritesCommentsWithSort()
        {
			string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}",
                responseContent, 1, 1, 10, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, CommentSortOrder, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetFavoritesCommentsWithSortAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?page={Page}",
                responseContent, 1, 1, 10, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, CommentSortOrder, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetFavoritesCommentsWithSortAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?limit={CommentsLimit}",
                responseContent, 1, 1, 10, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, CommentSortOrder, null, CommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetFavoritesCommentsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetFavoritesCommentsUri}?page={Page}",
                responseContent, Page, 1, 10, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesCommentsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetFavoritesCommentsUri}?limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, null, null, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesCommentsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetFavoritesCommentsUri}?page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, null, Page, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetFavoritesCommentsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetFavoritesCommentsUri}/{CommentSortOrder.ToURI()}?page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetFavoritesCommentsAsync(Username, CommentSortOrder, Page, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(Page);
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
        public async Task TestGetFavoritesCommentsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetFavoritesCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Users.GetFavoritesCommentsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
