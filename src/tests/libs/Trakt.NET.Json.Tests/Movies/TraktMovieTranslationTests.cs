namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieTranslationTests
    {
        [Fact]
        public void TestTraktMovieTranslationConstructor()
        {
            var movieTranslation = new TraktMovieTranslation();

            movieTranslation.Title.Should().BeNull();
            movieTranslation.Overview.Should().BeNull();
            movieTranslation.Tagline.Should().BeNull();
            movieTranslation.Language.Should().BeNull();
            movieTranslation.Country.Should().BeNull();

            movieTranslation.ToString().Should().Be("no title set");
        }

        [Fact]
        public async Task TestTraktMovieTranslationFromJson()
        {
            TraktMovieTranslation? movieTranslation = await TestUtility.DeserializeJsonAsync<TraktMovieTranslation>("Movies\\movietranslation.json");

            movieTranslation.Should().NotBeNull();

            movieTranslation!.Title.Should().Be("Guardians of the Galaxy Vol. 3");
            movieTranslation!.Overview.Should().Be("Star-Lord, encara recuperant-se de la pèrdua de Gamora, ha de reunir...");
            movieTranslation!.Tagline.Should().Be("Ho donaran tot.");
            movieTranslation!.Language.Should().Be("ca");
            movieTranslation!.Country.Should().Be("es");

            movieTranslation!.ToString().Should().Be("ca-ES=Guardians of the Galaxy Vol. 3");
        }

        [Fact]
        public async Task TestTraktMovieTranslationsFromJson()
        {
            IReadOnlyList<TraktMovieTranslation>? movieTranslations = await TestUtility.DeserializeJsonListAsync<TraktMovieTranslation>("Movies\\movietranslations.json");

            movieTranslations.Should().NotBeNull().And.HaveCount(2);

            TraktMovieTranslation movieTranslation = movieTranslations![0];

            movieTranslation.Should().NotBeNull();

            movieTranslation.Title.Should().Be("Guardians of the Galaxy Vol. 3");
            movieTranslation.Overview.Should().Be("Star-Lord, encara recuperant-se de la pèrdua de Gamora, ha de reunir...");
            movieTranslation.Tagline.Should().Be("Ho donaran tot.");
            movieTranslation.Language.Should().Be("ca");
            movieTranslation.Country.Should().Be("es");

            movieTranslation.ToString().Should().Be("ca-ES=Guardians of the Galaxy Vol. 3");

            // --------------------------------------------------------------------------------------------

            movieTranslation = movieTranslations![1];

            movieTranslation.Should().NotBeNull();

            movieTranslation.Title.Should().Be("Strážci Galaxie: Volume 3");
            movieTranslation.Overview.Should().Be("Oblíbená parta vesmírných ztroskotanců se zabydluje na Kdovíkde.");
            movieTranslation.Tagline.Should().Be("Ještě jednou a s citem");
            movieTranslation.Language.Should().Be("cs");
            movieTranslation.Country.Should().Be("cz");

            movieTranslation.ToString().Should().Be("cs-CZ=Strážci Galaxie: Volume 3");
        }
    }
}
