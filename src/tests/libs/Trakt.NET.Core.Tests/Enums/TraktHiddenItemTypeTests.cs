namespace TraktNET.Enums
{
    public sealed class TraktHiddenItemTypeTests
    {
        [Fact]
        public void TestTraktHiddenItemTypeToJson()
        {
            TraktHiddenItemType.Unspecified.ToJson().Should().BeNull();
            TraktHiddenItemType.Movie.ToJson().Should().Be("movie");
            TraktHiddenItemType.Show.ToJson().Should().Be("show");
            TraktHiddenItemType.Season.ToJson().Should().Be("season");
            TraktHiddenItemType.User.ToJson().Should().Be("user");
        }

        [Fact]
        public void TestTraktHiddenItemTypeFromJson()
        {
            "unspecified".ToTraktHiddenItemType().Should().Be(TraktHiddenItemType.Unspecified);
            "movie".ToTraktHiddenItemType().Should().Be(TraktHiddenItemType.Movie);
            "show".ToTraktHiddenItemType().Should().Be(TraktHiddenItemType.Show);
            "season".ToTraktHiddenItemType().Should().Be(TraktHiddenItemType.Season);
            "user".ToTraktHiddenItemType().Should().Be(TraktHiddenItemType.User);

            string? nullValue = null;
            nullValue.ToTraktHiddenItemType().Should().Be(TraktHiddenItemType.Unspecified);
        }

        [Fact]
        public void TestTraktHiddenItemTypeDisplayName()
        {
            TraktHiddenItemType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktHiddenItemType.Movie.DisplayName().Should().Be("Movie");
            TraktHiddenItemType.Show.DisplayName().Should().Be("Show");
            TraktHiddenItemType.Season.DisplayName().Should().Be("Season");
            TraktHiddenItemType.User.DisplayName().Should().Be("User");
        }
    }
}
