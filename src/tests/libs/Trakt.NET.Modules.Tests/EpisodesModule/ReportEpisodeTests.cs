using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class ReportEpisodeTests
    {
        private const string ReportEpisodeUri = $"episodes/{TestConstants.Episodes.EpisodeID}/report";

        [Fact]
        public async Task TestReportEpisodeWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUri, HttpStatusCode.Created);

            TraktResponse response = await client.Episodes.ReportEpisodeAsync(TestConstants.Episodes.TraktEpisodeID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportEpisodeWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUri, HttpStatusCode.Created);

            TraktResponse response = await client.Episodes.ReportEpisodeAsync(TestConstants.Episodes.EpisodeID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportEpisodeWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUri, HttpStatusCode.Created);

            TraktResponse response = await client.Episodes.ReportEpisodeAsync(TestConstants.Episodes.EpisodeIDs, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestReportEpisodeThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Episodes.ReportEpisodeAsync(TestConstants.Episodes.TraktEpisodeID, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReportEpisodeThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Episodes.ReportEpisodeAsync(default(TraktEpisodeIDs)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.ReportEpisodeAsync(new TraktEpisodeIDs(), TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.ReportEpisodeAsync(0, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.ReportEpisodeAsync(default(string)!, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Episodes.ReportEpisodeAsync(string.Empty, TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Episodes.ReportEpisodeAsync("episode id", TraktReason.Spam, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }

        [Fact]
        public async Task TestReportEpisodeThrowsPostValidationExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReportEpisodeUri, HttpStatusCode.Created);

            Func<Task<TraktResponse>> act = () => client.Episodes.ReportEpisodeAsync(TestConstants.Episodes.EpisodeID, TraktReason.Unspecified, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Episodes.ReportEpisodeAsync(TestConstants.Episodes.EpisodeID, TraktReason.Other, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Episodes.ReportEpisodeAsync(TestConstants.Episodes.EpisodeID, TraktReason.Other, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
