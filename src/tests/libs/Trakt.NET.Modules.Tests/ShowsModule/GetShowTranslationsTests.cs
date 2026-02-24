using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowTranslationsTests
    {
        private const string GetShowTranslationsUriPrefix = "shows";
        private const string GetShowTranslationsUriSuffix = "translations";
        private const string GetShowTranslationsUri = GetShowTranslationsUriPrefix + "/1390/" + GetShowTranslationsUriSuffix;
        private const string GetShowTranslationsUriWithSlug = $"{GetShowTranslationsUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowTranslationsUriSuffix}";

        [Theory]
        [InlineData(null, GetShowTranslationsUriWithSlug, "Shows\\showtranslations.json")]
        [InlineData("", GetShowTranslationsUriWithSlug, "Shows\\showtranslations.json")]
        [InlineData("es", $"{GetShowTranslationsUriWithSlug}/es", "Shows\\showtranslations.json")]
        public async Task TestGetShowTranslations(string? language, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktShowTranslation> response = await client.Shows.GetShowTranslationsAsync(TestConstants.Shows.ShowSlug, language, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowTranslationsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showtranslations.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowTranslationsUri, responseContent);

            TraktListResponse<TraktShowTranslation> response = await client.Shows.GetShowTranslationsAsync(TestConstants.Shows.ShowID, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowTranslationsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showtranslations.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowTranslationsUriWithSlug, responseContent);

            TraktListResponse<TraktShowTranslation> response = await client.Shows.GetShowTranslationsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktListResponse<TraktShowTranslation> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktShowTranslation> translations = response.Content!;

            translations[0].ShouldNotBeNull();
            translations[0].Title.ShouldBe("Juego de tronos");
            translations[0].Overview.ShouldStartWith("En una tierra donde los veranos");
            translations[0].Tagline.ShouldBe("Se acerca el invierno");
            translations[0].Language.ShouldBe("es");
            translations[0].Country.ShouldBe("es");

            translations[1].ShouldNotBeNull();
            translations[1].Title.ShouldBe("A Guerra dos Tronos");
            translations[1].Overview.ShouldStartWith("Numa terra onde o verão");
            translations[1].Tagline.ShouldBe("O inverno está a chegar.");
            translations[1].Language.ShouldBe("pt");
            translations[1].Country.ShouldBe("pt");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetShowTranslationsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowTranslationsUriWithSlug, statusCode);

            try
            {
                await client.Shows.GetShowTranslationsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowTranslationsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showtranslations.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowTranslationsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(default(TraktShowIDs), cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowTranslationsAsync(showIDs, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
