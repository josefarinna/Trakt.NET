using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetMinimalMovieCollectionTests
    {
        private const string GetMinimalMovieCollectionUri = "sync/collection/minimal/movies";

        [Theory]
        [InlineData(null, GetMinimalMovieCollectionUri)]
        [InlineData(TraktAvailableOn.Digital, $"{GetMinimalMovieCollectionUri}?available_on=digital")]
        public async Task TestGetMinimalMovieCollection(TraktAvailableOn? availableOn, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Collection\\getsynccollectionminimalmovies.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent);

            TraktResponse<Dictionary<string, string>> response = await client.Sync.GetMinimalMovieCollectionAsync(availableOn, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
            response.Content["batman-begins-2005"].ShouldBe("2014-10-11T17:00:54.000Z");
            response.Content["the-dark-knight-2008"].ShouldBe("2014-10-11T17:00:54.000Z");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetMinimalMovieCollectionThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetMinimalMovieCollectionUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, string>>>> act = () => client.Sync.GetMinimalMovieCollectionAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
