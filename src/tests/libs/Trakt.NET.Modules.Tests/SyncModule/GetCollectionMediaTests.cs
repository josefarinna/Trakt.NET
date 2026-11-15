using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetCollectionMediaTests
    {
        private const string GetCollectionMediaUri = "sync/collection/media";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemCount = 3U;
        private const TraktAvailableOn AvailableOn = TraktAvailableOn.Digital;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, Page, Limit, $"{GetCollectionMediaUri}?page=2&limit=4")]
        [InlineData(null, AvailableOn, Page, Limit, $"{GetCollectionMediaUri}?available_on=digital&page=2&limit=4")]
        [InlineData(ExtendedInfo, null, Page, Limit, $"{GetCollectionMediaUri}?extended=full&page=2&limit=4")]
        [InlineData(ExtendedInfo, AvailableOn, Page, Limit, $"{GetCollectionMediaUri}?available_on=digital&extended=full&page=2&limit=4")]
        [InlineData(null, null, null, null, GetCollectionMediaUri)]
        public async Task TestGetCollectionMedia(TraktExtendedInfo? extendedInfo, TraktAvailableOn? availableOn, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmedia.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page ?? 1U, 1, limit ?? 10U, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMedia> response = await client.Sync.GetCollectionMediaAsync(extendedInfo, availableOn, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMediaWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmedia.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMediaUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, ItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktSyncCollectionMedia> response = await client.Sync.GetCollectionMediaAsync(page: Page, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetCollectionMediaPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmedia.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMediaUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMedia> response = await client.Sync.GetCollectionMediaAsync(page: 2U, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetCollectionMediaUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetCollectionMediaPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionmedia.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMediaUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ItemCount);

            TraktPagedResponse<TraktSyncCollectionMedia> response = await client.Sync.GetCollectionMediaAsync(page: 1U, limit: Limit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetCollectionMediaUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(ItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetCollectionMediaThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetCollectionMediaUri}?page=1&limit=10", statusCode);

            Func<Task<TraktPagedResponse<TraktSyncCollectionMedia>>> act = () => client.Sync.GetCollectionMediaAsync(page: 1U, limit: 10U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
