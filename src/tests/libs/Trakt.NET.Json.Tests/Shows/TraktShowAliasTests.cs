namespace TraktNET.Json.Shows
{
    public sealed class TraktShowAliasTests
    {
        [Fact]
        public void TestTraktShowAliasConstructor()
        {
            var showAlias = new TraktShowAlias();

            showAlias.Title.ShouldBeNull();
            showAlias.Country.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktShowAliasFromJson()
        {
            TraktShowAlias? showAlias = await TestUtility.DeserializeJsonAsync<TraktShowAlias>("Shows\\showalias.json");

            showAlias.ShouldNotBeNull();

            showAlias!.Title.ShouldBe("Juego de Tronos");
            showAlias!.Country.ShouldBe("es");
        }

        [Fact]
        public async Task TestTraktShowAliasesFromJson()
        {
            IReadOnlyList<TraktShowAlias>? showAliases = await TestUtility.DeserializeJsonListAsync<TraktShowAlias>("Shows\\showaliases.json");

            showAliases.ShouldNotBeNull();
            showAliases!.Count.ShouldBe(3);

            TraktShowAlias showAlias = showAliases![0];

            showAlias.ShouldNotBeNull();
            showAlias.Title.ShouldBe("Juego de Tronos");
            showAlias.Country.ShouldBe("es");

            // --------------------------------------------------------------------------------------------

            showAlias = showAliases![1];

            showAlias.ShouldNotBeNull();
            showAlias.Title.ShouldBe("Game of Thrones - Das Lied von Eis und Feuer");
            showAlias.Country.ShouldBe("de");

            // --------------------------------------------------------------------------------------------

            showAlias = showAliases![2];

            showAlias.ShouldNotBeNull();
            showAlias.Title.ShouldBe("Le Trône de fer");
            showAlias.Country.ShouldBe("fr");
        }
    }
}
