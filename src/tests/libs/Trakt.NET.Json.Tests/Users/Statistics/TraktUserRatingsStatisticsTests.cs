namespace TraktNET.Json.Users
{
    public sealed class TraktUserRatingsStatisticsTests
    {
        [Fact]
        public void TestTraktUserRatingsStatisticsDefaultConstructor()
        {
            var userRatingsStatistics = new TraktUserRatingsStatistics();

            userRatingsStatistics.Total.ShouldBeNull();
            userRatingsStatistics.Distribution.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserRatingsStatisticsFromJson()
        {
            TraktUserRatingsStatistics? userRatingsStatistics = await TestUtility.DeserializeJsonAsync<TraktUserRatingsStatistics>("Users\\userratingsstatistics.json");

            userRatingsStatistics.ShouldNotBeNull();
            userRatingsStatistics.Total.ShouldBe(9257U);
            userRatingsStatistics.Distribution.ShouldNotBeNull();
            userRatingsStatistics.Distribution.ShouldNotBeEmpty();
            userRatingsStatistics.Distribution.Count.ShouldBe(10);
            userRatingsStatistics.Distribution.ShouldBe(new Dictionary<string, uint>
            {
                ["1"] = 78U,
                ["2"] = 45U,
                ["3"] = 55U,
                ["4"] = 96U,
                ["5"] = 183U,
                ["6"] = 545U,
                ["7"] = 1361U,
                ["8"] = 2259U,
                ["9"] = 1772U,
                ["10"] = 2863U
            });
        }
    }
}
