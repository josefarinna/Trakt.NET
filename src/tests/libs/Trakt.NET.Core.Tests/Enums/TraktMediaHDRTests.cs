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
        }

        [Fact]
        public void TestTraktMediaHDRDisplayName()
        {
            TraktMediaHDR.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktMediaHDR.DolbyVision.DisplayName().ShouldBe("Dolby Vision");
            TraktMediaHDR.HDR10.DisplayName().ShouldBe("HDR10");
            TraktMediaHDR.HDR10Plus.DisplayName().ShouldBe("HDR10 Plus");
            TraktMediaHDR.HLG.DisplayName().ShouldBe("HLG");
        }
    }
}
