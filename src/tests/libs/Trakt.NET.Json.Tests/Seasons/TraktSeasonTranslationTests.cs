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
        public void TestTraktSeasonTranslationToString()
        {
            var seasonTranslation = new TraktSeasonTranslation { Title = "Temporada 1" };
            seasonTranslation.ToString().ShouldBe("Temporada 1");

            seasonTranslation = new TraktSeasonTranslation { Language = "es" };
            seasonTranslation.ToString().ShouldBe("no title set");

            seasonTranslation = new TraktSeasonTranslation { Country = "es" };
            seasonTranslation.ToString().ShouldBe("no title set");
        }
    }
}
