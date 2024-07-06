namespace TraktNET.Enums
{
    public sealed class TraktSyncItemTypeTests
    {
        [Fact]
        public void TestTraktSyncItemTypeToJson()
        {
            TraktSyncItemType.Unspecified.ToJson().Should().BeNull();
            TraktSyncItemType.Movie.ToJson().Should().Be("movie");
            TraktSyncItemType.Show.ToJson().Should().Be("show");
            TraktSyncItemType.Season.ToJson().Should().Be("season");
            TraktSyncItemType.Episode.ToJson().Should().Be("episode");
        }

        [Fact]
        public void TestTraktSyncItemTypeFromJson()
        {
            "unspecified".ToTraktSyncItemType().Should().Be(TraktSyncItemType.Unspecified);
            "movie".ToTraktSyncItemType().Should().Be(TraktSyncItemType.Movie);
            "show".ToTraktSyncItemType().Should().Be(TraktSyncItemType.Show);
            "season".ToTraktSyncItemType().Should().Be(TraktSyncItemType.Season);
            "episode".ToTraktSyncItemType().Should().Be(TraktSyncItemType.Episode);

            string? nullValue = null;
            nullValue.ToTraktSyncItemType().Should().Be(TraktSyncItemType.Unspecified);
        }

        [Fact]
        public void TestTraktSyncItemTypeDisplayName()
        {
            TraktSyncItemType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktSyncItemType.Movie.DisplayName().Should().Be("Movie");
            TraktSyncItemType.Show.DisplayName().Should().Be("Show");
            TraktSyncItemType.Season.DisplayName().Should().Be("Season");
            TraktSyncItemType.Episode.DisplayName().Should().Be("Episode");
        }
    }
}
