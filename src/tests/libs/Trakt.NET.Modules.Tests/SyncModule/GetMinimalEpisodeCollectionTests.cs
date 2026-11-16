using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetMinimalEpisodeCollectionTests
    {
        private const string GetMinimalEpisodeCollectionUri = "sync/collection/minimal/episodes";

        [Theory]
        [InlineData(null, GetMinimalEpisodeCollectionUri)]
        [InlineData(TraktAvailableOn.Digital, $"{GetMinimalEpisodeCollectionUri}?available_on=digital")]
        public async Task TestGetMinimalEpisodeCollection(TraktAvailableOn? availableOn, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\getsynccollectionminimalepisodes.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent);

            TraktResponse<Dictionary<string, string>> response = await client.Sync.GetMinimalEpisodeCollectionAsync(availableOn, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
            response.Content["12345"].ShouldBe("2014-10-11T17:00:54.000Z");
            response.Content["67890"].ShouldBe("2014-10-11T17:00:54.000Z");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetMinimalEpisodeCollectionThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetMinimalEpisodeCollectionUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, string>>>> act = () => client.Sync.GetMinimalEpisodeCollectionAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
