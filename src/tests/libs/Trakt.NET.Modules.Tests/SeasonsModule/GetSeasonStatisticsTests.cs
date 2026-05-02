using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonStatisticsTests
    {
        private static readonly string GetSeasonStatisticsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/stats";
        private const uint SeasonNr = 1U;

        [Fact]
        public async Task TestGetSeasonStatistics()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonstatistics.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonStatisticsUri, responseContent);
            
            TraktResponse<TraktSeasonStatistics> response = await client.Seasons.GetSeasonStatisticsAsync($"{TestConstants.Shows.ShowID}", SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();

            TraktSeasonStatistics responseValue = response.Content!;

            responseValue.Watchers.ShouldBe(312487U);
            responseValue.Plays.ShouldBe(3697671U);
            responseValue.Collectors.ShouldBe(1748222U);
            responseValue.CollectedEpisodes.ShouldBe(1825953U);
            responseValue.Comments.ShouldBe(17U);
            responseValue.Lists.ShouldBe(1169U);
            responseValue.Votes.ShouldBe(6553U);
        }

        [Fact]
        public async Task TestGetSeasonStatisticsWithTraktID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonstatistics.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonStatisticsUri, responseContent);
            
            TraktResponse<TraktSeasonStatistics> response = await client.Seasons.GetSeasonStatisticsAsync(TestConstants.Shows.ShowID, SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonStatisticsWithShowIDsTraktID()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonstatistics.json");

            TraktClient client = ModuleTestUtility.GetClient(GetSeasonStatisticsUri, responseContent);
            
            TraktResponse<TraktSeasonStatistics> response = await client.Seasons.GetSeasonStatisticsAsync(showIDs, SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonStatisticsWithShowIDsSlug()
        {
            var showIDs = new TraktShowIDs
            {
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonstatistics.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/stats", responseContent);
            
            TraktResponse<TraktSeasonStatistics> response = await client.Seasons.GetSeasonStatisticsAsync(showIDs, SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonStatisticsWithShowIDs()
        {
            var showIDs = new TraktShowIDs
            {
                Trakt = TestConstants.Shows.ShowID,
                Slug = TestConstants.Shows.ShowSlug
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonstatistics.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/stats", responseContent);
            
            TraktResponse<TraktSeasonStatistics> response = await client.Seasons.GetSeasonStatisticsAsync(showIDs, SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonStatisticsWithShow()
        {
            var show = new TraktShow
            {
                IDs = new TraktShowIDs
                {
                    Trakt = TestConstants.Shows.ShowID,
                    Slug = TestConstants.Shows.ShowSlug
                }
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonstatistics.json");

            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/stats", responseContent);
            
            TraktResponse<TraktSeasonStatistics> response = await client.Seasons.GetSeasonStatisticsAsync(show, SeasonNr, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetSeasonStatisticsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonStatisticsUri, statusCode);

            Func<Task<TraktResponse<TraktSeasonStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(TestConstants.Shows.ShowID, SeasonNr, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonStatisticsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonStatisticsUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktSeasonStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(default(TraktShowIDs)!, SeasonNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonStatisticsAsync(default(TraktShow)!, SeasonNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonStatisticsAsync(new TraktShowIDs(), SeasonNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonStatisticsAsync(0, SeasonNr, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
