namespace TraktNET.Enums
{
    public sealed class TraktListItemTypeTests
    {
        [Fact]
        public void TestTraktListItemTypeToJson()
        {
            TraktListItemType.Unspecified.ToJson().ShouldBeNull();
            TraktListItemType.Movie.ToJson().ShouldBe("movie");
            TraktListItemType.Show.ToJson().ShouldBe("show");
            TraktListItemType.Season.ToJson().ShouldBe("season");
            TraktListItemType.Episode.ToJson().ShouldBe("episode");
            TraktListItemType.Person.ToJson().ShouldBe("person");
        }

        [Fact]
        public void TestTraktListItemTypeFromJson()
        {
            "unspecified".ToTraktListItemType().ShouldBe(TraktListItemType.Unspecified);
            "movie".ToTraktListItemType().ShouldBe(TraktListItemType.Movie);
            "show".ToTraktListItemType().ShouldBe(TraktListItemType.Show);
            "season".ToTraktListItemType().ShouldBe(TraktListItemType.Season);
            "episode".ToTraktListItemType().ShouldBe(TraktListItemType.Episode);
            "person".ToTraktListItemType().ShouldBe(TraktListItemType.Person);

            string? nullValue = null;
            nullValue.ToTraktListItemType().ShouldBe(TraktListItemType.Unspecified);
        }

        [Fact]
        public void TestTraktListItemTypeDisplayName()
        {
            TraktListItemType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktListItemType.Movie.DisplayName().ShouldBe("Movie");
            TraktListItemType.Show.DisplayName().ShouldBe("Show");
            TraktListItemType.Season.DisplayName().ShouldBe("Season");
            TraktListItemType.Episode.DisplayName().ShouldBe("Episode");
            TraktListItemType.Person.DisplayName().ShouldBe("Person");
        }
    }
}
