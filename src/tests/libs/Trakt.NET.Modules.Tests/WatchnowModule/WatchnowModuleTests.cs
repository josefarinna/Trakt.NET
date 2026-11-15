using System.Net;

namespace TraktNET.WatchnowModule
{
    public sealed class WatchnowModuleTests
    {
        private const string SourcesUri = "watchnow/sources";
        private const string Country = "us";
        private static readonly string SourcesCountryUri = $"watchnow/sources/{Country}";

        [Fact]
        public async Task TestGetWatchnowSources()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow_sources.json");
            TraktClient client = ModuleTestUtility.GetClient(SourcesUri, responseContent);

            TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>> response =
                await client.Watchnow.GetWatchnowSourcesAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
            response.Content[0].ContainsKey("us").ShouldBeTrue();
            response.Content[0]["us"][0].Source.ShouldBe("netflix");
            response.Content[0]["us"][0].Name.ShouldBe("Netflix");
        }

        [Fact]
        public async Task TestGetWatchnowSourcesWithCountry()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\watchnow_sources.json");
            TraktClient client = ModuleTestUtility.GetClient(SourcesCountryUri, responseContent);

            TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>> response =
                await client.Watchnow.GetWatchnowSourcesAsync(Country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(1);
            response.Content[0].ContainsKey("us").ShouldBeTrue();
            response.Content[0]["us"][0].Source.ShouldBe("netflix");
            response.Content[0]["us"][0].Name.ShouldBe("Netflix");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetWatchnowSourcesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(SourcesUri, statusCode);

            Func<Task<TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>>> act = () => client.Watchnow.GetWatchnowSourcesAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetWatchnowSourcesThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(SourcesCountryUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<Dictionary<string, IReadOnlyList<TraktWatchnowSource>>>>> act = () => client.Watchnow.GetWatchnowSourcesAsync(string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Watchnow.GetWatchnowSourcesAsync("   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
