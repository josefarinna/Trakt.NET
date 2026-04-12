namespace TraktNET.Json.Users
{
    public sealed class TraktUserShowsStatisticsTests
    {
        [Fact]
        public void TestTraktUserShowsStatisticsDefaultConstructor()
        {
            var userShowsStatistics = new TraktUserShowsStatistics();

            userShowsStatistics.Watched.ShouldBeNull();
            userShowsStatistics.Collected.ShouldBeNull();
            userShowsStatistics.Ratings.ShouldBeNull();
            userShowsStatistics.Comments.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserShowsStatisticsFromJson()
        {
            TraktUserShowsStatistics? userShowsStatistics = await TestUtility.DeserializeJsonAsync<TraktUserShowsStatistics>("Users\\usershowsstatistics.json");

            userShowsStatistics.ShouldNotBeNull();
            userShowsStatistics.Watched.ShouldBe(534U);
            userShowsStatistics.Collected.ShouldBe(117U);
            userShowsStatistics.Ratings.ShouldBe(64U);
            userShowsStatistics.Comments.ShouldBe(14U);
        }
    }
}
