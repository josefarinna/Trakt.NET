using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class UndoResetShowWatchedProgressTests
    {
        private const string UndoResetShowWatchedProgressUri = $"shows/{TestConstants.Shows.ShowID}/progress/watched/reset";
        private const string UndoResetShowWatchedProgressUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/progress/watched/reset";

        [Fact]
        public async Task TestUndoResetShowWatchedProgressWithID()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoResetShowWatchedProgressUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Shows.UndoResetShowWatchedProgressAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUndoResetShowWatchedProgressWithSlug()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoResetShowWatchedProgressUriWithSlug, HttpStatusCode.NoContent);

            TraktResponse response = await client.Shows.UndoResetShowWatchedProgressAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task TestUndoResetShowWatchedProgressWithIDs()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoResetShowWatchedProgressUriWithSlug, HttpStatusCode.NoContent);

            TraktResponse response = await client.Shows.UndoResetShowWatchedProgressAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestUndoResetShowWatchedProgressWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoResetShowWatchedProgressUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Shows.UndoResetShowWatchedProgressAsync(TestConstants.Shows.TraktShowID, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestUndoResetShowWatchedProgressWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UndoResetShowWatchedProgressUriWithSlug, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Shows.UndoResetShowWatchedProgressAsync(default(TraktShowIDs)!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.UndoResetShowWatchedProgressAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
