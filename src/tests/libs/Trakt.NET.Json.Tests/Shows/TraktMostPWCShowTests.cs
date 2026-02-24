namespace TraktNET.Json.Shows
{
    public sealed class TraktMostPWCShowTests
    {
        [Fact]
        public void TestTraktMostPWCShowConstructor()
        {
            var mostPWCShow = new TraktMostPWCShow();

            mostPWCShow.WatcherCount.ShouldBeNull();
            mostPWCShow.PlayCount.ShouldBeNull();
            mostPWCShow.CollectedCount.ShouldBeNull();
            mostPWCShow.Title.ShouldBeNull();
            mostPWCShow.Year.ShouldBeNull();
            mostPWCShow.IDs.ShouldBeNull();
            mostPWCShow.Tagline.ShouldBeNull();
            mostPWCShow.Overview.ShouldBeNull();
            mostPWCShow.Runtime.ShouldBeNull();
            mostPWCShow.Certification.ShouldBeNull();
            mostPWCShow.Country.ShouldBeNull();
            mostPWCShow.Trailer.ShouldBeNull();
            mostPWCShow.Homepage.ShouldBeNull();
            mostPWCShow.Status.ShouldBeNull();
            mostPWCShow.Rating.ShouldBeNull();
            mostPWCShow.Votes.ShouldBeNull();
            mostPWCShow.CommentCount.ShouldBeNull();
            mostPWCShow.UpdatedAt.ShouldBeNull();
            mostPWCShow.Language.ShouldBeNull();
            mostPWCShow.Languages.ShouldBeNull();
            mostPWCShow.AvailableTranslations.ShouldBeNull();
            mostPWCShow.Genres.ShouldBeNull();
            mostPWCShow.Subgenres.ShouldBeNull();
            mostPWCShow.OriginalTitle.ShouldBeNull();
            mostPWCShow.Images.ShouldBeNull();
            mostPWCShow.Colors.ShouldBeNull();
            mostPWCShow.FirstAired.ShouldBeNull();
            mostPWCShow.AiredEpisodes.ShouldBeNull();
            mostPWCShow.Airs.ShouldBeNull();
            mostPWCShow.Network.ShouldBeNull();

            mostPWCShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostPWCShowFromJsonMinimal()
        {
            TraktMostPWCShow? mostPWCShow = await TestUtility.DeserializeJsonAsync<TraktMostPWCShow>("Shows\\mostpwcshow_minimal.json");

            mostPWCShow.ShouldNotBeNull();
            mostPWCShow!.WatcherCount.ShouldBe(3910U);
            mostPWCShow!.PlayCount.ShouldBe(69164U);
            mostPWCShow!.CollectedCount.ShouldBe(1000U);

            mostPWCShow!.Title.ShouldBe("Game of Thrones");
            mostPWCShow!.Year.ShouldBe(2011U);

            mostPWCShow!.IDs!.Trakt.ShouldBe(1390U);
            mostPWCShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostPWCShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostPWCShow!.IDs!.TMDB.ShouldBe(1399U);
            mostPWCShow!.IDs!.TVDB.ShouldBe(121361U);
            mostPWCShow!.IDs!.HasAnyID.ShouldBe(true);
            mostPWCShow!.IDs!.BestID.ShouldBe("game-of-thrones");

            mostPWCShow!.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktMostPWCShowFromJson()
        {
            TraktMostPWCShow? mostPWCShow = await TestUtility.DeserializeJsonAsync<TraktMostPWCShow>("Shows\\mostpwcshow.json");
            ValidateMostPWCShow(mostPWCShow);
        }

        [Fact]
        public async Task TestTraktMostPWCShowsFromJsonMinimal()
        {
            IReadOnlyList<TraktMostPWCShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostPWCShow>("Shows\\mostpwcshows_minimal.json");

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
        public async Task TestTraktMostPWCShowsFromJson()
        {
            IReadOnlyList<TraktMostPWCShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostPWCShow>("Shows\\mostpwcshows.json");

            shows.ShouldNotBeNull();
            shows!.Count.ShouldBe(2);

            ValidateMostPWCShow(shows[0]);

            var show1 = shows[1];
            show1.Title.ShouldBe("Black Mirror");
            show1.WatcherCount.ShouldBe(1249U);
            show1.OriginalTitle.ShouldBe("Black Mirror");
            show1.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            show1.AiredEpisodes.ShouldBe(32U);
            show1.Network.ShouldBe("Netflix");
        }

        private static void ValidateMostPWCShow(TraktMostPWCShow? mostPWCShow)
        {
            mostPWCShow.ShouldNotBeNull();
            mostPWCShow!.WatcherCount.ShouldBe(3910U);
            mostPWCShow!.PlayCount.ShouldBe(69164U);

            mostPWCShow!.Title.ShouldBe("Game of Thrones");
            mostPWCShow!.Year.ShouldBe(2011U);

            mostPWCShow!.IDs.ShouldNotBeNull();
            mostPWCShow!.IDs!.Trakt.ShouldBe(1390U);
            mostPWCShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostPWCShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostPWCShow!.IDs!.TMDB.ShouldBe(1399U);
            mostPWCShow!.IDs!.TVDB.ShouldBe(121361U);

            mostPWCShow!.Tagline.ShouldBe("Winter is coming.");
            mostPWCShow!.Overview.ShouldStartWith("Seven noble families fight");
            mostPWCShow!.Runtime.ShouldBe(55U);
            mostPWCShow!.Certification.ShouldBe("TV-MA");
            mostPWCShow!.Country.ShouldBe("us");
            mostPWCShow!.Trailer.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            mostPWCShow!.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            mostPWCShow!.Status.ShouldBe(TraktShowStatus.Ended);
            mostPWCShow!.Rating.ShouldBe(8.89122f);
            mostPWCShow!.Votes.ShouldBe(145017U);
            mostPWCShow!.CommentCount.ShouldBe(449U);
            mostPWCShow!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-21T15:43:57.000Z"));
            mostPWCShow!.Language.ShouldBe("en");

            mostPWCShow!.Languages.ShouldNotBeNull();
            mostPWCShow!.Languages!.Count.ShouldBe(1);
            mostPWCShow!.Languages.ShouldBe(["en"], Case.Sensitive);

            mostPWCShow!.AvailableTranslations.ShouldNotBeNull();
            mostPWCShow!.AvailableTranslations!.Count.ShouldBe(48);
            mostPWCShow!.AvailableTranslations!.ShouldContain("es");
            mostPWCShow!.AvailableTranslations!.ShouldContain("en");

            mostPWCShow!.Genres.ShouldNotBeNull();
            mostPWCShow!.Genres!.Count.ShouldBe(4);
            mostPWCShow!.Genres.ShouldBe(["fantasy", "drama", "action", "adventure"], Case.Sensitive);

            mostPWCShow!.OriginalTitle.ShouldBe("Game of Thrones");

            mostPWCShow!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));

            mostPWCShow!.Airs.ShouldNotBeNull();
            mostPWCShow!.Airs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            mostPWCShow!.Airs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            mostPWCShow!.Airs!.Time.ShouldBe("21:00");
#endif
            mostPWCShow!.Airs!.Timezone.ShouldBe("America/New_York");

            mostPWCShow!.Network.ShouldBe("HBO");
        }
    }
}
