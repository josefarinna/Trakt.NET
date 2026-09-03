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

        [Fact]
        public async Task TestGetPlaybackProgress()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetPlaybackProgressWithSyncType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}/{SyncType.ToURI()}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(SyncType, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetPlaybackProgressWithStartAt()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?start_at={StartAtString}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(startAt: StartAt, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetPlaybackProgressWithStartAtAndEndAt()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?start_at={StartAtString}&end_at={EndAtString}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(startAt: StartAt, endAt: EndAt, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetPlaybackProgressWithSyncTypeAndStartAt()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}/episodes?start_at={StartAtString}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(TraktSyncType.Episode, startAt: StartAt, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetPlaybackProgressWithFilter()
        {
            var filter = new TraktFilter { Query = "batman" };
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?query=batman&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(filter: filter, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetPlaybackProgressWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}?extended=full&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(extendedInfo: TraktExtendedInfo.Full, page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetPlaybackProgressComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetPlaybackUri}/movies?start_at={StartAtString}&end_at={EndAtString}&page=3&limit=10", responseContent, 3, 1, 10, ItemCount);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(TraktSyncType.Movie, StartAt, EndAt, page: 3U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ResponseCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(3U);
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
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetPlaybackProgressThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlaybackUri, statusCode);

            Func<Task<TraktPagedResponse<TraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
