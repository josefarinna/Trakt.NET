using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktSearchIDTypeTests
    {
        [Fact]
        public void TestTraktSearchIDTypeToJson()
        {
            TraktSearchIDType.Unspecified.ToJson().ShouldBeNull();
            TraktSearchIDType.Trakt.ToJson().ShouldBe("trakt");
            TraktSearchIDType.ImDB.ToJson().ShouldBe("imdb");
            TraktSearchIDType.TmDB.ToJson().ShouldBe("tmdb");
            TraktSearchIDType.TvDB.ToJson().ShouldBe("tvdb");
            ((TraktSearchIDType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktSearchIDTypeFromJson()
        {
            "unspecified".ToTraktSearchIDType().ShouldBe(TraktSearchIDType.Unspecified);
            "trakt".ToTraktSearchIDType().ShouldBe(TraktSearchIDType.Trakt);
            "imdb".ToTraktSearchIDType().ShouldBe(TraktSearchIDType.ImDB);
            "tmdb".ToTraktSearchIDType().ShouldBe(TraktSearchIDType.TmDB);
            "tvdb".ToTraktSearchIDType().ShouldBe(TraktSearchIDType.TvDB);

            string? nullValue = null;
            nullValue.ToTraktSearchIDType().ShouldBe(TraktSearchIDType.Unspecified);
            "invalid".ToTraktSearchIDType().ShouldBe(TraktSearchIDType.Unspecified);
            "".ToTraktSearchIDType().ShouldBe(TraktSearchIDType.Unspecified);
        }

        [Fact]
        public void TestTraktSearchIDTypeDisplayName()
        {
            TraktSearchIDType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSearchIDType.Trakt.DisplayName().ShouldBe("Trakt");
            TraktSearchIDType.ImDB.DisplayName().ShouldBe("Internet Movie Database");
            TraktSearchIDType.TmDB.DisplayName().ShouldBe("The Movie Database");
            TraktSearchIDType.TvDB.DisplayName().ShouldBe("TheTVDB");
            ((TraktSearchIDType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktSearchIDTypeJsonConverter()
        {
            var converter = new TraktSearchIDTypeJsonConverter();
            converter.CanConvert(typeof(TraktSearchIDType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSearchIDType.Trakt, options).ShouldBe("\"trakt\"");
            JsonSerializer.Deserialize<TraktSearchIDType>("\"trakt\"", options).ShouldBe(TraktSearchIDType.Trakt);
            JsonSerializer.Deserialize<TraktSearchIDType>("\"\"", options).ShouldBe(TraktSearchIDType.Unspecified);
        }
    }
}
