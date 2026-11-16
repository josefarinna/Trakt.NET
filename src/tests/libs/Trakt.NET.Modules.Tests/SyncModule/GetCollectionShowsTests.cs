using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetCollectionShowsTests
    {
        private const string GetCollectionsShowUri = "sync/collection/shows";
        private const TraktAvailableOn AvailableOn = TraktAvailableOn.Digital;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, GetCollectionsShowUri)]
        [InlineData(null, AvailableOn, $"{GetCollectionsShowUri}?available_on=digital")]
        [InlineData(ExtendedInfo, null, $"{GetCollectionsShowUri}?extended=full")]
        [InlineData(ExtendedInfo, AvailableOn, $"{GetCollectionsShowUri}?available_on=digital&extended=full")]
        public async Task TestGetCollectionShows(TraktExtendedInfo? extendedInfo, TraktAvailableOn? availableOn, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\synccollectionshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, null, null, null, null);

            TraktListResponse<TraktSyncCollectionShow> response = await client.Sync.GetCollectionShowsAsync(extendedInfo, availableOn, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
            TraktSyncCollectionShow show1 = response.Content[0];
            show1.Seasons.ShouldNotBeNull();
            show1.Seasons.Count.ShouldBe(2);
            show1.Seasons[0].Episodes.ShouldNotBeNull();
            show1.Seasons[0].Episodes!.Count.ShouldBe(2);
            show1.Seasons[0].Episodes![0].AvailableOn.ShouldNotBeNull();
            show1.Seasons[0].Episodes![0].AvailableOn!.Count.ShouldBe(1);
            show1.Seasons[0].Episodes![0].AvailableOn![0].Name.ShouldBe(TraktAvailableOn.Digital);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetCollectionShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetCollectionsShowUri, statusCode);

            Func<Task<TraktListResponse<TraktSyncCollectionShow>>> act = () => client.Sync.GetCollectionShowsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}

