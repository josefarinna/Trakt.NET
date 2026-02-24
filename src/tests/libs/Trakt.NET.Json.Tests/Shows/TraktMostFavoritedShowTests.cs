namespace TraktNET.Json.Shows
{
    public sealed class TraktMostFavoritedShowTests
    {
        [Fact]
        public void TestTraktMostFavoritedShowConstructor()
        {
            var mostFavoritedShow = new TraktMostFavoritedShow();

            mostFavoritedShow.UserCount.ShouldBeNull();
            mostFavoritedShow.Title.ShouldBeNull();
            mostFavoritedShow.Year.ShouldBeNull();
            mostFavoritedShow.IDs.ShouldBeNull();
            mostFavoritedShow.Tagline.ShouldBeNull();
            mostFavoritedShow.Overview.ShouldBeNull();
            mostFavoritedShow.Runtime.ShouldBeNull();
            mostFavoritedShow.Certification.ShouldBeNull();
            mostFavoritedShow.Country.ShouldBeNull();
            mostFavoritedShow.Trailer.ShouldBeNull();
            mostFavoritedShow.Homepage.ShouldBeNull();
            mostFavoritedShow.Status.ShouldBeNull();
            mostFavoritedShow.Rating.ShouldBeNull();
            mostFavoritedShow.Votes.ShouldBeNull();
            mostFavoritedShow.CommentCount.ShouldBeNull();
            mostFavoritedShow.UpdatedAt.ShouldBeNull();
            mostFavoritedShow.Language.ShouldBeNull();
            mostFavoritedShow.Languages.ShouldBeNull();
            mostFavoritedShow.AvailableTranslations.ShouldBeNull();
            mostFavoritedShow.Genres.ShouldBeNull();
            mostFavoritedShow.Subgenres.ShouldBeNull();
            mostFavoritedShow.OriginalTitle.ShouldBeNull();
            mostFavoritedShow.FirstAired.ShouldBeNull();
            mostFavoritedShow.AiredEpisodes.ShouldBeNull();
            mostFavoritedShow.Airs.ShouldBeNull();
            mostFavoritedShow.Network.ShouldBeNull();

            mostFavoritedShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostFavoritedShowFromJsonMinimal()
        {
            TraktMostFavoritedShow? mostFavoritedShow = await TestUtility.DeserializeJsonAsync<TraktMostFavoritedShow>("Shows\\mostfavoritedshow_minimal.json");

            mostFavoritedShow.ShouldNotBeNull();
            mostFavoritedShow!.UserCount.ShouldBe(128U);

            mostFavoritedShow!.Title.ShouldBe("Game of Thrones");
            mostFavoritedShow!.Year.ShouldBe(2011U);

            mostFavoritedShow!.IDs!.Trakt.ShouldBe(1390U);
            mostFavoritedShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostFavoritedShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostFavoritedShow!.IDs!.TMDB.ShouldBe(1399U);
            mostFavoritedShow!.IDs!.TVDB.ShouldBe(121361U);
            mostFavoritedShow!.IDs!.HasAnyID.ShouldBe(true);
            mostFavoritedShow!.IDs!.BestID.ShouldBe("game-of-thrones");

            mostFavoritedShow!.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktMostFavoritedShowFromJson()
        {
            TraktMostFavoritedShow? mostFavoritedShow = await TestUtility.DeserializeJsonAsync<TraktMostFavoritedShow>("Shows\\mostfavoritedshow.json");
            ValidateMostFavoritedShow(mostFavoritedShow);
        }

        [Fact]
        public async Task TestTraktMostFavoritedShowsFromJsonMinimal()
        {
            IReadOnlyList<TraktMostFavoritedShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostFavoritedShow>("Shows\\mostfavoritedshows_minimal.json");

            shows.ShouldNotBeNull();
            shows!.Count.ShouldBe(2);

            var show0 = shows[0];
            show0.UserCount.ShouldBe(128U);
            show0.Title.ShouldBe("Game of Thrones");
            show0.Year.ShouldBe(2011U);
            show0.IDs!.Trakt.ShouldBe(1390U);

            var show1 = shows[1];
            show1.UserCount.ShouldBe(37U);
            show1.Title.ShouldBe("Black Mirror");
            show1.Year.ShouldBe(2011U);
            show1.IDs!.Trakt.ShouldBe(41793U);
        }

        [Fact]
        public async Task TestTraktMostFavoritedShowsFromJson()
        {
            IReadOnlyList<TraktMostFavoritedShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostFavoritedShow>("Shows\\mostfavoritedshows.json");

            shows.ShouldNotBeNull();
            shows!.Count.ShouldBe(2);

            // Valida el primer elemento exhaustivamente
            ValidateMostFavoritedShow(shows[0]);

            // Valida el segundo elemento para asegurar la integridad de la lista
            var show1 = shows[1];
            show1.UserCount.ShouldBe(37U);
            show1.Title.ShouldBe("Black Mirror");
            show1.Network.ShouldBe("Netflix");
            show1.Status.ShouldBe(TraktShowStatus.ReturningSeries);
        }

        private static void ValidateMostFavoritedShow(TraktMostFavoritedShow? mostFavoritedShow)
        {
            mostFavoritedShow.ShouldNotBeNull();
            mostFavoritedShow!.UserCount.ShouldBe(128U);

            mostFavoritedShow!.Title.ShouldBe("Game of Thrones");
            mostFavoritedShow!.Year.ShouldBe(2011U);

            mostFavoritedShow!.IDs.ShouldNotBeNull();
            mostFavoritedShow!.IDs!.Trakt.ShouldBe(1390U);
            mostFavoritedShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostFavoritedShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostFavoritedShow!.IDs!.TMDB.ShouldBe(1399U);
            mostFavoritedShow!.IDs!.TVDB.ShouldBe(121361U);

            mostFavoritedShow!.Tagline.ShouldBe("Winter is coming.");
            mostFavoritedShow!.Overview.ShouldStartWith("Seven noble families fight");
            mostFavoritedShow!.Runtime.ShouldBe(55U);
            mostFavoritedShow!.Certification.ShouldBe("TV-MA");
            mostFavoritedShow!.Country.ShouldBe("us");
            mostFavoritedShow!.Trailer.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            mostFavoritedShow!.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            mostFavoritedShow!.Status.ShouldBe(TraktShowStatus.Ended);
            mostFavoritedShow!.Rating.ShouldBe(8.89122f);
            mostFavoritedShow!.Votes.ShouldBe(145017U);
            mostFavoritedShow!.CommentCount.ShouldBe(449U);
            mostFavoritedShow!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-21T15:43:57.000Z"));
            mostFavoritedShow!.Language.ShouldBe("en");

            mostFavoritedShow!.Languages.ShouldNotBeNull();
            mostFavoritedShow!.Languages!.Count.ShouldBe(1);
            mostFavoritedShow!.Languages.ShouldBe(["en"], Case.Sensitive);

            mostFavoritedShow!.AvailableTranslations.ShouldNotBeNull();
            mostFavoritedShow!.AvailableTranslations!.Count.ShouldBe(48);
            mostFavoritedShow!.AvailableTranslations!.ShouldContain("es");

            mostFavoritedShow!.Genres.ShouldNotBeNull();
            mostFavoritedShow!.Genres!.Count.ShouldBe(4);
            mostFavoritedShow!.Genres.ShouldBe(["fantasy", "drama", "action", "adventure"], Case.Sensitive);

            mostFavoritedShow!.Subgenres.ShouldNotBeNull();
            mostFavoritedShow!.Subgenres!.Count.ShouldBe(4);
            mostFavoritedShow!.Subgenres.ShouldBe(["fantasy-world", "dragon", "kingdom", "king"], Case.Sensitive);

            mostFavoritedShow!.OriginalTitle.ShouldBe("Game of Thrones");
            mostFavoritedShow!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            mostFavoritedShow!.AiredEpisodes.ShouldBe(73U);

            mostFavoritedShow!.Airs.ShouldNotBeNull();
            mostFavoritedShow!.Airs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            mostFavoritedShow!.Airs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            mostFavoritedShow!.Airs!.Time.ShouldBe("21:00");
#endif
            mostFavoritedShow!.Airs!.Timezone.ShouldBe("America/New_York");

            mostFavoritedShow!.Network.ShouldBe("HBO");
        }
    }
}
