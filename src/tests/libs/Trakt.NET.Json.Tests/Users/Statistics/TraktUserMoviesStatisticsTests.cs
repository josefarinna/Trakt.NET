namespace TraktNET.Json.Users
{
    public sealed class TraktUserMoviesStatisticsTests
    {
        [Fact]
        public void TestTraktUserMoviesStatisticsDefaultConstructor()
        {
            var userMoviesStatistics = new TraktUserMoviesStatistics();

            userMoviesStatistics.Plays.ShouldBeNull();
            userMoviesStatistics.Watched.ShouldBeNull();
            userMoviesStatistics.Minutes.ShouldBeNull();
            userMoviesStatistics.Collected.ShouldBeNull();
            userMoviesStatistics.Ratings.ShouldBeNull();
            userMoviesStatistics.Comments.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserMoviesStatisticsFromJson()
        {
            TraktUserMoviesStatistics? userMoviesStatistics = await TestUtility.DeserializeJsonAsync<TraktUserMoviesStatistics>("Users\\usermoviesstatistics.json");

            userMoviesStatistics.ShouldNotBeNull();
            userMoviesStatistics.Plays.ShouldBe(552U);
            userMoviesStatistics.Watched.ShouldBe(534U);
            userMoviesStatistics.Minutes.ShouldBe(17330U);
            userMoviesStatistics.Collected.ShouldBe(117U);
            userMoviesStatistics.Ratings.ShouldBe(64U);
            userMoviesStatistics.Comments.ShouldBe(14U);
        }
    }
}
