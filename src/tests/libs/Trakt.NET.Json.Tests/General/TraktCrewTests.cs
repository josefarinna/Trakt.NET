namespace TraktNET.Json.General
{
    public sealed class TraktCrewTests
    {
        [Fact]
        public void TestTraktCrewConstructor()
        {
            var crew = new TraktCrew();

            crew.Sound.Should().BeNull();
            crew.Production.Should().BeNull();
            crew.Editing.Should().BeNull();
            crew.Art.Should().BeNull();
            crew.CostumeAndMakeUp.Should().BeNull();
            crew.Crew.Should().BeNull();
            crew.Writing.Should().BeNull();
            crew.Camera.Should().BeNull();
            crew.VisualEffects.Should().BeNull();
            crew.Directing.Should().BeNull();
            crew.Lighting.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktCrewFromJson()
        {
            TraktCrew? crew = await TestUtility.DeserializeJsonAsync<TraktCrew>("General\\crew.json");

            crew.Should().NotBeNull();

            crew!.Sound.Should().NotBeNull().And.HaveCount(1);
            crew!.Sound![0].Should().NotBeNull();
            crew!.Sound[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Original Music Composer"]);
            crew!.Sound[0].Person.Should().NotBeNull();
            crew!.Sound[0].Person!.Name.Should().Be("John Murphy");
            crew!.Sound[0].Person!.Ids.Should().NotBeNull();
            crew!.Sound[0].Person!.Ids!.Trakt.Should().Be(1005U);
            crew!.Sound[0].Person!.Ids!.Slug.Should().Be("john-murphy");
            crew!.Sound[0].Person!.Ids!.IMDB.Should().Be("nm0614373");
            crew!.Sound[0].Person!.Ids!.TMDB.Should().Be(960U);

            crew!.Production.Should().NotBeNull().And.HaveCount(1);
            crew!.Production![0].Should().NotBeNull();
            crew!.Production[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Casting"]);
            crew!.Production[0].Person.Should().NotBeNull();
            crew!.Production[0].Person!.Name.Should().Be("Sarah Halley Finn");
            crew!.Production[0].Person!.Ids.Should().NotBeNull();
            crew!.Production[0].Person!.Ids!.Trakt.Should().Be(3223U);
            crew!.Production[0].Person!.Ids!.Slug.Should().Be("sarah-halley-finn");
            crew!.Production[0].Person!.Ids!.IMDB.Should().Be("nm0278168");
            crew!.Production[0].Person!.Ids!.TMDB.Should().Be(7232U);

            crew!.Editing.Should().NotBeNull().And.HaveCount(1);
            crew!.Editing![0].Should().NotBeNull();
            crew!.Editing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Editor"]);
            crew!.Editing[0].Person.Should().NotBeNull();
            crew!.Editing[0].Person!.Name.Should().Be("Tatiana S. Riegel");
            crew!.Editing[0].Person!.Ids.Should().NotBeNull();
            crew!.Editing[0].Person!.Ids!.Trakt.Should().Be(3527U);
            crew!.Editing[0].Person!.Ids!.Slug.Should().Be("tatiana-s-riegel");
            crew!.Editing[0].Person!.Ids!.IMDB.Should().Be("nm0726186");
            crew!.Editing[0].Person!.Ids!.TMDB.Should().Be(33685U);

            crew!.Art.Should().NotBeNull().And.HaveCount(1);
            crew!.Art![0].Should().NotBeNull();
            crew!.Art[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Set Decoration"]);
            crew!.Art[0].Person.Should().NotBeNull();
            crew!.Art[0].Person!.Name.Should().Be("Rosemary Brandenburg");
            crew!.Art[0].Person!.Ids.Should().NotBeNull();
            crew!.Art[0].Person!.Ids!.Trakt.Should().Be(6020U);
            crew!.Art[0].Person!.Ids!.Slug.Should().Be("rosemary-brandenburg");
            crew!.Art[0].Person!.Ids!.IMDB.Should().Be("nm0104599");
            crew!.Art[0].Person!.Ids!.TMDB.Should().Be(13588U);

            crew!.CostumeAndMakeUp.Should().NotBeNull().And.HaveCount(1);
            crew!.CostumeAndMakeUp![0].Should().NotBeNull();
            crew!.CostumeAndMakeUp[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Costume Design"]);
            crew!.CostumeAndMakeUp[0].Person.Should().NotBeNull();
            crew!.CostumeAndMakeUp[0].Person!.Name.Should().Be("Judianna Makovsky");
            crew!.CostumeAndMakeUp[0].Person!.Ids.Should().NotBeNull();
            crew!.CostumeAndMakeUp[0].Person!.Ids!.Trakt.Should().Be(8106U);
            crew!.CostumeAndMakeUp[0].Person!.Ids!.Slug.Should().Be("judianna-makovsky");
            crew!.CostumeAndMakeUp[0].Person!.Ids!.IMDB.Should().Be("nm0538721");
            crew!.CostumeAndMakeUp[0].Person!.Ids!.TMDB.Should().Be(10970U);

            crew!.Crew.Should().NotBeNull().And.HaveCount(1);
            crew!.Crew![0].Should().NotBeNull();
            crew!.Crew[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Thanks"]);
            crew!.Crew[0].Person.Should().NotBeNull();
            crew!.Crew[0].Person!.Name.Should().Be("Mike Mignola");
            crew!.Crew[0].Person!.Ids.Should().NotBeNull();
            crew!.Crew[0].Person!.Ids!.Trakt.Should().Be(8710U);
            crew!.Crew[0].Person!.Ids!.Slug.Should().Be("mike-mignola");
            crew!.Crew[0].Person!.Ids!.IMDB.Should().Be("nm0586005");
            crew!.Crew[0].Person!.Ids!.TMDB.Should().Be(66266U);

            crew!.Writing.Should().NotBeNull().And.HaveCount(1);
            crew!.Writing![0].Should().NotBeNull();
            crew!.Writing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Characters"]);
            crew!.Writing[0].Person.Should().NotBeNull();
            crew!.Writing[0].Person!.Name.Should().Be("Larry Lieber");
            crew!.Writing[0].Person!.Ids.Should().NotBeNull();
            crew!.Writing[0].Person!.Ids!.Trakt.Should().Be(15622U);
            crew!.Writing[0].Person!.Ids!.Slug.Should().Be("larry-lieber");
            crew!.Writing[0].Person!.Ids!.IMDB.Should().Be("nm1293367");
            crew!.Writing[0].Person!.Ids!.TMDB.Should().Be(18876U);

            crew!.Camera.Should().NotBeNull().And.HaveCount(1);
            crew!.Camera![0].Should().NotBeNull();
            crew!.Camera[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Director of Photography"]);
            crew!.Camera[0].Person.Should().NotBeNull();
            crew!.Camera[0].Person!.Name.Should().Be("Henry Braham");
            crew!.Camera[0].Person!.Ids.Should().NotBeNull();
            crew!.Camera[0].Person!.Ids!.Trakt.Should().Be(19744U);
            crew!.Camera[0].Person!.Ids!.Slug.Should().Be("henry-braham");
            crew!.Camera[0].Person!.Ids!.IMDB.Should().Be("nm0103956");
            crew!.Camera[0].Person!.Ids!.TMDB.Should().Be(23422U);

            crew!.VisualEffects.Should().NotBeNull().And.HaveCount(1);
            crew!.VisualEffects![0].Should().NotBeNull();
            crew!.VisualEffects[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Visual Effects Supervisor"]);
            crew!.VisualEffects[0].Person.Should().NotBeNull();
            crew!.VisualEffects[0].Person!.Name.Should().Be("Theo Bialek");
            crew!.VisualEffects[0].Person!.Ids.Should().NotBeNull();
            crew!.VisualEffects[0].Person!.Ids!.Trakt.Should().Be(22793U);
            crew!.VisualEffects[0].Person!.Ids!.Slug.Should().Be("theo-bialek");
            crew!.VisualEffects[0].Person!.Ids!.IMDB.Should().Be("nm1322273");
            crew!.VisualEffects[0].Person!.Ids!.TMDB.Should().Be(42275U);

            crew!.Directing.Should().NotBeNull().And.HaveCount(1);
            crew!.Directing![0].Should().NotBeNull();
            crew!.Directing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Script Supervisor"]);
            crew!.Directing[0].Person.Should().NotBeNull();
            crew!.Directing[0].Person!.Name.Should().Be("Kera Dacy");
            crew!.Directing[0].Person!.Ids.Should().NotBeNull();
            crew!.Directing[0].Person!.Ids!.Trakt.Should().Be(155049U);
            crew!.Directing[0].Person!.Ids!.Slug.Should().Be("kera-dacy");
            crew!.Directing[0].Person!.Ids!.IMDB.Should().BeNull();
            crew!.Directing[0].Person!.Ids!.TMDB.Should().Be(230505U);

            crew!.Lighting.Should().NotBeNull().And.HaveCount(1);
            crew!.Lighting![0].Should().NotBeNull();
            crew!.Lighting[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Chief Lighting Technician"]);
            crew!.Lighting[0].Person.Should().NotBeNull();
            crew!.Lighting[0].Person!.Name.Should().Be("Dan Cornwall");
            crew!.Lighting[0].Person!.Ids.Should().NotBeNull();
            crew!.Lighting[0].Person!.Ids!.Trakt.Should().Be(486318U);
            crew!.Lighting[0].Person!.Ids!.Slug.Should().Be("dan-cornwall");
            crew!.Lighting[0].Person!.Ids!.IMDB.Should().Be("nm0180473");
            crew!.Lighting[0].Person!.Ids!.TMDB.Should().Be(1403412U);
        }
    }
}
