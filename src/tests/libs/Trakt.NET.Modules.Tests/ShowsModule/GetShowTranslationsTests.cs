using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowTranslationsTests
    {
        private const string GetShowTranslationsUri = $"shows/{TestConstants.Shows.ShowID}/translations";
        private const string GetShowTranslationsUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/translations";
        private const int ListItemCount = 2;
        private const string Language = "es";

        [Fact]
        public async Task TestGetShowTranslationsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showtranslations.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowTranslationsUriWithSlug, responseContent);

            TraktListResponse<TraktShowTranslation> response = await client.Shows.GetShowTranslationsAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Theory]
        [InlineData(null, GetShowTranslationsUri)]
        [InlineData(Language, $"{GetShowTranslationsUri}?language={Language}")]
        [InlineData("", GetShowTranslationsUri)]
        public async Task TestGetShowTranslationsWithID(string? language, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showtranslations.json");
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktShowTranslation> response = await client.Shows.GetShowTranslationsAsync(TestConstants.Shows.TraktShowID, language, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Fact]
        public async Task TestGetShowTranslationsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showtranslations.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowTranslationsUriWithSlug, responseContent);

            TraktListResponse<TraktShowTranslation> response = await client.Shows.GetShowTranslationsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(ListItemCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowTranslationsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowTranslationsUri, statusCode);

            Func<Task<TraktListResponse<TraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowTranslationsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowTranslationsUriWithSlug, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowTranslationsAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
