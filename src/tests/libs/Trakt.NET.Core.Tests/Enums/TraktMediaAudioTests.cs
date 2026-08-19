using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktMediaAudioTests
    {
        [Fact]
        public void TestTraktMediaAudioToJson()
        {
            TraktMediaAudio.Unspecified.ToJson().ShouldBeNull();
            TraktMediaAudio.LPCM.ToJson().ShouldBe("lpcm");
            TraktMediaAudio.MP3.ToJson().ShouldBe("mp3");
            TraktMediaAudio.AAC.ToJson().ShouldBe("aac");
            TraktMediaAudio.OGG.ToJson().ShouldBe("ogg");
            TraktMediaAudio.WMA.ToJson().ShouldBe("wma");
            TraktMediaAudio.DTS.ToJson().ShouldBe("dts");
            TraktMediaAudio.DTSMA.ToJson().ShouldBe("dts_ma");
            TraktMediaAudio.DTSX.ToJson().ShouldBe("dts_x");
            TraktMediaAudio.DolbyPrologic.ToJson().ShouldBe("dolby_prologic");
            TraktMediaAudio.DolbyDigital.ToJson().ShouldBe("dolby_digital");
            TraktMediaAudio.DolbyDigitalPlus.ToJson().ShouldBe("dolby_digital_plus");
            TraktMediaAudio.DolbyTrueHD.ToJson().ShouldBe("dolby_truehd");
            TraktMediaAudio.DolbyAtmos.ToJson().ShouldBe("dolby_atmos");
            TraktMediaAudio.DTSHR.ToJson().ShouldBe("dts_hr");
            TraktMediaAudio.AURO3D.ToJson().ShouldBe("auro_3d");
            ((TraktMediaAudio)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktMediaAudioFromJson()
        {
            "unspecified".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.Unspecified);
            "lpcm".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.LPCM);
            "mp3".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.MP3);
            "aac".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.AAC);
            "ogg".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.OGG);
            "wma".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.WMA);
            "dts".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.DTS);
            "dts_ma".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.DTSMA);
            "dts_x".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.DTSX);
            "dolby_prologic".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.DolbyPrologic);
            "dolby_digital".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.DolbyDigital);
            "dolby_digital_plus".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.DolbyDigitalPlus);
            "dolby_truehd".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.DolbyTrueHD);
            "dolby_atmos".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.DolbyAtmos);
            "dts_hr".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.DTSHR);
            "auro_3d".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.AURO3D);

            string? nullValue = null;
            nullValue.ToTraktMediaAudio().ShouldBe(TraktMediaAudio.Unspecified);
            "invalid".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.Unspecified);
            "".ToTraktMediaAudio().ShouldBe(TraktMediaAudio.Unspecified);
        }

        [Fact]
        public void TestTraktMediaAudioDisplayName()
        {
            TraktMediaAudio.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktMediaAudio.LPCM.DisplayName().ShouldBe("LPCM");
            TraktMediaAudio.MP3.DisplayName().ShouldBe("MP3");
            TraktMediaAudio.AAC.DisplayName().ShouldBe("AAC");
            TraktMediaAudio.OGG.DisplayName().ShouldBe("OGG");
            TraktMediaAudio.WMA.DisplayName().ShouldBe("WMA");
            TraktMediaAudio.DTS.DisplayName().ShouldBe("DTS");
            TraktMediaAudio.DTSMA.DisplayName().ShouldBe("DTS Master Audio");
            TraktMediaAudio.DTSX.DisplayName().ShouldBe("DTS X");
            TraktMediaAudio.DolbyPrologic.DisplayName().ShouldBe("Dolby Prologic");
            TraktMediaAudio.DolbyDigital.DisplayName().ShouldBe("Dolby Digital");
            TraktMediaAudio.DolbyDigitalPlus.DisplayName().ShouldBe("Dolby Digital Plus");
            TraktMediaAudio.DolbyTrueHD.DisplayName().ShouldBe("Dolby True HD");
            TraktMediaAudio.DolbyAtmos.DisplayName().ShouldBe("Dolby Atmos");
            TraktMediaAudio.DTSHR.DisplayName().ShouldBe("DTS HR");
            TraktMediaAudio.AURO3D.DisplayName().ShouldBe("AURO 3D");
            ((TraktMediaAudio)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktMediaAudioJsonConverter()
        {
            var converter = new TraktMediaAudioJsonConverter();
            converter.CanConvert(typeof(TraktMediaAudio)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktMediaAudio.LPCM, options).ShouldBe("\"lpcm\"");
            JsonSerializer.Deserialize<TraktMediaAudio>("\"lpcm\"", options).ShouldBe(TraktMediaAudio.LPCM);
            JsonSerializer.Deserialize<TraktMediaAudio>("\"\"", options).ShouldBe(TraktMediaAudio.Unspecified);
        }
    }
}
