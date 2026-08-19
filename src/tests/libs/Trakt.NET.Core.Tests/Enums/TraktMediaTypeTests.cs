using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktMediaTypeTests
    {
        [Fact]
        public void TestTraktMediaTypeToJson()
        {
            TraktMediaType.Unspecified.ToJson().ShouldBeNull();
            TraktMediaType.Digital.ToJson().ShouldBe("digital");
            TraktMediaType.Bluray.ToJson().ShouldBe("bluray");
            TraktMediaType.HDDVD.ToJson().ShouldBe("hddvd");
            TraktMediaType.DVD.ToJson().ShouldBe("dvd");
            TraktMediaType.VCD.ToJson().ShouldBe("vcd");
            TraktMediaType.VHS.ToJson().ShouldBe("vhs");
            TraktMediaType.BetaMax.ToJson().ShouldBe("betamax");
            TraktMediaType.LaserDisc.ToJson().ShouldBe("laserdisc");
            ((TraktMediaType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktMediaTypeFromJson()
        {
            "unspecified".ToTraktMediaType().ShouldBe(TraktMediaType.Unspecified);
            "digital".ToTraktMediaType().ShouldBe(TraktMediaType.Digital);
            "bluray".ToTraktMediaType().ShouldBe(TraktMediaType.Bluray);
            "hddvd".ToTraktMediaType().ShouldBe(TraktMediaType.HDDVD);
            "dvd".ToTraktMediaType().ShouldBe(TraktMediaType.DVD);
            "vcd".ToTraktMediaType().ShouldBe(TraktMediaType.VCD);
            "vhs".ToTraktMediaType().ShouldBe(TraktMediaType.VHS);
            "betamax".ToTraktMediaType().ShouldBe(TraktMediaType.BetaMax);
            "laserdisc".ToTraktMediaType().ShouldBe(TraktMediaType.LaserDisc);

            string? nullValue = null;
            nullValue.ToTraktMediaType().ShouldBe(TraktMediaType.Unspecified);
            "invalid".ToTraktMediaType().ShouldBe(TraktMediaType.Unspecified);
            "".ToTraktMediaType().ShouldBe(TraktMediaType.Unspecified);
        }

        [Fact]
        public void TestTraktMediaTypeDisplayName()
        {
            TraktMediaType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktMediaType.Digital.DisplayName().ShouldBe("Digital");
            TraktMediaType.Bluray.DisplayName().ShouldBe("Bluray");
            TraktMediaType.HDDVD.DisplayName().ShouldBe("HD DVD");
            TraktMediaType.DVD.DisplayName().ShouldBe("DVD");
            TraktMediaType.VCD.DisplayName().ShouldBe("VCD");
            TraktMediaType.VHS.DisplayName().ShouldBe("VHS");
            TraktMediaType.BetaMax.DisplayName().ShouldBe("BetaMax");
            TraktMediaType.LaserDisc.DisplayName().ShouldBe("LaserDisc");
            ((TraktMediaType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktMediaTypeJsonConverter()
        {
            var converter = new TraktMediaTypeJsonConverter();
            converter.CanConvert(typeof(TraktMediaType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktMediaType.Digital, options).ShouldBe("\"digital\"");
            JsonSerializer.Deserialize<TraktMediaType>("\"digital\"", options).ShouldBe(TraktMediaType.Digital);
            JsonSerializer.Deserialize<TraktMediaType>("\"\"", options).ShouldBe(TraktMediaType.Unspecified);
        }
    }
}
