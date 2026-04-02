namespace TraktNET.Json.Responses
{
    public class TraktPostResponseNotFoundUserTests
    {
        [Fact]
        public void TestTraktPostResponseNotFoundUserDefaultConstructor()
        {
            var postResponseNotFoundUser = new TraktPostResponseNotFoundUser();

            postResponseNotFoundUser.IDs.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPostResponseNotFoundUserFromJson()
        {
            TraktPostResponseNotFoundUser? postResponseNotFoundUser = await TestUtility.DeserializeJsonAsync<TraktPostResponseNotFoundUser>("Responses\\traktpostresponsenotfounduser.json");

            postResponseNotFoundUser.ShouldNotBeNull();
            postResponseNotFoundUser.IDs.ShouldNotBeNull();
            postResponseNotFoundUser.IDs.Slug.ShouldBe("user-slug");
        }
    }
}
