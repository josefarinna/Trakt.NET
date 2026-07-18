namespace TraktNET.Enums
{
    public sealed class TraktCalendarMediaTypeTests
    {
        [Fact]
        public void TestTraktCalendarMediaTypeToJson()
        {
            TraktCalendarMediaType.Unspecified.ToJson().ShouldBeNull();
            TraktCalendarMediaType.Movie.ToJson().ShouldBe("movie");
            TraktCalendarMediaType.Show.ToJson().ShouldBe("show");
        }

        [Fact]
        public void TestTraktCalendarMediaTypeFromJson()
        {
            "unspecified".ToTraktCalendarMediaType().ShouldBe(TraktCalendarMediaType.Unspecified);
            "movie".ToTraktCalendarMediaType().ShouldBe(TraktCalendarMediaType.Movie);
            "show".ToTraktCalendarMediaType().ShouldBe(TraktCalendarMediaType.Show);

            string? nullValue = null;
            nullValue.ToTraktCalendarMediaType().ShouldBe(TraktCalendarMediaType.Unspecified);
        }

        [Fact]
        public void TestTraktCalendarMediaTypeDisplayName()
        {
            TraktCalendarMediaType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktCalendarMediaType.Movie.DisplayName().ShouldBe("Movie");
            TraktCalendarMediaType.Show.DisplayName().ShouldBe("Show");
        }
    }
}
