namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonIDsTests
    {
        [Fact]
        public void TestTraktSeasonIDsConstructor()
        {
            var seasonIDs = new TraktSeasonIDs();

            seasonIDs.Trakt.Should().BeNull();
            seasonIDs.TVDB.Should().BeNull();
            seasonIDs.TMDB.Should().BeNull();

            seasonIDs.HasAnyID.Should().BeFalse();
            seasonIDs.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktSeasonIDsFromJson()
        {
            TraktSeasonIDs? seasonIDs = await TestUtility.DeserializeJsonAsync<TraktSeasonIDs>("Seasons\\seasonids.json");

            seasonIDs.Should().NotBeNull();

            seasonIDs!.Trakt.Should().Be(3963U);
            seasonIDs!.TVDB.Should().Be(364731U);
            seasonIDs!.TMDB.Should().Be(3624U);

            seasonIDs!.HasAnyID.Should().BeTrue();
            seasonIDs!.BestID.Should().Be("3963");
        }
    }
}
