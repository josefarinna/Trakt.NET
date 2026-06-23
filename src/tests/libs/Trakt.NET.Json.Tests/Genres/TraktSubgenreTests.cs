namespace TraktNET.Json.Genres
{
    public sealed class TraktSubgenreTests
    {
        [Fact]
        public void TestTraktSubgenreDefaultConstructor()
        {
            var traktSubgenre = new TraktSubgenre();

            traktSubgenre.Name.ShouldBeNull();
            traktSubgenre.Slug.ShouldBeNull();
            traktSubgenre.ToString().ShouldBe("name not set, slug not set");
        }

        [Fact]
        public async Task TestTraktSubgenreFromJson()
        {
            TraktSubgenre? traktSubgenre = await TestUtility.DeserializeJsonAsync<TraktSubgenre>("Genres\\genre.json");

            traktSubgenre.ShouldNotBeNull();
            traktSubgenre.Name.ShouldBe("Action");
            traktSubgenre.Slug.ShouldBe("action");
            traktSubgenre.ToString().ShouldBe("Action, action");
        }
    }
}
