namespace TraktNET.Enums
{
    public sealed class TraktMediaHDRTests
    {
        [Fact]
        public void TestTraktMediaHDRToJson()
        {
            TraktMediaHDR.Unspecified.ToJson().Should().BeNull();
            TraktMediaHDR.DolbyVision.ToJson().Should().Be("dolby_vision");
            TraktMediaHDR.HDR10.ToJson().Should().Be("hdr10");
            TraktMediaHDR.HDR10Plus.ToJson().Should().Be("hdr10_plus");
            TraktMediaHDR.HLG.ToJson().Should().Be("hlg");
        }

        [Fact]
        public void TestTraktMediaHDRFromJson()
        {
            "unspecified".ToTraktMediaHDR().Should().Be(TraktMediaHDR.Unspecified);
            "dolby_vision".ToTraktMediaHDR().Should().Be(TraktMediaHDR.DolbyVision);
            "hdr10".ToTraktMediaHDR().Should().Be(TraktMediaHDR.HDR10);
            "hdr10_plus".ToTraktMediaHDR().Should().Be(TraktMediaHDR.HDR10Plus);
            "hlg".ToTraktMediaHDR().Should().Be(TraktMediaHDR.HLG);

            string? nullValue = null;
            nullValue.ToTraktMediaHDR().Should().Be(TraktMediaHDR.Unspecified);
        }

        [Fact]
        public void TestTraktMediaHDRDisplayName()
        {
            TraktMediaHDR.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktMediaHDR.DolbyVision.DisplayName().Should().Be("Dolby Vision");
            TraktMediaHDR.HDR10.DisplayName().Should().Be("HDR10");
            TraktMediaHDR.HDR10Plus.DisplayName().Should().Be("HDR10 Plus");
            TraktMediaHDR.HLG.DisplayName().Should().Be("HLG");
        }
    }
}
