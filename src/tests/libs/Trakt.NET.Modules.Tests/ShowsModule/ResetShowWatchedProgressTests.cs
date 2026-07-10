using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class ResetShowWatchedProgressTests
    {
        private const string ResetShowWatchedProgressUri = $"shows/{TestConstants.Shows.ShowID}/progress/watched/reset";
        private const string ResetShowWatchedProgressUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/progress/watched/reset";

        private static readonly DateTime ResetAt = new(2024, 9, 23, 19, 8, 15, DateTimeKind.Utc);
        private const string ResetAtValue = "2024-09-23T19:08:15.000Z";

        [Fact]
        public async Task TestResetShowWatchedProgressWithID()
        {
            string responseContent = $"{{\"reset_at\": \"{ResetAtValue}\"}}";
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUri, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(
                TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithSlug()
        {
            string responseContent = $"{{\"reset_at\": \"{ResetAtValue}\"}}";
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithIDs()
        {
            string responseContent = $"{{\"reset_at\": \"{ResetAtValue}\"}}";
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(
                TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithResetAt()
        {
            string responseContent = $"{{\"reset_at\": \"{ResetAtValue}\"}}";
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, ResetAt, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
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
        public async Task TestResetShowWatchedProgressThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, statusCode);

            Func<Task<TraktResponse<TraktShowResetWatchedProgress>>> act = () => client.Shows.ResetShowWatchedProgressAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktShowResetWatchedProgress>>> act = () => client.Shows.ResetShowWatchedProgressAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.ResetShowWatchedProgressAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
