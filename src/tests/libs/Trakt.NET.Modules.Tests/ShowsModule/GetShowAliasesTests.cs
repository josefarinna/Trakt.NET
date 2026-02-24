using System.Net;

namespace TraktNET.ShowsModule
{
    public sealed class GetShowAliasesTests
    {
        private const string GetShowAliasesUriPrefix = "shows";
        private const string GetShowAliasesUriSuffix = "aliases";
        private static readonly string GetShowAliasesUri = $"{GetShowAliasesUriPrefix}/{TestConstants.Shows.ShowID}/{GetShowAliasesUriSuffix}";
        private static readonly string GetShowAliasesUriWithSlug = $"{GetShowAliasesUriPrefix}/{TestConstants.Shows.ShowSlug}/{GetShowAliasesUriSuffix}";

        [Fact]
        public async Task TestGetShowAliasesWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showaliases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAliasesUri, responseContent);

            TraktListResponse<TraktShowAlias> response = await client.Shows.GetShowAliasesAsync(TestConstants.Shows.ShowID, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowAliasesWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showaliases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAliasesUriWithSlug, responseContent);

            TraktListResponse<TraktShowAlias> response = await client.Shows.GetShowAliasesAsync(TestConstants.Shows.ShowSlug, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetShowAliasesWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showaliases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAliasesUriWithSlug, responseContent);

            TraktListResponse<TraktShowAlias> response = await client.Shows.GetShowAliasesAsync(TestConstants.Shows.ShowIDs, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktListResponse<TraktShowAlias> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(3);

            IReadOnlyList<TraktShowAlias> showAliases = response.Content!;

            showAliases[0].Title.ShouldBe("Juego de Tronos");
            showAliases[0].Country.ShouldBe("es");

            showAliases[1].Title.ShouldBe("Game of Thrones - Das Lied von Eis und Feuer");
            showAliases[1].Country.ShouldBe("de");

            showAliases[2].Title.ShouldBe("Le Trône de fer");
            showAliases[2].Country.ShouldBe("fr");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiShowNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetShowAliasesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetShowAliasesUri, statusCode);

            try
            {
                await client.Shows.GetShowAliasesAsync(TestConstants.Shows.ShowID, TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetShowAliasesWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Shows\\showaliases.json");
            TraktClient client = ModuleTestUtility.GetClient(GetShowAliasesUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktShowAlias>>> act = () => client.Shows.GetShowAliasesAsync(default(TraktShowIDs), TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();
            act = () => client.Shows.GetShowAliasesAsync(showIDs, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
