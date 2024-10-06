namespace TraktNET.Json.People
{
    public sealed class TraktPersonSocialIDsTests
    {
        [Fact]
        public void TestTraktPersonSocialIDsConstructor()
        {
            var personSocialIDs = new TraktPersonSocialIDs();

            personSocialIDs.Twitter.Should().BeNull();
            personSocialIDs.Facebook.Should().BeNull();
            personSocialIDs.Instagram.Should().BeNull();
            personSocialIDs.Wikipedia.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktPersonSocialIDsFromJson()
        {
            TraktPersonSocialIDs? personSocialIDs = await TestUtility.DeserializeJsonAsync<TraktPersonSocialIDs>("People\\personsocialids.json");

            personSocialIDs.Should().NotBeNull();

            personSocialIDs!.Twitter.Should().Be("BryanCranston");
            personSocialIDs!.Facebook.Should().Be("thebryancranston");
            personSocialIDs!.Instagram.Should().Be("bryancranston");
            personSocialIDs!.Wikipedia.Should().Be("test-data");
        }
    }
}
