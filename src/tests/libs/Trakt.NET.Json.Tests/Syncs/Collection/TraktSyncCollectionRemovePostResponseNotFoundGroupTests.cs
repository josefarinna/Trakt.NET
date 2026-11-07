namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionRemovePostResponseNotFoundGroupTests
    {
        [Fact]
        public void TestTraktSyncCollectionRemovePostResponseNotFoundGroupDefaultConstructor()
        {
            var notFoundGroup = new TraktSyncCollectionRemovePostResponseNotFoundGroup();

            notFoundGroup.Movies.ShouldBeNull();
            notFoundGroup.Shows.ShouldBeNull();
            notFoundGroup.Seasons.ShouldBeNull();
            notFoundGroup.Episodes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollectionRemovePostResponseNotFoundGroupFromJson()
        {
            TraktSyncCollectionRemovePostResponseNotFoundGroup? notFoundGroup = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionRemovePostResponseNotFoundGroup>("Syncs\\Collection\\synccollectionremovepostresponsenotfoundgroup.json");

            notFoundGroup.ShouldNotBeNull();

            notFoundGroup.Movies.ShouldNotBeNull();
            notFoundGroup.Movies.Count.ShouldBe(1);
            notFoundGroup.Movies[0].IDs.ShouldNotBeNull();
            notFoundGroup.Movies[0].IDs!.IMDB.ShouldBe("tt0000111");

            notFoundGroup.Shows.ShouldNotBeNull();
            notFoundGroup.Shows.Count.ShouldBe(1);
            notFoundGroup.Shows[0].IDs.ShouldNotBeNull();
            notFoundGroup.Shows[0].IDs!.IMDB.ShouldBe("tt0000222");

            notFoundGroup.Seasons.ShouldNotBeNull();
            notFoundGroup.Seasons.Count.ShouldBe(1);
            notFoundGroup.Seasons[0].IDs.ShouldNotBeNull();
            notFoundGroup.Seasons[0].IDs!.Trakt.ShouldBe(10U);

            notFoundGroup.Episodes.ShouldNotBeNull();
            notFoundGroup.Episodes.Count.ShouldBe(1);
            notFoundGroup.Episodes[0].IDs.ShouldNotBeNull();
            notFoundGroup.Episodes[0].IDs!.Trakt.ShouldBe(20U);
        }
    }
}

