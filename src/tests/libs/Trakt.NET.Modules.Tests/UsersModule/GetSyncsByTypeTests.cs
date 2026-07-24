using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetSyncsByTypeTests
    {
        private const string GetSyncsUri = "users/syncs/plex";
        private const uint Page = 2;
        private const uint Limit = 4;
        private const uint ItemCount = 1;

        [Fact]
        public async Task TestGetSyncsByType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\syncs.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSyncsUri, responseContent, 1, 1, 10, ItemCount);

            TraktPagedResponse<TraktUserSync> response = await client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);

            TraktUserSync item = response.Content[0];
            item.ShouldNotBeNull();
            item.Id.ShouldBe(12345UL);
            item.Kind.ShouldBe(TraktUserSyncType.Plex);
            item.Source.ShouldBe("plex");
        }

        [Fact]
        public async Task TestGetSyncsByTypeWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\syncs.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncsUri}?page={Page}",
                responseContent, Page, 1, 10, ItemCount);

            TraktPagedResponse<TraktUserSync> response = await client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Page.ShouldBe(Page);
        }

        [Fact]
        public async Task TestGetSyncsByTypeWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\syncs.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncsUri}?limit={Limit}",
                responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktUserSync> response = await client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Limit.ShouldBe(Limit);
        }

        [Fact]
        public async Task TestGetSyncsByTypeWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\syncs.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncsUri}?page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktUserSync> response = await client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Page.ShouldBe(Page);
            response.Limit.ShouldBe(Limit);
        }

        [Fact]
        public async Task TestGetSyncsByTypePagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\syncs.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncsUri}?page=2&limit={Limit}",
                responseContent, 2, 5, Limit, ItemCount);

            TraktPagedResponse<TraktUserSync> response = await client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSyncsByTypePagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\syncs.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserSync> response = await client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSyncsByTypePagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\syncs.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncsUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserSync> response = await client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSyncsByTypePagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\syncs.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncsUri}?page=1&limit={Limit}",
                responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktUserSync> response = await client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSyncsByTypePagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\syncs.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncsUri}?page=2&limit={Limit}",
                responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserSync> response = await client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetOAuthClient(client, $"{GetSyncsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSyncsByTypePagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\syncs.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetSyncsUri}?page=1&limit={Limit}",
                responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktUserSync> response = await client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetOAuthClient(client, $"{GetSyncsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Page.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSyncsByTypeThrowsRequestValidationException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSyncsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktUserSync>>> act = () => client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Unspecified, cancellationToken: TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<TraktRequestValidationException>();
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
        public async Task TestGetSyncsByTypeThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetSyncsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserSync>>> act = () => client.Users.GetSyncsByTypeAsync(
                TraktUserSyncType.Plex, cancellationToken: TestContext.Current.CancellationToken);

            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
