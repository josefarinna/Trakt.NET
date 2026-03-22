namespace TraktNET.Json.Networks
{
    public sealed class TraktNetworkTests
    {
        [Fact]
        public void TestTraktNetworkDefaultConstructor()
        {
            var network = new TraktNetwork();

            network.Name.ShouldBeNull();
            network.Country.ShouldBeNull();
            network.IDs.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktNetworkFromJson()
        {
            TraktNetwork? network = await TestUtility.DeserializeJsonAsync<TraktNetwork>("Networks\\network.json");

            network.ShouldNotBeNull();
            network.Name.ShouldBe("CBS");
            network.Country.ShouldBe("us");

            network.IDs.ShouldNotBeNull();
            network.IDs!.Trakt.ShouldBe(22U);
            network.IDs!.TMDB.ShouldBe(16U);
        }
    }
}
