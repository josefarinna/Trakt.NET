namespace TraktNET.Enums
{
    public sealed class TraktFilterSectionTests
    {
        [Fact]
        public void TestTraktFilterSectionToJson()
        {
            TraktFilterSection.Unspecified.ToJson().Should().BeNull();
            TraktFilterSection.Movies.ToJson().Should().Be("movies");
            TraktFilterSection.Shows.ToJson().Should().Be("shows");
            TraktFilterSection.Calendars.ToJson().Should().Be("calendars");
            TraktFilterSection.Search.ToJson().Should().Be("search");
        }

        [Fact]
        public void TestTraktFilterSectionFromJson()
        {
            "unspecified".ToTraktFilterSection().Should().Be(TraktFilterSection.Unspecified);
            "movies".ToTraktFilterSection().Should().Be(TraktFilterSection.Movies);
            "shows".ToTraktFilterSection().Should().Be(TraktFilterSection.Shows);
            "calendars".ToTraktFilterSection().Should().Be(TraktFilterSection.Calendars);
            "search".ToTraktFilterSection().Should().Be(TraktFilterSection.Search);

            string? nullValue = null;
            nullValue.ToTraktFilterSection().Should().Be(TraktFilterSection.Unspecified);
        }

        [Fact]
        public void TestTraktFilterSectionDisplayName()
        {
            TraktFilterSection.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktFilterSection.Movies.DisplayName().Should().Be("Movies");
            TraktFilterSection.Shows.DisplayName().Should().Be("Shows");
            TraktFilterSection.Calendars.DisplayName().Should().Be("Calendars");
            TraktFilterSection.Search.DisplayName().Should().Be("Search");
        }
    }
}
