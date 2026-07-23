namespace TraktNET.Json.General
{
    public sealed class TraktSentimentItemTests
    {
        [Fact]
        public void TestTraktSentimentItemConstructor()
        {
            var item = new TraktSentimentItem();
            item.Sentiment.ShouldBeNull();
            item.CommentIDs.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSentimentItemFromJson()
        {
            TraktSentimentItem? item = await TestUtility.DeserializeJsonAsync<TraktSentimentItem>("General\\sentimentitem.json");

            item.ShouldNotBeNull();
            item!.Sentiment.ShouldBe("funny");
            item!.CommentIDs.ShouldNotBeNull();
            item!.CommentIDs!.Count.ShouldBe(2);
            item!.CommentIDs!.ShouldBe([123U, 456U]);
        }
    }
}
