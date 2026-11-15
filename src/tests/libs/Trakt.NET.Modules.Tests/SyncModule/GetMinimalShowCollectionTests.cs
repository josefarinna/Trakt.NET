using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetMinimalShowCollectionTests
    {
        private const string GetMinimalShowCollectionUri = "sync/collection/minimal/shows";

        [Theory]
        [InlineData(null, GetMinimalShowCollectionUri)]
        [InlineData(TraktAvailableOn.Digital, $"{GetMinimalShowCollectionUri}?available_on=digital")]
        public async Task TestGetMinimalShowCollection(TraktAvailableOn? availableOn, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\getsynccollectionminimalshows.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent);

            TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, string>>>> response = await client.Sync.GetMinimalShowCollectionAsync(availableOn, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
            response.Content["game-of-thrones"]["1"]["1"].ShouldBe("2014-10-11T17:00:54.000Z");
            response.Content["game-of-thrones"]["1"]["2"].ShouldBe("2014-10-11T17:00:54.000Z");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetMinimalShowCollectionThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetMinimalShowCollectionUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>>> act = () => client.Sync.GetMinimalShowCollectionAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
