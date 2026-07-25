using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class ReportShowSeasonTests
    {
        private const string ReportSeasonUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/report";
        private const string ReportSeasonUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/report";
        private const uint SeasonNr = 1U;

        [Fact]
        public async Task TestReportShowSeasonWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUri, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.ReportShowSeasonAsync(TestConstants.Shows.TraktShowID, SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportShowSeasonWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.ReportShowSeasonAsync(TestConstants.Shows.ShowSlug, SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportShowSeasonWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.ReportShowSeasonAsync(TestConstants.Shows.ShowIDs, SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
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
        public async Task TestReportShowSeasonThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Shows.ReportShowSeasonAsync(TestConstants.Shows.TraktShowID, SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportShowSeasonThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Shows.ReportShowSeasonAsync(default(TraktShowIDs)!, SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Shows.ReportShowSeasonAsync(new TraktShowIDs(), SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.ReportShowSeasonAsync(0, SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.ReportShowSeasonAsync(default(string)!, SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.ReportShowSeasonAsync(string.Empty, SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.ReportShowSeasonAsync("show id", SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestReportShowSeasonThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Shows.ReportShowSeasonAsync(TestConstants.Shows.ShowSlug, SeasonNr, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Shows.ReportShowSeasonAsync(TestConstants.Shows.ShowSlug, SeasonNr, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Shows.ReportShowSeasonAsync(TestConstants.Shows.ShowSlug, SeasonNr, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
