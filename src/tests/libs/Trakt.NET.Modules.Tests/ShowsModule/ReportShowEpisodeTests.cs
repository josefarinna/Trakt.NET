using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class ReportShowEpisodeTests
    {
        private const string ReportEpisodeUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1/report";
        private const string ReportEpisodeUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/seasons/1/episodes/1/report";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;

        [Fact]
        public async Task TestReportShowEpisodeWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUri, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.ReportShowEpisodeAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportShowEpisodeWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.ReportShowEpisodeAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportShowEpisodeWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUriWithSlug, HttpStatusCode.Created);

            TraktResponse response = await client.Shows.ReportShowEpisodeAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestReportShowEpisodeThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Shows.ReportShowEpisodeAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportShowEpisodeThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Shows.ReportShowEpisodeAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Shows.ReportShowEpisodeAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.ReportShowEpisodeAsync(0, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.ReportShowEpisodeAsync(default(string)!, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.ReportShowEpisodeAsync(string.Empty, SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.ReportShowEpisodeAsync("show id", SeasonNr, EpisodeNr, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestReportShowEpisodeThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Shows.ReportShowEpisodeAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Shows.ReportShowEpisodeAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Shows.ReportShowEpisodeAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
