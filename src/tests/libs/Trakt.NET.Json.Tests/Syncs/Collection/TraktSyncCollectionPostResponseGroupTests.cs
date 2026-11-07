namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionPostResponseGroupTests
    {
        [Fact]
        public void TestTraktSyncCollectionPostResponseGroupDefaultConstructor()
        {
            var responseGroup = new TraktSyncCollectionPostResponseGroup();

            responseGroup.Movies.ShouldBeNull();
            responseGroup.Episodes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollectionPostResponseGroupFromJson()
        {
            TraktSyncCollectionPostResponseGroup? responseGroup = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionPostResponseGroup>("Syncs\\Collection\\synccollectionpostresponsegroup.json");

            responseGroup.ShouldNotBeNull();
            responseGroup.Movies.ShouldBe(1U);
            responseGroup.Episodes.ShouldBe(12U);
        }
    }
}

