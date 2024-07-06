namespace TraktNET.Enums
{
    public sealed class TraktReleaseTypeTests
    {
        [Fact]
        public void TestTraktReleaseTypeToJson()
        {
            TraktReleaseType.Unspecified.ToJson().Should().BeNull();
            TraktReleaseType.Unknown.ToJson().Should().Be("unknown");
            TraktReleaseType.Premiere.ToJson().Should().Be("premiere");
            TraktReleaseType.Limited.ToJson().Should().Be("limited");
            TraktReleaseType.Theatrical.ToJson().Should().Be("theatrical");
            TraktReleaseType.Digital.ToJson().Should().Be("digital");
            TraktReleaseType.Physical.ToJson().Should().Be("physical");
            TraktReleaseType.TV.ToJson().Should().Be("tv");
        }

        [Fact]
        public void TestTraktReleaseTypeFromJson()
        {
            "unspecified".ToTraktReleaseType().Should().Be(TraktReleaseType.Unspecified);
            "unknown".ToTraktReleaseType().Should().Be(TraktReleaseType.Unknown);
            "premiere".ToTraktReleaseType().Should().Be(TraktReleaseType.Premiere);
            "limited".ToTraktReleaseType().Should().Be(TraktReleaseType.Limited);
            "theatrical".ToTraktReleaseType().Should().Be(TraktReleaseType.Theatrical);
            "digital".ToTraktReleaseType().Should().Be(TraktReleaseType.Digital);
            "physical".ToTraktReleaseType().Should().Be(TraktReleaseType.Physical);
            "tv".ToTraktReleaseType().Should().Be(TraktReleaseType.TV);

            string? nullValue = null;
            nullValue.ToTraktReleaseType().Should().Be(TraktReleaseType.Unspecified);
        }

        [Fact]
        public void TestTraktReleaseTypeDisplayName()
        {
            TraktReleaseType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktReleaseType.Unknown.DisplayName().Should().Be("Unknown");
            TraktReleaseType.Premiere.DisplayName().Should().Be("Premiere");
            TraktReleaseType.Limited.DisplayName().Should().Be("Limited");
            TraktReleaseType.Theatrical.DisplayName().Should().Be("Theatrical");
            TraktReleaseType.Digital.DisplayName().Should().Be("Digital");
            TraktReleaseType.Physical.DisplayName().Should().Be("Physical");
            TraktReleaseType.TV.DisplayName().Should().Be("TV");
        }
    }
}
