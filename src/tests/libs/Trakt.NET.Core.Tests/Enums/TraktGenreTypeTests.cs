namespace TraktNET.Enums
{
    public sealed class TraktGenreTypeTests
    {
        [Fact]
        public void TestTraktGenreTypeToJson()
        {
            TraktGenreType.Unspecified.ToJson().ShouldBeNull();
            TraktGenreType.Movies.ToJson().ShouldBe("movies");
            TraktGenreType.Shows.ToJson().ShouldBe("shows");
        }

        [Fact]
        public void TestTraktGenreTypeFromJson()
        {
            "unspecified".ToTraktGenreType().ShouldBe(TraktGenreType.Unspecified);
            "movies".ToTraktGenreType().ShouldBe(TraktGenreType.Movies);
            "shows".ToTraktGenreType().ShouldBe(TraktGenreType.Shows);

            string? nullValue = null;
            nullValue.ToTraktGenreType().ShouldBe(TraktGenreType.Unspecified);
        }

        [Fact]
        public void TestTraktGenreTypeDisplayName()
        {
            TraktGenreType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktGenreType.Movies.DisplayName().ShouldBe("Movies");
            TraktGenreType.Shows.DisplayName().ShouldBe("Shows");
        }
    }
}
