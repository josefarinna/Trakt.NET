using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonJustwatchLinksTests
    {
        private const uint SeasonNumber = 1U;
        private const string Country = "us";
        private static readonly string SeasonJustwatchLinksUri = $"shows/{TestConstants.Shows.TraktShowID}/seasons/{SeasonNumber}/watchnow/justwatch_links/{Country}";
        private static readonly string SeasonJustwatchLinksUriWithSlug = $"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNumber}/watchnow/justwatch_links/{Country}";

        [Fact]
        public async Task TestGetSeasonJustwatchLinksWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(SeasonJustwatchLinksUri, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.TraktShowID, SeasonNumber, Country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.ContainsKey("netflix").ShouldBeTrue();
            response.Content["netflix"].ShouldBe("https://justwatch.com/netflix");
        }

        [Fact]
        public async Task TestGetSeasonJustwatchLinksWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(SeasonJustwatchLinksUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.ShowSlug, SeasonNumber, Country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonJustwatchLinksWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Watchnow\\justwatch_links.json");
            TraktClient client = ModuleTestUtility.GetClient(SeasonJustwatchLinksUriWithSlug, responseContent);

            TraktResponse<Dictionary<string, string>> response =
                await client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.ShowIDs, SeasonNumber, Country, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        public async Task TestGetSeasonJustwatchLinksThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(SeasonJustwatchLinksUri, statusCode);

            Func<Task<TraktResponse<Dictionary<string, string>>>> act = () => client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.TraktShowID, SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonJustwatchLinksThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(SeasonJustwatchLinksUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<Dictionary<string, string>>>> act = () => client.Seasons.GetSeasonJustwatchLinksAsync(default(TraktShowIDs)!, SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync(new TraktShowIDs(), SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync(string.Empty, SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync("   ", SeasonNumber, Country, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.ShowSlug, SeasonNumber, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Seasons.GetSeasonJustwatchLinksAsync(TestConstants.Shows.ShowSlug, SeasonNumber, "   ", cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
