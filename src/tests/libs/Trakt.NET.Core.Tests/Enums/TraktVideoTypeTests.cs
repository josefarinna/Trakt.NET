namespace TraktNET.Enums
{
    public sealed class TraktVideoTypeTests
    {
        [Fact]
        public void TestTraktVideoTypeToJson()
        {
            TraktVideoType.Unspecified.ToJson().ShouldBeNull();
            TraktVideoType.BehindTheScenes.ToJson().ShouldBe("behind the scenes");
            TraktVideoType.Bloopers.ToJson().ShouldBe("bloopers");
            TraktVideoType.Clip.ToJson().ShouldBe("clip");
            TraktVideoType.Featurette.ToJson().ShouldBe("featurette");
            TraktVideoType.OpeningCredits.ToJson().ShouldBe("opening credits");
            TraktVideoType.Recap.ToJson().ShouldBe("recap");
            TraktVideoType.Teaser.ToJson().ShouldBe("teaser");
            TraktVideoType.Trailer.ToJson().ShouldBe("trailer");
        }

        [Fact]
        public void TestTraktVideoTypeFromJson()
        {
            "unspecified".ToTraktVideoType().ShouldBe(TraktVideoType.Unspecified);
            "behind the scenes".ToTraktVideoType().ShouldBe(TraktVideoType.BehindTheScenes);
            "bloopers".ToTraktVideoType().ShouldBe(TraktVideoType.Bloopers);
            "clip".ToTraktVideoType().ShouldBe(TraktVideoType.Clip);
            "featurette".ToTraktVideoType().ShouldBe(TraktVideoType.Featurette);
            "opening credits".ToTraktVideoType().ShouldBe(TraktVideoType.OpeningCredits);
            "recap".ToTraktVideoType().ShouldBe(TraktVideoType.Recap);
            "teaser".ToTraktVideoType().ShouldBe(TraktVideoType.Teaser);
            "trailer".ToTraktVideoType().ShouldBe(TraktVideoType.Trailer);

            string? nullValue = null;
            nullValue.ToTraktVideoType().ShouldBe(TraktVideoType.Unspecified);
        }

        [Fact]
        public void TestTraktVideoTypeDisplayName()
        {
            TraktVideoType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktVideoType.BehindTheScenes.DisplayName().ShouldBe("Behind The Scenes");
            TraktVideoType.Bloopers.DisplayName().ShouldBe("Bloopers");
            TraktVideoType.Clip.DisplayName().ShouldBe("Clip");
            TraktVideoType.Featurette.DisplayName().ShouldBe("Featurette");
            TraktVideoType.OpeningCredits.DisplayName().ShouldBe("Opening Credits");
            TraktVideoType.Recap.DisplayName().ShouldBe("Recap");
            TraktVideoType.Teaser.DisplayName().ShouldBe("Teaser");
            TraktVideoType.Trailer.DisplayName().ShouldBe("Trailer");
        }
    }
}
