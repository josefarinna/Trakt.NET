namespace TraktNET.Enums
{
    public sealed class TraktListTypeTests
    {
        [Fact]
        public void TestTraktListTypeToJson()
        {
            TraktListType.Unspecified.ToJson().ShouldBeNull();
            TraktListType.Personal.ToJson().ShouldBe("personal");
            TraktListType.Official.ToJson().ShouldBe("official");
            TraktListType.Watchlist.ToJson().ShouldBe("watchlists");
            TraktListType.Recommendations.ToJson().ShouldBe("recommendations");
            TraktListType.All.ToJson().ShouldBe("all");
        }

        [Fact]
        public void TestTraktListTypeFromJson()
        {
            "unspecified".ToTraktListType().ShouldBe(TraktListType.Unspecified);
            "personal".ToTraktListType().ShouldBe(TraktListType.Personal);
            "official".ToTraktListType().ShouldBe(TraktListType.Official);
            "watchlists".ToTraktListType().ShouldBe(TraktListType.Watchlist);
            "recommendations".ToTraktListType().ShouldBe(TraktListType.Recommendations);
            "all".ToTraktListType().ShouldBe(TraktListType.All);

            string? nullValue = null;
            nullValue.ToTraktListType().ShouldBe(TraktListType.Unspecified);
        }

        [Fact]
        public void TestTraktListTypeDisplayName()
        {
            TraktListType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktListType.Personal.DisplayName().ShouldBe("Personal");
            TraktListType.Official.DisplayName().ShouldBe("Official");
            TraktListType.Watchlist.DisplayName().ShouldBe("Watchlists");
            TraktListType.Recommendations.DisplayName().ShouldBe("Recommendations");
            TraktListType.All.DisplayName().ShouldBe("All");
        }
    }
}
