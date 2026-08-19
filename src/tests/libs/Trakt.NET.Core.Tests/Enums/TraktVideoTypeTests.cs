using System.Text.Json;

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
            ((TraktVideoType)99).ToJson().ShouldBeNull();
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
            "invalid".ToTraktVideoType().ShouldBe(TraktVideoType.Unspecified);
            "".ToTraktVideoType().ShouldBe(TraktVideoType.Unspecified);
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
            ((TraktVideoType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktVideoTypeJsonConverter()
        {
            var converter = new TraktVideoTypeJsonConverter();
            converter.CanConvert(typeof(TraktVideoType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktVideoType.BehindTheScenes, options).ShouldBe("\"behind the scenes\"");
            JsonSerializer.Deserialize<TraktVideoType>("\"behind the scenes\"", options).ShouldBe(TraktVideoType.BehindTheScenes);
            JsonSerializer.Deserialize<TraktVideoType>("\"\"", options).ShouldBe(TraktVideoType.Unspecified);
        }
    }
}
