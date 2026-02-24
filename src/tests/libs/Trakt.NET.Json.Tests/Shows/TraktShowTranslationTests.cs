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
        public async Task TestTraktShowTranslationsFromJson()
        {
            IReadOnlyList<TraktShowTranslation>? showTranslations = await TestUtility.DeserializeJsonListAsync<TraktShowTranslation>("Shows\\showtranslations.json");

            showTranslations.ShouldNotBeNull();
            showTranslations!.Count.ShouldBe(2);

            TraktShowTranslation showTranslation = showTranslations![0];

            showTranslation.ShouldNotBeNull();

            showTranslation.Title.ShouldBe("Juego de tronos");
            showTranslation.Overview.ShouldStartWith("En una tierra donde los veranos duran décadas");
            showTranslation.Tagline.ShouldBe("Se acerca el invierno");
            showTranslation.Language.ShouldBe("es");
            showTranslation.Country.ShouldBe("es");

            showTranslation.ToString().ShouldBe("es-ES=Juego de tronos");

            // --------------------------------------------------------------------------------------------

            showTranslation = showTranslations![1];

            showTranslation.ShouldNotBeNull();

            showTranslation.Title.ShouldBe("A Guerra dos Tronos");
            showTranslation.Overview.ShouldStartWith("Numa terra onde o verão abrange décadas");
            showTranslation.Tagline.ShouldBe("O inverno está a chegar.");
            showTranslation.Language.ShouldBe("pt");
            showTranslation.Country.ShouldBe("pt");

            showTranslation.ToString().ShouldBe("pt-PT=A Guerra dos Tronos");
        }
    }
}
