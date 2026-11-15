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
        public async Task TestReportShowSeasonThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Shows.ReportShowSeasonAsync(TestConstants.Shows.TraktShowID, SeasonNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportShowSeasonThrowsArgumentException()
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
