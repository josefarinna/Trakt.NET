namespace TraktNET.Json.Shows
{
    public sealed class TraktShowCollectionProgressTests
    {
        [Fact]
        public void TestTraktShowCollectionProgressConstructor()
        {
            var collectionProgress = new TraktShowCollectionProgress();

            collectionProgress.Aired.ShouldBeNull();
            collectionProgress.Completed.ShouldBeNull();
            collectionProgress.LastCollectedAt.ShouldBeNull();
            collectionProgress.Seasons.ShouldBeNull();
            collectionProgress.HiddenSeasons.ShouldBeNull();
            collectionProgress.NextEpisode.ShouldBeNull();
            collectionProgress.LastEpisode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktShowCollectionProgressFromJson()
        {
            TraktShowCollectionProgress? collectionProgress = await TestUtility.DeserializeJsonAsync<TraktShowCollectionProgress>("Shows\\showcollectionprogress.json");

            collectionProgress.ShouldNotBeNull();

            collectionProgress!.Aired.ShouldBe(73U);
            collectionProgress.Completed.ShouldBe(0U);
            collectionProgress.LastCollectedAt.ShouldBeNull();

            collectionProgress.NextEpisode.ShouldNotBeNull();
            collectionProgress.NextEpisode!.Season.ShouldBe(1U);
            collectionProgress.NextEpisode!.Number.ShouldBe(1U);
            collectionProgress.NextEpisode!.Title.ShouldBe("Winter Is Coming");
            collectionProgress.NextEpisode!.IDs.ShouldNotBeNull();
            collectionProgress.NextEpisode!.IDs!.Trakt.ShouldBe(73640U);

            collectionProgress.Seasons.ShouldNotBeNull();
            collectionProgress.Seasons!.Count.ShouldBe(8);

            TraktSeasonCollectionProgress season1 = collectionProgress.Seasons[0];
            season1.ShouldNotBeNull();
            season1.Number.ShouldBe(1U);
            season1.Aired.ShouldBe(10U);
            season1.Completed.ShouldBe(0U);
            season1.Episodes.ShouldNotBeNull();
            season1.Episodes!.Count.ShouldBe(10);

            TraktEpisodeCollectionProgress episode1 = season1.Episodes[0];
            episode1.ShouldNotBeNull();
            episode1.Number.ShouldBe(1U);
            episode1.Completed.ShouldBe(false);
            episode1.LastWatchedAt.ShouldBeNull();

            TraktSeasonCollectionProgress season8 = collectionProgress.Seasons[7];
            season8.ShouldNotBeNull();
            season8.Number.ShouldBe(8U);
            season8.Aired.ShouldBe(6U);
            season8.Completed.ShouldBe(0U);
            season8.Episodes.ShouldNotBeNull();
            season8.Episodes!.Count.ShouldBe(6);
        }
    }
}
