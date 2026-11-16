using System.Net;

namespace TraktNET.EpisodesModule
{
    public sealed class GetEpisodeStatisticsTests
    {
        private readonly string GetEpisodeStatisticsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/{SeasonNr}/episodes/{EpisodeNr}/stats";
        private const uint SeasonNr = 1U;
        private const uint EpisodeNr = 1U;

        [Fact]
        public async Task TestGetEpisodeStatisticsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodestatistics.json");

            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeStatisticsUri, responseContent);
            
            TraktResponse<TraktEpisodeStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktEpisodeStatistics responseValue = response.Content;

            responseValue.Watchers.ShouldBe(233273U);
            responseValue.Plays.ShouldBe(303464U);
            responseValue.Collectors.ShouldBe(92759U);
            responseValue.Comments.ShouldBe(4U);
            responseValue.Lists.ShouldBe(418U);
            responseValue.Votes.ShouldBe(3919U);
        }

        [Fact]
        public async Task TestGetEpisodeStatisticsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodestatistics.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/stats",
                responseContent);

            TraktResponse<TraktEpisodeStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(TestConstants.Shows.ShowSlug, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeStatisticsWithIDs()
        {

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodestatistics.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/stats",
                responseContent);

            TraktResponse<TraktEpisodeStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(TestConstants.Shows.ShowIDs, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeStatisticsWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Episodes\\episodestatistics.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/episodes/{EpisodeNr}/stats",
                responseContent);

            TraktResponse<TraktEpisodeStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(show, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiEpisodeNotFoundException))]
        public async Task TestGetEpisodeStatisticsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeStatisticsUri, statusCode);

            Func<Task<TraktResponse<TraktEpisodeStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(TestConstants.Shows.TraktShowID, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetEpisodeStatisticsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetEpisodeStatisticsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktEpisodeStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(default(TraktShowIDs)!, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync(default(TraktShow)!, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync(new TraktShowIDs(), SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync(0, SeasonNr, EpisodeNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
