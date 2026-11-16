using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class ReportSeasonTests
    {
        private const string ReportSeasonUri = $"seasons/{TestConstants.Seasons.SeasonID}/report";

        [Fact]
        public async Task TestReportSeasonWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUri, HttpStatusCode.Created);

            TraktResponse response = await client.Seasons.ReportSeasonAsync(TestConstants.Seasons.TraktSeasonID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportSeasonWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUri, HttpStatusCode.Created);

            TraktResponse response = await client.Seasons.ReportSeasonAsync(TestConstants.Seasons.SeasonID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportSeasonWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUri, HttpStatusCode.Created);

            TraktResponse response = await client.Seasons.ReportSeasonAsync(TestConstants.Seasons.SeasonIDs, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        public async Task TestReportSeasonThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Seasons.ReportSeasonAsync(TestConstants.Seasons.TraktSeasonID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportSeasonThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Seasons.ReportSeasonAsync(default(TraktSeasonIDs)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.ReportSeasonAsync(new TraktSeasonIDs(), TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.ReportSeasonAsync(0, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.ReportSeasonAsync(default(string)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Seasons.ReportSeasonAsync(string.Empty, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Seasons.ReportSeasonAsync("season id", TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestReportSeasonThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportSeasonUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Seasons.ReportSeasonAsync(TestConstants.Seasons.SeasonID, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Seasons.ReportSeasonAsync(TestConstants.Seasons.SeasonID, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Seasons.ReportSeasonAsync(TestConstants.Seasons.SeasonID, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
