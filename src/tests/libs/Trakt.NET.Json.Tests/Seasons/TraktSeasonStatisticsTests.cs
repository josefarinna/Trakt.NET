namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonStatisticsTests
    {
        [Fact]
        public void TestTraktSeasonStatisticsConstructor()
        {
            var seasonStatistics = new TraktSeasonStatistics();

            seasonStatistics.Watchers.ShouldBeNull();
            seasonStatistics.Plays.ShouldBeNull();
            seasonStatistics.Collectors.ShouldBeNull();
            seasonStatistics.CollectedEpisodes.ShouldBeNull();
            seasonStatistics.Comments.ShouldBeNull();
            seasonStatistics.Lists.ShouldBeNull();
            seasonStatistics.Votes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSeasonStatisticsFromJson()
        {
            TraktSeasonStatistics? seasonStatistics = await TestUtility.DeserializeJsonAsync<TraktSeasonStatistics>("Seasons\\seasonstatistics.json");

            seasonStatistics.ShouldNotBeNull();

            seasonStatistics!.Watchers.ShouldBe(312487U);
            seasonStatistics!.Plays.ShouldBe(3697671U);
            seasonStatistics!.Collectors.ShouldBe(1748222U);
            seasonStatistics!.CollectedEpisodes.ShouldBe(1825953U);
            seasonStatistics!.Comments.ShouldBe(17U);
            seasonStatistics!.Lists.ShouldBe(1169U);
            seasonStatistics!.Votes.ShouldBe(6553U);
        }
    }
}
