namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionMediaTests
    {
        [Fact]
        public void TestTraktSyncCollectionMediaDefaultConstructor()
        {
            var syncCollectionMedia = new TraktSyncCollectionMedia();

            syncCollectionMedia.Type.ShouldBeNull();
            syncCollectionMedia.Movie.ShouldBeNull();
            syncCollectionMedia.Show.ShouldBeNull();
            syncCollectionMedia.Episode.ShouldBeNull();
            syncCollectionMedia.Seasons.ShouldBeNull();
            syncCollectionMedia.CollectedAt.ShouldBeNull();
            syncCollectionMedia.UpdatedAt.ShouldBeNull();
            syncCollectionMedia.LastCollectedAt.ShouldBeNull();
            syncCollectionMedia.LastUpdatedAt.ShouldBeNull();
            syncCollectionMedia.AvailableOn.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollectionMediaMovieFromJson()
        {
            TraktSyncCollectionMedia? syncCollectionMedia =
                await TestUtility.DeserializeJsonAsync<TraktSyncCollectionMedia>("Syncs\\Collection\\synccollectionmedia_movie.json");

            syncCollectionMedia.ShouldNotBeNull();
            syncCollectionMedia.Type.ShouldBe(TraktSyncItemType.Movie);
            syncCollectionMedia.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            syncCollectionMedia.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            syncCollectionMedia.Movie.ShouldNotBeNull();
            syncCollectionMedia.Movie.Title.ShouldBe("The Dark Knight");
            syncCollectionMedia.Movie.Year.ShouldBe(2008U);
            syncCollectionMedia.Movie.IDs.ShouldNotBeNull();
            syncCollectionMedia.Movie.IDs.Trakt.ShouldBe(120U);
            syncCollectionMedia.Movie.IDs.Slug.ShouldBe("the-dark-knight-2008");
            syncCollectionMedia.Movie.IDs.IMDB.ShouldBe("tt0468569");
            syncCollectionMedia.Movie.IDs.TMDB.ShouldBe(155U);

            syncCollectionMedia.AvailableOn.ShouldNotBeNull();
            syncCollectionMedia.AvailableOn.Count.ShouldBe(2);
            syncCollectionMedia.AvailableOn[0].Name.ShouldBe("netflix");
            syncCollectionMedia.AvailableOn[1].Name.ShouldBe("max");

            syncCollectionMedia.Show.ShouldBeNull();
            syncCollectionMedia.Episode.ShouldBeNull();
            syncCollectionMedia.Seasons.ShouldBeNull();
            syncCollectionMedia.LastCollectedAt.ShouldBeNull();
            syncCollectionMedia.LastUpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollectionMediaShowFromJson()
        {
            TraktSyncCollectionMedia? syncCollectionMedia =
                await TestUtility.DeserializeJsonAsync<TraktSyncCollectionMedia>("Syncs\\Collection\\synccollectionmedia_show.json");

            syncCollectionMedia.ShouldNotBeNull();
            syncCollectionMedia.Type.ShouldBe(TraktSyncItemType.Show);
            syncCollectionMedia.LastCollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-04-02T17:26:44.000Z"));
            syncCollectionMedia.LastUpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-04-02T17:26:44.000Z"));

            syncCollectionMedia.Show.ShouldNotBeNull();
            syncCollectionMedia.Show.Title.ShouldBe("Game of Thrones");
            syncCollectionMedia.Show.Year.ShouldBe(2011U);
            syncCollectionMedia.Show.IDs.ShouldNotBeNull();
            syncCollectionMedia.Show.IDs.Trakt.ShouldBe(1390U);
            syncCollectionMedia.Show.IDs.Slug.ShouldBe("game-of-thrones");
            syncCollectionMedia.Show.IDs.TVDB.ShouldBe(121361U);
            syncCollectionMedia.Show.IDs.IMDB.ShouldBe("tt0944947");
            syncCollectionMedia.Show.IDs.TMDB.ShouldBe(1399U);

            syncCollectionMedia.Seasons.ShouldNotBeNull();
            syncCollectionMedia.Seasons.Count.ShouldBe(1);
            syncCollectionMedia.Seasons[0].Number.ShouldBe(1U);
            syncCollectionMedia.Seasons[0].Episodes.ShouldNotBeNull();
            syncCollectionMedia.Seasons[0].Episodes!.Count.ShouldBe(2);
            syncCollectionMedia.Seasons[0].Episodes![0].Number.ShouldBe(1U);
            syncCollectionMedia.Seasons[0].Episodes![0].CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            syncCollectionMedia.Seasons[0].Episodes![1].Number.ShouldBe(2U);
            syncCollectionMedia.Seasons[0].Episodes![1].CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            syncCollectionMedia.Movie.ShouldBeNull();
            syncCollectionMedia.Episode.ShouldBeNull();
            syncCollectionMedia.CollectedAt.ShouldBeNull();
            syncCollectionMedia.UpdatedAt.ShouldBeNull();
            syncCollectionMedia.AvailableOn.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollectionMediaEpisodeFromJson()
        {
            TraktSyncCollectionMedia? syncCollectionMedia =
                await TestUtility.DeserializeJsonAsync<TraktSyncCollectionMedia>("Syncs\\Collection\\synccollectionmedia_episode.json");

            syncCollectionMedia.ShouldNotBeNull();
            syncCollectionMedia.Type.ShouldBe(TraktSyncItemType.Episode);
            syncCollectionMedia.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            syncCollectionMedia.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            syncCollectionMedia.Episode.ShouldNotBeNull();
            syncCollectionMedia.Episode.Season.ShouldBe(1U);
            syncCollectionMedia.Episode.Number.ShouldBe(1U);
            syncCollectionMedia.Episode.Title.ShouldBe("Winter Is Coming");
            syncCollectionMedia.Episode.IDs.ShouldNotBeNull();
            syncCollectionMedia.Episode.IDs.Trakt.ShouldBe(73640U);
            syncCollectionMedia.Episode.IDs.TVDB.ShouldBe(3254641U);
            syncCollectionMedia.Episode.IDs.IMDB.ShouldBe("tt1480055");
            syncCollectionMedia.Episode.IDs.TMDB.ShouldBe(63056U);

            syncCollectionMedia.Show.ShouldNotBeNull();
            syncCollectionMedia.Show.Title.ShouldBe("Game of Thrones");
            syncCollectionMedia.Show.Year.ShouldBe(2011U);
            syncCollectionMedia.Show.IDs.ShouldNotBeNull();
            syncCollectionMedia.Show.IDs.Trakt.ShouldBe(1390U);
            syncCollectionMedia.Show.IDs.Slug.ShouldBe("game-of-thrones");
            syncCollectionMedia.Show.IDs.TVDB.ShouldBe(121361U);
            syncCollectionMedia.Show.IDs.IMDB.ShouldBe("tt0944947");
            syncCollectionMedia.Show.IDs.TMDB.ShouldBe(1399U);

            syncCollectionMedia.AvailableOn.ShouldNotBeNull();
            syncCollectionMedia.AvailableOn.Count.ShouldBe(1);
            syncCollectionMedia.AvailableOn[0].Name.ShouldBe("max");

            syncCollectionMedia.Movie.ShouldBeNull();
            syncCollectionMedia.Seasons.ShouldBeNull();
            syncCollectionMedia.LastCollectedAt.ShouldBeNull();
            syncCollectionMedia.LastUpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollectionMediaListFromJson()
        {
            IReadOnlyList<TraktSyncCollectionMedia>? syncCollectionMediaList =
                await TestUtility.DeserializeJsonListAsync<TraktSyncCollectionMedia>("Syncs\\Collection\\synccollectionmedia.json");

            syncCollectionMediaList.ShouldNotBeNull();
            syncCollectionMediaList.Count.ShouldBe(3);

            syncCollectionMediaList[0].Type.ShouldBe(TraktSyncItemType.Movie);
            syncCollectionMediaList[0].Movie.ShouldNotBeNull();
            syncCollectionMediaList[0].Movie!.Title.ShouldBe("The Dark Knight");

            syncCollectionMediaList[1].Type.ShouldBe(TraktSyncItemType.Show);
            syncCollectionMediaList[1].Show.ShouldNotBeNull();
            syncCollectionMediaList[1].Show!.Title.ShouldBe("Game of Thrones");

            syncCollectionMediaList[2].Type.ShouldBe(TraktSyncItemType.Episode);
            syncCollectionMediaList[2].Episode.ShouldNotBeNull();
            syncCollectionMediaList[2].Episode!.Title.ShouldBe("Winter Is Coming");
            syncCollectionMediaList[2].Show.ShouldNotBeNull();
            syncCollectionMediaList[2].Show!.Title.ShouldBe("Game of Thrones");
        }
    }
}
