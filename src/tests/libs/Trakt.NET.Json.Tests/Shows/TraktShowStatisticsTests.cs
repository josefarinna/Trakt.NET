namespace TraktNET.Json.Shows
{
    public sealed class TraktShowStatisticsTests
    {
        [Fact]
        public void TestTraktShowStatisticsConstructor()
        {
            var showStatistics = new TraktShowStatistics();

            showStatistics.Watchers.ShouldBeNull();
            showStatistics.Plays.ShouldBeNull();
            showStatistics.Collectors.ShouldBeNull();
            showStatistics.CollectedEpisodes.ShouldBeNull();
            showStatistics.Comments.ShouldBeNull();
            showStatistics.Lists.ShouldBeNull();
            showStatistics.Votes.ShouldBeNull();
            showStatistics.Favorited.ShouldBeNull();
            showStatistics.Recommended.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktShowStatisticsFromJson()
        {
            TraktShowStatistics? showStatistics = await TestUtility.DeserializeJsonAsync<TraktShowStatistics>("Shows\\showstatistics.json");

            showStatistics.ShouldNotBeNull();

            showStatistics!.Watchers.ShouldBe(343626U);
            showStatistics!.Plays.ShouldBe(26909587U);
            showStatistics!.Collectors.ShouldBe(1778445U);
            showStatistics!.CollectedEpisodes.ShouldBe(1853440U);
            showStatistics!.Comments.ShouldBe(449U);
            showStatistics!.Lists.ShouldBe(368247U);
            showStatistics!.Votes.ShouldBe(145026U);
            showStatistics!.Favorited.ShouldBe(13892U);
            showStatistics!.Recommended.ShouldBe(13892U);
        }
    }
}
