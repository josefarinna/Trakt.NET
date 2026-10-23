using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktAvailableOnTests
    {
        [Fact]
        public void TestTraktAvailableOnToJson()
        {
            TraktAvailableOn.Unspecified.ToJson().ShouldBeNull();
            TraktAvailableOn.Digital.ToJson().ShouldBe("digital");
            TraktAvailableOn.Other.ToJson().ShouldBe("other");
            TraktAvailableOn.Plex.ToJson().ShouldBe("plex");
            TraktAvailableOn.Jellyfin.ToJson().ShouldBe("jellyfin");
            ((TraktAvailableOn)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktAvailableOnFromJson()
        {
            "unspecified".ToTraktAvailableOn().ShouldBe(TraktAvailableOn.Unspecified);
            "digital".ToTraktAvailableOn().ShouldBe(TraktAvailableOn.Digital);
            "other".ToTraktAvailableOn().ShouldBe(TraktAvailableOn.Other);
            "plex".ToTraktAvailableOn().ShouldBe(TraktAvailableOn.Plex);
            "jellyfin".ToTraktAvailableOn().ShouldBe(TraktAvailableOn.Jellyfin);

            string? nullValue = null;
            nullValue.ToTraktAvailableOn().ShouldBe(TraktAvailableOn.Unspecified);
            "invalid".ToTraktAvailableOn().ShouldBe(TraktAvailableOn.Unspecified);
            "".ToTraktAvailableOn().ShouldBe(TraktAvailableOn.Unspecified);
        }

        [Fact]
        public void TestTraktAvailableOnToURI()
        {
            TraktAvailableOn.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktAvailableOn.Digital.ToURI().ShouldBe("digital");
            TraktAvailableOn.Other.ToURI().ShouldBe("other");
            TraktAvailableOn.Plex.ToURI().ShouldBe("plex");
            TraktAvailableOn.Jellyfin.ToURI().ShouldBe("jellyfin");
            ((TraktAvailableOn)99).ToURI().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktAvailableOnDisplayName()
        {
            TraktAvailableOn.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktAvailableOn.Digital.DisplayName().ShouldBe("Digital");
            TraktAvailableOn.Other.DisplayName().ShouldBe("Other");
            TraktAvailableOn.Plex.DisplayName().ShouldBe("Plex");
            TraktAvailableOn.Jellyfin.DisplayName().ShouldBe("Jellyfin");
            ((TraktAvailableOn)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktAvailableOnJsonConverter()
        {
            var converter = new TraktAvailableOnJsonConverter();
            converter.CanConvert(typeof(TraktAvailableOn)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktAvailableOn.Digital, options).ShouldBe("\"digital\"");
            JsonSerializer.Deserialize<TraktAvailableOn>("\"digital\"", options).ShouldBe(TraktAvailableOn.Digital);
            JsonSerializer.Deserialize<TraktAvailableOn>("\"\"", options).ShouldBe(TraktAvailableOn.Unspecified);
        }
    }
}

