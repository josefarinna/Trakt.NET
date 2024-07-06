namespace TraktNET.Enums
{
    public sealed class TraktMediaTypeTests
    {
        [Fact]
        public void TestTraktMediaTypeToJson()
        {
            TraktMediaType.Unspecified.ToJson().Should().BeNull();
            TraktMediaType.Digital.ToJson().Should().Be("digital");
            TraktMediaType.Bluray.ToJson().Should().Be("bluray");
            TraktMediaType.HDDVD.ToJson().Should().Be("hddvd");
            TraktMediaType.DVD.ToJson().Should().Be("dvd");
            TraktMediaType.VCD.ToJson().Should().Be("vcd");
            TraktMediaType.VHS.ToJson().Should().Be("vhs");
            TraktMediaType.BetaMax.ToJson().Should().Be("betamax");
            TraktMediaType.LaserDisc.ToJson().Should().Be("laserdisc");
        }

        [Fact]
        public void TestTraktMediaTypeFromJson()
        {
            "unspecified".ToTraktMediaType().Should().Be(TraktMediaType.Unspecified);
            "digital".ToTraktMediaType().Should().Be(TraktMediaType.Digital);
            "bluray".ToTraktMediaType().Should().Be(TraktMediaType.Bluray);
            "hddvd".ToTraktMediaType().Should().Be(TraktMediaType.HDDVD);
            "dvd".ToTraktMediaType().Should().Be(TraktMediaType.DVD);
            "vcd".ToTraktMediaType().Should().Be(TraktMediaType.VCD);
            "vhs".ToTraktMediaType().Should().Be(TraktMediaType.VHS);
            "betamax".ToTraktMediaType().Should().Be(TraktMediaType.BetaMax);
            "laserdisc".ToTraktMediaType().Should().Be(TraktMediaType.LaserDisc);

            string? nullValue = null;
            nullValue.ToTraktMediaType().Should().Be(TraktMediaType.Unspecified);
        }

        [Fact]
        public void TestTraktMediaTypeDisplayName()
        {
            TraktMediaType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktMediaType.Digital.DisplayName().Should().Be("Digital");
            TraktMediaType.Bluray.DisplayName().Should().Be("Bluray");
            TraktMediaType.HDDVD.DisplayName().Should().Be("HD DVD");
            TraktMediaType.DVD.DisplayName().Should().Be("DVD");
            TraktMediaType.VCD.DisplayName().Should().Be("VCD");
            TraktMediaType.VHS.DisplayName().Should().Be("VHS");
            TraktMediaType.BetaMax.DisplayName().Should().Be("BetaMax");
            TraktMediaType.LaserDisc.DisplayName().Should().Be("LaserDisc");
        }
    }
}
