namespace TraktNET.Json.Users
{
    public sealed class TraktPermissionsTests
    {
        [Fact]
        public void TestTraktPermissionsDefaultConstructor()
        {
            var permissions = new TraktPermissions();

            permissions.Commenting.ShouldBeNull();
            permissions.Liking.ShouldBeNull();
            permissions.Following.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktPermissionsFromJson()
        {
            TraktPermissions? permissions = await TestUtility.DeserializeJsonAsync<TraktPermissions>("Users\\permissions.json");

            permissions.ShouldNotBeNull();
            permissions.Commenting.ShouldBe(true);
            permissions.Liking.ShouldBe(true);
            permissions.Following.ShouldBe(true);
        }
    }
}
