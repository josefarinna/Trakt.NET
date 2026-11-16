using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonEpisodesTests
    {
        private const string GetSeasonEpisodesUri = "shows/1390/seasons/1";
        private const uint SeasonNr = 1U;
        private const uint ItemCount = 10U;

        [Theory]
        [InlineData(null, null, GetSeasonEpisodesUri)]
        [InlineData("es", null, $"{GetSeasonEpisodesUri}?translations=es")]
        [InlineData(null, TraktExtendedInfo.Full, $"{GetSeasonEpisodesUri}?extended=full")]
        [InlineData("all", TraktExtendedInfo.Full, $"{GetSeasonEpisodesUri}?translations=all&extended=full")]
        public async Task TestGetSeasonEpisodesWithID(string? translations, TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktEpisode> response =
                await client.Seasons.GetSeasonEpisodesAsync(TestConstants.Shows.TraktShowID, SeasonNr, translations, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            var episodes = response.Content.ToList();
            episodes.Count.ShouldBe(10);

            TraktEpisode firstEpisode = episodes[0];
            firstEpisode.Number.ShouldBe(1U);
            firstEpisode.Season.ShouldBe(1U);
            firstEpisode.Title.ShouldBe("Winter Is Coming");
            firstEpisode.IDs!.Trakt.ShouldBe(73640U);
            firstEpisode.IDs.IMDB.ShouldBe("tt1480055");
            firstEpisode.Runtime.ShouldBe(62U);
            firstEpisode.EpisodeType.ShouldBe(TraktEpisodeType.SeriesPremiere);

            firstEpisode.Translations.ShouldNotBeNull();
            TraktEpisodeTranslation translation = firstEpisode.Translations.First();
            translation.Language.ShouldBe("es");
            translation.Title.ShouldBe("Se acerca el invierno");
        }

        [Fact]
        public async Task TestGetSeasonEpisodesWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonepisodes.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/1", responseContent);

            TraktListResponse<TraktEpisode> response =
                await client.Seasons.GetSeasonEpisodesAsync(TestConstants.Shows.ShowSlug, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Count.ShouldBe(10);

            TraktEpisode lastEpisode = response.Content[response.Content.Count - 1];
            lastEpisode.Number.ShouldBe(10U);
            lastEpisode.Title.ShouldBe("Fire and Blood");
            lastEpisode.EpisodeType.ShouldBe(TraktEpisodeType.SeasonFinale);
        }

        [Fact]
        public async Task TestGetSeasonEpisodesWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/1", responseContent, 1, 1, 10, ItemCount);

            TraktListResponse<TraktEpisode> response = await client.Seasons.GetSeasonEpisodesAsync(TestConstants.Shows.ShowIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
        }

        [Fact]
        public async Task TestGetSeasonEpisodesWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonepisodes.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/1", responseContent, 1, 1, 10, ItemCount);

            TraktListResponse<TraktEpisode> response = await client.Seasons.GetSeasonEpisodesAsync(show, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        public async Task TestGetSeasonEpisodesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonEpisodesUri, statusCode);

            Func<Task<TraktListResponse<TraktEpisode>>> act = () => client.Seasons.GetSeasonEpisodesAsync(TestConstants.Shows.TraktShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonEpisodesWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonEpisodesUri, HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktEpisode>>> act =
                () => client.Seasons.GetSeasonEpisodesAsync(default(TraktShowIDs)!, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonEpisodesAsync(default(TraktShow)!, SeasonNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonEpisodesAsync(new TraktShowIDs(), SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonEpisodesAsync(0, SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
