namespace TraktNET.Enums
{
    public sealed class TraktMediaResolutionTests
    {
        [Fact]
        public void TestTraktMediaResolutionToJson()
        {
            TraktMediaResolution.Unspecified.ToJson().ShouldBeNull();
            TraktMediaResolution.UHD4k.ToJson().ShouldBe("uhd_4k");
            TraktMediaResolution.HD1080p.ToJson().ShouldBe("hd_1080p");
            TraktMediaResolution.HD1080i.ToJson().ShouldBe("hd_1080i");
            TraktMediaResolution.HD720p.ToJson().ShouldBe("hd_720p");
            TraktMediaResolution.SD576p.ToJson().ShouldBe("sd_576p");
            TraktMediaResolution.SD576i.ToJson().ShouldBe("sd_576i");
            TraktMediaResolution.SD480p.ToJson().ShouldBe("sd_480p");
            TraktMediaResolution.SD480i.ToJson().ShouldBe("sd_480i");
        }

        [Fact]
        public void TestTraktMediaResolutionFromJson()
        {
            "unspecified".ToTraktMediaResolution().ShouldBe(TraktMediaResolution.Unspecified);
            "uhd_4k".ToTraktMediaResolution().ShouldBe(TraktMediaResolution.UHD4k);
            "hd_1080p".ToTraktMediaResolution().ShouldBe(TraktMediaResolution.HD1080p);
            "hd_1080i".ToTraktMediaResolution().ShouldBe(TraktMediaResolution.HD1080i);
            "hd_720p".ToTraktMediaResolution().ShouldBe(TraktMediaResolution.HD720p);
            "sd_576p".ToTraktMediaResolution().ShouldBe(TraktMediaResolution.SD576p);
            "sd_576i".ToTraktMediaResolution().ShouldBe(TraktMediaResolution.SD576i);
            "sd_480p".ToTraktMediaResolution().ShouldBe(TraktMediaResolution.SD480p);
            "sd_480i".ToTraktMediaResolution().ShouldBe(TraktMediaResolution.SD480i);

            string? nullValue = null;
            nullValue.ToTraktMediaResolution().ShouldBe(TraktMediaResolution.Unspecified);
        }

        [Fact]
        public void TestTraktMediaResolutionDisplayName()
        {
            TraktMediaResolution.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktMediaResolution.UHD4k.DisplayName().ShouldBe("Ultra HD 4k");
            TraktMediaResolution.HD1080p.DisplayName().ShouldBe("Full HD 1080p");
            TraktMediaResolution.HD1080i.DisplayName().ShouldBe("Full HD 1080i");
            TraktMediaResolution.HD720p.DisplayName().ShouldBe("HD 720p");
            TraktMediaResolution.SD576p.DisplayName().ShouldBe("SD 576p");
            TraktMediaResolution.SD576i.DisplayName().ShouldBe("SD 576i");
            TraktMediaResolution.SD480p.DisplayName().ShouldBe("SD 480p");
            TraktMediaResolution.SD480i.DisplayName().ShouldBe("SD 480i");
        }
    }
}
