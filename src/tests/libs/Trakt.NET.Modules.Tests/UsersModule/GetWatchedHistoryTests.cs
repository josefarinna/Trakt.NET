using System.Globalization;
using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetWatchedHistoryTests
    {
        private const string GetWatchedHistoryUri = $"users/{Username}/history";
        private const string Username = "sean";
        private const uint Page = 2U;
        private const uint HistoryLimit = 4U;
        private const uint HistoryItemCount = 4U;
        private const uint HistoryItemID = 4U;
        private const TraktSyncItemType HistoryItemType = TraktSyncItemType.Episode;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private const string HistoryStartAt = "2024-01-01T00:00:00.000Z";
        private const string HistoryEndAt = "2024-02-01T00:00:00.000Z";
        private static readonly DateTime StartAt = TestUtility.ParseUTCDateTime(HistoryStartAt);
        private static readonly DateTime EndAt = TestUtility.ParseUTCDateTime(HistoryEndAt);

        [Theory]
        [InlineData(null, null, null, null, null, null, null, null, GetWatchedHistoryUri)]
        [InlineData(HistoryItemType, null, null, null, null, null, null, null, $"{GetWatchedHistoryUri}/episodes")]
        [InlineData(HistoryItemType, HistoryItemID, null, null, null, null, null, null, $"{GetWatchedHistoryUri}/episodes/4")]
        [InlineData(null, null, HistoryStartAt, null, null, null, null, null, $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}")]
        [InlineData(null, null, null, HistoryEndAt, null, null, null, null, $"{GetWatchedHistoryUri}?end_at={HistoryEndAt}")]
        [InlineData(null, null, null, null, "batman", null, Page, HistoryLimit, $"{GetWatchedHistoryUri}?query=batman&page=2&limit=4")]
        [InlineData(null, null, null, null, null, ExtendedInfo, null, null, $"{GetWatchedHistoryUri}?extended=full")]
        [InlineData(null, null, null, null, null, null, Page, null, $"{GetWatchedHistoryUri}?page=2")]
        [InlineData(null, null, null, null, null, null, null, HistoryLimit, $"{GetWatchedHistoryUri}?limit=4")]
        [InlineData(HistoryItemType, HistoryItemID, HistoryStartAt, HistoryEndAt, null, ExtendedInfo, Page, HistoryLimit,
                    $"{GetWatchedHistoryUri}/episodes/4?start_at={HistoryStartAt}&end_at={HistoryEndAt}&extended=full&page=2&limit=4")]
        public async Task TestGetWatchedHistory(TraktSyncItemType? historyItemType, uint? itemId, string? startAt, string? endAt, string? query,
                                                TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page ?? 1U, 1, limit ?? 10U, HistoryItemCount);

            TraktFilter? filter = query is not null ? new TraktFilter { Query = query } : null;

            TraktPagedResponse<TraktHistoryItem> response = await client.Users.GetWatchedHistoryAsync(Username, historyItemType, itemId,
                startAt is not null ? TestUtility.ParseUTCDateTime(startAt) : null, endAt is not null ? TestUtility.ParseUTCDateTime(endAt) : null,
                filter, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchedHistoryUri, responseContent, 1, 1, 10, HistoryItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktHistoryItem> response = await client.Users.GetWatchedHistoryAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/history", responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response = await client.Users.GetWatchedHistoryAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={2}&limit={HistoryLimit}",
                responseContent, 2, 5, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 2, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={2}&limit={HistoryLimit}",
                responseContent, 2, 2, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 2, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={1}&limit={HistoryLimit}",
                responseContent, 1, 2, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 1, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={1}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 1, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={2}&limit={HistoryLimit}",
                responseContent, 2, 2, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 2, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={1}&limit={HistoryLimit}",
                responseContent, 1, 2, HistoryLimit, HistoryItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={1}&limit={HistoryLimit}",
                responseContent, 1, 2, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 1, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page=2&limit={HistoryLimit}",
                responseContent, 2, 2, HistoryLimit, HistoryItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiUserNotFoundException))]
        public async Task TestGetWatchedHistoryThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetWatchedHistoryUri, statusCode);

            Func<Task<TraktPagedResponse<TraktHistoryItem>>> act = () => client.Users.GetWatchedHistoryAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
