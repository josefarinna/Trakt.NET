namespace TraktNET.Enums
{
    public sealed class TraktSearchIDTypeTests
    {
        [Fact]
        public void TestTraktSearchIDTypeToJson()
        {
            TraktSearchIDType.Unspecified.ToJson().Should().BeNull();
            TraktSearchIDType.Trakt.ToJson().Should().Be("trakt");
            TraktSearchIDType.ImDB.ToJson().Should().Be("imdb");
            TraktSearchIDType.TmDB.ToJson().Should().Be("tmdb");
            TraktSearchIDType.TvDB.ToJson().Should().Be("tvdb");
            TraktSearchIDType.TVRage.ToJson().Should().Be("tvrage");
        }

        [Fact]
        public void TestTraktSearchIDTypeFromJson()
        {
            "unspecified".ToTraktSearchIDType().Should().Be(TraktSearchIDType.Unspecified);
            "trakt".ToTraktSearchIDType().Should().Be(TraktSearchIDType.Trakt);
            "imdb".ToTraktSearchIDType().Should().Be(TraktSearchIDType.ImDB);
            "tmdb".ToTraktSearchIDType().Should().Be(TraktSearchIDType.TmDB);
            "tvdb".ToTraktSearchIDType().Should().Be(TraktSearchIDType.TvDB);
            "tvrage".ToTraktSearchIDType().Should().Be(TraktSearchIDType.TVRage);

            string? nullValue = null;
            nullValue.ToTraktSearchIDType().Should().Be(TraktSearchIDType.Unspecified);
        }

        [Fact]
        public void TestTraktSearchIDTypeDisplayName()
        {
            TraktSearchIDType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktSearchIDType.Trakt.DisplayName().Should().Be("Trakt");
            TraktSearchIDType.ImDB.DisplayName().Should().Be("Internet Movie Database");
            TraktSearchIDType.TmDB.DisplayName().Should().Be("The Movie Database");
            TraktSearchIDType.TvDB.DisplayName().Should().Be("TheTVDB");
            TraktSearchIDType.TVRage.DisplayName().Should().Be("TVRage");
        }
    }
}
