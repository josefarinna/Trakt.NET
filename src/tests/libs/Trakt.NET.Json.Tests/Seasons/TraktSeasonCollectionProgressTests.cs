namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonCollectionProgressTests
    {
        [Fact]
        public void TestTraktSeasonCollectionProgressConstructor()
        {
            var collectionProgress = new TraktSeasonCollectionProgress();

            collectionProgress.Number.ShouldBeNull();
            collectionProgress.Aired.ShouldBeNull();
            collectionProgress.Title.ShouldBeNull();
            collectionProgress.Completed.ShouldBeNull();
            collectionProgress.Episodes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSeasonCollectionProgressFromJson()
        {
            TraktSeasonCollectionProgress? collectionProgress = await TestUtility.DeserializeJsonAsync<TraktSeasonCollectionProgress>("Seasons\\seasoncollectionprogress.json");

            collectionProgress.ShouldNotBeNull();

            collectionProgress.Number.ShouldBe(1U);
            collectionProgress.Title.ShouldBeNull();
            collectionProgress.Aired.ShouldBe(10U);
            collectionProgress.Completed.ShouldBe(0U);

            collectionProgress.Episodes.ShouldNotBeNull();
            collectionProgress.Episodes.Count.ShouldBe(10);

            TraktEpisodeCollectionProgress episode1 = collectionProgress.Episodes[0];
            episode1.ShouldNotBeNull();
            episode1.Number.ShouldBe(1U);
            episode1.Completed.ShouldBe(true);
            episode1.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2012-10-09T14:32:00.000Z"));

            TraktEpisodeCollectionProgress episode2 = collectionProgress.Episodes[1];
            episode2.ShouldNotBeNull();
            episode2.Number.ShouldBe(2U);
            episode2.Completed.ShouldBe(false);
            episode2.CollectedAt.ShouldBeNull();
        }
    }
}
