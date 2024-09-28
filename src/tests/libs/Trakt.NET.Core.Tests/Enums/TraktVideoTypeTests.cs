namespace TraktNET.Enums
{
    public sealed class TraktVideoTypeTests
    {
        [Fact]
        public void TestTraktVideoTypeToJson()
        {
            TraktVideoType.Unspecified.ToJson().Should().BeNull();
            TraktVideoType.BehindTheScenes.ToJson().Should().Be("behind the scenes");
            TraktVideoType.Bloopers.ToJson().Should().Be("bloopers");
            TraktVideoType.Clip.ToJson().Should().Be("clip");
            TraktVideoType.Featurette.ToJson().Should().Be("featurette");
            TraktVideoType.OpeningCredits.ToJson().Should().Be("opening credits");
            TraktVideoType.Recap.ToJson().Should().Be("recap");
            TraktVideoType.Teaser.ToJson().Should().Be("teaser");
            TraktVideoType.Trailer.ToJson().Should().Be("trailer");
        }

        [Fact]
        public void TestTraktVideoTypeFromJson()
        {
            "unspecified".ToTraktVideoType().Should().Be(TraktVideoType.Unspecified);
            "behind the scenes".ToTraktVideoType().Should().Be(TraktVideoType.BehindTheScenes);
            "bloopers".ToTraktVideoType().Should().Be(TraktVideoType.Bloopers);
            "clip".ToTraktVideoType().Should().Be(TraktVideoType.Clip);
            "featurette".ToTraktVideoType().Should().Be(TraktVideoType.Featurette);
            "opening credits".ToTraktVideoType().Should().Be(TraktVideoType.OpeningCredits);
            "recap".ToTraktVideoType().Should().Be(TraktVideoType.Recap);
            "teaser".ToTraktVideoType().Should().Be(TraktVideoType.Teaser);
            "trailer".ToTraktVideoType().Should().Be(TraktVideoType.Trailer);

            string? nullValue = null;
            nullValue.ToTraktVideoType().Should().Be(TraktVideoType.Unspecified);
        }

        [Fact]
        public void TestTraktVideoTypeDisplayName()
        {
            TraktVideoType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktVideoType.BehindTheScenes.DisplayName().Should().Be("Behind The Scenes");
            TraktVideoType.Bloopers.DisplayName().Should().Be("Bloopers");
            TraktVideoType.Clip.DisplayName().Should().Be("Clip");
            TraktVideoType.Featurette.DisplayName().Should().Be("Featurette");
            TraktVideoType.OpeningCredits.DisplayName().Should().Be("Opening Credits");
            TraktVideoType.Recap.DisplayName().Should().Be("Recap");
            TraktVideoType.Teaser.DisplayName().Should().Be("Teaser");
            TraktVideoType.Trailer.DisplayName().Should().Be("Trailer");
        }
    }
}
