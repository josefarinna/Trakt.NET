namespace TraktNET.Json.Lists
{
    public sealed partial class TraktListItemUpdatePostTests
    {
        [Fact]
        public void TestListItemUpdatePostDefaultConstructor()
        {
            var listItemUpdatePost = new TraktListItemUpdatePost();
            listItemUpdatePost.Notes.ShouldBeNull();
        }

        [Fact]
        public async Task TestListItemUpdatePostFromJson()
        {
            TraktListItemUpdatePost? listItemUpdatePost = await TestUtility.DeserializeJsonAsync<TraktListItemUpdatePost>("Lists\\listitemupdate.json");

            listItemUpdatePost.ShouldNotBeNull();
            listItemUpdatePost.Notes.ShouldBe("This is a great movie!");
        }
    }
}
