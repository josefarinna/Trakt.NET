using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeTranslationsTests
    {
        private const string GetEpisodeTranslationsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1/translations";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;

        [Theory]
        [InlineData(null, GetEpisodeTranslationsUri)]
        [InlineData("en", $"{GetEpisodeTranslationsUri}?language=en")]
        public async Task TestGetEpisodeTranslationsWithID(string? languageCode, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodetranslations.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, languageCode, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeTranslationsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodetranslations.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/translations", responseContent);

            TraktListResponse<TraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeTranslationsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodetranslations.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/translations", responseContent);

            TraktListResponse<TraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TestGetEpisodeTranslationsWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodetranslations.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/translations", responseContent);

            TraktListResponse<TraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(show, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestGetEpisodeTranslationsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeTranslationsUri, statusCode);

            Func<Task<TraktListResponse<TraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeTranslationsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeTranslationsUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync(default(TraktShow)!, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync(new TraktShowIDs(), SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync(0, SeasonNr, EpisodeNr);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
