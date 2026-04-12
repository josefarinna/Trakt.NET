namespace TraktNET.Json.Users
{
    public sealed class TraktUserPersonalListItemsPostResponseGroupTests
    {
        [Fact]
        public void TestTraktUserPersonalListItemsPostResponseGroupDefaultConstructor()
        {
            var personalListItemsPostResponseGroup = new TraktUserPersonalListItemsPostResponseGroup();

            personalListItemsPostResponseGroup.Movies.ShouldBeNull();
            personalListItemsPostResponseGroup.Shows.ShouldBeNull();
            personalListItemsPostResponseGroup.Seasons.ShouldBeNull();
            personalListItemsPostResponseGroup.Episodes.ShouldBeNull();
            personalListItemsPostResponseGroup.People.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserPersonalListItemsPostResponseGroupFromJson()
        {
            TraktUserPersonalListItemsPostResponseGroup? personalListItemsPostResponseGroup = await TestUtility.DeserializeJsonAsync<TraktUserPersonalListItemsPostResponseGroup>("Users\\userpersonallistimtespostresponsegroup.json");

            personalListItemsPostResponseGroup.ShouldNotBeNull();
            personalListItemsPostResponseGroup.Movies.ShouldBe(1U);
            personalListItemsPostResponseGroup.Shows.ShouldBe(2U);
            personalListItemsPostResponseGroup.Seasons.ShouldBe(3U);
            personalListItemsPostResponseGroup.Episodes.ShouldBe(4U);
            personalListItemsPostResponseGroup.People.ShouldBe(5U);
        }
    }
}
