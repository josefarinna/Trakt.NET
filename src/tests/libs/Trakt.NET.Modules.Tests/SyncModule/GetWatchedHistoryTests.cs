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

        [Fact]
        public async Task TestGetWatchedHistory()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Page.ShouldBe(Page);
            response.Limit.ShouldBe(Limit);

            var firstItem = response.Content[0];
            firstItem.ID.ShouldBe(1982346U);
            firstItem.Type.ShouldBe(TraktSyncItemType.Movie);
            firstItem.Movie.ShouldNotBeNull();
            firstItem.Movie!.Title.ShouldBe("The Dark Knight");
            firstItem.Action.ShouldBe(TraktHistoryActionType.Scrobble);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithHistoryItemType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(historyItemType: HistoryItemType, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Page.ShouldBe(Page);
            response.Limit.ShouldBe(Limit);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithHistoryItemTypeAndItemId()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}/shows/123?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(historyItemType: TraktSyncItemType.Show, itemId: 123U, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Page.ShouldBe(Page);
            response.Limit.ShouldBe(Limit);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartAt()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}?start_at={StartAtString}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(startAt: StartAt, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Page.ShouldBe(Page);
            response.Limit.ShouldBe(Limit);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithEndAt()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}?end_at={EndAtString}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(endAt: EndAt, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Page.ShouldBe(Page);
            response.Limit.ShouldBe(Limit);
        }

        [Fact]
        public async Task TestGetWatchedHistoryComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetWatchedHistoryUri}/episodes/251?start_at={StartAtString}&end_at={EndAtString}&extended=full&page=2&limit=10", responseContent, 2, 1, 10, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(
                historyItemType: TraktSyncItemType.Episode,
                itemId: 251U,
                startAt: StartAt,
                endAt: EndAt,
                extendedInfo: ExtendedInfo,
                page: 2U,
                limit: 10U,
                cancellationToken: TestContext.Current.CancellationToken
            );

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
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
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetWatchedHistoryThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchedHistoryUri, statusCode);

            Func<Task<TraktPagedResponse<TraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
