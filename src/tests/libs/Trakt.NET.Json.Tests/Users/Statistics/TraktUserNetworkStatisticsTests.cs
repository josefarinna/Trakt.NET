namespace TraktNET.Json.Users
{
    public sealed class TraktUserNetworkStatisticsTests
    {
        [Fact]
        public void TestTraktUserNetworkStatisticsDefaultConstructor()
        {
            var userNetworkStatistics = new TraktUserNetworkStatistics();

            userNetworkStatistics.Friends.ShouldBeNull();
            userNetworkStatistics.Followers.ShouldBeNull();
            userNetworkStatistics.Following.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserNetworkStatisticsFromJson()
        {
            TraktUserNetworkStatistics? userNetworkStatistics = await TestUtility.DeserializeJsonAsync<TraktUserNetworkStatistics>("Users\\usernetworkstatistics.json");

            userNetworkStatistics.ShouldNotBeNull();
            userNetworkStatistics.Friends.ShouldBe(1U);
            userNetworkStatistics.Followers.ShouldBe(4U);
            userNetworkStatistics.Following.ShouldBe(11U);
        }
    }
}
