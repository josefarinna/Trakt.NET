namespace TraktNET.Json.General
{
    public sealed class TraktCastAndCrewTests
    {
        [Fact]
        public void TestTraktCastAndCrewConstructor()
        {
            var castAndCrew = new TraktCastAndCrew();

            castAndCrew.Cast.Should().BeNull();
            castAndCrew.Crew.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktCastAndCrewFromJson()
        {
            TraktCastAndCrew? castAndCrew = await TestUtility.DeserializeJsonAsync<TraktCastAndCrew>("General\\castandcrew.json");

            castAndCrew.Should().NotBeNull();

            castAndCrew!.Cast.Should().NotBeNull().And.HaveCount(2);
            castAndCrew!.Cast![0].Should().NotBeNull();
            castAndCrew!.Cast![1].Should().NotBeNull();

            castAndCrew!.Cast[0].Characters.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo(["Peter Quill", "Star-Lord"]);
            castAndCrew!.Cast[0].Person.Should().NotBeNull();
            castAndCrew!.Cast[0].Person!.Name.Should().Be("Chris Pratt");
            castAndCrew!.Cast[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Cast[0].Person!.Ids!.Trakt.Should().Be(422885U);
            castAndCrew!.Cast[0].Person!.Ids!.Slug.Should().Be("chris-pratt");
            castAndCrew!.Cast[0].Person!.Ids!.IMDB.Should().Be("nm0695435");
            castAndCrew!.Cast[0].Person!.Ids!.TMDB.Should().Be(73457U);

            castAndCrew!.Cast[1].Characters.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Gamora"]);
            castAndCrew!.Cast[1].Person.Should().NotBeNull();
            castAndCrew!.Cast[1].Person!.Name.Should().Be("Zoe Saldaña");
            castAndCrew!.Cast[1].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Cast[1].Person!.Ids!.Trakt.Should().Be(475U);
            castAndCrew!.Cast[1].Person!.Ids!.Slug.Should().Be("zoe-saldana");
            castAndCrew!.Cast[1].Person!.Ids!.IMDB.Should().Be("nm0757855");
            castAndCrew!.Cast[1].Person!.Ids!.TMDB.Should().Be(8691U);

            castAndCrew!.Crew.Should().NotBeNull();

            castAndCrew!.Crew!.Sound.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.Sound![0].Should().NotBeNull();
            castAndCrew!.Crew.Sound[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Original Music Composer"]);
            castAndCrew!.Crew.Sound[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.Sound[0].Person!.Name.Should().Be("John Murphy");
            castAndCrew!.Crew.Sound[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.Sound[0].Person!.Ids!.Trakt.Should().Be(1005U);
            castAndCrew!.Crew.Sound[0].Person!.Ids!.Slug.Should().Be("john-murphy");
            castAndCrew!.Crew.Sound[0].Person!.Ids!.IMDB.Should().Be("nm0614373");
            castAndCrew!.Crew.Sound[0].Person!.Ids!.TMDB.Should().Be(960U);

            castAndCrew!.Crew.Production.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.Production![0].Should().NotBeNull();
            castAndCrew!.Crew.Production[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Casting"]);
            castAndCrew!.Crew.Production[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.Production[0].Person!.Name.Should().Be("Sarah Halley Finn");
            castAndCrew!.Crew.Production[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.Production[0].Person!.Ids!.Trakt.Should().Be(3223U);
            castAndCrew!.Crew.Production[0].Person!.Ids!.Slug.Should().Be("sarah-halley-finn");
            castAndCrew!.Crew.Production[0].Person!.Ids!.IMDB.Should().Be("nm0278168");
            castAndCrew!.Crew.Production[0].Person!.Ids!.TMDB.Should().Be(7232U);

            castAndCrew!.Crew.Editing.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.Editing![0].Should().NotBeNull();
            castAndCrew!.Crew.Editing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Editor"]);
            castAndCrew!.Crew.Editing[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.Editing[0].Person!.Name.Should().Be("Tatiana S. Riegel");
            castAndCrew!.Crew.Editing[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.Editing[0].Person!.Ids!.Trakt.Should().Be(3527U);
            castAndCrew!.Crew.Editing[0].Person!.Ids!.Slug.Should().Be("tatiana-s-riegel");
            castAndCrew!.Crew.Editing[0].Person!.Ids!.IMDB.Should().Be("nm0726186");
            castAndCrew!.Crew.Editing[0].Person!.Ids!.TMDB.Should().Be(33685U);

            castAndCrew!.Crew.Art.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.Art![0].Should().NotBeNull();
            castAndCrew!.Crew.Art[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Set Decoration"]);
            castAndCrew!.Crew.Art[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.Art[0].Person!.Name.Should().Be("Rosemary Brandenburg");
            castAndCrew!.Crew.Art[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.Art[0].Person!.Ids!.Trakt.Should().Be(6020U);
            castAndCrew!.Crew.Art[0].Person!.Ids!.Slug.Should().Be("rosemary-brandenburg");
            castAndCrew!.Crew.Art[0].Person!.Ids!.IMDB.Should().Be("nm0104599");
            castAndCrew!.Crew.Art[0].Person!.Ids!.TMDB.Should().Be(13588U);

            castAndCrew!.Crew.CostumeAndMakeUp.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.CostumeAndMakeUp![0].Should().NotBeNull();
            castAndCrew!.Crew.CostumeAndMakeUp[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Costume Design"]);
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.Name.Should().Be("Judianna Makovsky");
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.Ids!.Trakt.Should().Be(8106U);
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.Ids!.Slug.Should().Be("judianna-makovsky");
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.Ids!.IMDB.Should().Be("nm0538721");
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.Ids!.TMDB.Should().Be(10970U);

            castAndCrew!.Crew.Crew.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.Crew![0].Should().NotBeNull();
            castAndCrew!.Crew.Crew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Thanks"]);
            castAndCrew!.Crew.Crew[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.Crew[0].Person!.Name.Should().Be("Mike Mignola");
            castAndCrew!.Crew.Crew[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.Crew[0].Person!.Ids!.Trakt.Should().Be(8710U);
            castAndCrew!.Crew.Crew[0].Person!.Ids!.Slug.Should().Be("mike-mignola");
            castAndCrew!.Crew.Crew[0].Person!.Ids!.IMDB.Should().Be("nm0586005");
            castAndCrew!.Crew.Crew[0].Person!.Ids!.TMDB.Should().Be(66266U);

            castAndCrew!.Crew.Writing.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.Writing![0].Should().NotBeNull();
            castAndCrew!.Crew.Writing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Characters"]);
            castAndCrew!.Crew.Writing[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.Writing[0].Person!.Name.Should().Be("Larry Lieber");
            castAndCrew!.Crew.Writing[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.Writing[0].Person!.Ids!.Trakt.Should().Be(15622U);
            castAndCrew!.Crew.Writing[0].Person!.Ids!.Slug.Should().Be("larry-lieber");
            castAndCrew!.Crew.Writing[0].Person!.Ids!.IMDB.Should().Be("nm1293367");
            castAndCrew!.Crew.Writing[0].Person!.Ids!.TMDB.Should().Be(18876U);

            castAndCrew!.Crew.Camera.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.Camera![0].Should().NotBeNull();
            castAndCrew!.Crew.Camera[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Director of Photography"]);
            castAndCrew!.Crew.Camera[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.Camera[0].Person!.Name.Should().Be("Henry Braham");
            castAndCrew!.Crew.Camera[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.Camera[0].Person!.Ids!.Trakt.Should().Be(19744U);
            castAndCrew!.Crew.Camera[0].Person!.Ids!.Slug.Should().Be("henry-braham");
            castAndCrew!.Crew.Camera[0].Person!.Ids!.IMDB.Should().Be("nm0103956");
            castAndCrew!.Crew.Camera[0].Person!.Ids!.TMDB.Should().Be(23422U);

            castAndCrew!.Crew.VisualEffects.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.VisualEffects![0].Should().NotBeNull();
            castAndCrew!.Crew.VisualEffects[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Visual Effects Supervisor"]);
            castAndCrew!.Crew.VisualEffects[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.VisualEffects[0].Person!.Name.Should().Be("Theo Bialek");
            castAndCrew!.Crew.VisualEffects[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.VisualEffects[0].Person!.Ids!.Trakt.Should().Be(22793U);
            castAndCrew!.Crew.VisualEffects[0].Person!.Ids!.Slug.Should().Be("theo-bialek");
            castAndCrew!.Crew.VisualEffects[0].Person!.Ids!.IMDB.Should().Be("nm1322273");
            castAndCrew!.Crew.VisualEffects[0].Person!.Ids!.TMDB.Should().Be(42275U);

            castAndCrew!.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.Directing![0].Should().NotBeNull();
            castAndCrew!.Crew.Directing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Script Supervisor"]);
            castAndCrew!.Crew.Directing[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.Directing[0].Person!.Name.Should().Be("Kera Dacy");
            castAndCrew!.Crew.Directing[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.Directing[0].Person!.Ids!.Trakt.Should().Be(155049U);
            castAndCrew!.Crew.Directing[0].Person!.Ids!.Slug.Should().Be("kera-dacy");
            castAndCrew!.Crew.Directing[0].Person!.Ids!.IMDB.Should().BeNull();
            castAndCrew!.Crew.Directing[0].Person!.Ids!.TMDB.Should().Be(230505U);

            castAndCrew!.Crew.Lighting.Should().NotBeNull().And.HaveCount(1);
            castAndCrew!.Crew.Lighting![0].Should().NotBeNull();
            castAndCrew!.Crew.Lighting[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Chief Lighting Technician"]);
            castAndCrew!.Crew.Lighting[0].Person.Should().NotBeNull();
            castAndCrew!.Crew.Lighting[0].Person!.Name.Should().Be("Dan Cornwall");
            castAndCrew!.Crew.Lighting[0].Person!.Ids.Should().NotBeNull();
            castAndCrew!.Crew.Lighting[0].Person!.Ids!.Trakt.Should().Be(486318U);
            castAndCrew!.Crew.Lighting[0].Person!.Ids!.Slug.Should().Be("dan-cornwall");
            castAndCrew!.Crew.Lighting[0].Person!.Ids!.IMDB.Should().Be("nm0180473");
            castAndCrew!.Crew.Lighting[0].Person!.Ids!.TMDB.Should().Be(1403412U);
        }
    }
}
