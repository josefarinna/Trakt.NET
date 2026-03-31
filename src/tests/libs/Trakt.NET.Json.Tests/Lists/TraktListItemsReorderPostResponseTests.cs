namespace TraktNET.Json.Lists
{
    public sealed class TraktListItemsReorderPostResponseTests
    {
        [Fact]
        public void TestTraktListItemsReorderPostResponseDefaultConstructor()
        {
            var listItemsReorderPostResponse = new TraktListItemsReorderPostResponse();

            listItemsReorderPostResponse.Updated.ShouldBeNull();
            listItemsReorderPostResponse.SkippedIDs.ShouldBeNull();
            listItemsReorderPostResponse.List.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktListItemsReorderPostResponseFromJson()
        {
            TraktListItemsReorderPostResponse? listItemsReorderPostResponse = await TestUtility.DeserializeJsonAsync<TraktListItemsReorderPostResponse>("Lists\\listitemsreorderpostresponse.json");

            listItemsReorderPostResponse.ShouldNotBeNull();

            listItemsReorderPostResponse.Updated.ShouldBe(6);
            listItemsReorderPostResponse.SkippedIDs.ShouldNotBeNull();
            listItemsReorderPostResponse.SkippedIDs.Count.ShouldBe(1);
            listItemsReorderPostResponse.SkippedIDs.ShouldBe([ 2 ]);

            listItemsReorderPostResponse.List.ShouldNotBeNull();
            listItemsReorderPostResponse.List.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-04-27T21:40:41.000Z"));
            listItemsReorderPostResponse.List.ItemCount.ShouldBe(5);
        }
    }
}
