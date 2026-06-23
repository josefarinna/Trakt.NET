namespace TraktNET.Json.Genres
{
    public sealed class TraktGenreTests
    {
        [Fact]
        public void TestTraktGenreDefaultConstructor()
        {
            var traktGenre = new TraktGenre();

            traktGenre.Name.ShouldBeNull();
            traktGenre.Slug.ShouldBeNull();
            traktGenre.Type.ShouldBeNull();
            traktGenre.Subgenres.ShouldBeNull();
            traktGenre.ToString().ShouldBe("name not set, slug not set");
        }

        [Fact]
        public async Task TestTraktGenreFromJson()
        {
            TraktGenre? traktGenre = await TestUtility.DeserializeJsonAsync<TraktGenre>("Genres\\genre.json");

            traktGenre.ShouldNotBeNull();
            traktGenre.Name.ShouldBe("Action");
            traktGenre.Slug.ShouldBe("action");
            traktGenre.Type.ShouldBeNull();
            traktGenre.ToString().ShouldBe("Action, action");
        }
    }
}
