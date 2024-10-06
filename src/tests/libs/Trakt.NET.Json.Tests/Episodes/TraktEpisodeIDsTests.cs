namespace TraktNET.Json.Episodes
{
    public sealed class TraktEpisodeIDsTests
    {
        [Fact]
        public void TestTraktEpisodeIDsConstructor()
        {
            var episodeIDs = new TraktEpisodeIDs();

            episodeIDs.Trakt.Should().BeNull();
            episodeIDs.TVDB.Should().BeNull();
            episodeIDs.IMDB.Should().BeNull();
            episodeIDs.TMDB.Should().BeNull();

            episodeIDs.HasAnyID.Should().BeFalse();
            episodeIDs.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktEpisodeIDsFromJson()
        {
            TraktEpisodeIDs? episodeIDs = await TestUtility.DeserializeJsonAsync<TraktEpisodeIDs>("Episodes\\episodeids.json");

            episodeIDs.Should().NotBeNull();

            episodeIDs!.Trakt.Should().Be(73640U);
            episodeIDs!.TVDB.Should().Be(3254641U);
            episodeIDs!.IMDB.Should().Be("tt1480055");
            episodeIDs!.TMDB.Should().Be(63056U);

            episodeIDs!.HasAnyID.Should().BeTrue();
            episodeIDs!.BestID.Should().Be("73640");
        }
    }
}
