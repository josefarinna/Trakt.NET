namespace TraktNET.Json.General
{
    public sealed class TraktCrewMemberTests
    {
        [Fact]
        public void TestTraktCrewMemberConstructor()
        {
            var crewMember = new TraktCrewMember();

            crewMember.Jobs.Should().BeNull();
            crewMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktCrewMemberFromJson()
        {
            TraktCrewMember? crewMember = await TestUtility.DeserializeJsonAsync<TraktCrewMember>("General\\crewmember.json");

            crewMember.Should().NotBeNull();

            crewMember!.Jobs.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["Original Music Composer"]);

            crewMember!.Person.Should().NotBeNull();
            crewMember!.Person!.Name.Should().Be("John Murphy");
            crewMember!.Person!.IDs.Should().NotBeNull();
            crewMember!.Person!.IDs!.Trakt.Should().Be(1005U);
            crewMember!.Person!.IDs!.Slug.Should().Be("john-murphy");
            crewMember!.Person!.IDs!.IMDB.Should().Be("nm0614373");
            crewMember!.Person!.IDs!.TMDB.Should().Be(960U);
        }
    }
}
