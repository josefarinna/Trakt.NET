namespace TraktNET.Json.Users
{
    public sealed class TraktUserIDsTests
    {
        [Fact]
        public void TestTraktUserIDsConstructor()
        {
            var userIDs = new TraktUserIDs();

            userIDs.Slug.Should().BeNull();
            userIDs.UUID.Should().BeNull();

            userIDs.HasAnyID.Should().BeFalse();
            userIDs.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktUserIDsFromJson()
        {
            TraktUserIDs? userIDs = await TestUtility.DeserializeJsonAsync<TraktUserIDs>("Users\\userids.json");

            userIDs.Should().NotBeNull();

            userIDs!.Slug.Should().Be("ixxus");
            userIDs!.UUID.Should().Be("jljgsagj092ß9u0294jlgalngoi0t0qntggnafng82");

            userIDs!.HasAnyID.Should().BeTrue();
            userIDs!.BestID.Should().Be("ixxus");
        }
    }
}
