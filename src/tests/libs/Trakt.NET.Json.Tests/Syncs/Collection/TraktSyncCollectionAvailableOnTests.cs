namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionAvailableOnTests
    {
        [Fact]
        public void TestTraktSyncCollectionAvailableOnDefaultConstructor()
        {
            var availableOn = new TraktSyncCollectionAvailableOn();
            availableOn.Name.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollectionAvailableOnFromJson()
        {
            TraktSyncCollectionAvailableOn? availableOn = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionAvailableOn>("Syncs\\Collection\\synccollectionavailableon.json");

            availableOn.ShouldNotBeNull();
            availableOn.Name.ShouldBe("netflix");
        }
    }
}
