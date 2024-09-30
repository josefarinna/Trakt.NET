namespace TraktNET.Json.General
{
    public sealed class TraktStudioIDsTests
    {
        [Fact]
        public void TestTraktStudioIDsConstructor()
        {
            var studioIDs = new TraktStudioIDs();

            studioIDs.Trakt.Should().BeNull();
            studioIDs.Slug.Should().BeNull();
            studioIDs.TMDB.Should().BeNull();

            studioIDs.HasAnyID.Should().BeFalse();
            studioIDs.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktStudioIDsFromJson()
        {
            TraktStudioIDs? studioIDs = await TestUtility.DeserializeJsonAsync<TraktStudioIDs>("General\\studioids.json");

            studioIDs.Should().NotBeNull();

            studioIDs!.Trakt.Should().Be(181U);
            studioIDs!.Slug.Should().Be("marvel-studios");
            studioIDs!.TMDB.Should().Be(420U);

            studioIDs!.HasAnyID.Should().BeTrue();
            studioIDs!.BestID.Should().Be("marvel-studios");
        }
    }
}
