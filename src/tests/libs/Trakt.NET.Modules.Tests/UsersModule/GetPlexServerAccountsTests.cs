using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetPlexServerAccountsTests
    {
        private const string ServerId = "some_server_id";
        private const string GetPlexServerAccountsUri = $"users/settings/plex/servers/{ServerId}";

        [Fact]
        public async Task TestGetPlexServerAccounts()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\plexserveraccounts.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexServerAccountsUri, responseContent);
            TraktResponse<TraktPlexServerAccountsAndLibraries> response = await client.Users.GetPlexServerAccountsAsync(ServerId, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            response.Content.Accounts.ShouldNotBeNull();
            response.Content.Accounts[0].Name.ShouldBe("account1");

            response.Content.Libraries.ShouldNotBeNull();
            response.Content.Libraries[0].Title.ShouldBe("Movies");
            response.Content.Libraries[0].Selected.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPlexServerAccountsThrowsArgumentNullException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexServerAccountsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktPlexServerAccountsAndLibraries>>> act = () => client.Users.GetPlexServerAccountsAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.GetPlexServerAccountsAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
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
        public async Task TestGetPlexServerAccountsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexServerAccountsUri, statusCode);

            Func<Task<TraktResponse<TraktPlexServerAccountsAndLibraries>>> act = () => client.Users.GetPlexServerAccountsAsync(ServerId, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
