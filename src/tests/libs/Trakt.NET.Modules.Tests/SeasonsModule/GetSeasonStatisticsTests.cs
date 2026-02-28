using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonStatisticsTests
    {
        private const string GetSeasonStatisticsUriPrefix = "shows";
        private const string GetSeasonStatisticsUriSuffix = "stats";
        private const uint SeasonNumber = 1U;
        private static readonly string GetSeasonStatisticsUri = $"{GetSeasonStatisticsUriPrefix}/{TestConstants.Shows.ShowID}/seasons/1/{GetSeasonStatisticsUriSuffix}";
        private static readonly string GetSeasonStatisticsUriWithSlug = $"{GetSeasonStatisticsUriPrefix}/{TestConstants.Shows.ShowSlug}/seasons/1/{GetSeasonStatisticsUriSuffix}";

        [Fact]
        public async Task TestGetSeasonStatisticsWithID()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonStatisticsUri, responseContent);

            TraktResponse<TraktSeasonStatistics> response = await client.Seasons.GetSeasonStatisticsAsync(TestConstants.Shows.ShowID, SeasonNumber, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetSeasonStatisticsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonStatisticsUriWithSlug, responseContent);

            TraktResponse<TraktSeasonStatistics> response = await client.Seasons.GetSeasonStatisticsAsync(TestConstants.Shows.ShowSlug, SeasonNumber, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        [Fact]
        public async Task TestGetSeasonStatisticsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonStatisticsUriWithSlug, responseContent);

            TraktResponse<TraktSeasonStatistics> response = await client.Seasons.GetSeasonStatisticsAsync(TestConstants.Shows.ShowIDs, SeasonNumber, TestContext.Current.CancellationToken);

            ValidateResponse(response);
        }

        private static void ValidateResponse(TraktResponse<TraktSeasonStatistics> response)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            TraktSeasonStatistics seasonStatistics = response.Content!;

            seasonStatistics.Watchers.ShouldBe(312487U);
            seasonStatistics.Plays.ShouldBe(3697671U);
            seasonStatistics.Collectors.ShouldBe(1748222U);
            seasonStatistics.CollectedEpisodes.ShouldBe(1825953U);
            seasonStatistics.Comments.ShouldBe(17U);
            seasonStatistics.Lists.ShouldBe(1169U);
            seasonStatistics.Votes.ShouldBe(6553U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        public async Task TestGetSeasonStatisticsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonStatisticsUri, statusCode);

            try
            {
                await client.Seasons.GetSeasonStatisticsAsync(TestConstants.Shows.ShowID, SeasonNumber, TestContext.Current.CancellationToken);
                Assert.Fail("Exception should have been thrown");
            }
            catch (Exception exception)
            {
                exception.GetType().ShouldBe(exceptionType);
            }
        }

        [Fact]
        public async Task TestGetSeasonStatisticsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonstatistics.json");
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonStatisticsUriWithSlug, responseContent);

#pragma warning disable CS8625
            Func<Task<TraktResponse<TraktSeasonStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(default(TraktShowIDs), SeasonNumber, TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<ArgumentException>();

            var ShowIDs = new TraktShowIDs();
            act = () => client.Seasons.GetSeasonStatisticsAsync(ShowIDs, SeasonNumber, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
