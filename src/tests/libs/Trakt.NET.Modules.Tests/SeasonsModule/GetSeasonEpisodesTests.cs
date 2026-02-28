using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonEpisodesTests
    {
        private const string GetSeasonEpisodesUri = "shows";
        private const uint SeasonNumber = 1U;

        [Theory]
        [InlineData(null, null, $"{GetSeasonEpisodesUri}/1390/seasons/1", "Seasons\\seasonepisodes.json")]
        [InlineData("es", null, $"{GetSeasonEpisodesUri}/1390/seasons/1?translations=es", "Seasons\\seasonepisodes.json")]
        [InlineData(null, TraktExtendedInfo.Full, $"{GetSeasonEpisodesUri}/1390/seasons/1?extended=full", "Seasons\\seasonepisodes.json")]
        [InlineData("all", TraktExtendedInfo.Full, $"{GetSeasonEpisodesUri}/1390/seasons/1?translations=all&extended=full", "Seasons\\seasonepisodes.json")]
        public async Task TestGetSeasonEpisodesWithID(string? translations, TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktEpisode> response =
                await client.Seasons.GetSeasonEpisodesAsync(TestConstants.Shows.ShowID, SeasonNumber, translations, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            var episodes = response.Content!.ToList();
            episodes.Count.ShouldBe(10);

            TraktEpisode firstEpisode = episodes[0];
            firstEpisode.Number.ShouldBe(1U);
            firstEpisode.Season.ShouldBe(1U);
            firstEpisode.Title.ShouldBe("Winter Is Coming");
            firstEpisode.IDs!.Trakt.ShouldBe(73640U);
            firstEpisode.IDs!.IMDB.ShouldBe("tt1480055");
            firstEpisode.Runtime.ShouldBe(62U);
            firstEpisode.EpisodeType.ShouldBe(TraktEpisodeType.SeriesPremiere);

            firstEpisode.Translations.ShouldNotBeNull();
            var translation = firstEpisode.Translations!.First();
            translation.Language.ShouldBe("es");
            translation.Title.ShouldBe("Se acerca el invierno");
        }

        [Theory]
        [InlineData(null, null, $"{GetSeasonEpisodesUri}/game-of-thrones/seasons/1", "Seasons\\seasonepisodes.json")]
        public async Task TestGetSeasonEpisodesWithSlug(string? translations, TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktEpisode> response =
                await client.Seasons.GetSeasonEpisodesAsync(TestConstants.Shows.ShowSlug, SeasonNumber, translations, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);

            TraktEpisode lastEpisode = response.Content![response.Content.Count - 1];
            lastEpisode.Number.ShouldBe(10U);
            lastEpisode.Title.ShouldBe("Fire and Blood");
            lastEpisode.EpisodeType.ShouldBe(TraktEpisodeType.SeasonFinale);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetSeasonEpisodesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonEpisodesUri}/1390/seasons/{SeasonNumber}", statusCode);

            try
            {
                await client.Seasons.GetSeasonEpisodesAsync(TestConstants.Shows.ShowID, SeasonNumber,
                                                           cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetSeasonEpisodesWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonepisodes.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonEpisodesUri}/game-of-thrones/seasons/{SeasonNumber}", responseContent);

#pragma warning disable CS8625
            Func<Task<TraktListResponse<TraktEpisode>>> act =
                () => client.Seasons.GetSeasonEpisodesAsync(default(TraktShowIDs), SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625

            await act.ShouldThrowAsync<ArgumentException>();

            var showIDs = new TraktShowIDs();

            act = () => client.Seasons.GetSeasonEpisodesAsync(showIDs, SeasonNumber, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
