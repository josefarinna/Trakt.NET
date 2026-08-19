using System.Text.Json;

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
            ((TraktSmartListMediaType)99).ToJson().ShouldBeNull();
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
            "invalid".ToTraktSmartListMediaType().ShouldBe(TraktSmartListMediaType.Unspecified);
            "".ToTraktSmartListMediaType().ShouldBe(TraktSmartListMediaType.Unspecified);
        }

        [Fact]
        public void TestTraktSmartListMediaTypeDisplayName()
        {
            TraktSmartListMediaType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSmartListMediaType.Movies.DisplayName().ShouldBe("Movies");
            TraktSmartListMediaType.Shows.DisplayName().ShouldBe("Shows");
            TraktSmartListMediaType.Media.DisplayName().ShouldBe("Media");
            ((TraktSmartListMediaType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktSmartListMediaTypeJsonConverter()
        {
            var converter = new TraktSmartListMediaTypeJsonConverter();
            converter.CanConvert(typeof(TraktSmartListMediaType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSmartListMediaType.Movies, options).ShouldBe("\"movies\"");
            JsonSerializer.Deserialize<TraktSmartListMediaType>("\"movies\"", options).ShouldBe(TraktSmartListMediaType.Movies);
            JsonSerializer.Deserialize<TraktSmartListMediaType>("\"\"", options).ShouldBe(TraktSmartListMediaType.Unspecified);
        }
    }
}
