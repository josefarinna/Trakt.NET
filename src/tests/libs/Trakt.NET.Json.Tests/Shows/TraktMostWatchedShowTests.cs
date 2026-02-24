namespace TraktNET.Json.Shows
{
    public sealed class TraktMostWatchedShowTests
    {
        [Fact]
        public void TestTraktMostWatchedShowConstructor()
        {
            var mostWatchedShow = new TraktMostWatchedShow();

            mostWatchedShow.WatcherCount.ShouldBeNull();
            mostWatchedShow.PlayCount.ShouldBeNull();
            mostWatchedShow.CollectedCount.ShouldBeNull();
            mostWatchedShow.Title.ShouldBeNull();
            mostWatchedShow.Year.ShouldBeNull();
            mostWatchedShow.IDs.ShouldBeNull();
            mostWatchedShow.Tagline.ShouldBeNull();
            mostWatchedShow.Overview.ShouldBeNull();
            mostWatchedShow.Runtime.ShouldBeNull();
            mostWatchedShow.Certification.ShouldBeNull();
            mostWatchedShow.Country.ShouldBeNull();
            mostWatchedShow.Trailer.ShouldBeNull();
            mostWatchedShow.Homepage.ShouldBeNull();
            mostWatchedShow.Status.ShouldBeNull();
            mostWatchedShow.Rating.ShouldBeNull();
            mostWatchedShow.Votes.ShouldBeNull();
            mostWatchedShow.CommentCount.ShouldBeNull();
            mostWatchedShow.UpdatedAt.ShouldBeNull();
            mostWatchedShow.Language.ShouldBeNull();
            mostWatchedShow.Languages.ShouldBeNull();
            mostWatchedShow.AvailableTranslations.ShouldBeNull();
            mostWatchedShow.Genres.ShouldBeNull();
            mostWatchedShow.Subgenres.ShouldBeNull();
            mostWatchedShow.OriginalTitle.ShouldBeNull();
            mostWatchedShow.Images.ShouldBeNull();
            mostWatchedShow.Colors.ShouldBeNull();
            mostWatchedShow.FirstAired.ShouldBeNull();
            mostWatchedShow.AiredEpisodes.ShouldBeNull();
            mostWatchedShow.Airs.ShouldBeNull();
            mostWatchedShow.Network.ShouldBeNull();

            mostWatchedShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostWatchedShowFromJsonMinimal()
        {
            TraktMostWatchedShow? mostWatchedShow = await TestUtility.DeserializeJsonAsync<TraktMostWatchedShow>("Shows\\mostpwcshow_minimal.json");

            mostWatchedShow.ShouldNotBeNull();
            mostWatchedShow!.WatcherCount.ShouldBe(3910U);
            mostWatchedShow!.PlayCount.ShouldBe(69164U);
            mostWatchedShow!.CollectedCount.ShouldBe(1000U);

            mostWatchedShow!.Title.ShouldBe("Game of Thrones");
            mostWatchedShow!.Year.ShouldBe(2011U);

            mostWatchedShow!.IDs!.Trakt.ShouldBe(1390U);
            mostWatchedShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostWatchedShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostWatchedShow!.IDs!.TMDB.ShouldBe(1399U);
            mostWatchedShow!.IDs!.TVDB.ShouldBe(121361U);
            mostWatchedShow!.IDs!.HasAnyID.ShouldBe(true);
            mostWatchedShow!.IDs!.BestID.ShouldBe("game-of-thrones");

            mostWatchedShow!.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktMostWatchedShowFromJson()
        {
            TraktMostWatchedShow? mostWatchedShow = await TestUtility.DeserializeJsonAsync<TraktMostWatchedShow>("Shows\\mostpwcshow.json");
            ValidateMostWatchedShow(mostWatchedShow);
        }

        [Fact]
        public async Task TestTraktMostWatchedShowsFromJsonMinimal()
        {
            IReadOnlyList<TraktMostWatchedShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostWatchedShow>("Shows\\mostpwcshows_minimal.json");

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
        public async Task TestTraktMostWatchedShowsFromJson()
        {
            IReadOnlyList<TraktMostWatchedShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostWatchedShow>("Shows\\mostpwcshows.json");

            shows.ShouldNotBeNull();
            shows!.Count.ShouldBe(2);

            ValidateMostWatchedShow(shows[0]);

            var show1 = shows[1];
            show1.Title.ShouldBe("Black Mirror");
            show1.WatcherCount.ShouldBe(1249U);
            show1.OriginalTitle.ShouldBe("Black Mirror");
            show1.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            show1.AiredEpisodes.ShouldBe(32U);
            show1.Network.ShouldBe("Netflix");
        }

        private static void ValidateMostWatchedShow(TraktMostWatchedShow? mostWatchedShow)
        {
            mostWatchedShow.ShouldNotBeNull();
            mostWatchedShow!.WatcherCount.ShouldBe(3910U);
            mostWatchedShow!.PlayCount.ShouldBe(69164U);

            mostWatchedShow!.Title.ShouldBe("Game of Thrones");
            mostWatchedShow!.Year.ShouldBe(2011U);

            mostWatchedShow!.IDs.ShouldNotBeNull();
            mostWatchedShow!.IDs!.Trakt.ShouldBe(1390U);
            mostWatchedShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostWatchedShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostWatchedShow!.IDs!.TMDB.ShouldBe(1399U);
            mostWatchedShow!.IDs!.TVDB.ShouldBe(121361U);

            mostWatchedShow!.Tagline.ShouldBe("Winter is coming.");
            mostWatchedShow!.Overview.ShouldStartWith("Seven noble families fight");
            mostWatchedShow!.Runtime.ShouldBe(55U);
            mostWatchedShow!.Certification.ShouldBe("TV-MA");
            mostWatchedShow!.Country.ShouldBe("us");
            mostWatchedShow!.Trailer.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            mostWatchedShow!.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            mostWatchedShow!.Status.ShouldBe(TraktShowStatus.Ended);
            mostWatchedShow!.Rating.ShouldBe(8.89122f);
            mostWatchedShow!.Votes.ShouldBe(145017U);
            mostWatchedShow!.CommentCount.ShouldBe(449U);
            mostWatchedShow!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-21T15:43:57.000Z"));
            mostWatchedShow!.Language.ShouldBe("en");

            mostWatchedShow!.Languages.ShouldNotBeNull();
            mostWatchedShow!.Languages!.Count.ShouldBe(1);
            mostWatchedShow!.Languages.ShouldBe(["en"], Case.Sensitive);

            mostWatchedShow!.AvailableTranslations.ShouldNotBeNull();
            mostWatchedShow!.AvailableTranslations!.Count.ShouldBe(48);
            mostWatchedShow!.AvailableTranslations!.ShouldContain("es");
            mostWatchedShow!.AvailableTranslations!.ShouldContain("en");

            mostWatchedShow!.Genres.ShouldNotBeNull();
            mostWatchedShow!.Genres!.Count.ShouldBe(4);
            mostWatchedShow!.Genres.ShouldBe(["fantasy", "drama", "action", "adventure"], Case.Sensitive);

            mostWatchedShow!.OriginalTitle.ShouldBe("Game of Thrones");

            mostWatchedShow!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));

            mostWatchedShow!.Airs.ShouldNotBeNull();
            mostWatchedShow!.Airs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            mostWatchedShow!.Airs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            mostWatchedShow!.Airs!.Time.ShouldBe("21:00");
#endif
            mostWatchedShow!.Airs!.Timezone.ShouldBe("America/New_York");

            mostWatchedShow!.Network.ShouldBe("HBO");
        }
    }
}
