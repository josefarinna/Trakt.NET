namespace TraktNET.Json.Lists
{
    public sealed partial class TraktListItemsReorderPostTests
    {
        [Fact]
        public void TestListItemsReorderPostDefaultConstructor()
        {
            var listItemsReorderPost = new TraktListItemsReorderPost();
            listItemsReorderPost.Rank.ShouldBeNull();
        }

        [Fact]
        public async Task TestListItemsReorderPostFromJson()
        {
            TraktListItemsReorderPost? listItemsReorderPost = await TestUtility.DeserializeJsonAsync<TraktListItemsReorderPost>("Lists\\listitemsreorder.json");

            listItemsReorderPost.ShouldNotBeNull();
            listItemsReorderPost.Rank.ShouldNotBeNull();
            listItemsReorderPost.Rank!.Count.ShouldBe(7);
            listItemsReorderPost.Rank.ShouldBe([823, 224, 88768, 356456, 245, 2, 890]);
        }
    }
}
