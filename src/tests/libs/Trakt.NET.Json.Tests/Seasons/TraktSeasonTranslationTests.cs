namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonTranslationTests
    {
        [Fact]
        public void TestTraktSeasonTranslationConstructor()
        {
            var seasonTranslation = new TraktSeasonTranslation();

            seasonTranslation.Title.ShouldBeNull();
            seasonTranslation.Overview.ShouldBeNull();
            seasonTranslation.Language.ShouldBeNull();
            seasonTranslation.Country.ShouldBeNull();

            seasonTranslation.ToString().ShouldBe("no title set");
        }

        [Fact]
        public async Task TestTraktSeasonTranslationFromJson()
        {
            TraktSeasonTranslation? seasonTranslation = await TestUtility.DeserializeJsonAsync<TraktSeasonTranslation>("Seasons\\seasontranslation.json");

            seasonTranslation.ShouldNotBeNull();

            seasonTranslation!.Title.ShouldBe("Temporada 1");
            seasonTranslation!.Overview.ShouldStartWith("Se avecinan problemas en los Siete Reinos de Poniente.");
            seasonTranslation!.Language.ShouldBe("es");
            seasonTranslation!.Country.ShouldBe("es");

            seasonTranslation!.ToString().ShouldBe("es-ES=Temporada 1");
        }

        [Fact]
        public async Task TestTraktSeasonTranslationsFromJson()
        {
            IReadOnlyList<TraktSeasonTranslation>? seasonTranslations = await TestUtility.DeserializeJsonListAsync<TraktSeasonTranslation>("Seasons\\seasontranslations.json");

            seasonTranslations.ShouldNotBeNull();
            seasonTranslations!.Count.ShouldBe(2);

            TraktSeasonTranslation seasonTranslation = seasonTranslations![0];

            seasonTranslation.ShouldNotBeNull();

            seasonTranslation.Title.ShouldBe("Temporada 1");
            seasonTranslation.Overview.ShouldStartWith("Se avecinan problemas en los Siete Reinos de Poniente.");
            seasonTranslation.Language.ShouldBe("es");
            seasonTranslation.Country.ShouldBe("es");

            seasonTranslation.ToString().ShouldBe("es-ES=Temporada 1");

            // --------------------------------------------------------------------------------------------

            seasonTranslation = seasonTranslations![1];

            seasonTranslation.ShouldNotBeNull();

            seasonTranslation.Title.ShouldBe("null");
            seasonTranslation.Overview.ShouldStartWith("Die fiktive Welt von Westeros, in der Jahreszeiten sich über Jahre hinziehen");
            seasonTranslation.Language.ShouldBe("de");
            seasonTranslation.Country.ShouldBe("de");

            seasonTranslation.ToString().ShouldBe("de-DE=null");
        }
    }
}
