using System.Net;

namespace TraktNET.LanguagesModule
{
    public sealed class TraktLanguagesModuleTests
    {
        private const string LanguagesMoviesUri = "languages/movies";
        private const string LanguagesShowsUri = "languages/shows";

        [Fact]
        public async Task TestGetLanguagesMovies()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Languages\\languagesmovies.json");
            TraktClient client = ModuleTestUtility.GetClient(LanguagesMoviesUri, responseContent);

            TraktListResponse<TraktLanguage> response =
                await client.Languages.GetLanguagesAsync(TraktLanguageItemType.Movies, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(177);
        }

        [Fact]
        public async Task TestGetLanguagesShows()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Languages\\languagesshows.json");
            TraktClient client = ModuleTestUtility.GetClient(LanguagesShowsUri, responseContent);

            TraktListResponse<TraktLanguage> response =
                await client.Languages.GetLanguagesAsync(TraktLanguageItemType.Shows, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(117);
        }

        [Theory]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetLanguagesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(LanguagesMoviesUri, statusCode);

            try
            {
                await client.Languages.GetLanguagesAsync(TraktLanguageItemType.Movies, TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                exception.ShouldBeOfType(exceptionType);
            }
        }
    }
}
