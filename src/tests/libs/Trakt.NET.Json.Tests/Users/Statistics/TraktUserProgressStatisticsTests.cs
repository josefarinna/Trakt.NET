namespace TraktNET.Json.Users
{
    public sealed class TraktUserProgressStatisticsTests
    {
        [Fact]
        public void TestTraktUserProgressStatisticsDefaultConstructor()
        {
            var userProgressStatistics = new TraktUserProgressStatistics();

            userProgressStatistics.Started.ShouldBeNull();
            userProgressStatistics.Finished.ShouldBeNull();
            userProgressStatistics.Dropped.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserProgressStatisticsFromJson()
        {
            TraktUserProgressStatistics? userProgressStatistics = await TestUtility.DeserializeJsonAsync<TraktUserProgressStatistics>("Users\\userprogressstatistics.json");

            userProgressStatistics.ShouldNotBeNull();
            userProgressStatistics.Started.ShouldBe(388U);
            userProgressStatistics.Finished.ShouldBe(276U);
            userProgressStatistics.Dropped.ShouldBe(22U);
        }
    }
}
