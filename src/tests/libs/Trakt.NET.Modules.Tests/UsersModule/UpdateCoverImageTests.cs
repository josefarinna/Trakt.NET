using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UpdateCoverImageTests
    {
        private const string UpdateCoverUri = "users/set_cover";

        [Fact]
        public async Task TestUpdateCover()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCoverUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Users.UpdateCoverImageAsync(TraktCoverType.Movie, 123U, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
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
        public async Task TestUpdateCoverThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCoverUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.UpdateCoverImageAsync(TraktCoverType.Movie, 123U, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdateCoverArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateCoverUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Users.UpdateCoverImageAsync(TraktCoverType.Unspecified, 123U, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdateCoverImageAsync(TraktCoverType.Movie, 0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
