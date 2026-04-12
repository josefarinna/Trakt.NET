namespace TraktNET.Json.Users
{
    public sealed class TraktUserSeasonsStatisticsTests
    {
        [Fact]
        public void TestTraktUserSeasonsStatisticsDefaultConstructor()
        {
            var userSeasonsStatistics = new TraktUserSeasonsStatistics();

            userSeasonsStatistics.Ratings.ShouldBeNull();
            userSeasonsStatistics.Comments.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserSeasonsStatisticsFromJson()
        {
            TraktUserSeasonsStatistics? userSeasonsStatistics = await TestUtility.DeserializeJsonAsync<TraktUserSeasonsStatistics>("Users\\userseasonsstatistics.json");

            userSeasonsStatistics.ShouldNotBeNull();
            userSeasonsStatistics.Ratings.ShouldBe(6U);
            userSeasonsStatistics.Comments.ShouldBe(1U);
        }
    }
}
