namespace TraktNET.Json.Media
{
    public sealed class TraktTrendingMediaTests
    {
        [Fact]
        public void TestTraktTrendingMediaConstructor()
        {
            var item = new TraktTrendingMedia();

            item.Watchers.ShouldBeNull();
            item.Type.ShouldBeNull();
            item.Movie.ShouldBeNull();
            item.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktTrendingMediaFromJson()
        {
            IReadOnlyList<TraktTrendingMedia>? media = await TestUtility.DeserializeJsonListAsync<TraktTrendingMedia>("Media\\trendingmedia.json");

            media.ShouldNotBeNull();
            media!.Count.ShouldBe(2);

            media[0].Watchers.ShouldBe(150U);
            media[0].Type.ShouldBe(TraktSearchResultType.Movie);
            media[0].Movie.ShouldNotBeNull();
            media[0].Movie!.Title.ShouldBe("TRON: Legacy");

            media[1].Watchers.ShouldBe(250U);
            media[1].Type.ShouldBe(TraktSearchResultType.Show);
            media[1].Show.ShouldNotBeNull();
            media[1].Show!.Title.ShouldBe("Breaking Bad");
        }
    }
}
