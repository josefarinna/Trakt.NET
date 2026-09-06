namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionEpisodeTests
    {
        [Fact]
        public void TestTraktSyncCollectionEpisodeConstructor()
        {
            var syncCollectionEpisode = new TraktSyncCollectionEpisode();

            syncCollectionEpisode.Type.ShouldBeNull();
            syncCollectionEpisode.Episode.ShouldBeNull();
            syncCollectionEpisode.Show.ShouldBeNull();
            syncCollectionEpisode.CollectedAt.ShouldBeNull();
            syncCollectionEpisode.UpdatedAt.ShouldBeNull();
            syncCollectionEpisode.AvailableOn.ShouldBeNull();
            syncCollectionEpisode.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktSyncCollectionEpisodeFromJson()
        {
            TraktSyncCollectionEpisode? syncCollectionEpisode = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionEpisode>("Syncs\\Collection\\synccollectionepisode.json");

            syncCollectionEpisode.ShouldNotBeNull();
            syncCollectionEpisode.Type.ShouldBe(TraktSyncItemType.Episode);
            syncCollectionEpisode.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            syncCollectionEpisode.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            syncCollectionEpisode.Episode.ShouldNotBeNull();
            syncCollectionEpisode.Episode.Season.ShouldBe(1U);
            syncCollectionEpisode.Episode.Number.ShouldBe(1U);
            syncCollectionEpisode.Episode.Title.ShouldBe("Winter Is Coming");

            syncCollectionEpisode.Episode.IDs.ShouldNotBeNull();
            syncCollectionEpisode.Episode.IDs.Trakt.ShouldBe(73640U);
            syncCollectionEpisode.Episode.IDs.TVDB.ShouldBe(3254641U);
            syncCollectionEpisode.Episode.IDs.IMDB.ShouldBe("tt1480055");
            syncCollectionEpisode.Episode.IDs.TMDB.ShouldBe(63056U);

            syncCollectionEpisode.Show.ShouldNotBeNull();
            syncCollectionEpisode.Show.Title.ShouldBe("Game of Thrones");
            syncCollectionEpisode.Show.Year.ShouldBe(2011U);

            syncCollectionEpisode.Show.IDs.ShouldNotBeNull();
            syncCollectionEpisode.Show.IDs.Trakt.ShouldBe(1390U);
            syncCollectionEpisode.Show.IDs.Slug.ShouldBe("game-of-thrones");
            syncCollectionEpisode.Show.IDs.TVDB.ShouldBe(121361U);
            syncCollectionEpisode.Show.IDs.IMDB.ShouldBe("tt0944947");
            syncCollectionEpisode.Show.IDs.TMDB.ShouldBe(1399U);

            syncCollectionEpisode.AvailableOn.ShouldNotBeNull();
            syncCollectionEpisode.AvailableOn.Count.ShouldBe(1);
            syncCollectionEpisode.AvailableOn[0].Name.ShouldBe("max");

            syncCollectionEpisode.ToString().ShouldBe(syncCollectionEpisode.Episode.ToString());
        }

        [Fact]
        public async Task TestTraktSyncCollectionEpisodeArrayFromJson()
        {
            IReadOnlyList<TraktSyncCollectionEpisode>? syncCollectionEpisodes = await TestUtility.DeserializeJsonListAsync<TraktSyncCollectionEpisode>("Syncs\\Collection\\synccollectionepisodes.json");

            syncCollectionEpisodes.ShouldNotBeNull();
            syncCollectionEpisodes.Count.ShouldBe(2);

            TraktSyncCollectionEpisode episode1 = syncCollectionEpisodes[0];
            episode1.Type.ShouldBe(TraktSyncItemType.Episode);
            episode1.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            episode1.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            episode1.Episode.ShouldNotBeNull();
            episode1.Episode.Season.ShouldBe(1U);
            episode1.Episode.Number.ShouldBe(1U);
            episode1.Episode.Title.ShouldBe("Winter Is Coming");
            episode1.Show.ShouldNotBeNull();
            episode1.Show.Title.ShouldBe("Game of Thrones");
            episode1.AvailableOn.ShouldNotBeNull();
            episode1.AvailableOn.Count.ShouldBe(1);
            episode1.AvailableOn[0].Name.ShouldBe("max");

            TraktSyncCollectionEpisode episode2 = syncCollectionEpisodes[1];
            episode2.Type.ShouldBe(TraktSyncItemType.Episode);
            episode2.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-02T10:11:12.000Z"));
            episode2.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-02T10:11:12.000Z"));
            episode2.Episode.ShouldNotBeNull();
            episode2.Episode.Season.ShouldBe(1U);
            episode2.Episode.Number.ShouldBe(2U);
            episode2.Episode.Title.ShouldBe("The Kingsroad");
            episode2.Show.ShouldNotBeNull();
            episode2.Show.Title.ShouldBe("Game of Thrones");
            episode2.AvailableOn.ShouldNotBeNull();
            episode2.AvailableOn.Count.ShouldBe(1);
            episode2.AvailableOn[0].Name.ShouldBe("max");
        }
    }
}
