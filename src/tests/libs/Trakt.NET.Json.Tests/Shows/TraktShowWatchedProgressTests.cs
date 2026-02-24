namespace TraktNET.Json.Shows
{
    public sealed class TraktShowWatchedProgressTests
    {
        [Fact]
        public void TestTraktShowWatchedProgressConstructor()
        {
            var watchedProgress = new TraktShowWatchedProgress();

            watchedProgress.Aired.ShouldBeNull();
            watchedProgress.Completed.ShouldBeNull();
            watchedProgress.LastWatchedAt.ShouldBeNull();
            watchedProgress.ResetAt.ShouldBeNull();
            watchedProgress.Stats.ShouldBeNull();
            watchedProgress.Seasons.ShouldBeNull();
            watchedProgress.HiddenSeasons.ShouldBeNull();
            watchedProgress.NextEpisode.ShouldBeNull();
            watchedProgress.LastEpisode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktShowWatchedProgressFromJson()
        {
            TraktShowWatchedProgress? watchedProgress = await TestUtility.DeserializeJsonAsync<TraktShowWatchedProgress>("Shows\\showwatchedprogress.json");

            watchedProgress.ShouldNotBeNull();

            watchedProgress!.Aired.ShouldBe(73U);
            watchedProgress.Completed.ShouldBe(73U);
            watchedProgress.LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2019-05-20T11:45:00.000Z"));
            watchedProgress.ResetAt.ShouldBeNull();

            watchedProgress.LastEpisode.ShouldNotBeNull();
            watchedProgress.LastEpisode!.Season.ShouldBe(8U);
            watchedProgress.LastEpisode!.Number.ShouldBe(6U);
            watchedProgress.LastEpisode!.Title.ShouldBe("The Iron Throne");
            watchedProgress.LastEpisode!.IDs.ShouldNotBeNull();
            watchedProgress.LastEpisode!.IDs!.Trakt.ShouldBe(3465698U);

            watchedProgress.NextEpisode.ShouldBeNull();

            watchedProgress.Seasons.ShouldNotBeNull();
            watchedProgress.Seasons!.Count.ShouldBe(8);

            TraktSeasonWatchedProgress season1 = watchedProgress.Seasons[0];
            season1.ShouldNotBeNull();
            season1.Number.ShouldBe(1U);
            season1.Aired.ShouldBe(10U);
            season1.Completed.ShouldBe(10U);

            season1.Stats.ShouldNotBeNull();
            season1.Stats!.PlayCount.ShouldBe(10U);
            season1.Stats!.MinutesWatched.ShouldBe(567U);

            season1.Episodes.ShouldNotBeNull();
            season1.Episodes!.Count.ShouldBe(10);

            TraktEpisodeWatchedProgress episode1 = season1.Episodes[0];
            episode1.ShouldNotBeNull();
            episode1.Number.ShouldBe(1U);
            episode1.Completed.ShouldBe(true);
            episode1.LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2012-10-09T14:32:00.000Z"));

            episode1.Stats.ShouldNotBeNull();
            episode1.Stats!.PlayCount.ShouldBe(1U);
            episode1.Stats!.MinutesWatched.ShouldBe(62U);

            watchedProgress.HiddenSeasons.ShouldNotBeNull();
            watchedProgress.HiddenSeasons!.Count.ShouldBe(0);
        }
    }
}
