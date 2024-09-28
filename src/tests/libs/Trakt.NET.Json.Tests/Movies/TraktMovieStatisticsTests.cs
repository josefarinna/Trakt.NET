namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieStatisticsTests
    {
        [Fact]
        public void TestTraktMovieStatisticsConstructor()
        {
            var movieStatistics = new TraktMovieStatistics();

            movieStatistics.Watchers.Should().BeNull();
            movieStatistics.Plays.Should().BeNull();
            movieStatistics.Collectors.Should().BeNull();
            movieStatistics.Comments.Should().BeNull();
            movieStatistics.Lists.Should().BeNull();
            movieStatistics.Votes.Should().BeNull();
            movieStatistics.Favorited.Should().BeNull();
            movieStatistics.Recommended.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktMovieStatisticsFromJson()
        {
            TraktMovieStatistics? movieStatistics = await TestUtility.DeserializeJsonAsync<TraktMovieStatistics>("Movies\\moviestatistics.json");

            movieStatistics.Should().NotBeNull();

            movieStatistics!.Watchers.Should().Be(164943U);
            movieStatistics!.Plays.Should().Be(219925U);
            movieStatistics!.Collectors.Should().Be(66444U);
            movieStatistics!.Comments.Should().Be(177U);
            movieStatistics!.Lists.Should().Be(51079U);
            movieStatistics!.Votes.Should().Be(18906U);
            movieStatistics!.Favorited.Should().Be(773U);
            movieStatistics!.Recommended.Should().Be(773U);
        }
    }
}
