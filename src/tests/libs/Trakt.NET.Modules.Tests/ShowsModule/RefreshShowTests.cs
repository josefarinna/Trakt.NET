using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class RefreshShowTests
    {
        private const string RefreshShowUriPrefix = "shows";
        private const string RefreshShowUriSuffix = "refresh";
        private const string RefreshShowUriWithSlug = RefreshShowUriPrefix + "/" + TestConstants.Shows.ShowSlug + "/" + RefreshShowUriSuffix;
        private static readonly string RefreshShowUri = $"{RefreshShowUriPrefix}/{TestConstants.Shows.ShowID}/{RefreshShowUriSuffix}";

        [Fact]
        public async Task TestRefreshShowWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{RefreshShowUriPrefix}/{TestConstants.Shows.ShowID}/{RefreshShowUriSuffix}", HttpStatusCode.Created);

            TraktResponse response = await client.Shows.RefreshShowAsync(TestConstants.Shows.ShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshShowWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshShowUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.RefreshShowAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestRefreshShowWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshShowUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.RefreshShowAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
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
        public async Task TestRefreshShowThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshShowUri, statusCode);

            try
            {
                await client.Shows.RefreshShowAsync(TestConstants.Shows.ShowID, TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestRefreshShowThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshShowUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Shows.RefreshShowAsync(default(TraktShowIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Shows.RefreshShowAsync(new TraktShowIDs(), TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.RefreshShowAsync(0, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
