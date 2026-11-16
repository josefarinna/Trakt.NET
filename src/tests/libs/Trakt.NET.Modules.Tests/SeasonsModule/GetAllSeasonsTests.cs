using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetAllSeasonTests
    {
        private const string GetAllSeasonsUri = $"shows/{TestConstants.Shows.ShowID}/seasons";
        private const string TranslationLanguageCode = "en";
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, GetAllSeasonsUri)]
        [InlineData(ExtendedInfo, null, $"{GetAllSeasonsUri}?extended=full")]
        [InlineData(null, TranslationLanguageCode, $"{GetAllSeasonsUri}?translations={TranslationLanguageCode}")]
        [InlineData(ExtendedInfo, TranslationLanguageCode, $"{GetAllSeasonsUri}?extended=full&translations={TranslationLanguageCode}")]
        [InlineData(null, "all", $"{GetAllSeasonsUri}?translations=all")]
        [InlineData(ExtendedInfo, "all", $"{GetAllSeasonsUri}?extended=full&translations=all")]
        public async Task TestGetAllSeasonsWithID(TraktExtendedInfo? extendedInfo, string? translationLanguageCode, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(TestConstants.Shows.TraktShowID, extendedInfo, translationLanguageCode, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons", responseContent);
            
            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(TestConstants.Shows.ShowSlug, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons", responseContent);
            
            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(TestConstants.Shows.ShowIDs, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Fact]
        public async Task TestGetAllSeasonsWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\allseasons.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons", responseContent);
            
            TraktListResponse<TraktSeason> response = await client.Seasons.GetAllSeasonsAsync(show, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(8);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        public async Task TestGetAllSeasonsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetAllSeasonsUri, statusCode);

            Func<Task<TraktListResponse<TraktSeason>>> act = () => client.Seasons.GetAllSeasonsAsync(TestConstants.Shows.TraktShowID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllSeasonsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetAllSeasonsUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktSeason>>> act =
                () => client.Seasons.GetAllSeasonsAsync(default(TraktShowIDs)!, cancellationToken: TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetAllSeasonsAsync(default(TraktShow)!, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetAllSeasonsAsync(new TraktShowIDs(), cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetAllSeasonsAsync(0, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
