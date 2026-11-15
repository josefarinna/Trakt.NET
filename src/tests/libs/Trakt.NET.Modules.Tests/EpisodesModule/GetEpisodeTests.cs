using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeTests
    {
        private readonly string GetEpisodeUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1")]
        [InlineData(ExtendedInfo, $"shows/{TestConstants.Shows.ShowID}/seasons/1/episodes/1?extended=full")]
        public async Task TestGetEpisodeWithID(TraktExtendedInfo? extendedInfo, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktResponse<TraktEpisode> response = await client.Episodes.GetEpisodeAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            TraktEpisode responseValue = response.Content;
            responseValue.Title.ShouldBe("Winter Is Coming");
            responseValue.Season.ShouldBe(1U);
            responseValue.Number.ShouldBe(1U);
            responseValue.NumberAbsolute.ShouldBe(1U);
            responseValue.Overview.ShouldBe("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            responseValue.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            responseValue.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-22T18:44:49.000Z"));
            responseValue.Rating.ShouldBe(8.08208f);
            responseValue.Votes.ShouldBe(14619U);
            responseValue.CommentCount.ShouldBe(38U);
            responseValue.IDs.ShouldNotBeNull();
            responseValue.IDs.Trakt.ShouldBe(73640U);
            responseValue.IDs.TVDB.ShouldBe(3254641U);
            responseValue.IDs.IMDB.ShouldBe("tt1480055");
            responseValue.IDs.TMDB.ShouldBe(63056U);
            responseValue.AvailableTranslations.ShouldNotBeNull();
            responseValue.AvailableTranslations.Count.ShouldBe(30);
            responseValue.Runtime.ShouldBe(62U);
            responseValue.EpisodeType.ShouldBe(TraktEpisodeType.SeriesPremiere);
        }

        [Fact]
        public async Task TestGetEpisodeWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}",
                responseContent);

            TraktResponse<TraktEpisode> response = await client.Episodes.GetEpisodeAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}", responseContent);

            TraktResponse<TraktEpisode> response = await client.Episodes.GetEpisodeAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeWithShow()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episode_full.json");

            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}", responseContent);

            TraktResponse<TraktEpisode> response = await client.Episodes.GetEpisodeAsync(show, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestGetEpisodeWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeUri, statusCode);

            Func<Task<TraktResponse<TraktEpisode>>> act = () => client.Episodes.GetEpisodeAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktEpisode>>> act = () => client.Episodes.GetEpisodeAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeAsync(default(TraktShow)!, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeAsync(0, SeasonNr, EpisodeNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
