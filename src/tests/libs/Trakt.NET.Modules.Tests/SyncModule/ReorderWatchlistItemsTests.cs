using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class ReorderWatchlistItemsTests
    {
        private const string ReorderWatchlistItemsUri = "sync/watchlist/reorder";
        private readonly List<uint> ReorderedItems = [923, 324, 98768, 456456, 345, 2, 990];

        [Fact]
        public async Task TestReorderWatchlistItems()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\listitemsreorderpostresponse.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderWatchlistItemsUri, responseContent);
            TraktResponse<TraktListItemsReorderPostResponse> response = await client.Sync.ReorderWatchlistItemsAsync(ReorderedItems, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktListItemsReorderPostResponse responseValue = response.Content;

            responseValue.Updated.ShouldBe(6U);
            responseValue.SkippedIDs.ShouldNotBeNull();
            responseValue.SkippedIDs.Count.ShouldBe(1);
            responseValue.SkippedIDs.ShouldBeEquivalentTo(new List<uint> { 2 });
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestReorderWatchlistItemsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderWatchlistItemsUri, statusCode);

            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act = () => client.Sync.ReorderWatchlistItemsAsync(ReorderedItems, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestReorderWatchlistItemsArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ReorderWatchlistItemsUri, HttpStatusCode.OK);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktListItemsReorderPostResponse>>> act = () => client.Sync.ReorderWatchlistItemsAsync(null, TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
