using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetSyncPausedItemsTests
    {
        private const ulong SyncId = 12345UL;
        private const string GetSyncPausedItemsUri = "users/syncs/12345/paused";
        private const uint Page = 2;
        private const uint Limit = 4;
        private const uint ItemCount = 1;

        [Fact]
        public async Task TestGetSyncPausedItems()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_paused.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSyncPausedItemsUri, responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktUserSyncItem> response = await client.Users.GetSyncPausedItemsAsync(
                SyncId, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);

            TraktUserSyncItem item = response.Content[0];
            item.ShouldNotBeNull();
            item.Kind.ShouldBe(TraktUserSyncItemKind.History);
            item.Type.ShouldBe(TraktSyncItemType.Movie);
            item.Movie.ShouldNotBeNull();
            item.Movie.Title.ShouldBe("Fight Club");
        }

        [Fact]
        public async Task TestGetSyncPausedItemsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_paused.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncPausedItemsUri}?page={Page}",
                responseContent, Page, 1, 10, ItemCount);

            TraktPagedResponse<TraktUserSyncItem> response = await client.Users.GetSyncPausedItemsAsync(
                SyncId, page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetSyncPausedItemsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_paused.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncPausedItemsUri}?limit={Limit}",
                responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktUserSyncItem> response = await client.Users.GetSyncPausedItemsAsync(
                SyncId, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Limit.ShouldBe(Limit);
        }

        [Fact]
        public async Task TestGetSyncPausedItemsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_paused.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncPausedItemsUri}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktUserSyncItem> response = await client.Users.GetSyncPausedItemsAsync(
                SyncId, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(Page);
            response.Limit.ShouldBe(Limit);
        }

        [Fact]
        public async Task TestGetSyncPausedItemsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_paused.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncPausedItemsUri}?page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ItemCount);

            TraktPagedResponse<TraktUserSyncItem> response = await client.Users.GetSyncPausedItemsAsync(
                SyncId, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSyncPausedItemsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_paused.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncPausedItemsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserSyncItem> response = await client.Users.GetSyncPausedItemsAsync(
                SyncId, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSyncPausedItemsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_paused.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncPausedItemsUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserSyncItem> response = await client.Users.GetSyncPausedItemsAsync(
                SyncId, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSyncPausedItemsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_paused.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncPausedItemsUri}?page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktUserSyncItem> response = await client.Users.GetSyncPausedItemsAsync(
                SyncId, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSyncPausedItemsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_paused.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncPausedItemsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserSyncItem> response = await client.Users.GetSyncPausedItemsAsync(
                SyncId, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetOAuthClient(client, $"{GetSyncPausedItemsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSyncPausedItemsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\sync_paused.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncPausedItemsUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserSyncItem> response = await client.Users.GetSyncPausedItemsAsync(
                SyncId, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetOAuthClient(client, $"{GetSyncPausedItemsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
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
        public async Task TestGetSyncPausedItemsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSyncPausedItemsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserSyncItem>>> act = () => client.Users.GetSyncPausedItemsAsync(
                SyncId, cancellationToken: TestContext.Current.CancellationToken);

            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSyncPausedItemsThrowsRequestValidationException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSyncPausedItemsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktUserSyncItem>>> act = () => client.Users.GetSyncPausedItemsAsync(
                0UL, cancellationToken: TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
