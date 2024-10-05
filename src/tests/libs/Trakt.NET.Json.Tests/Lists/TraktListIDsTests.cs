namespace TraktNET.Json.Lists
{
    public sealed class TraktListIDsTests
    {
        [Fact]
        public void TestTraktListIDsConstructor()
        {
            var listIDs = new TraktListIDs();

            listIDs.Trakt.Should().BeNull();
            listIDs.Slug.Should().BeNull();

            listIDs.HasAnyID.Should().BeFalse();
            listIDs.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktListIDsFromJson()
        {
            TraktListIDs? listIDs = await TestUtility.DeserializeJsonAsync<TraktListIDs>("Lists\\listids.json");

            listIDs.Should().NotBeNull();

            listIDs!.Trakt.Should().Be(1248149U);
            listIDs!.Slug.Should().Be("marvel-cinematic-universe");

            listIDs!.HasAnyID.Should().BeTrue();
            listIDs!.BestID.Should().Be("marvel-cinematic-universe");
        }
    }
}
