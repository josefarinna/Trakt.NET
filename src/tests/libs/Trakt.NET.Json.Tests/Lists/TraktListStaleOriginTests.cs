namespace TraktNET.Json.Lists
{
    public sealed class TraktListStaleOriginTests
    {
        [Fact]
        public void TestTraktListStaleOriginConstructor()
        {
            var staleOrigin = new TraktListStaleOrigin();

            staleOrigin.Name.ShouldBeNull();
            staleOrigin.Url.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktListStaleOriginFromJson()
        {
            TraktListStaleOrigin? staleOrigin = await TestUtility.DeserializeJsonAsync<TraktListStaleOrigin>("Lists\\list_stale_origin.json");

            staleOrigin.ShouldNotBeNull();
            staleOrigin.Name.ShouldBe("mdblist");
            staleOrigin.Url.ShouldBe("https://mdblist.com");
        }
    }
}
