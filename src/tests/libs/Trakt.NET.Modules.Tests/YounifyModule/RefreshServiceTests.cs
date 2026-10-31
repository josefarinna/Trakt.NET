using System.Net;
using Shouldly;
using Xunit;

namespace TraktNET.YounifyModule
{
    public sealed class RefreshServiceTests
    {
        private const string RefreshServiceUri = "younify/users/refresh";

        [Fact]
        public async Task TestRefreshService()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshServiceUri, HttpStatusCode.Created);

            var post = new TraktYounifyRefreshServicePost
            {
                ServiceId = "netflix",
                SkipSync = true
            };

            TraktResponse response = await client.Younify.RefreshServiceAsync(post, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestRefreshServiceThrowsValidationException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshServiceUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Younify.RefreshServiceAsync(null!, TestContext.Current.CancellationToken);
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
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVipValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestRefreshServiceThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var post = new TraktYounifyRefreshServicePost
            {
                ServiceId = "netflix",
                SkipSync = true
            };
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshServiceUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Younify.RefreshServiceAsync(post, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
