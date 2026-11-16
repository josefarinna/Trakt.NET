using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class UpdateWatchlistItemTests
    {
        private readonly string UpdateWatchlistItemUri = $"sync/watchlist/{WatchlistItemId}";
        private const uint WatchlistItemId = 123U;
        private const string Notes = "This is a great movie!";

        [Fact]
        public async Task TestUpdateWatchlistItem()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateWatchlistItemUri, HttpStatusCode.NoContent);
            TraktResponse response = await client.Sync.UpdateWatchlistItemAsync(WatchlistItemId, Notes, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestUpdateWatchlistItemThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateWatchlistItemUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Sync.UpdateWatchlistItemAsync(WatchlistItemId, Notes, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
