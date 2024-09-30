namespace TraktNET.Json.General
{
    public sealed class TraktStudioTests
    {
        [Fact]
        public void TestTraktStudioConstructor()
        {
            var studio = new TraktStudio();

            studio.Name.Should().BeNull();
            studio.Country.Should().BeNull();
            studio.IDs.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktStudioFromJson()
        {
            TraktStudio? studio = await TestUtility.DeserializeJsonAsync<TraktStudio>("General\\studio.json");

            studio.Should().NotBeNull();

            studio!.Name.Should().Be("Marvel Studios");
            studio!.Country.Should().Be("us");

            studio!.IDs!.Trakt.Should().Be(181U);
            studio!.IDs!.Slug.Should().Be("marvel-studios");
            studio!.IDs!.TMDB.Should().Be(420U);
            studio!.IDs!.HasAnyID.Should().BeTrue();
            studio!.IDs!.BestID.Should().Be("marvel-studios");
        }
    }
}
