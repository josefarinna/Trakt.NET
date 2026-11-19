using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class UpdateWatchlistTests
    {
        private readonly string UpdateWatchlistUri = $"sync/watchlist";
        private const string NewDescription = "new description";

        [Theory]
        [InlineData(NewDescription, null, null, null, "sync/watchlist")]
        [InlineData(null, TraktSortBy.Rank, null, null, "sync/watchlist")]
        [InlineData(null, null, TraktSortHow.Descending, null, "sync/watchlist")]
        [InlineData(NewDescription, null, null, TraktExtendedInfo.Images, "sync/watchlist?extended=images")]
        [InlineData(NewDescription, TraktSortBy.Rank, TraktSortHow.Descending, TraktExtendedInfo.Images, "sync/watchlist?extended=images")]
        public async Task TestUpdateWatchlist(string? description, TraktSortBy? sortBy, TraktSortHow? sortHow, TraktExtendedInfo? extendedInfo, string expectedUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(expectedUri, responseContent);
            TraktResponse<TraktList> response = await client.Sync.UpdateWatchlistAsync(description, sortBy, sortHow, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestUpdateWatchlistThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateWatchlistUri, statusCode);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Sync.UpdateWatchlistAsync(NewDescription, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdateWatchlistThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateWatchlistUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktList>>> act = () => client.Sync.UpdateWatchlistAsync(cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
