using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class ResetShowWatchedProgressTests
    {
        private const string ResetShowWatchedProgressUri = $"shows/{TestConstants.Shows.ShowID}/progress/watched/reset";
        private const string ResetShowWatchedProgressUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/progress/watched/reset";
        private const string ResetAtValue = "2024-09-23T19:08:15.000Z";

        private static readonly DateTime ResetAt = TestUtility.ParseUTCDateTime(ResetAtValue);

        [Theory]
        [InlineData(null)]
        [InlineData(ResetAtValue)]
        public async Task TestResetShowWatchedProgressWithID(string? resetAt)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showresetwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUri, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(TestConstants.Shows.TraktShowID,
                resetAt is not null ? TestUtility.ParseUTCDateTime(resetAt) : null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.ResetAt.ShouldBe(ResetAt);
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showresetwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(
                TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.ResetAt.ShouldBe(ResetAt);
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showresetwatchedprogress.json");
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, responseContent, null, null, null, null);

            TraktResponse<TraktShowResetWatchedProgress> response = await client.Shows.ResetShowWatchedProgressAsync(
                TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content!.ResetAt.ShouldBe(ResetAt);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestResetShowWatchedProgressWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUri, statusCode);

            Func<Task<TraktResponse<TraktShowResetWatchedProgress>>> act = () => client.Shows.ResetShowWatchedProgressAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestResetShowWatchedProgressWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ResetShowWatchedProgressUriWithSlug, HttpStatusCode.Created);

            Func<Task<TraktResponse<TraktShowResetWatchedProgress>>> act = () => client.Shows.ResetShowWatchedProgressAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.ResetShowWatchedProgressAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
