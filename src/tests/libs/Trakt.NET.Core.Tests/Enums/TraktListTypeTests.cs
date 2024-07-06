namespace TraktNET.Enums
{
    public sealed class TraktListTypeTests
    {
        [Fact]
        public void TestTraktListTypeToJson()
        {
            TraktListType.Unspecified.ToJson().Should().BeNull();
            TraktListType.Personal.ToJson().Should().Be("personal");
            TraktListType.Official.ToJson().Should().Be("official");
            TraktListType.Watchlist.ToJson().Should().Be("watchlists");
            TraktListType.Recommendations.ToJson().Should().Be("recommendations");
            TraktListType.All.ToJson().Should().Be("all");
        }

        [Fact]
        public void TestTraktListTypeFromJson()
        {
            "unspecified".ToTraktListType().Should().Be(TraktListType.Unspecified);
            "personal".ToTraktListType().Should().Be(TraktListType.Personal);
            "official".ToTraktListType().Should().Be(TraktListType.Official);
            "watchlists".ToTraktListType().Should().Be(TraktListType.Watchlist);
            "recommendations".ToTraktListType().Should().Be(TraktListType.Recommendations);
            "all".ToTraktListType().Should().Be(TraktListType.All);

            string? nullValue = null;
            nullValue.ToTraktListType().Should().Be(TraktListType.Unspecified);
        }

        [Fact]
        public void TestTraktListTypeDisplayName()
        {
            TraktListType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktListType.Personal.DisplayName().Should().Be("Personal");
            TraktListType.Official.DisplayName().Should().Be("Official");
            TraktListType.Watchlist.DisplayName().Should().Be("Watchlists");
            TraktListType.Recommendations.DisplayName().Should().Be("Recommendations");
            TraktListType.All.DisplayName().Should().Be("All");
        }
    }
}
