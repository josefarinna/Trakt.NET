namespace TraktNET.Json.Comments
{
    public sealed class TraktCommentUserStatsTests
    {
        [Fact]
        public void TestTraktCommentUserStatsConstructor()
        {
            var commentUserStats = new TraktCommentUserStats();

            commentUserStats.Rating.Should().BeNull();
            commentUserStats.PlayCount.Should().BeNull();
            commentUserStats.CompletedCount.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktCommentUserStatsFromJson()
        {
            TraktCommentUserStats? commentUserStats = await TestUtility.DeserializeJsonAsync<TraktCommentUserStats>("Comments\\commentuserstats.json");

            commentUserStats.Should().NotBeNull();

            commentUserStats!.Rating.Should().Be(9U);
            commentUserStats!.PlayCount.Should().Be(3U);
            commentUserStats!.CompletedCount.Should().Be(1U);
        }
    }
}
