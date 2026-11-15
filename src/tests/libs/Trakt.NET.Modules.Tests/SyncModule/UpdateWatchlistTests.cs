using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class UpdateWatchlistTests
    {
        private readonly string UpdateWatchlistUri = $"sync/watchlist";
        private const string NewDescription = "new description";
        private readonly TraktSortBy NewSortBy = TraktSortBy.Rank;
        private readonly TraktSortHow NewSortHow = TraktSortHow.Descending;

        [Fact]
        public async Task TestUpdateWatchlist()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Lists\\list.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateWatchlistUri, responseContent);
            TraktResponse<TraktList> response = await client.Sync.UpdateWatchlistAsync(NewDescription, NewSortBy, NewSortHow, TestContext.Current.CancellationToken);

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

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktList>>> act = () => client.Sync.UpdateWatchlistAsync(default, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
