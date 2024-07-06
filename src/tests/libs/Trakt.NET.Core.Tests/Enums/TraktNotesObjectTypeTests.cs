namespace TraktNET.Enums
{
    public sealed class TraktNotesObjectTypeTests
    {
        [Fact]
        public void TestTraktNotesObjectTypeToJson()
        {
            TraktNotesObjectType.Unspecified.ToJson().Should().BeNull();
            TraktNotesObjectType.All.ToJson().Should().Be("all");
            TraktNotesObjectType.Movie.ToJson().Should().Be("movie");
            TraktNotesObjectType.Show.ToJson().Should().Be("show");
            TraktNotesObjectType.Season.ToJson().Should().Be("season");
            TraktNotesObjectType.Episode.ToJson().Should().Be("episode");
            TraktNotesObjectType.Person.ToJson().Should().Be("person");
            TraktNotesObjectType.History.ToJson().Should().Be("history");
            TraktNotesObjectType.Collection.ToJson().Should().Be("collection");
            TraktNotesObjectType.Rating.ToJson().Should().Be("rating");
        }

        [Fact]
        public void TestTraktNotesObjectTypeFromJson()
        {
            "unspecified".ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.Unspecified);
            "all".ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.All);
            "movie".ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.Movie);
            "show".ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.Show);
            "season".ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.Season);
            "episode".ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.Episode);
            "person".ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.Person);
            "history".ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.History);
            "collection".ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.Collection);
            "rating".ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.Rating);

            string? nullValue = null;
            nullValue.ToTraktNotesObjectType().Should().Be(TraktNotesObjectType.Unspecified);
        }

        [Fact]
        public void TestTraktNotesObjectTypeDisplayName()
        {
            TraktNotesObjectType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktNotesObjectType.All.DisplayName().Should().Be("All");
            TraktNotesObjectType.Movie.DisplayName().Should().Be("Movie");
            TraktNotesObjectType.Show.DisplayName().Should().Be("Show");
            TraktNotesObjectType.Season.DisplayName().Should().Be("Season");
            TraktNotesObjectType.Episode.DisplayName().Should().Be("Episode");
            TraktNotesObjectType.Person.DisplayName().Should().Be("Person");
            TraktNotesObjectType.History.DisplayName().Should().Be("History");
            TraktNotesObjectType.Collection.DisplayName().Should().Be("Collection");
            TraktNotesObjectType.Rating.DisplayName().Should().Be("Rating");
        }
    }
}
