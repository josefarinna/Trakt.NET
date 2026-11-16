using System.Net;

namespace TraktNET.LanguagesModule
{
    public sealed partial class GetShowLanguagesTests
    {
        private const string ShowLanguagesUri = "languages/shows";

        [Fact]
        public async Task TestGetShowLanguages()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Languages\\languagesshows.json");

            TraktClient client = ModuleTestUtility.GetClient(ShowLanguagesUri, responseContent);
            TraktListResponse<TraktLanguage> response = await client.Languages.GetShowLanguagesAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(117);

            List<TraktLanguage> languages = [.. response.Content];
            languages[0].Name.ShouldBe("Abkhazian");
            languages[0].Code.ShouldBe("ab");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetShowLanguagesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(ShowLanguagesUri, statusCode);

            Func<Task<TraktListResponse<TraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
