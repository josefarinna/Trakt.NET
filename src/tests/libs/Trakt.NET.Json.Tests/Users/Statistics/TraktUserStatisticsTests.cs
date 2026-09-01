namespace TraktNET.Json.Users
{
    public sealed class TraktUserStatisticsTests
    {
        [Fact]
        public void TestTraktUserStatisticsDefaultConstructor()
        {
            var userStatistics = new TraktUserStatistics();

            userStatistics.Movies.ShouldBeNull();
            userStatistics.Shows.ShouldBeNull();
            userStatistics.Seasons.ShouldBeNull();
            userStatistics.Episodes.ShouldBeNull();
            userStatistics.Network.ShouldBeNull();
            userStatistics.Ratings.ShouldBeNull();
            userStatistics.Progress.ShouldBeNull();
            userStatistics.Lists.ShouldBeNull();
            userStatistics.TotalMinutes.ShouldBeNull();
            userStatistics.TotalPlays.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserStatisticsFromJson()
        {
            TraktUserStatistics? userStatistics = await TestUtility.DeserializeJsonAsync<TraktUserStatistics>("Users\\userstatistics.json");

            userStatistics.ShouldNotBeNull();

            userStatistics.Movies.ShouldNotBeNull();
            userStatistics.Movies.Plays.ShouldBe(552U);
            userStatistics.Movies.Watched.ShouldBe(534U);
            userStatistics.Movies.Minutes.ShouldBe(17330U);
            userStatistics.Movies.Collected.ShouldBe(117U);
            userStatistics.Movies.Ratings.ShouldBe(64U);
            userStatistics.Movies.Comments.ShouldBe(14U);

            userStatistics.Shows.ShouldNotBeNull();
            userStatistics.Shows.Watched.ShouldBe(534U);
            userStatistics.Shows.Collected.ShouldBe(117U);
            userStatistics.Shows.Ratings.ShouldBe(64U);
            userStatistics.Shows.Comments.ShouldBe(14U);

            userStatistics.Seasons.ShouldNotBeNull();
            userStatistics.Seasons.Ratings.ShouldBe(6U);
            userStatistics.Seasons.Comments.ShouldBe(1U);

            userStatistics.Episodes.ShouldNotBeNull();
            userStatistics.Episodes.Plays.ShouldBe(552U);
            userStatistics.Episodes.Watched.ShouldBe(534U);
            userStatistics.Episodes.Minutes.ShouldBe(17330U);
            userStatistics.Episodes.Collected.ShouldBe(117U);
            userStatistics.Episodes.Ratings.ShouldBe(64U);
            userStatistics.Episodes.Comments.ShouldBe(14U);

            userStatistics.Network.ShouldNotBeNull();
            userStatistics.Network.Friends.ShouldBe(1U);
            userStatistics.Network.Followers.ShouldBe(4U);
            userStatistics.Network.Following.ShouldBe(11U);

            userStatistics.Ratings.ShouldNotBeNull();
            userStatistics.Ratings.Total.ShouldBe(9257U);
            userStatistics.Ratings.Distribution.ShouldNotBeNull();
            userStatistics.Ratings.Distribution.ShouldNotBeEmpty();
            userStatistics.Ratings.Distribution.Count.ShouldBe(10);
            userStatistics.Ratings.Distribution.ShouldBe(new Dictionary<string, uint>
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

            userStatistics.Progress.ShouldNotBeNull();
            userStatistics.Progress.Started.ShouldBe(388U);
            userStatistics.Progress.Finished.ShouldBe(276U);
            userStatistics.Progress.Dropped.ShouldBe(22U);

            userStatistics.Lists.ShouldBe(31U);
            userStatistics.TotalMinutes.ShouldBe(618949U);
            userStatistics.TotalPlays.ShouldBe(12473U);
        }
    }
}
