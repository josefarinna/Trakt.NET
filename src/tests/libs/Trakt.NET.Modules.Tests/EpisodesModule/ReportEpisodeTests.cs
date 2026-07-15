using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class ReportEpisodeTests
    {
        private const string ReportEpisodeUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1/report";
        private const string ReportEpisodeUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/episodes/1/report";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;

        [Fact]
        public async Task TestReportEpisodeWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUri, HttpStatusCode.Created);

            TraktResponse response = await client.Episodes.ReportEpisodeAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportEpisodeWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Episodes.ReportEpisodeAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportEpisodeWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Episodes.ReportEpisodeAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
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
        public async Task TestReportEpisodeThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Episodes.ReportEpisodeAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportEpisodeThrowsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Episodes.ReportEpisodeAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.ReportEpisodeAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.ReportEpisodeAsync(0, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.ReportEpisodeAsync(default(string)!, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Episodes.ReportEpisodeAsync(string.Empty, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Episodes.ReportEpisodeAsync("show id", SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestReportEpisodeThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Episodes.ReportEpisodeAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Episodes.ReportEpisodeAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Episodes.ReportEpisodeAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
