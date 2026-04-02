namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionShowTests
    {
        [Fact]
        public void TestTraktSyncCollectionShowConstructor()
        {
            var syncCollectionShow = new TraktSyncCollectionShow();

            syncCollectionShow.Type.ShouldBeNull();
            syncCollectionShow.LastCollectedAt.ShouldBeNull();
            syncCollectionShow.LastUpdatedAt.ShouldBeNull();
            syncCollectionShow.Seasons.ShouldBeNull();
            syncCollectionShow.Title.ShouldBeNull();
            syncCollectionShow.Year.ShouldBeNull();
            syncCollectionShow.IDs.ShouldBeNull();
            syncCollectionShow.Tagline.ShouldBeNull();
            syncCollectionShow.Overview.ShouldBeNull();
            syncCollectionShow.Runtime.ShouldBeNull();
            syncCollectionShow.Certification.ShouldBeNull();
            syncCollectionShow.Country.ShouldBeNull();
            syncCollectionShow.Trailer.ShouldBeNull();
            syncCollectionShow.Homepage.ShouldBeNull();
            syncCollectionShow.Status.ShouldBeNull();
            syncCollectionShow.Rating.ShouldBeNull();
            syncCollectionShow.Votes.ShouldBeNull();
            syncCollectionShow.CommentCount.ShouldBeNull();
            syncCollectionShow.UpdatedAt.ShouldBeNull();
            syncCollectionShow.Language.ShouldBeNull();
            syncCollectionShow.Languages.ShouldBeNull();
            syncCollectionShow.AvailableTranslations.ShouldBeNull();
            syncCollectionShow.Genres.ShouldBeNull();
            syncCollectionShow.Subgenres.ShouldBeNull();
            syncCollectionShow.OriginalTitle.ShouldBeNull();
            syncCollectionShow.Images.ShouldBeNull();
            syncCollectionShow.Colors.ShouldBeNull();
            syncCollectionShow.FirstAired.ShouldBeNull();
            syncCollectionShow.AiredEpisodes.ShouldBeNull();
            syncCollectionShow.Airs.ShouldBeNull();
            syncCollectionShow.Network.ShouldBeNull();

            syncCollectionShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktSyncCollectionShowFromJsonMinimal()
        {
            TraktSyncCollectionShow? syncCollectionShow = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionShow>("Syncs\\Collection\\synccollectionshow_minimal.json");

            syncCollectionShow.ShouldNotBeNull();
            syncCollectionShow.LastCollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-04-02T17:26:44.000Z"));
            syncCollectionShow.LastUpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-04-02T17:26:44.000Z"));
            
            syncCollectionShow.Seasons.ShouldNotBeNull();
            syncCollectionShow.Seasons.Count.ShouldBe(1);
            syncCollectionShow.Seasons[0].Number.ShouldBe(1U);
            syncCollectionShow.Seasons[0].Episodes.ShouldNotBeNull();
            syncCollectionShow.Seasons[0].Episodes!.Count.ShouldBe(2);
            syncCollectionShow.Seasons[0].Episodes![0].ShouldNotBeNull();
            syncCollectionShow.Seasons[0].Episodes![0].Number.ShouldBe(1U);
            syncCollectionShow.Seasons[0].Episodes![0].CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-04-02T17:26:44.000Z"));

            syncCollectionShow!.Title.ShouldBe("Game of Thrones");
            syncCollectionShow!.Year.ShouldBe(2011U);

            syncCollectionShow!.IDs!.Trakt.ShouldBe(1390U);
            syncCollectionShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            syncCollectionShow!.IDs!.IMDB.ShouldBe("tt0944947");
            syncCollectionShow!.IDs!.TMDB.ShouldBe(1399U);
            syncCollectionShow!.IDs!.TVDB.ShouldBe(121361U);
            syncCollectionShow!.IDs!.HasAnyID.ShouldBe(true);
            syncCollectionShow!.IDs!.BestID.ShouldBe("game-of-thrones");

            syncCollectionShow!.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktSyncCollectionShowFromJson()
        {
            TraktSyncCollectionShow? syncCollectionShow = await TestUtility.DeserializeJsonAsync<TraktSyncCollectionShow>("Syncs\\Collection\\synccollectionshow.json");
            ValidatesyncCollectionShow(syncCollectionShow);
        }

        private static void ValidatesyncCollectionShow(TraktSyncCollectionShow? syncCollectionShow)
        {
            syncCollectionShow.ShouldNotBeNull();
            syncCollectionShow.LastCollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-04-02T17:26:44.000Z"));
            syncCollectionShow.LastUpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-04-02T17:26:44.000Z"));
            
            syncCollectionShow.Seasons.ShouldNotBeNull();
            syncCollectionShow.Seasons.Count.ShouldBe(1);
            syncCollectionShow.Seasons[0].Number.ShouldBe(1U);
            syncCollectionShow.Seasons[0].Episodes.ShouldNotBeNull();
            syncCollectionShow.Seasons[0].Episodes!.Count.ShouldBe(2);
            syncCollectionShow.Seasons[0].Episodes![0].ShouldNotBeNull();
            syncCollectionShow.Seasons[0].Episodes![0].Number.ShouldBe(1U);
            syncCollectionShow.Seasons[0].Episodes![0].CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-04-02T17:26:44.000Z"));

            syncCollectionShow!.Title.ShouldBe("Game of Thrones");
            syncCollectionShow!.Year.ShouldBe(2011U);

            syncCollectionShow!.IDs.ShouldNotBeNull();
            syncCollectionShow!.IDs!.Trakt.ShouldBe(1390U);
            syncCollectionShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            syncCollectionShow!.IDs!.IMDB.ShouldBe("tt0944947");
            syncCollectionShow!.IDs!.TMDB.ShouldBe(1399U);
            syncCollectionShow!.IDs!.TVDB.ShouldBe(121361U);

            syncCollectionShow!.Tagline.ShouldBe("Winter is coming.");
            syncCollectionShow!.Overview.ShouldStartWith("Seven noble families fight");
            syncCollectionShow!.Runtime.ShouldBe(55U);
            syncCollectionShow!.Certification.ShouldBe("TV-MA");
            syncCollectionShow!.Country.ShouldBe("us");
            syncCollectionShow!.Trailer.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            syncCollectionShow!.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            syncCollectionShow!.Status.ShouldBe(TraktShowStatus.Ended);
            syncCollectionShow!.Rating.ShouldBe(8.89122f);
            syncCollectionShow!.Votes.ShouldBe(145017U);
            syncCollectionShow!.CommentCount.ShouldBe(449U);
            syncCollectionShow!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-21T15:43:57.000Z"));
            syncCollectionShow!.Language.ShouldBe("en");

            syncCollectionShow!.Languages.ShouldNotBeNull();
            syncCollectionShow!.Languages!.Count.ShouldBe(1);
            syncCollectionShow!.Languages.ShouldBe(["en"], Case.Sensitive);

            syncCollectionShow!.AvailableTranslations.ShouldNotBeNull();
            syncCollectionShow!.AvailableTranslations!.Count.ShouldBe(48);
            syncCollectionShow!.AvailableTranslations!.ShouldContain("es");
            syncCollectionShow!.AvailableTranslations!.ShouldContain("en");

            syncCollectionShow!.Genres.ShouldNotBeNull();
            syncCollectionShow!.Genres!.Count.ShouldBe(4);
            syncCollectionShow!.Genres.ShouldBe(["fantasy", "drama", "action", "adventure"], Case.Sensitive);

            syncCollectionShow!.OriginalTitle.ShouldBe("Game of Thrones");

            syncCollectionShow!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));

            syncCollectionShow!.Airs.ShouldNotBeNull();
            syncCollectionShow!.Airs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            syncCollectionShow!.Airs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            syncCollectionShow!.Airs!.Time.ShouldBe("21:00");
#endif
            syncCollectionShow!.Airs!.Timezone.ShouldBe("America/New_York");

            syncCollectionShow!.Network.ShouldBe("HBO");
        }
    }
}
