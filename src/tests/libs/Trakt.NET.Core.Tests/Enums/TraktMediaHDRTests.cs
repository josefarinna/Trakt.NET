using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktMediaHDRTests
    {
        [Fact]
        public void TestTraktMediaHDRToJson()
        {
            TraktMediaHDR.Unspecified.ToJson().ShouldBeNull();
            TraktMediaHDR.DolbyVision.ToJson().ShouldBe("dolby_vision");
            TraktMediaHDR.HDR10.ToJson().ShouldBe("hdr10");
            TraktMediaHDR.HDR10Plus.ToJson().ShouldBe("hdr10_plus");
            TraktMediaHDR.HLG.ToJson().ShouldBe("hlg");
            ((TraktMediaHDR)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktMediaHDRFromJson()
        {
            "unspecified".ToTraktMediaHDR().ShouldBe(TraktMediaHDR.Unspecified);
            "dolby_vision".ToTraktMediaHDR().ShouldBe(TraktMediaHDR.DolbyVision);
            "hdr10".ToTraktMediaHDR().ShouldBe(TraktMediaHDR.HDR10);
            "hdr10_plus".ToTraktMediaHDR().ShouldBe(TraktMediaHDR.HDR10Plus);
            "hlg".ToTraktMediaHDR().ShouldBe(TraktMediaHDR.HLG);

            string? nullValue = null;
            nullValue.ToTraktMediaHDR().ShouldBe(TraktMediaHDR.Unspecified);
            "invalid".ToTraktMediaHDR().ShouldBe(TraktMediaHDR.Unspecified);
            "".ToTraktMediaHDR().ShouldBe(TraktMediaHDR.Unspecified);
        }

        [Fact]
        public void TestTraktMediaHDRDisplayName()
        {
            TraktMediaHDR.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktMediaHDR.DolbyVision.DisplayName().ShouldBe("Dolby Vision");
            TraktMediaHDR.HDR10.DisplayName().ShouldBe("HDR10");
            TraktMediaHDR.HDR10Plus.DisplayName().ShouldBe("HDR10 Plus");
            TraktMediaHDR.HLG.DisplayName().ShouldBe("HLG");
            ((TraktMediaHDR)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktMediaHDRJsonConverter()
        {
            var converter = new TraktMediaHDRJsonConverter();
            converter.CanConvert(typeof(TraktMediaHDR)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktMediaHDR.DolbyVision, options).ShouldBe("\"dolby_vision\"");
            JsonSerializer.Deserialize<TraktMediaHDR>("\"dolby_vision\"", options).ShouldBe(TraktMediaHDR.DolbyVision);
            JsonSerializer.Deserialize<TraktMediaHDR>("\"\"", options).ShouldBe(TraktMediaHDR.Unspecified);
        }
    }
}
