namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionPostResponseNotFoundGroupTests
    {
        [Fact]
        public void TestTraktSyncCollectionPostResponseNotFoundGroupDefaultConstructor()
        {
            var notFoundGroup = new TraktSyncCollectionPostResponseNotFoundGroup();

            notFoundGroup.Movies.ShouldBeNull();
            notFoundGroup.Shows.ShouldBeNull();
            notFoundGroup.Seasons.ShouldBeNull();
            notFoundGroup.Episodes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollectionPostResponseNotFoundGroupFromJson()
        {
            TraktSyncCollectionPostResponseNotFoundGroup? notFoundGroup = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionPostResponseNotFoundGroup>("Syncs\\Collection\\synccollectionpostresponsenotfoundgroup.json");

            notFoundGroup.ShouldNotBeNull();

            notFoundGroup.Movies.ShouldNotBeNull();
            notFoundGroup.Movies.Count.ShouldBe(1);

            TraktSyncCollectionPostMovie movie = notFoundGroup.Movies[0];
            movie.ShouldNotBeNull();
            movie.CollectedAt.ShouldBe(TraktCollectedAt.Released);
            movie.Title.ShouldBe("Tron: Legacy");
            movie.Year.ShouldBe(2010U);
            movie.IDs.ShouldNotBeNull();
            movie.IDs!.IMDB.ShouldBe("tt0000111");
            movie.MediaType.ShouldBe(TraktMediaType.Bluray);
            movie.Resolution.ShouldBe(TraktMediaResolution.UHD4k);
            movie.HDR.ShouldBe(TraktMediaHDR.DolbyVision);
            movie.Audio.ShouldBe(TraktMediaAudio.DolbyDigitalPlusAtmos);
            movie.AudioChannels.ShouldBe(TraktMediaAudioChannel.Channels71);
            movie.ThreeDimensional.ShouldBe(true);

            notFoundGroup.Shows.ShouldNotBeNull();
            notFoundGroup.Shows.Count.ShouldBe(1);

            TraktSyncCollectionPostShow show = notFoundGroup.Shows[0];
            show.ShouldNotBeNull();
            show.CollectedAt.ShouldBe(TraktCollectedAt.Unknown);
            show.Title.ShouldBe("Game of Thrones");
            show.Year.ShouldBe(2011U);
            show.IDs.ShouldNotBeNull();
            show.IDs!.IMDB.ShouldBe("tt0000222");
            show.Seasons.ShouldNotBeNull();
            show.Seasons.Count.ShouldBe(1);
            show.Seasons[0].Number.ShouldBe(1);
            show.Seasons[0].CollectedAt.ShouldBe(TraktCollectedAt.Now);
            show.Seasons[0].Episodes.ShouldNotBeNull();
            show.Seasons[0].Episodes!.Count.ShouldBe(1);
            show.Seasons[0].Episodes![0].Number.ShouldBe(1);
            show.Seasons[0].Episodes![0].CollectedAt.ShouldBe(new TraktCollectedAt(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z")));

            notFoundGroup.Seasons.ShouldNotBeNull();
            notFoundGroup.Seasons.Count.ShouldBe(1);
            notFoundGroup.Seasons[0].CollectedAt.ShouldBe(TraktCollectedAt.Released);
            notFoundGroup.Seasons[0].IDs.ShouldNotBeNull();
            notFoundGroup.Seasons[0].IDs!.Trakt.ShouldBe(10U);

            notFoundGroup.Episodes.ShouldNotBeNull();
            notFoundGroup.Episodes.Count.ShouldBe(1);
            notFoundGroup.Episodes[0].CollectedAt.ShouldBe(TraktCollectedAt.Now);
            notFoundGroup.Episodes[0].IDs.ShouldNotBeNull();
            notFoundGroup.Episodes[0].IDs!.Trakt.ShouldBe(20U);
        }
    }
}

