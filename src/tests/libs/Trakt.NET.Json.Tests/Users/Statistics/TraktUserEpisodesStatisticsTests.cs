namespace TraktNET.Json.Users
{
    public sealed class TraktUserEpisodesStatisticsTests
    {
        [Fact]
        public void TestTraktUserEpisodesStatisticsDefaultConstructor()
        {
            var userEpisodesStatistics = new TraktUserEpisodesStatistics();

            userEpisodesStatistics.Plays.ShouldBeNull();
            userEpisodesStatistics.Watched.ShouldBeNull();
            userEpisodesStatistics.Minutes.ShouldBeNull();
            userEpisodesStatistics.Collected.ShouldBeNull();
            userEpisodesStatistics.Ratings.ShouldBeNull();
            userEpisodesStatistics.Comments.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserEpisodesStatisticsFromJson()
        {
            TraktUserEpisodesStatistics? userEpisodesStatistics = await TestUtility.DeserializeJsonAsync<TraktUserEpisodesStatistics>("Users\\userepisodesstatistics.json");

            userEpisodesStatistics.ShouldNotBeNull();
            userEpisodesStatistics.Plays.ShouldBe(552U);
            userEpisodesStatistics.Watched.ShouldBe(534U);
            userEpisodesStatistics.Minutes.ShouldBe(17330U);
            userEpisodesStatistics.Collected.ShouldBe(117U);
            userEpisodesStatistics.Ratings.ShouldBe(64U);
            userEpisodesStatistics.Comments.ShouldBe(14U);
        }
    }
}
