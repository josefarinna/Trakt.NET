namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionRemovePostResponseTests
    {
        [Fact]
        public void TestTraktSyncCollectionRemovePostResponseDefaultConstructor()
        {
            var response = new TraktSyncCollectionRemovePostResponse();

            response.Deleted.ShouldBeNull();
            response.NotFound.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollectionRemovePostResponseFromJson()
        {
            TraktSyncCollectionRemovePostResponse? response = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionRemovePostResponse>("Syncs\\Collection\\synccollectionremove.json");

            response.ShouldNotBeNull();

            response.Deleted.ShouldNotBeNull();
            response.Deleted.Movies.ShouldBe(1U);
            response.Deleted.Episodes.ShouldBe(12U);

            response.NotFound.ShouldNotBeNull();
            response.NotFound.Movies.ShouldNotBeNull();
            response.NotFound.Movies.Count.ShouldBe(1);
            response.NotFound.Movies[0].IDs.ShouldNotBeNull();
            response.NotFound.Movies[0].IDs!.IMDB.ShouldBe("tt0000111");

            response.NotFound.Shows.ShouldNotBeNull();
            response.NotFound.Shows.Count.ShouldBe(0);
            response.NotFound.Seasons.ShouldNotBeNull();
            response.NotFound.Seasons.Count.ShouldBe(0);
            response.NotFound.Episodes.ShouldNotBeNull();
            response.NotFound.Episodes.Count.ShouldBe(0);
        }
    }
}

