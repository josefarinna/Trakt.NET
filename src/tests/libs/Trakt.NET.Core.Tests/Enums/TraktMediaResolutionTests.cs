namespace TraktNET.Enums
{
    public sealed class TraktMediaResolutionTests
    {
        [Fact]
        public void TestTraktMediaResolutionToJson()
        {
            TraktMediaResolution.Unspecified.ToJson().Should().BeNull();
            TraktMediaResolution.UHD4k.ToJson().Should().Be("uhd_4k");
            TraktMediaResolution.HD1080p.ToJson().Should().Be("hd_1080p");
            TraktMediaResolution.HD1080i.ToJson().Should().Be("hd_1080i");
            TraktMediaResolution.HD720p.ToJson().Should().Be("hd_720p");
            TraktMediaResolution.SD576p.ToJson().Should().Be("sd_576p");
            TraktMediaResolution.SD576i.ToJson().Should().Be("sd_576i");
            TraktMediaResolution.SD480p.ToJson().Should().Be("sd_480p");
            TraktMediaResolution.SD480i.ToJson().Should().Be("sd_480i");
        }

        [Fact]
        public void TestTraktMediaResolutionFromJson()
        {
            "unspecified".ToTraktMediaResolution().Should().Be(TraktMediaResolution.Unspecified);
            "uhd_4k".ToTraktMediaResolution().Should().Be(TraktMediaResolution.UHD4k);
            "hd_1080p".ToTraktMediaResolution().Should().Be(TraktMediaResolution.HD1080p);
            "hd_1080i".ToTraktMediaResolution().Should().Be(TraktMediaResolution.HD1080i);
            "hd_720p".ToTraktMediaResolution().Should().Be(TraktMediaResolution.HD720p);
            "sd_576p".ToTraktMediaResolution().Should().Be(TraktMediaResolution.SD576p);
            "sd_576i".ToTraktMediaResolution().Should().Be(TraktMediaResolution.SD576i);
            "sd_480p".ToTraktMediaResolution().Should().Be(TraktMediaResolution.SD480p);
            "sd_480i".ToTraktMediaResolution().Should().Be(TraktMediaResolution.SD480i);

            string? nullValue = null;
            nullValue.ToTraktMediaResolution().Should().Be(TraktMediaResolution.Unspecified);
        }

        [Fact]
        public void TestTraktMediaResolutionDisplayName()
        {
            TraktMediaResolution.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktMediaResolution.UHD4k.DisplayName().Should().Be("Ultra HD 4k");
            TraktMediaResolution.HD1080p.DisplayName().Should().Be("Full HD 1080p");
            TraktMediaResolution.HD1080i.DisplayName().Should().Be("Full HD 1080i");
            TraktMediaResolution.HD720p.DisplayName().Should().Be("HD 720p");
            TraktMediaResolution.SD576p.DisplayName().Should().Be("SD 576p");
            TraktMediaResolution.SD576i.DisplayName().Should().Be("SD 576i");
            TraktMediaResolution.SD480p.DisplayName().Should().Be("SD 480p");
            TraktMediaResolution.SD480i.DisplayName().Should().Be("SD 480i");
        }
    }
}
