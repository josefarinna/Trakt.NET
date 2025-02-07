namespace TraktNET.Enums
{
    public sealed class TraktNotesObjectTypeTests
    {
        [Fact]
        public void TestTraktNotesObjectTypeToJson()
        {
            TraktNotesObjectType.Unspecified.ToJson().ShouldBeNull();
            TraktNotesObjectType.All.ToJson().ShouldBe("all");
            TraktNotesObjectType.Movie.ToJson().ShouldBe("movie");
            TraktNotesObjectType.Show.ToJson().ShouldBe("show");
            TraktNotesObjectType.Season.ToJson().ShouldBe("season");
            TraktNotesObjectType.Episode.ToJson().ShouldBe("episode");
            TraktNotesObjectType.Person.ToJson().ShouldBe("person");
            TraktNotesObjectType.History.ToJson().ShouldBe("history");
            TraktNotesObjectType.Collection.ToJson().ShouldBe("collection");
            TraktNotesObjectType.Rating.ToJson().ShouldBe("rating");
        }

        [Fact]
        public void TestTraktNotesObjectTypeFromJson()
        {
            "unspecified".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Unspecified);
            "all".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.All);
            "movie".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Movie);
            "show".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Show);
            "season".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Season);
            "episode".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Episode);
            "person".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Person);
            "history".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.History);
            "collection".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Collection);
            "rating".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Rating);

            string? nullValue = null;
            nullValue.ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Unspecified);
        }

        [Fact]
        public void TestTraktNotesObjectTypeDisplayName()
        {
            TraktNotesObjectType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktNotesObjectType.All.DisplayName().ShouldBe("All");
            TraktNotesObjectType.Movie.DisplayName().ShouldBe("Movie");
            TraktNotesObjectType.Show.DisplayName().ShouldBe("Show");
            TraktNotesObjectType.Season.DisplayName().ShouldBe("Season");
            TraktNotesObjectType.Episode.DisplayName().ShouldBe("Episode");
            TraktNotesObjectType.Person.DisplayName().ShouldBe("Person");
            TraktNotesObjectType.History.DisplayName().ShouldBe("History");
            TraktNotesObjectType.Collection.DisplayName().ShouldBe("Collection");
            TraktNotesObjectType.Rating.DisplayName().ShouldBe("Rating");
        }
    }
}
