namespace TraktNET.Json.Watched
{
    public sealed class TraktWatchedEpisodeTests
    {
        [Fact]
        public void TestTraktWatchedEpisodeDefaultConstructor()
        {
            var watchedEpisode = new TraktWatchedEpisode();

            watchedEpisode.Plays.ShouldBeNull();
            watchedEpisode.LastWatchedAt.ShouldBeNull();
            watchedEpisode.LastUpdatedAt.ShouldBeNull();
            watchedEpisode.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchedEpisodeFromJson()
        {
            TraktWatchedEpisode? watchedEpisode = await TestUtility.DeserializeJsonAsync<TraktWatchedEpisode>("Watched\\watchedepisode.json");

            watchedEpisode.ShouldNotBeNull();
            watchedEpisode.Plays.ShouldBe(1U);
            watchedEpisode.LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-04-23T19:02:00.000Z"));
            watchedEpisode.LastUpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-04-23T19:02:00.000Z"));

            watchedEpisode.Episode.ShouldNotBeNull();
            watchedEpisode.Episode.Season.ShouldBe(4U);
            watchedEpisode.Episode.Number.ShouldBe(8U);
            watchedEpisode.Episode.Title.ShouldBe("DON'T LEAVE ME HANGING HERE");
            watchedEpisode.Episode.IDs.ShouldNotBeNull();
            watchedEpisode.Episode.IDs.Trakt.ShouldBe(14007201U);
            watchedEpisode.Episode.IDs.TVDB.ShouldBe(11572740U);
            watchedEpisode.Episode.IDs.IMDB.ShouldBe("tt39848785");
            watchedEpisode.Episode.IDs.TMDB.ShouldBe(6951284U);
        }
    }
}
