namespace TraktNET.Json.Shows
{
    public sealed class TraktShowTranslationTests
    {
        [Fact]
        public void TestTraktShowTranslationConstructor()
        {
            var showTranslation = new TraktShowTranslation();

            showTranslation.Title.ShouldBeNull();
            showTranslation.Overview.ShouldBeNull();
            showTranslation.Tagline.ShouldBeNull();
            showTranslation.Language.ShouldBeNull();
            showTranslation.Country.ShouldBeNull();

            showTranslation.ToString().ShouldBe("no title set");
        }

        [Fact]
        public async Task TestTraktShowTranslationFromJson()
        {
            TraktShowTranslation? showTranslation = await TestUtility.DeserializeJsonAsync<TraktShowTranslation>("Shows\\showtranslation.json");

            showTranslation.ShouldNotBeNull();

            showTranslation!.Title.ShouldBe("Juego de tronos");
            showTranslation!.Overview.ShouldStartWith("En una tierra donde los veranos duran décadas");
            showTranslation!.Tagline.ShouldBe("Se acerca el invierno");
            showTranslation!.Language.ShouldBe("es");
            showTranslation!.Country.ShouldBe("es");

            showTranslation!.ToString().ShouldBe("es-ES=Juego de tronos");
        }

        [Fact]
        public void TestTraktShowTranslationToString()
        {
            var showTranslation = new TraktShowTranslation { Title = "Juego de tronos" };
            showTranslation.ToString().ShouldBe("Juego de tronos");

            showTranslation = new TraktShowTranslation { Language = "es" };
            showTranslation.ToString().ShouldBe("no title set");

            showTranslation = new TraktShowTranslation { Country = "es" };
            showTranslation.ToString().ShouldBe("no title set");
        }
    }
}
