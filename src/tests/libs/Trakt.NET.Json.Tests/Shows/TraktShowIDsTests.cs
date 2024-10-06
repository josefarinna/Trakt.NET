namespace TraktNET.Json.Shows
{
    public sealed class TraktShowIDsTests
    {
        [Fact]
        public void TestTraktShowIDsConstructor()
        {
            var showIDs = new TraktShowIDs();

            showIDs.Trakt.Should().BeNull();
            showIDs.Slug.Should().BeNull();
            showIDs.TVDB.Should().BeNull();
            showIDs.IMDB.Should().BeNull();
            showIDs.TMDB.Should().BeNull();

            showIDs.HasAnyID.Should().BeFalse();
            showIDs.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktShowIDsFromJson()
        {
            TraktShowIDs? showIDs = await TestUtility.DeserializeJsonAsync<TraktShowIDs>("Shows\\showids.json");

            showIDs.Should().NotBeNull();

            showIDs!.Trakt.Should().Be(1390U);
            showIDs!.Slug.Should().Be("game-of-thrones");
            showIDs!.TVDB.Should().Be(121361U);
            showIDs!.IMDB.Should().Be("tt0944947");
            showIDs!.TMDB.Should().Be(1399U);

            showIDs!.HasAnyID.Should().BeTrue();
            showIDs!.BestID.Should().Be("game-of-thrones");
        }
    }
}
