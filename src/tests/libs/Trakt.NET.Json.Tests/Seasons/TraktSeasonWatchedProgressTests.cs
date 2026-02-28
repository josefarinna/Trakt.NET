namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonWatchedProgressTests
    {
        [Fact]
        public void TestTraktSeasonWatchedProgressConstructor()
        {
            var watchedProgress = new TraktSeasonWatchedProgress();

            watchedProgress.Title.ShouldBeNull();
            watchedProgress.Aired.ShouldBeNull();
            watchedProgress.Completed.ShouldBeNull();
            watchedProgress.Stats.ShouldBeNull();
            watchedProgress.Episodes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSeasonWatchedProgressFromJson()
        {
            TraktSeasonWatchedProgress? watchedProgress = await TestUtility.DeserializeJsonAsync<TraktSeasonWatchedProgress>("Seasons\\seasonwatchedprogress.json");

            watchedProgress.ShouldNotBeNull();

            watchedProgress.Title.ShouldBe("Season 1");
            watchedProgress.Aired.ShouldBe(10U);
            watchedProgress.Completed.ShouldBe(10U);

            watchedProgress.Stats.ShouldNotBeNull();
            watchedProgress.Stats.PlayCount.ShouldBe(10U);
            watchedProgress.Stats.MinutesWatched.ShouldBe(567U);
            watchedProgress.Stats.MinutesLeft.ShouldBe(0U);

            watchedProgress.Episodes.ShouldNotBeNull();

            TraktEpisodeWatchedProgress episode1 = watchedProgress.Episodes[0];
            episode1.ShouldNotBeNull();
            episode1.Number.ShouldBe(1U);
            episode1.Completed.ShouldBe(true);
            episode1.LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2012-10-09T14:32:00.000Z"));

            episode1.Stats.ShouldNotBeNull();
            episode1.Stats!.PlayCount.ShouldBe(1U);
            episode1.Stats!.MinutesWatched.ShouldBe(62U);
        }
    }
}
