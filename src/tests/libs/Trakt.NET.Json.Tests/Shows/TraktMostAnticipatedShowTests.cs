namespace TraktNET.Json.Shows
{
    public sealed class TraktMostAnticipatedShowTests
    {
        [Fact]
        public void TestTraktMostAnticipatedShowConstructor()
        {
            var mostAnticipatedShow = new TraktMostAnticipatedShow();

            mostAnticipatedShow.ListCount.ShouldBeNull();
            mostAnticipatedShow.Title.ShouldBeNull();
            mostAnticipatedShow.Year.ShouldBeNull();
            mostAnticipatedShow.IDs.ShouldBeNull();
            mostAnticipatedShow.Tagline.ShouldBeNull();
            mostAnticipatedShow.Overview.ShouldBeNull();
            mostAnticipatedShow.Runtime.ShouldBeNull();
            mostAnticipatedShow.Certification.ShouldBeNull();
            mostAnticipatedShow.Country.ShouldBeNull();
            mostAnticipatedShow.Trailer.ShouldBeNull();
            mostAnticipatedShow.Homepage.ShouldBeNull();
            mostAnticipatedShow.Status.ShouldBeNull();
            mostAnticipatedShow.Rating.ShouldBeNull();
            mostAnticipatedShow.Votes.ShouldBeNull();
            mostAnticipatedShow.CommentCount.ShouldBeNull();
            mostAnticipatedShow.UpdatedAt.ShouldBeNull();
            mostAnticipatedShow.Language.ShouldBeNull();
            mostAnticipatedShow.Languages.ShouldBeNull();
            mostAnticipatedShow.AvailableTranslations.ShouldBeNull();
            mostAnticipatedShow.Genres.ShouldBeNull();
            mostAnticipatedShow.Subgenres.ShouldBeNull();
            mostAnticipatedShow.OriginalTitle.ShouldBeNull();
            mostAnticipatedShow.Images.ShouldBeNull();
            mostAnticipatedShow.Colors.ShouldBeNull();
            mostAnticipatedShow.FirstAired.ShouldBeNull();
            mostAnticipatedShow.AiredEpisodes.ShouldBeNull();
            mostAnticipatedShow.Airs.ShouldBeNull();
            mostAnticipatedShow.Network.ShouldBeNull();

            mostAnticipatedShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostAnticipatedShowFromJsonMinimal()
        {
            TraktMostAnticipatedShow? mostAnticipatedShow = await TestUtility.DeserializeJsonAsync<TraktMostAnticipatedShow>("Shows\\mostanticipatedshow_minimal.json");

            mostAnticipatedShow.ShouldNotBeNull();
            mostAnticipatedShow!.ListCount.ShouldBe(12805U);

            mostAnticipatedShow!.Title.ShouldBe("Game of Thrones");
            mostAnticipatedShow!.Year.ShouldBe(2011U);

            mostAnticipatedShow!.IDs!.Trakt.ShouldBe(1390U);
            mostAnticipatedShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostAnticipatedShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostAnticipatedShow!.IDs!.TMDB.ShouldBe(1399U);
            mostAnticipatedShow!.IDs!.TVDB.ShouldBe(121361U);
            mostAnticipatedShow!.IDs!.HasAnyID.ShouldBe(true);
            mostAnticipatedShow!.IDs!.BestID.ShouldBe("game-of-thrones");

            mostAnticipatedShow!.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktMostAnticipatedShowFromJson()
        {
            TraktMostAnticipatedShow? mostAnticipatedShow = await TestUtility.DeserializeJsonAsync<TraktMostAnticipatedShow>("Shows\\mostanticipatedshow.json");
            ValidateMostAnticipatedShow(mostAnticipatedShow);
        }

        [Fact]
        public async Task TestTraktMostAnticipatedShowsFromJsonMinimal()
        {
            IReadOnlyList<TraktMostAnticipatedShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostAnticipatedShow>("Shows\\mostanticipatedshows_minimal.json");

            shows.ShouldNotBeNull();
            shows!.Count.ShouldBe(2);

            var show0 = shows[0];
            show0.ListCount.ShouldBe(12805U);
            show0.Title.ShouldBe("Game of Thrones");
            show0.Year.ShouldBe(2011U);
            show0.IDs!.Trakt.ShouldBe(1390U);
            show0.IDs!.Slug.ShouldBe("game-of-thrones");

            var show1 = shows[1];
            show1.ListCount.ShouldBe(23502U);
            show1.Title.ShouldBe("Stranger Things");
            show1.Year.ShouldBe(2016U);
            show1.IDs!.Trakt.ShouldBe(104439U);
        }

        [Fact]
        public async Task TestTraktMostAnticipatedShowsFromJson()
        {
            IReadOnlyList<TraktMostAnticipatedShow>? shows = await TestUtility.DeserializeJsonListAsync<TraktMostAnticipatedShow>("Shows\\mostanticipatedshows.json");

            shows.ShouldNotBeNull();
            shows!.Count.ShouldBe(2);

            // Valida el primer elemento con todo el detalle posible
            ValidateMostAnticipatedShow(shows[0]);

            // Valida el segundo elemento para asegurar que la iteración funciona
            var show1 = shows[1];
            show1.Title.ShouldBe("Stranger Things");
            show1.Network.ShouldBe("Netflix");
            show1.Status.ShouldBe(TraktShowStatus.Ended);
            show1.Airs!.Day.ShouldBe(TraktDayOfWeek.Wednesday);
        }

        private static void ValidateMostAnticipatedShow(TraktMostAnticipatedShow? mostAnticipatedShow)
        {
            mostAnticipatedShow.ShouldNotBeNull();
            mostAnticipatedShow!.ListCount.ShouldBe(12805U);
            mostAnticipatedShow!.Title.ShouldBe("Game of Thrones");
            mostAnticipatedShow!.Year.ShouldBe(2011U);

            mostAnticipatedShow!.IDs.ShouldNotBeNull();
            mostAnticipatedShow!.IDs!.Trakt.ShouldBe(1390U);
            mostAnticipatedShow!.IDs!.Slug.ShouldBe("game-of-thrones");
            mostAnticipatedShow!.IDs!.IMDB.ShouldBe("tt0944947");
            mostAnticipatedShow!.IDs!.TMDB.ShouldBe(1399U);
            mostAnticipatedShow!.IDs!.TVDB.ShouldBe(121361U);

            mostAnticipatedShow!.Tagline.ShouldBe("Winter Is Coming");
            mostAnticipatedShow!.Overview.ShouldStartWith("Seven noble families fight");
            mostAnticipatedShow!.Runtime.ShouldBe(60U);
            mostAnticipatedShow!.Certification.ShouldBe("TV-MA");
            mostAnticipatedShow!.Country.ShouldBe("us");
            mostAnticipatedShow!.Trailer.ShouldBe("http://youtube.com/watch?v=F9Bo89m2f6g");
            mostAnticipatedShow!.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            mostAnticipatedShow!.Status.ShouldBe(TraktShowStatus.Ended);
            mostAnticipatedShow!.Rating.ShouldBe(8.891263f);
            mostAnticipatedShow!.Votes.ShouldBe(145001U);
            mostAnticipatedShow!.CommentCount.ShouldBe(449U);
            mostAnticipatedShow!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-02-21T15:43:57.000Z"));
            mostAnticipatedShow!.Language.ShouldBe("en");

            mostAnticipatedShow!.Languages.ShouldNotBeNull();
            mostAnticipatedShow!.Languages!.Count.ShouldBe(1);
            mostAnticipatedShow!.Languages.ShouldBe(["en"], Case.Sensitive);

            mostAnticipatedShow!.AvailableTranslations.ShouldNotBeNull();
            mostAnticipatedShow!.AvailableTranslations!.Count.ShouldBe(4);
            mostAnticipatedShow!.AvailableTranslations.ShouldBe(["en", "es", "fr", "de"], Case.Sensitive);

            mostAnticipatedShow!.Genres.ShouldNotBeNull();
            mostAnticipatedShow!.Genres!.Count.ShouldBe(4);
            mostAnticipatedShow!.Genres.ShouldBe(["fantasy", "drama", "action", "adventure"], Case.Sensitive);

            mostAnticipatedShow!.Subgenres.ShouldNotBeNull();
            mostAnticipatedShow!.Subgenres!.Count.ShouldBe(4);
            mostAnticipatedShow!.Subgenres.ShouldBe(["fantasy-world", "dragon", "kingdom", "king"], Case.Sensitive);

            mostAnticipatedShow!.OriginalTitle.ShouldBe("Game of Thrones");

            mostAnticipatedShow!.Images.ShouldNotBeNull();
            mostAnticipatedShow!.Images!.Poster.ShouldBe(["media.trakt.tv/images/shows/000/001/390/posters/medium/93df9cd612.jpg.webp"]);

            mostAnticipatedShow!.Colors.ShouldNotBeNull();
            mostAnticipatedShow!.Colors!.Poster.ShouldBe(["#AD836A", "#261713"]);

            mostAnticipatedShow!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T07:00:00Z"));
            mostAnticipatedShow!.AiredEpisodes.ShouldBe(73U);

            mostAnticipatedShow!.Airs.ShouldNotBeNull();
            mostAnticipatedShow!.Airs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            mostAnticipatedShow!.Airs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            mostAnticipatedShow!.Airs!.Time.ShouldBe("21:00");
#endif
            mostAnticipatedShow!.Airs!.Timezone.ShouldBe("America/New_York");

            mostAnticipatedShow!.Network.ShouldBe("HBO");
        }
    }
}
