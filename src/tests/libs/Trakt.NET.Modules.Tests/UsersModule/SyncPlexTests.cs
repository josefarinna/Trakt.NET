using System;
using System.Net;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace TraktNET.UsersModule
{
    public sealed class SyncPlexTests
    {
        private const string SyncPlexUri = "users/settings/plex/sync";

        [Fact]
        public async Task TestSyncPlex()
        {
            var syncPost = new TraktPlexSyncPost
            {
                ServerId = "server1",
                AllData = true
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(SyncPlexUri, HttpStatusCode.Created);
            TraktResponse response = await client.Users.SyncPlexAsync(syncPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestSyncPlexThrowsArgumentNullException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(SyncPlexUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Users.SyncPlexAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
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
        public async Task TestSyncPlexThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            var syncPost = new TraktPlexSyncPost();
            TraktClient client = ModuleTestUtility.GetOAuthClient(SyncPlexUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.SyncPlexAsync(syncPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
