namespace TraktNET.Json.Shows
{
    public sealed class TraktMostCollectedShowTests
    {
        [Fact]
        public void TestTraktMostCollectedShowConstructor()
        {
            var mostCollectedShow = new TraktMostCollectedShow();

            mostCollectedShow.WatcherCount.ShouldBeNull();
            mostCollectedShow.PlayCount.ShouldBeNull();
            mostCollectedShow.CollectedCount.ShouldBeNull();
            mostCollectedShow.CollectorCount.ShouldBeNull();
            mostCollectedShow.Title.ShouldBeNull();
            mostCollectedShow.Year.ShouldBeNull();
            mostCollectedShow.IDs.ShouldBeNull();
            mostCollectedShow.Tagline.ShouldBeNull();
            mostCollectedShow.Overview.ShouldBeNull();
            mostCollectedShow.Runtime.ShouldBeNull();
            mostCollectedShow.Certification.ShouldBeNull();
            mostCollectedShow.Country.ShouldBeNull();
            mostCollectedShow.Trailer.ShouldBeNull();
            mostCollectedShow.Homepage.ShouldBeNull();
            mostCollectedShow.Status.ShouldBeNull();
            mostCollectedShow.Rating.ShouldBeNull();
            mostCollectedShow.Votes.ShouldBeNull();
            mostCollectedShow.CommentCount.ShouldBeNull();
            mostCollectedShow.UpdatedAt.ShouldBeNull();
            mostCollectedShow.Language.ShouldBeNull();
            mostCollectedShow.Languages.ShouldBeNull();
            mostCollectedShow.AvailableTranslations.ShouldBeNull();
            mostCollectedShow.Genres.ShouldBeNull();
            mostCollectedShow.Subgenres.ShouldBeNull();
            mostCollectedShow.OriginalTitle.ShouldBeNull();
            mostCollectedShow.Images.ShouldBeNull();
            mostCollectedShow.Colors.ShouldBeNull();
            mostCollectedShow.FirstAired.ShouldBeNull();
            mostCollectedShow.AiredEpisodes.ShouldBeNull();
            mostCollectedShow.Airs.ShouldBeNull();
            mostCollectedShow.Network.ShouldBeNull();

            mostCollectedShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostCollectedShowFromJsonMinimal()
        {
            TraktMostCollectedShow? mostCollectedShow = await TestUtility.DeserializeJsonAsync<TraktMostCollectedShow>("Shows\\mostpwcshow_minimal.json");

            mostCollectedShow.ShouldNotBeNull();
            mostCollectedShow!.WatcherCount.ShouldBe(3910U);
            mostCollectedShow!.PlayCount.ShouldBe(69164U);
            mostCollectedShow!.CollectedCount.ShouldBe(1000U);
            mostCollectedShow!.CollectorCount.ShouldBe(499U);

            mostCollectedShow!.Title.ShouldBe("Game of Thrones");
            mostCollectedShow!.Year.ShouldBe(2011U);

            mostCollectedShow!.IDs!.Trakt.ShouldBe(1390U);
            mostCollectedShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostCollectedShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostCollectedShow!.IDs!.TMDB.ShouldBe(1399U);
            mostCollectedShow!.IDs!.TVDB.ShouldBe(121361U);
            mostCollectedShow!.IDs!.HasAnyID.ShouldBe(true);
            mostCollectedShow!.IDs!.BestID.ShouldBe("game-of-thrones");

            mostCollectedShow!.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktMostCollectedShowFromJson()
        {
            TraktMostCollectedShow? mostCollectedShow = await TestUtility.DeserializeJsonAsync<TraktMostCollectedShow>("Shows\\mostpwcshow.json");
            ValidateMostCollectedShow(mostCollectedShow);
        }

        [Fact]
        public async Task TestTraktMostCollectedShowsFromJsonMinimal()
        {
            IReadOnlyList<TraktMostCollectedShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostCollectedShow>("Shows\\mostpwcshows_minimal.json");

            shows.ShouldNotBeNull();
            shows!.Count.ShouldBe(2);

            var show0 = shows[0];
            show0.WatcherCount.ShouldBe(3910U);
            show0.Title.ShouldBe("Game of Thrones");
            show0.IDs!.Trakt.ShouldBe(1390U);

            var show1 = shows[1];
            show1.WatcherCount.ShouldBe(1249U);
            show1.Title.ShouldBe("Black Mirror");
            show1.Year.ShouldBe(2011U);
            show1.IDs!.Trakt.ShouldBe(41793U);
        }

        [Fact]
        public async Task TestTraktMostCollectedShowsFromJson()
        {
            IReadOnlyList<TraktMostCollectedShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostCollectedShow>("Shows\\mostpwcshows.json");

            shows.ShouldNotBeNull();
            shows!.Count.ShouldBe(2);

            ValidateMostCollectedShow(shows[0]);

            var show1 = shows[1];
            show1.Title.ShouldBe("Black Mirror");
            show1.WatcherCount.ShouldBe(1249U);
            show1.OriginalTitle.ShouldBe("Black Mirror");
            show1.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            show1.AiredEpisodes.ShouldBe(32U);
            show1.Network.ShouldBe("Netflix");
        }

        private static void ValidateMostCollectedShow(TraktMostCollectedShow? mostCollectedShow)
        {
            mostCollectedShow.ShouldNotBeNull();
            mostCollectedShow!.WatcherCount.ShouldBe(3910U);
            mostCollectedShow!.PlayCount.ShouldBe(69164U);
            mostCollectedShow!.CollectedCount.ShouldBe(1000U);
            mostCollectedShow!.CollectorCount.ShouldBe(499U);

            mostCollectedShow!.Title.ShouldBe("Game of Thrones");
            mostCollectedShow!.Year.ShouldBe(2011U);

            mostCollectedShow!.IDs.ShouldNotBeNull();
            mostCollectedShow!.IDs!.Trakt.ShouldBe(1390U);
            mostCollectedShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostCollectedShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostCollectedShow!.IDs!.TMDB.ShouldBe(1399U);
            mostCollectedShow!.IDs!.TVDB.ShouldBe(121361U);

            mostCollectedShow!.Tagline.ShouldBe("Winter is coming.");
            mostCollectedShow!.Overview.ShouldStartWith("Seven noble families fight");
            mostCollectedShow!.Runtime.ShouldBe(55U);
            mostCollectedShow!.Certification.ShouldBe("TV-MA");
            mostCollectedShow!.Country.ShouldBe("us");
            mostCollectedShow!.Trailer.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            mostCollectedShow!.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            mostCollectedShow!.Status.ShouldBe(TraktShowStatus.Ended);
            mostCollectedShow!.Rating.ShouldBe(8.89122f);
            mostCollectedShow!.Votes.ShouldBe(145017U);
            mostCollectedShow!.CommentCount.ShouldBe(449U);
            mostCollectedShow!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-21T15:43:57.000Z"));
            mostCollectedShow!.Language.ShouldBe("en");

            mostCollectedShow!.Languages.ShouldNotBeNull();
            mostCollectedShow!.Languages!.Count.ShouldBe(1);
            mostCollectedShow!.Languages.ShouldBe(["en"], Case.Sensitive);

            mostCollectedShow!.AvailableTranslations.ShouldNotBeNull();
            mostCollectedShow!.AvailableTranslations!.Count.ShouldBe(48);
            mostCollectedShow!.AvailableTranslations!.ShouldContain("es");
            mostCollectedShow!.AvailableTranslations!.ShouldContain("en");

            mostCollectedShow!.Genres.ShouldNotBeNull();
            mostCollectedShow!.Genres!.Count.ShouldBe(4);
            mostCollectedShow!.Genres.ShouldBe(["fantasy", "drama", "action", "adventure"], Case.Sensitive);

            mostCollectedShow!.OriginalTitle.ShouldBe("Game of Thrones");

            mostCollectedShow!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));

            mostCollectedShow!.Airs.ShouldNotBeNull();
            mostCollectedShow!.Airs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            mostCollectedShow!.Airs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            mostCollectedShow!.Airs!.Time.ShouldBe("21:00");
#endif
            mostCollectedShow!.Airs!.Timezone.ShouldBe("America/New_York");

            mostCollectedShow!.Network.ShouldBe("HBO");
        }
    }
}
