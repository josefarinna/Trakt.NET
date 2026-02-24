namespace TraktNET.Json.Shows
{
    public sealed class TraktMostPlayedShowTests
    {
        [Fact]
        public void TestTraktMostPlayedShowConstructor()
        {
            var mostPlayedShow = new TraktMostPlayedShow();

            mostPlayedShow.WatcherCount.ShouldBeNull();
            mostPlayedShow.PlayCount.ShouldBeNull();
            mostPlayedShow.CollectedCount.ShouldBeNull();
            mostPlayedShow.Title.ShouldBeNull();
            mostPlayedShow.Year.ShouldBeNull();
            mostPlayedShow.IDs.ShouldBeNull();
            mostPlayedShow.Tagline.ShouldBeNull();
            mostPlayedShow.Overview.ShouldBeNull();
            mostPlayedShow.Runtime.ShouldBeNull();
            mostPlayedShow.Certification.ShouldBeNull();
            mostPlayedShow.Country.ShouldBeNull();
            mostPlayedShow.Trailer.ShouldBeNull();
            mostPlayedShow.Homepage.ShouldBeNull();
            mostPlayedShow.Status.ShouldBeNull();
            mostPlayedShow.Rating.ShouldBeNull();
            mostPlayedShow.Votes.ShouldBeNull();
            mostPlayedShow.CommentCount.ShouldBeNull();
            mostPlayedShow.UpdatedAt.ShouldBeNull();
            mostPlayedShow.Language.ShouldBeNull();
            mostPlayedShow.Languages.ShouldBeNull();
            mostPlayedShow.AvailableTranslations.ShouldBeNull();
            mostPlayedShow.Genres.ShouldBeNull();
            mostPlayedShow.Subgenres.ShouldBeNull();
            mostPlayedShow.OriginalTitle.ShouldBeNull();
            mostPlayedShow.Images.ShouldBeNull();
            mostPlayedShow.Colors.ShouldBeNull();
            mostPlayedShow.FirstAired.ShouldBeNull();
            mostPlayedShow.AiredEpisodes.ShouldBeNull();
            mostPlayedShow.Airs.ShouldBeNull();
            mostPlayedShow.Network.ShouldBeNull();

            mostPlayedShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostPlayedShowFromJsonMinimal()
        {
            TraktMostPlayedShow? mostPlayedShow = await TestUtility.DeserializeJsonAsync<TraktMostPlayedShow>("Shows\\mostpwcshow_minimal.json");

            mostPlayedShow.ShouldNotBeNull();
            mostPlayedShow!.WatcherCount.ShouldBe(3910U);
            mostPlayedShow!.PlayCount.ShouldBe(69164U);
            mostPlayedShow!.CollectedCount.ShouldBe(1000U);

            mostPlayedShow!.Title.ShouldBe("Game of Thrones");
            mostPlayedShow!.Year.ShouldBe(2011U);

            mostPlayedShow!.IDs!.Trakt.ShouldBe(1390U);
            mostPlayedShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostPlayedShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostPlayedShow!.IDs!.TMDB.ShouldBe(1399U);
            mostPlayedShow!.IDs!.TVDB.ShouldBe(121361U);
            mostPlayedShow!.IDs!.HasAnyID.ShouldBe(true);
            mostPlayedShow!.IDs!.BestID.ShouldBe("game-of-thrones");

            mostPlayedShow!.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktMostPlayedShowFromJson()
        {
            TraktMostPlayedShow? mostPlayedShow = await TestUtility.DeserializeJsonAsync<TraktMostPlayedShow>("Shows\\mostpwcshow.json");
            ValidateMostPlayedShow(mostPlayedShow);
        }

        [Fact]
        public async Task TestTraktMostPlayedShowsFromJsonMinimal()
        {
            IReadOnlyList<TraktMostPlayedShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostPlayedShow>("Shows\\mostpwcshows_minimal.json");

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
        public async Task TestTraktMostPlayedShowsFromJson()
        {
            IReadOnlyList<TraktMostPlayedShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostPlayedShow>("Shows\\mostpwcshows.json");

            shows.ShouldNotBeNull();
            shows!.Count.ShouldBe(2);

            ValidateMostPlayedShow(shows[0]);

            var show1 = shows[1];
            show1.Title.ShouldBe("Black Mirror");
            show1.WatcherCount.ShouldBe(1249U);
            show1.OriginalTitle.ShouldBe("Black Mirror");
            show1.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            show1.AiredEpisodes.ShouldBe(32U);
            show1.Network.ShouldBe("Netflix");
        }

        private static void ValidateMostPlayedShow(TraktMostPlayedShow? mostPlayedShow)
        {
            mostPlayedShow.ShouldNotBeNull();
            mostPlayedShow!.WatcherCount.ShouldBe(3910U);
            mostPlayedShow!.PlayCount.ShouldBe(69164U);

            mostPlayedShow!.Title.ShouldBe("Game of Thrones");
            mostPlayedShow!.Year.ShouldBe(2011U);

            mostPlayedShow!.IDs.ShouldNotBeNull();
            mostPlayedShow!.IDs!.Trakt.ShouldBe(1390U);
            mostPlayedShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostPlayedShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostPlayedShow!.IDs!.TMDB.ShouldBe(1399U);
            mostPlayedShow!.IDs!.TVDB.ShouldBe(121361U);

            mostPlayedShow!.Tagline.ShouldBe("Winter is coming.");
            mostPlayedShow!.Overview.ShouldStartWith("Seven noble families fight");
            mostPlayedShow!.Runtime.ShouldBe(55U);
            mostPlayedShow!.Certification.ShouldBe("TV-MA");
            mostPlayedShow!.Country.ShouldBe("us");
            mostPlayedShow!.Trailer.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            mostPlayedShow!.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            mostPlayedShow!.Status.ShouldBe(TraktShowStatus.Ended);
            mostPlayedShow!.Rating.ShouldBe(8.89122f);
            mostPlayedShow!.Votes.ShouldBe(145017U);
            mostPlayedShow!.CommentCount.ShouldBe(449U);
            mostPlayedShow!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-21T15:43:57.000Z"));
            mostPlayedShow!.Language.ShouldBe("en");

            mostPlayedShow!.Languages.ShouldNotBeNull();
            mostPlayedShow!.Languages!.Count.ShouldBe(1);
            mostPlayedShow!.Languages.ShouldBe(["en"], Case.Sensitive);

            mostPlayedShow!.AvailableTranslations.ShouldNotBeNull();
            mostPlayedShow!.AvailableTranslations!.Count.ShouldBe(48);
            mostPlayedShow!.AvailableTranslations!.ShouldContain("es");
            mostPlayedShow!.AvailableTranslations!.ShouldContain("en");

            mostPlayedShow!.Genres.ShouldNotBeNull();
            mostPlayedShow!.Genres!.Count.ShouldBe(4);
            mostPlayedShow!.Genres.ShouldBe(["fantasy", "drama", "action", "adventure"], Case.Sensitive);

            mostPlayedShow!.OriginalTitle.ShouldBe("Game of Thrones");

            mostPlayedShow!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));

            mostPlayedShow!.Airs.ShouldNotBeNull();
            mostPlayedShow!.Airs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            mostPlayedShow!.Airs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            mostPlayedShow!.Airs!.Time.ShouldBe("21:00");
#endif
            mostPlayedShow!.Airs!.Timezone.ShouldBe("America/New_York");

            mostPlayedShow!.Network.ShouldBe("HBO");
        }
    }
}
