using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetWatchedHistoryTests
    {
        private const string GetWatchedHistoryUri = "sync/history";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemCount = 4U;
        private const TraktSyncItemType HistoryItemType = TraktSyncItemType.Movie;
        private static readonly DateTime StartAt = new(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly DateTime EndAt = new(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc);
        private const string StartAtString = "2024-01-01T00:00:00.000Z";
        private const string EndAtString = "2024-02-01T00:00:00.000Z";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, null, Page, Limit, null, $"{GetWatchedHistoryUri}?page=2&limit=4")]
        [InlineData(HistoryItemType, null, null, null, null, Page, Limit, null, $"{GetWatchedHistoryUri}/movies?page=2&limit=4")]
        [InlineData(TraktSyncItemType.Show, 123U, null, null, null, Page, Limit, null, $"{GetWatchedHistoryUri}/shows/123?page=2&limit=4")]
        [InlineData(null, null, StartAtString, null, null, Page, Limit, null, $"{GetWatchedHistoryUri}?start_at={StartAtString}&page=2&limit=4")]
        [InlineData(null, null, null, EndAtString, null, Page, Limit, null, $"{GetWatchedHistoryUri}?end_at={EndAtString}&page=2&limit=4")]
        [InlineData(null, null, null, null, null, Page, Limit, "batman", $"{GetWatchedHistoryUri}?query=batman&page=2&limit=4")]
        [InlineData(TraktSyncItemType.Episode, 251U, StartAtString, EndAtString, ExtendedInfo, 2U, 10U, null, $"{GetWatchedHistoryUri}/episodes/251?start_at={StartAtString}&end_at={EndAtString}&extended=full&page=2&limit=10")]
        public async Task TestGetWatchedHistory(TraktSyncItemType? historyItemType, uint? itemId, string? startAt, string? endAt, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string? query, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, 10);

            TraktFilter? filter = query is not null ? new TraktFilter { Query = query } : null;

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(historyItemType, itemId, startAt is not null ? TestUtility.ParseUTCDateTime(startAt) : null, endAt is not null ? TestUtility.ParseUTCDateTime(endAt) : null, filter, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
            var firstItem = response.Content[0];
            firstItem.ID.ShouldBe(1982346U);
            firstItem.Type.ShouldBe(TraktSyncItemType.Movie);
            firstItem.Movie.ShouldNotBeNull();
            firstItem.Movie!.Title.ShouldBe("The Dark Knight");
            firstItem.Action.ShouldBe(TraktHistoryActionType.Scrobble);
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(page: 2U, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(page: 2U, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(page: 1U, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(page: 1U, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(page: 2U, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetWatchedHistoryUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, 10);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(page: 1U, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetWatchedHistoryUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, 10);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetWatchedHistoryThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchedHistoryUri, statusCode);

            Func<Task<TraktPagedResponse<TraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
