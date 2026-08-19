using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktReleaseTypeTests
    {
        [Fact]
        public void TestTraktReleaseTypeToJson()
        {
            TraktReleaseType.Unspecified.ToJson().ShouldBeNull();
            TraktReleaseType.Unknown.ToJson().ShouldBe("unknown");
            TraktReleaseType.Premiere.ToJson().ShouldBe("premiere");
            TraktReleaseType.Limited.ToJson().ShouldBe("limited");
            TraktReleaseType.Theatrical.ToJson().ShouldBe("theatrical");
            TraktReleaseType.Digital.ToJson().ShouldBe("digital");
            TraktReleaseType.Physical.ToJson().ShouldBe("physical");
            TraktReleaseType.TV.ToJson().ShouldBe("tv");
            ((TraktReleaseType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktReleaseTypeFromJson()
        {
            "unspecified".ToTraktReleaseType().ShouldBe(TraktReleaseType.Unspecified);
            "unknown".ToTraktReleaseType().ShouldBe(TraktReleaseType.Unknown);
            "premiere".ToTraktReleaseType().ShouldBe(TraktReleaseType.Premiere);
            "limited".ToTraktReleaseType().ShouldBe(TraktReleaseType.Limited);
            "theatrical".ToTraktReleaseType().ShouldBe(TraktReleaseType.Theatrical);
            "digital".ToTraktReleaseType().ShouldBe(TraktReleaseType.Digital);
            "physical".ToTraktReleaseType().ShouldBe(TraktReleaseType.Physical);
            "tv".ToTraktReleaseType().ShouldBe(TraktReleaseType.TV);

            string? nullValue = null;
            nullValue.ToTraktReleaseType().ShouldBe(TraktReleaseType.Unspecified);
            "invalid".ToTraktReleaseType().ShouldBe(TraktReleaseType.Unspecified);
            "".ToTraktReleaseType().ShouldBe(TraktReleaseType.Unspecified);
        }

        [Fact]
        public void TestTraktReleaseTypeDisplayName()
        {
            TraktReleaseType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktReleaseType.Unknown.DisplayName().ShouldBe("Unknown");
            TraktReleaseType.Premiere.DisplayName().ShouldBe("Premiere");
            TraktReleaseType.Limited.DisplayName().ShouldBe("Limited");
            TraktReleaseType.Theatrical.DisplayName().ShouldBe("Theatrical");
            TraktReleaseType.Digital.DisplayName().ShouldBe("Digital");
            TraktReleaseType.Physical.DisplayName().ShouldBe("Physical");
            TraktReleaseType.TV.DisplayName().ShouldBe("TV");
            ((TraktReleaseType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktReleaseTypeJsonConverter()
        {
            var converter = new TraktReleaseTypeJsonConverter();
            converter.CanConvert(typeof(TraktReleaseType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktReleaseType.Unknown, options).ShouldBe("\"unknown\"");
            JsonSerializer.Deserialize<TraktReleaseType>("\"unknown\"", options).ShouldBe(TraktReleaseType.Unknown);
            JsonSerializer.Deserialize<TraktReleaseType>("\"\"", options).ShouldBe(TraktReleaseType.Unspecified);
        }
    }
}
