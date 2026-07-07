namespace TraktNET.Json.Watchnow
{
    public sealed class TraktStreamingRankTests
    {
        [Fact]
        public void TestTraktStreamingRankConstructor()
        {
            var streamingRank = new TraktStreamingRank();

            streamingRank.Rank.ShouldBeNull();
            streamingRank.Delta.ShouldBeNull();
            streamingRank.Link.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktStreamingRankFromJson()
        {
            TraktStreamingRank? streamingRank = await TestUtility.DeserializeJsonAsync<TraktStreamingRank>("Watchnow\\streamingrank.json");

            streamingRank.ShouldNotBeNull();
            streamingRank.Rank.ShouldBe(5);
            streamingRank.Delta.ShouldBe(2);
            streamingRank.Link.ShouldBe("https://trakt.tv/shows/trending/rank");
        }
    }
}
