namespace TraktNET.Json.Networks
{
    public sealed partial class TraktNetworkIDsTests
    {
        [Fact]
        public void TestTraktNetworkIdsDefaultConstructor()
        {
            var networkIds = new TraktNetworkIDs();

            networkIds.Trakt.ShouldBeNull();
            networkIds.TMDB.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktNetworkIdsFromJson()
        {
            TraktNetworkIDs? networkIds = await TestUtility.DeserializeJsonAsync<TraktNetworkIDs>("Networks\\networkids.json");

            networkIds.ShouldNotBeNull();
            networkIds.Trakt.ShouldBe(869U);
            networkIds.TMDB.ShouldBe(1446U);
        }
    }
}
