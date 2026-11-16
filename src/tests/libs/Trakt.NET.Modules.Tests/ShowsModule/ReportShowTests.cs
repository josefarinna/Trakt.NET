using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class ReportShowTests
    {
        private const string ReportShowUri = $"shows/{TestConstants.Shows.ShowID}/report";
        private const string ReportShowUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/report";

        [Fact]
        public async Task TestReportShowWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportShowUri, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.ReportShowAsync(TestConstants.Shows.TraktShowID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportShowWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportShowUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.ReportShowAsync(TestConstants.Shows.ShowSlug, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportShowWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportShowUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.ReportShowAsync(TestConstants.Shows.ShowIDs, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestReportShowThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportShowUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Shows.ReportShowAsync(TestConstants.Shows.TraktShowID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportShowThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportShowUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Shows.ReportShowAsync(default(TraktShowIDs)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Shows.ReportShowAsync(new TraktShowIDs(), TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.ReportShowAsync(0, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.ReportShowAsync(default(string)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.ReportShowAsync(string.Empty, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.ReportShowAsync("show id", TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestReportShowThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportShowUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Shows.ReportShowAsync(TestConstants.Shows.ShowSlug, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Shows.ReportShowAsync(TestConstants.Shows.ShowSlug, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Shows.ReportShowAsync(TestConstants.Shows.ShowSlug, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
