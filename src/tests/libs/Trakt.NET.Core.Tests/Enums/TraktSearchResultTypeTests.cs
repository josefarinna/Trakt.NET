namespace TraktNET.Enums
{
    public sealed class TraktSearchResultTypeTests
    {
        [Fact]
        public void TestTraktSearchResultTypeToJson()
        {
            TraktSearchResultType.Unspecified.ToJson().ShouldBeNull();
            TraktSearchResultType.Movie.ToJson().ShouldBe("movie");
            TraktSearchResultType.Show.ToJson().ShouldBe("show");
            TraktSearchResultType.Episode.ToJson().ShouldBe("episode");
            TraktSearchResultType.Person.ToJson().ShouldBe("person");
            TraktSearchResultType.List.ToJson().ShouldBe("list");
        }

        [Fact]
        public void TestTraktSearchResultTypeFromJson()
        {
            "unspecified".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Unspecified);
            "movie".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Movie);
            "show".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Show);
            "episode".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Episode);
            "person".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Person);
            "list".ToTraktSearchResultType().ShouldBe(TraktSearchResultType.List);

            string? nullValue = null;
            nullValue.ToTraktSearchResultType().ShouldBe(TraktSearchResultType.Unspecified);
        }

        [Fact]
        public void TestTraktSearchResultTypeDisplayName()
        {
            TraktSearchResultType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSearchResultType.Movie.DisplayName().ShouldBe("Movie");
            TraktSearchResultType.Show.DisplayName().ShouldBe("Show");
            TraktSearchResultType.Episode.DisplayName().ShouldBe("Episode");
            TraktSearchResultType.Person.DisplayName().ShouldBe("Person");
            TraktSearchResultType.List.DisplayName().ShouldBe("List");
        }
    }
}
