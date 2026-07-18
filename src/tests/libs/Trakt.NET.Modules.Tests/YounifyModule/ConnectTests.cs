using System.Net;
using Shouldly;
using Xunit;

namespace TraktNET.YounifyModule
{
    public sealed class ConnectTests
    {
        private const string ConnectUri = "younify/connect";

        [Fact]
        public async Task TestConnect()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Younify\\connect.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectUri, responseContent);

            var post = new TraktYounifyConnectPost
            {
                ServiceId = "netflix",
                ReturnUrl = "https://trakt.tv/return"
            };

            TraktResponse<TraktYounifyConnectResponse> response =
                await client.Younify.ConnectAsync(post, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Url.ShouldBe("https://younify.trakt.tv/connect/netflix?token=abcdef");
        }

        [Fact]
        public async Task TestConnectThrowsArgumentNullException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktYounifyConnectResponse>>> act = () => client.Younify.ConnectAsync(null!, TestContext.Current.CancellationToken);
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
        public async Task TestConnectThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            var post = new TraktYounifyConnectPost
            {
                ServiceId = "netflix",
                ReturnUrl = "https://trakt.tv/return"
            };
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectUri, statusCode);

            Func<Task<TraktResponse<TraktYounifyConnectResponse>>> act = () => client.Younify.ConnectAsync(post, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
