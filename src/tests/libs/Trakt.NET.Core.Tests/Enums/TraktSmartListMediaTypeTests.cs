namespace TraktNET.Enums
{
    public sealed class TraktSmartListMediaTypeTests
    {
        [Fact]
        public void TestTraktSmartListMediaTypeToJson()
        {
            TraktSmartListMediaType.Unspecified.ToJson().ShouldBeNull();
            TraktSmartListMediaType.Movies.ToJson().ShouldBe("movies");
            TraktSmartListMediaType.Shows.ToJson().ShouldBe("shows");
            TraktSmartListMediaType.Media.ToJson().ShouldBe("media");
        }

        [Fact]
        public void TestTraktSmartListMediaTypeFromJson()
        {
            "unspecified".ToTraktSmartListMediaType().ShouldBe(TraktSmartListMediaType.Unspecified);
            "movies".ToTraktSmartListMediaType().ShouldBe(TraktSmartListMediaType.Movies);
            "shows".ToTraktSmartListMediaType().ShouldBe(TraktSmartListMediaType.Shows);
            "media".ToTraktSmartListMediaType().ShouldBe(TraktSmartListMediaType.Media);

            string? nullValue = null;
            nullValue.ToTraktSmartListMediaType().ShouldBe(TraktSmartListMediaType.Unspecified);
        }

        [Fact]
        public void TestTraktSmartListMediaTypeDisplayName()
        {
            TraktSmartListMediaType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSmartListMediaType.Movies.DisplayName().ShouldBe("Movies");
            TraktSmartListMediaType.Shows.DisplayName().ShouldBe("Shows");
            TraktSmartListMediaType.Media.DisplayName().ShouldBe("Media");
        }
    }
}
