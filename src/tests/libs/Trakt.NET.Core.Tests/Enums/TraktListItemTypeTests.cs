namespace TraktNET.Enums
{
    public sealed class TraktListItemTypeTests
    {
        [Fact]
        public void TestTraktListItemTypeToJson()
        {
            TraktListItemType.Unspecified.ToJson().Should().BeNull();
            TraktListItemType.Movie.ToJson().Should().Be("movie");
            TraktListItemType.Show.ToJson().Should().Be("show");
            TraktListItemType.Season.ToJson().Should().Be("season");
            TraktListItemType.Episode.ToJson().Should().Be("episode");
            TraktListItemType.Person.ToJson().Should().Be("person");
        }

        [Fact]
        public void TestTraktListItemTypeFromJson()
        {
            "unspecified".ToTraktListItemType().Should().Be(TraktListItemType.Unspecified);
            "movie".ToTraktListItemType().Should().Be(TraktListItemType.Movie);
            "show".ToTraktListItemType().Should().Be(TraktListItemType.Show);
            "season".ToTraktListItemType().Should().Be(TraktListItemType.Season);
            "episode".ToTraktListItemType().Should().Be(TraktListItemType.Episode);
            "person".ToTraktListItemType().Should().Be(TraktListItemType.Person);

            string? nullValue = null;
            nullValue.ToTraktListItemType().Should().Be(TraktListItemType.Unspecified);
        }

        [Fact]
        public void TestTraktListItemTypeDisplayName()
        {
            TraktListItemType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktListItemType.Movie.DisplayName().Should().Be("Movie");
            TraktListItemType.Show.DisplayName().Should().Be("Show");
            TraktListItemType.Season.DisplayName().Should().Be("Season");
            TraktListItemType.Episode.DisplayName().Should().Be("Episode");
            TraktListItemType.Person.DisplayName().Should().Be("Person");
        }
    }
}
