namespace TraktNET.Json.General
{
    public sealed class TraktCastMemberTests
    {
        [Fact]
        public void TestTraktCastMemberConstructor()
        {
            var castMember = new TraktCastMember();

            castMember.Characters.Should().BeNull();
            castMember.Person.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktCastMemberFromJson()
        {
            TraktCastMember? castMember = await TestUtility.DeserializeJsonAsync<TraktCastMember>("General\\castmember.json");

            castMember.Should().NotBeNull();

            castMember!.Characters.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo(["Peter Quill", "Star-Lord"]);
            castMember!.Person.Should().NotBeNull();
            castMember!.Person!.Name.Should().Be("Chris Pratt");
            castMember!.Person!.Ids.Should().NotBeNull();
            castMember!.Person!.Ids!.Trakt.Should().Be(422885U);
            castMember!.Person!.Ids!.Slug.Should().Be("chris-pratt");
            castMember!.Person!.Ids!.IMDB.Should().Be("nm0695435");
            castMember!.Person!.Ids!.TMDB.Should().Be(73457U);
        }
    }
}
