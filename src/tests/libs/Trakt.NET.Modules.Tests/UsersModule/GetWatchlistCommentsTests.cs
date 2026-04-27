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

        [Fact]
        public async Task TestGetWatchlistComments()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(GetWatchlistCommentsUri, responseContent, 1, 1, 10, CommentsCount);

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
        public async Task TestGetWatchlistCommentsWithSort()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}",
                responseContent, 1, 1, 10, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, CommentSortOrder, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestGetWatchlistCommentsWithSortAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?page={Page}",
                responseContent, 1, 1, 10, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, CommentSortOrder, Page, null, TestContext.Current.CancellationToken);

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
        public async Task TestGetWatchlistCommentsWithSortAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?limit={CommentsLimit}",
                responseContent, 1, 1, 10, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, CommentSortOrder, null, CommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetWatchlistCommentsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetWatchlistCommentsUri}?page={Page}",
                responseContent, Page, 1, 10, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchlistCommentsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetWatchlistCommentsUri}?limit={CommentsLimit}",
                responseContent, 1, 1, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, null, null, CommentsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)CommentsCount);
            response.ItemCount.ShouldBe(CommentsCount);
            response.Limit.ShouldBe(CommentsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchlistCommentsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetWatchlistCommentsUri}?page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, null, Page, CommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetWatchlistCommentsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\comments.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchlistCommentsUri}/{CommentSortOrder.ToURI()}?page={Page}&limit={CommentsLimit}",
                responseContent, Page, 1, CommentsLimit, CommentsCount);

            TraktPagedResponse<TraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(Username, CommentSortOrder, Page, CommentsLimit, TestContext.Current.CancellationToken);

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
        public async Task TestGetWatchlistCommentsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetWatchlistCommentsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Users.GetWatchlistCommentsAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
