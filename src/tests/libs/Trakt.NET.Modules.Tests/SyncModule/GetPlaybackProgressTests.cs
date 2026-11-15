using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetPlaybackProgressTests
    {
        private const string GetPlaybackUri = "sync/playback";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemCount = 10U;
        private const uint ResponseCount = 2U;
        private const TraktSyncType SyncType = TraktSyncType.Movie;
        private static readonly DateTime StartAt = new(2015, 2, 18, 12, 54, 39, DateTimeKind.Utc);
        private static readonly DateTime EndAt = new(2016, 11, 7, 3, 11, 0, DateTimeKind.Utc);
        private const string StartAtString = "2015-02-18T12:54:39.000Z";
        private const string EndAtString = "2016-11-07T03:11:00.000Z";

        [Theory]
        [InlineData(null, null, null, null, Page, Limit, $"{GetPlaybackUri}?page=2&limit=4")]
        [InlineData(SyncType, null, null, null, Page, Limit, $"{GetPlaybackUri}/movies?page=2&limit=4")]
        [InlineData(null, "2015-02-18T12:54:39.000Z", null, null, Page, Limit, $"{GetPlaybackUri}?start_at={StartAtString}&page=2&limit=4")]
        [InlineData(null, "2015-02-18T12:54:39.000Z", "2016-11-07T03:11:00.000Z", null, Page, Limit, $"{GetPlaybackUri}?start_at={StartAtString}&end_at={EndAtString}&page=2&limit=4")]
        [InlineData(TraktSyncType.Episode, "2015-02-18T12:54:39.000Z", null, null, Page, Limit, $"{GetPlaybackUri}/episodes?start_at={StartAtString}&page=2&limit=4")]
        [InlineData(null, null, null, TraktExtendedInfo.Full, Page, Limit, $"{GetPlaybackUri}?extended=full&page=2&limit=4")]
        [InlineData(TraktSyncType.Movie, "2015-02-18T12:54:39.000Z", "2016-11-07T03:11:00.000Z", null, 3U, 10U, $"{GetPlaybackUri}/movies?start_at={StartAtString}&end_at={EndAtString}&page=3&limit=10")]
        public async Task TestGetPlaybackProgress(TraktSyncType? objectType, string? startAt, string? endAt, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(objectType, startAt is not null ? TestUtility.ParseUTCDateTime(startAt) : null, endAt is not null ? TestUtility.ParseUTCDateTime(endAt) : null, null, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(limit ?? Limit);
            response.Page.ShouldBe(page ?? Page);
            response.PageCount.ShouldBe(1U);
        }

        [Theory]
        [InlineData(null, null, null, null, Page, Limit, $"{GetPlaybackUri}?query=batman&page=2&limit=4")]
        public async Task TestGetPlaybackProgressWithFilter(TraktSyncType? objectType, string? startAt, string? endAt, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            var filter = new TraktFilter { Query = "batman" };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(objectType, startAt is not null ? TestUtility.ParseUTCDateTime(startAt) : null, endAt is not null ? TestUtility.ParseUTCDateTime(endAt) : null, filter, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(limit ?? Limit);
            response.Page.ShouldBe(page ?? Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetPlaybackProgressPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPlaybackProgressPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetPlaybackProgressPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPlaybackProgressPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetPlaybackProgressPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(page: 2, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetPlaybackUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetPlaybackProgressPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(page: 1, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetPlaybackUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetPlaybackProgressThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlaybackUri, statusCode);

            Func<Task<TraktPagedResponse<TraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
