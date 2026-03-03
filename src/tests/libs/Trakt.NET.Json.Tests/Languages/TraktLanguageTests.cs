namespace TraktNET.Json.Languages
{
    public sealed class TraktLanguageTests
    {
        [Fact]
        public void TestTraktLanguageConstructor()
        {
            var language = new TraktLanguage();

            language.Name.ShouldBeNull();
            language.Code.ShouldBeNull();
            language.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktLanguageFromJson()
        {
            IReadOnlyList<TraktLanguage>? languages = await TestUtility.DeserializeJsonListAsync<TraktLanguage>("Languages\\languagesmovies.json");

            languages.ShouldNotBeNull();
            languages!.Count.ShouldBe(177);

            TraktLanguage firstLanguage = languages[0];
            firstLanguage.Name.ShouldBe("Abkhazian");
            firstLanguage.Code.ShouldBe("ab");
            firstLanguage.ToString().ShouldBe("Abkhazian");

            TraktLanguage arabic = languages.First(l => l.Code == "ar");
            arabic.Name.ShouldBe("Arabic");
        }
    }
}
