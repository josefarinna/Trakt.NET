namespace TraktNET.Enums
{
    public sealed class TraktSearchRecentTypeTests
    {
        [Fact]
        public void TestTraktSearchRecentTypeToJson()
        {
            TraktSearchRecentType.Unspecified.ToJson().ShouldBeNull();
            TraktSearchRecentType.Movie.ToJson().ShouldBe("movies");
            TraktSearchRecentType.Show.ToJson().ShouldBe("shows");
            TraktSearchRecentType.Person.ToJson().ShouldBe("people");
            TraktSearchRecentType.List.ToJson().ShouldBe("lists");
        }

        [Fact]
        public void TestTraktSearchRecentTypeFromJson()
        {
            "unspecified".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Unspecified);
            "movies".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Movie);
            "shows".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Show);
            "people".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Person);
            "lists".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.List);

            string? nullValue = null;
            nullValue.ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Unspecified);
        }

        [Fact]
        public void TestTraktSearchRecentTypeDisplayName()
        {
            TraktSearchRecentType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSearchRecentType.Movie.DisplayName().ShouldBe("Movies");
            TraktSearchRecentType.Show.DisplayName().ShouldBe("Shows");
            TraktSearchRecentType.Person.DisplayName().ShouldBe("People");
            TraktSearchRecentType.List.DisplayName().ShouldBe("Lists");
        }
    }
}
