namespace TraktNET.Json.People
{
    public sealed class TraktPersonIDsTests
    {
        [Fact]
        public void TestTraktPersonIDsConstructor()
        {
            var personIDs = new TraktPersonIDs();

            personIDs.Trakt.Should().BeNull();
            personIDs.Slug.Should().BeNull();
            personIDs.IMDB.Should().BeNull();
            personIDs.TMDB.Should().BeNull();

            personIDs.HasAnyID.Should().BeFalse();
            personIDs.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktPersonIDsFromJson()
        {
            TraktPersonIDs? personIDs = await TestUtility.DeserializeJsonAsync<TraktPersonIDs>("People\\personids.json");

            personIDs.Should().NotBeNull();

            personIDs!.Trakt.Should().Be(297737U);
            personIDs!.Slug.Should().Be("bryan-cranston");
            personIDs!.IMDB.Should().Be("nm0186505");
            personIDs!.TMDB.Should().Be(17419U);

            personIDs!.HasAnyID.Should().BeTrue();
            personIDs!.BestID.Should().Be("bryan-cranston");
        }
    }
}
