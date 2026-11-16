using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowJustwatchLinksTests
    {
        private const string Country = "us";
        private const string GetShowJustwatchLinksUri = $"shows/{TestConstants.Shows.ShowID}/watchnow/justwatch_links/{Country}";
        private const string GetShowJustwatchLinksUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/watchnow/justwatch_links/{Country}";

        [Fact]
        public async Task TestGetShowJustwatchLinksWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowJustwatchLinksUri, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Shows.GetShowJustwatchLinksAsync(TestConstants.Shows.TraktShowID, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.ContainsKey("netflix").ShouldBeTrue();
            response.Content["netflix"].ShouldBe("https://justwatch.com/netflix");
        }

        [Fact]
        public async Task TestGetShowJustwatchLinksWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowJustwatchLinksUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Shows.GetShowJustwatchLinksAsync(TestConstants.Shows.ShowSlug, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowJustwatchLinksWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowJustwatchLinksUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Shows.GetShowJustwatchLinksAsync(TestConstants.Shows.ShowIDs, Country, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        public async Task TestGetShowJustwatchLinksThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowJustwatchLinksUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, string>>>> act = () => client.Shows.GetShowJustwatchLinksAsync(TestConstants.Shows.TraktShowID, Country, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetShowJustwatchLinksThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowJustwatchLinksUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<Dictionary<string, string>>>> act = () => client.Shows.GetShowJustwatchLinksAsync(default(TraktShowIDs)!, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Shows.GetShowJustwatchLinksAsync(new TraktShowIDs(), Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Shows.GetShowJustwatchLinksAsync(string.Empty, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.GetShowJustwatchLinksAsync("   ", Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.GetShowJustwatchLinksAsync(TestConstants.Shows.ShowSlug, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Shows.GetShowJustwatchLinksAsync(TestConstants.Shows.ShowSlug, "   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
