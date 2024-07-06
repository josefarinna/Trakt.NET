namespace TraktNET.Enums
{
    public sealed class TraktSearchIdTypeTests
    {
        [Fact]
        public void TestTraktSearchIdTypeToJson()
        {
            TraktSearchIdType.Unspecified.ToJson().Should().BeNull();
            TraktSearchIdType.Trakt.ToJson().Should().Be("trakt");
            TraktSearchIdType.ImDB.ToJson().Should().Be("imdb");
            TraktSearchIdType.TmDB.ToJson().Should().Be("tmdb");
            TraktSearchIdType.TvDB.ToJson().Should().Be("tvdb");
            TraktSearchIdType.TVRage.ToJson().Should().Be("tvrage");
        }

        [Fact]
        public void TestTraktSearchIdTypeFromJson()
        {
            "unspecified".ToTraktSearchIdType().Should().Be(TraktSearchIdType.Unspecified);
            "trakt".ToTraktSearchIdType().Should().Be(TraktSearchIdType.Trakt);
            "imdb".ToTraktSearchIdType().Should().Be(TraktSearchIdType.ImDB);
            "tmdb".ToTraktSearchIdType().Should().Be(TraktSearchIdType.TmDB);
            "tvdb".ToTraktSearchIdType().Should().Be(TraktSearchIdType.TvDB);
            "tvrage".ToTraktSearchIdType().Should().Be(TraktSearchIdType.TVRage);

            string? nullValue = null;
            nullValue.ToTraktSearchIdType().Should().Be(TraktSearchIdType.Unspecified);
        }

        [Fact]
        public void TestTraktSearchIdTypeDisplayName()
        {
            TraktSearchIdType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktSearchIdType.Trakt.DisplayName().Should().Be("Trakt");
            TraktSearchIdType.ImDB.DisplayName().Should().Be("Internet Movie Database");
            TraktSearchIdType.TmDB.DisplayName().Should().Be("The Movie Database");
            TraktSearchIdType.TvDB.DisplayName().Should().Be("TheTVDB");
            TraktSearchIdType.TVRage.DisplayName().Should().Be("TVRage");
        }
    }
}
