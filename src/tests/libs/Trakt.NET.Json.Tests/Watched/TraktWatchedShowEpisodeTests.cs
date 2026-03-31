namespace TraktNET.Json.Watched
{
    public sealed class TraktWatchedShowEpisodeTests
    {
        [Fact]
        public void TestTraktWatchedShowEpisodeDefaultConstructor()
        {
            var watchedShowEpisode = new TraktWatchedShowEpisode();

            watchedShowEpisode.Number.ShouldBeNull();
            watchedShowEpisode.Plays.ShouldBeNull();
            watchedShowEpisode.LastWatchedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchedShowEpisodeFromJson()
        {
            TraktWatchedShowEpisode? watchedShowEpisode = await TestUtility.DeserializeJsonAsync<TraktWatchedShowEpisode>("Watched\\watchedshowepisode.json");

            watchedShowEpisode.ShouldNotBeNull();
            watchedShowEpisode.Number.ShouldBe(1U);
            watchedShowEpisode.Plays.ShouldBe(1U);
            watchedShowEpisode.LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-12T17:00:54.000Z"));
        }
    }
}
