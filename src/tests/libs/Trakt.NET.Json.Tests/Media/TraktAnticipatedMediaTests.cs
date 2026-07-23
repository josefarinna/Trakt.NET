namespace TraktNET.Json.Media
{
    public sealed class TraktAnticipatedMediaTests
    {
        [Fact]
        public void TestTraktAnticipatedMediaConstructor()
        {
            var item = new TraktAnticipatedMedia();

            item.ListCount.ShouldBeNull();
            item.Type.ShouldBeNull();
            item.Movie.ShouldBeNull();
            item.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktAnticipatedMediaFromJson()
        {
            IReadOnlyList<TraktAnticipatedMedia>? media = await TestUtility.DeserializeJsonListAsync<TraktAnticipatedMedia>("Media\\anticipatedmedia.json");

            media.ShouldNotBeNull();
            media!.Count.ShouldBe(2);

            media[0].ListCount.ShouldBe(50U);
            media[0].Type.ShouldBe(TraktSearchResultType.Movie);
            media[0].Movie.ShouldNotBeNull();
            media[0].Movie!.Title.ShouldBe("TRON: Legacy");

            media[1].ListCount.ShouldBe(80U);
            media[1].Type.ShouldBe(TraktSearchResultType.Show);
            media[1].Show.ShouldNotBeNull();
            media[1].Show!.Title.ShouldBe("Breaking Bad");
        }
    }
}
