namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncProgressWatchedItemTests
    {
        [Fact]
        public void TestTraktSyncProgressWatchedItemDefaultConstructor()
        {
            var item = new TraktSyncProgressWatchedItem();

            item.Show.ShouldBeNull();
            item.Progress.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncProgressWatchedItemFromMinimalJson()
        {
            TraktSyncProgressWatchedItem? item = await TestUtility.DeserializeJsonAsync<TraktSyncProgressWatchedItem>("Syncs\\Progress\\syncprogresswatched_minimal.json");

            item.ShouldNotBeNull();
            item.Show.ShouldNotBeNull();
            item.Show.Title.ShouldBe("Breaking Bad");
            item.Show.Year.ShouldBeNull();
            item.Show.IDs.ShouldNotBeNull();
            item.Show.IDs.Trakt.ShouldBe(1U);
            item.Show.IDs.Slug.ShouldBeNullOrEmpty();

            item.Progress.ShouldNotBeNull();
            item.Progress.Aired.ShouldBe(62U);
            item.Progress.Completed.ShouldBe(62U);
            item.Progress.LastWatchedAt.ShouldBeNull();
            item.Progress.ResetAt.ShouldBeNull();
            item.Progress.NextEpisode.ShouldBeNull();
            item.Progress.LastEpisode.ShouldBeNull();
            item.Progress.Stats.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncProgressWatchedItemFromFullJson()
        {
            TraktSyncProgressWatchedItem? item = await TestUtility.DeserializeJsonAsync<TraktSyncProgressWatchedItem>("Syncs\\Progress\\syncprogresswatched_item.json");

            item.ShouldNotBeNull();
            item.Show.ShouldNotBeNull();
            item.Show.Title.ShouldBe("Breaking Bad");
            item.Show.Year.ShouldBe(2008U);
            item.Show.IDs.ShouldNotBeNull();
            item.Show.IDs.Trakt.ShouldBe(1U);
            item.Show.IDs.Slug.ShouldBe("breaking-bad");
            item.Show.IDs.TVDB.ShouldBe(81189U);
            item.Show.IDs.IMDB.ShouldBe("tt0903747");
            item.Show.IDs.TMDB.ShouldBe(1396U);

            item.Progress.ShouldNotBeNull();
            item.Progress.Aired.ShouldBe(62U);
            item.Progress.Completed.ShouldBe(62U);
            item.Progress.LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-13T17:00:54.000Z"));
            item.Progress.ResetAt.ShouldBeNull();
            item.Progress.NextEpisode.ShouldBeNull();
            item.Progress.LastEpisode.ShouldNotBeNull();
            item.Progress.LastEpisode.Season.ShouldBe(5U);
            item.Progress.LastEpisode.Number.ShouldBe(16U);
            item.Progress.LastEpisode.Title.ShouldBe("Felina");
            item.Progress.LastEpisode.IDs.ShouldNotBeNull();
            item.Progress.LastEpisode.IDs.Trakt.ShouldBe(107U);
            item.Progress.LastEpisode.IDs.TVDB.ShouldBe(4627451U);
            item.Progress.LastEpisode.IDs.IMDB.ShouldBe("tt2301451");
            item.Progress.LastEpisode.IDs.TMDB.ShouldBe(62161U);

            item.Progress.Stats.ShouldNotBeNull();
            item.Progress.Stats.PlayCount.ShouldBe(62U);
            item.Progress.Stats.MinutesWatched.ShouldBe(2980U);
            item.Progress.Stats.MinutesLeft.ShouldBe(0U);
        }
    }
}
