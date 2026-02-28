using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonTranslationsTests
    {
        private const string GetSeasonTranslationsUriPrefix = "shows";
        private const string GetSeasonTranslationsUriSuffix = "translations";
        private const uint SeasonNumber = 1U;
        private const string GetSeasonTranslationsUri = GetSeasonTranslationsUriPrefix + "/1390/seasons/1/" + GetSeasonTranslationsUriSuffix;
        private const string GetSeasonTranslationsUriWithSlug = $"{GetSeasonTranslationsUriPrefix}/{TestConstants.Shows.ShowSlug}/seasons/1/{GetSeasonTranslationsUriSuffix}";

        [Theory]
        [InlineData(null, GetSeasonTranslationsUriWithSlug, "Seasons\\seasontranslations.json")]
        [InlineData("", GetSeasonTranslationsUriWithSlug, "Seasons\\seasontranslations.json")]
        [InlineData("es", $"{GetSeasonTranslationsUriWithSlug}/es", "Seasons\\seasontranslations.json")]
        public async Task TestGetSeasonTranslations(string? language, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktSeasonTranslation> response = await client.Seasons.GetSeasonTranslationsAsync(TestConstants.Shows.ShowSlug, SeasonNumber, language, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetSeasonTranslationsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasontranslations.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonTranslationsUri, responseContent);

            TraktListResponse<TraktSeasonTranslation> response = await client.Seasons.GetSeasonTranslationsAsync(TestConstants.Shows.ShowID, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetSeasonTranslationsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasontranslations.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonTranslationsUriWithSlug, responseContent);

            TraktListResponse<TraktSeasonTranslation> response = await client.Seasons.GetSeasonTranslationsAsync(TestConstants.Shows.ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktListResponse<TraktSeasonTranslation> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktSeasonTranslation> translations = response.Content!;

            translations[0].ShouldNotBeNull();
            translations[0].Title.ShouldBe("Temporada 1");
            translations[0].Overview.ShouldStartWith("Se avecinan problemas en los Siete Reinos de Poniente.");
            translations[0].Language.ShouldBe("es");
            translations[0].Country.ShouldBe("es");

            translations[1].ShouldNotBeNull();
            translations[1].Title.ShouldBe("null");
            translations[1].Overview.ShouldStartWith("Die fiktive Welt von Westeros, in der Jahreszeiten sich über Jahre hinziehen");
            translations[1].Language.ShouldBe("de");
            translations[1].Country.ShouldBe("de");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetSeasonTranslationsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonTranslationsUriWithSlug, statusCode);

            try
            {
                await client.Seasons.GetSeasonTranslationsAsync(TestConstants.Shows.ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetSeasonTranslationsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasontranslations.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonTranslationsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktSeasonTranslation>>> act = () => client.Seasons.GetSeasonTranslationsAsync(default(TraktShowIDs), SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var ShowIDs = new TraktShowIDs();
            act = () => client.Seasons.GetSeasonTranslationsAsync(ShowIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
