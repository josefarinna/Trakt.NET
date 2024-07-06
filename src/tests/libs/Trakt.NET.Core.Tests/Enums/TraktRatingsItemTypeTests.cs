namespace TraktNET.Enums
{
    public sealed class TraktRatingsItemTypeTests
    {
        [Fact]
        public void TestTraktRatingsItemTypeToJson()
        {
            TraktRatingsItemType.Unspecified.ToJson().Should().BeNull();
            TraktRatingsItemType.Movie.ToJson().Should().Be("movie");
            TraktRatingsItemType.Show.ToJson().Should().Be("show");
            TraktRatingsItemType.Season.ToJson().Should().Be("season");
            TraktRatingsItemType.Episode.ToJson().Should().Be("episode");
            TraktRatingsItemType.All.ToJson().Should().Be("all");
        }

        [Fact]
        public void TestTraktRatingsItemTypeFromJson()
        {
            "unspecified".ToTraktRatingsItemType().Should().Be(TraktRatingsItemType.Unspecified);
            "movie".ToTraktRatingsItemType().Should().Be(TraktRatingsItemType.Movie);
            "show".ToTraktRatingsItemType().Should().Be(TraktRatingsItemType.Show);
            "season".ToTraktRatingsItemType().Should().Be(TraktRatingsItemType.Season);
            "episode".ToTraktRatingsItemType().Should().Be(TraktRatingsItemType.Episode);
            "all".ToTraktRatingsItemType().Should().Be(TraktRatingsItemType.All);

            string? nullValue = null;
            nullValue.ToTraktRatingsItemType().Should().Be(TraktRatingsItemType.Unspecified);
        }

        [Fact]
        public void TestTraktRatingsItemTypeDisplayName()
        {
            TraktRatingsItemType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktRatingsItemType.Movie.DisplayName().Should().Be("Movie");
            TraktRatingsItemType.Show.DisplayName().Should().Be("Show");
            TraktRatingsItemType.Season.DisplayName().Should().Be("Season");
            TraktRatingsItemType.Episode.DisplayName().Should().Be("Episode");
            TraktRatingsItemType.All.DisplayName().Should().Be("All");
        }
    }
}
