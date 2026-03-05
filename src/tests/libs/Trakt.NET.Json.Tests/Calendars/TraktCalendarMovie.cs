namespace TraktNET.Json.Calendars
{
    public sealed class TraktCalendarMovieTests
    {
        [Fact]
        public void TestTraktCalendarMovieConstructor()
        {
            var calendarMovie = new TraktCalendarMovie();

            calendarMovie.Released.ShouldBeNull();
            calendarMovie.Movie.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCalendarMovieFromJsonMinimal()
        {
            TraktCalendarMovie? calendarMovie = await TestUtility.DeserializeJsonAsync<TraktCalendarMovie>("Calendars\\calendarmovie_minimal.json");

            calendarMovie.ShouldNotBeNull();
            calendarMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2012-05-04T00:00:00.000Z"));

            calendarMovie.Movie.ShouldNotBeNull();
            calendarMovie.Movie!.Title.ShouldBe("The Avengers");
            calendarMovie.Movie.Year.ShouldBe(2012U);
            calendarMovie.Movie.IDs.ShouldNotBeNull();
            calendarMovie.Movie.IDs!.Trakt.ShouldBe(14701U);
            calendarMovie.Movie.IDs.Slug.ShouldBe("the-avengers-2012");
            calendarMovie.Movie.IDs.IMDB.ShouldBe("tt0848228");
            calendarMovie.Movie.IDs.TMDB.ShouldBe(24428U);
        }

        [Fact]
        public async Task TestTraktCalendarMovieFromJsonFull()
        {
            TraktCalendarMovie? calendarMovie = await TestUtility.DeserializeJsonAsync<TraktCalendarMovie>("Calendars\\calendarmovie.json");

            calendarMovie.ShouldNotBeNull();
            calendarMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2012-05-04T00:00:00.000Z"));

            calendarMovie.Movie.ShouldNotBeNull();
            TraktMovie movie = calendarMovie.Movie!;

            movie.Title.ShouldBe("The Avengers");
            movie.Tagline.ShouldBe("Some assembly required.");
            movie.Runtime.ShouldBe(143U);
            movie.Certification.ShouldBe("PG-13");
            movie.Country.ShouldBe("us");
            movie.Rating.ShouldBe(8.11563f);
            movie.Votes.ShouldBe(74746U);
            movie.Status.ShouldBe(TraktMovieStatus.Released);

            movie.Genres.ShouldNotBeNull();

            movie.UpdatedAt.ShouldNotBeNull();
            movie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-03-05T16:52:03.000Z"));
        }
    }
}
