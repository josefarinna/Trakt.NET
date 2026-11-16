using System.Net;

namespace TraktNET.LanguagesModule
{
    public sealed partial class GetMovieLanguagesTests
    {
        private const string MovieLanguagesUri = "languages/movies";

        [Fact]
        public async Task TestGetMovieLanguages()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Languages\\languagesmovies.json");

            TraktClient client = ModuleTestUtility.GetClient(MovieLanguagesUri, responseContent);
            TraktListResponse<TraktLanguage> response = await client.Languages.GetMovieLanguagesAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(177);

            List<TraktLanguage> languages = [.. response.Content];
            languages[0].Name.ShouldBe("Abkhazian");
            languages[0].Code.ShouldBe("ab");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetMovieLanguagesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(MovieLanguagesUri, statusCode);

            Func<Task<TraktListResponse<TraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
