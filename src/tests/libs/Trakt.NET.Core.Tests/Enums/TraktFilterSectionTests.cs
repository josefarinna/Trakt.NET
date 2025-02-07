namespace TraktNET.Enums
{
    public sealed class TraktFilterSectionTests
    {
        [Fact]
        public void TestTraktFilterSectionToJson()
        {
            TraktFilterSection.Unspecified.ToJson().ShouldBeNull();
            TraktFilterSection.Movies.ToJson().ShouldBe("movies");
            TraktFilterSection.Shows.ToJson().ShouldBe("shows");
            TraktFilterSection.Calendars.ToJson().ShouldBe("calendars");
            TraktFilterSection.Search.ToJson().ShouldBe("search");
        }

        [Fact]
        public void TestTraktFilterSectionFromJson()
        {
            "unspecified".ToTraktFilterSection().ShouldBe(TraktFilterSection.Unspecified);
            "movies".ToTraktFilterSection().ShouldBe(TraktFilterSection.Movies);
            "shows".ToTraktFilterSection().ShouldBe(TraktFilterSection.Shows);
            "calendars".ToTraktFilterSection().ShouldBe(TraktFilterSection.Calendars);
            "search".ToTraktFilterSection().ShouldBe(TraktFilterSection.Search);

            string? nullValue = null;
            nullValue.ToTraktFilterSection().ShouldBe(TraktFilterSection.Unspecified);
        }

        [Fact]
        public void TestTraktFilterSectionDisplayName()
        {
            TraktFilterSection.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktFilterSection.Movies.DisplayName().ShouldBe("Movies");
            TraktFilterSection.Shows.DisplayName().ShouldBe("Shows");
            TraktFilterSection.Calendars.DisplayName().ShouldBe("Calendars");
            TraktFilterSection.Search.DisplayName().ShouldBe("Search");
        }
    }
}
