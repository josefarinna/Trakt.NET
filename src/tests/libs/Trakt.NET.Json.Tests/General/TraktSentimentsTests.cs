namespace TraktNET.Json.General
{
    public sealed class TraktSentimentsTests
    {
        [Fact]
        public void TestTraktSentimentsConstructor()
        {
            var sentiments = new TraktSentiments();

            sentiments.Good.ShouldBeNull();
            sentiments.Bad.ShouldBeNull();
            sentiments.AnalyzedAt.ShouldBeNull();
            sentiments.CommentCount.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSentimentsFromJson()
        {
            TraktSentiments? sentiments = await TestUtility.DeserializeJsonAsync<TraktSentiments>("General\\sentiments.json");

            sentiments.ShouldNotBeNull();
            sentiments!.Good.ShouldNotBeNull();
            sentiments!.Good!.Count.ShouldBe(1);
            sentiments!.Good![0].Sentiment.ShouldBe("funny");
            sentiments!.Good![0].CommentIDs.ShouldNotBeNull();
            sentiments!.Good![0].CommentIDs!.Count.ShouldBe(2);
            sentiments!.Good![0].CommentIDs!.ShouldBe([123U, 456U]);

            sentiments!.Bad.ShouldNotBeNull();
            sentiments!.Bad!.Count.ShouldBe(1);
            sentiments!.Bad![0].Sentiment.ShouldBe("boring");
            sentiments!.Bad![0].CommentIDs.ShouldNotBeNull();
            sentiments!.Bad![0].CommentIDs!.Count.ShouldBe(1);
            sentiments!.Bad![0].CommentIDs!.ShouldBe([789U]);

            sentiments!.AnalyzedAt.ShouldBe(DateTime.Parse("2026-07-23T12:34:56.000Z", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime());
            sentiments!.CommentCount.ShouldBe(100U);
        }
    }
}
