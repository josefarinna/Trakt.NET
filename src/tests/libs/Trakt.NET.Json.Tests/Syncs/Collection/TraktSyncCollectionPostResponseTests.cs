namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionPostResponseTests
    {
        [Fact]
        public void TestTraktSyncCollectionPostResponseDefaultConstructor()
        {
            var response = new TraktSyncCollectionPostResponse();

            response.Added.ShouldBeNull();
            response.Updated.ShouldBeNull();
            response.Existing.ShouldBeNull();
            response.NotFound.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollectionPostResponseFromJson()
        {
            TraktSyncCollectionPostResponse? response = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionPostResponse>("Syncs\\Collection\\synccollectionpostresponse.json");

            response.ShouldNotBeNull();

            response.Added.ShouldNotBeNull();
            response.Added.Movies.ShouldBe(1U);
            response.Added.Episodes.ShouldBe(12U);

            response.Updated.ShouldNotBeNull();
            response.Updated.Movies.ShouldBe(3U);
            response.Updated.Episodes.ShouldBe(1U);

            response.Existing.ShouldNotBeNull();
            response.Existing.Movies.ShouldBe(2U);
            response.Existing.Episodes.ShouldBe(0U);

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

