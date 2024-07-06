namespace TraktNET.Enums
{
    public sealed class TraktMediaAudioTests
    {
        [Fact]
        public void TestTraktMediaAudioToJson()
        {
            TraktMediaAudio.Unspecified.ToJson().Should().BeNull();
            TraktMediaAudio.LPCM.ToJson().Should().Be("lpcm");
            TraktMediaAudio.MP3.ToJson().Should().Be("mp3");
            TraktMediaAudio.AAC.ToJson().Should().Be("aac");
            TraktMediaAudio.OGG.ToJson().Should().Be("ogg");
            TraktMediaAudio.WMA.ToJson().Should().Be("wma");
            TraktMediaAudio.DTS.ToJson().Should().Be("dts");
            TraktMediaAudio.DTSMA.ToJson().Should().Be("dts_ma");
            TraktMediaAudio.DTSX.ToJson().Should().Be("dts_x");
            TraktMediaAudio.DolbyPrologic.ToJson().Should().Be("dolby_prologic");
            TraktMediaAudio.DolbyDigital.ToJson().Should().Be("dolby_digital");
            TraktMediaAudio.DolbyDigitalPlus.ToJson().Should().Be("dolby_digital_plus");
            TraktMediaAudio.DolbyTrueHD.ToJson().Should().Be("dolby_truehd");
            TraktMediaAudio.DolbyAtmos.ToJson().Should().Be("dolby_atmos");
            TraktMediaAudio.DTSHR.ToJson().Should().Be("dts_hr");
            TraktMediaAudio.AURO3D.ToJson().Should().Be("auro_3d");
        }

        [Fact]
        public void TestTraktMediaAudioFromJson()
        {
            "unspecified".ToTraktMediaAudio().Should().Be(TraktMediaAudio.Unspecified);
            "lpcm".ToTraktMediaAudio().Should().Be(TraktMediaAudio.LPCM);
            "mp3".ToTraktMediaAudio().Should().Be(TraktMediaAudio.MP3);
            "aac".ToTraktMediaAudio().Should().Be(TraktMediaAudio.AAC);
            "ogg".ToTraktMediaAudio().Should().Be(TraktMediaAudio.OGG);
            "wma".ToTraktMediaAudio().Should().Be(TraktMediaAudio.WMA);
            "dts".ToTraktMediaAudio().Should().Be(TraktMediaAudio.DTS);
            "dts_ma".ToTraktMediaAudio().Should().Be(TraktMediaAudio.DTSMA);
            "dts_x".ToTraktMediaAudio().Should().Be(TraktMediaAudio.DTSX);
            "dolby_prologic".ToTraktMediaAudio().Should().Be(TraktMediaAudio.DolbyPrologic);
            "dolby_digital".ToTraktMediaAudio().Should().Be(TraktMediaAudio.DolbyDigital);
            "dolby_digital_plus".ToTraktMediaAudio().Should().Be(TraktMediaAudio.DolbyDigitalPlus);
            "dolby_truehd".ToTraktMediaAudio().Should().Be(TraktMediaAudio.DolbyTrueHD);
            "dolby_atmos".ToTraktMediaAudio().Should().Be(TraktMediaAudio.DolbyAtmos);
            "dts_hr".ToTraktMediaAudio().Should().Be(TraktMediaAudio.DTSHR);
            "auro_3d".ToTraktMediaAudio().Should().Be(TraktMediaAudio.AURO3D);

            string? nullValue = null;
            nullValue.ToTraktMediaAudio().Should().Be(TraktMediaAudio.Unspecified);
        }

        [Fact]
        public void TestTraktMediaAudioDisplayName()
        {
            TraktMediaAudio.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktMediaAudio.LPCM.DisplayName().Should().Be("LPCM");
            TraktMediaAudio.MP3.DisplayName().Should().Be("MP3");
            TraktMediaAudio.AAC.DisplayName().Should().Be("AAC");
            TraktMediaAudio.OGG.DisplayName().Should().Be("OGG");
            TraktMediaAudio.WMA.DisplayName().Should().Be("WMA");
            TraktMediaAudio.DTS.DisplayName().Should().Be("DTS");
            TraktMediaAudio.DTSMA.DisplayName().Should().Be("DTS Master Audio");
            TraktMediaAudio.DTSX.DisplayName().Should().Be("DTS X");
            TraktMediaAudio.DolbyPrologic.DisplayName().Should().Be("Dolby Prologic");
            TraktMediaAudio.DolbyDigital.DisplayName().Should().Be("Dolby Digital");
            TraktMediaAudio.DolbyDigitalPlus.DisplayName().Should().Be("Dolby Digital Plus");
            TraktMediaAudio.DolbyTrueHD.DisplayName().Should().Be("Dolby True HD");
            TraktMediaAudio.DolbyAtmos.DisplayName().Should().Be("Dolby Atmos");
            TraktMediaAudio.DTSHR.DisplayName().Should().Be("DTS HR");
            TraktMediaAudio.AURO3D.DisplayName().Should().Be("AURO 3D");
        }
    }
}
