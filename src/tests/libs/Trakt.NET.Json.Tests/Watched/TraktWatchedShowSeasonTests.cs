namespace TraktNET.Json.Watched
{
    public sealed class TraktWatchedShowSeasonTests
    {
        [Fact]
        public void TestTraktWatchedShowSeasonDefaultConstructor()
        {
            var watchedShowSeason = new TraktWatchedShowSeason();

            watchedShowSeason.Number.ShouldBeNull();
            watchedShowSeason.Episodes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchedShowSeasonFromJson()
        {
            TraktWatchedShowSeason? watchedShowSeason = await TestUtility.DeserializeJsonAsync<TraktWatchedShowSeason>("Watched\\watchedshowseason.json");

            watchedShowSeason.ShouldNotBeNull();
            watchedShowSeason.Number.ShouldBe(1U);

            watchedShowSeason.Episodes.ShouldNotBeNull();
            watchedShowSeason.Episodes.Count.ShouldBe(2);
            var episodes = watchedShowSeason.Episodes.ToArray();

            episodes[0].Number.ShouldBe(1U);
            episodes[0].Plays.ShouldBe(1U);
            episodes[0].LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-12T17:00:54.000Z").ToUniversalTime());

            episodes[1].Number.ShouldBe(2U);
            episodes[1].Plays.ShouldBe(1U);
            episodes[1].LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }
    }
}
