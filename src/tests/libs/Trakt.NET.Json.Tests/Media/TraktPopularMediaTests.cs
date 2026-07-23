namespace TraktNET.Json.Media
{
    public sealed class TraktPopularMediaTests
    {
        [Fact]
        public void TestTraktPopularMediaConstructor()
        {
            var item = new TraktPopularMedia();

            item.Type.ShouldBeNull();
            item.Movie.ShouldBeNull();
            item.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPopularMediaFromJson()
        {
            IReadOnlyList<TraktPopularMedia>? media = await TestUtility.DeserializeJsonListAsync<TraktPopularMedia>("Media\\popularmedia.json");

            media.ShouldNotBeNull();
            media!.Count.ShouldBe(2);

            media[0].Type.ShouldBe(TraktSearchResultType.Movie);
            media[0].Movie.ShouldNotBeNull();
            media[0].Movie!.Title.ShouldBe("TRON: Legacy");

            media[1].Type.ShouldBe(TraktSearchResultType.Show);
            media[1].Show.ShouldNotBeNull();
            media[1].Show!.Title.ShouldBe("Breaking Bad");
        }
    }
}
