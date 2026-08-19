namespace TraktNET.Json.Movies
{
    public sealed class TraktHotMovieTests
    {
        [Fact]
        public void TestTraktHotMovieConstructor()
        {
            var hotMovie = new TraktHotMovie();

            hotMovie.ListCount.ShouldBeNull();
            hotMovie.Title.ShouldBeNull();
            hotMovie.Year.ShouldBeNull();
            hotMovie.IDs.ShouldBeNull();
            hotMovie.Tagline.ShouldBeNull();
            hotMovie.Overview.ShouldBeNull();
            hotMovie.Released.ShouldBeNull();
            hotMovie.Runtime.ShouldBeNull();
            hotMovie.Country.ShouldBeNull();
            hotMovie.Trailer.ShouldBeNull();
            hotMovie.Homepage.ShouldBeNull();
            hotMovie.Status.ShouldBeNull();
            hotMovie.Rating.ShouldBeNull();
            hotMovie.Votes.ShouldBeNull();
            hotMovie.CommentCount.ShouldBeNull();
            hotMovie.UpdatedAt.ShouldBeNull();
            hotMovie.Language.ShouldBeNull();
            hotMovie.Languages.ShouldBeNull();
            hotMovie.AvailableTranslations.ShouldBeNull();
            hotMovie.Genres.ShouldBeNull();
            hotMovie.Certification.ShouldBeNull();

            hotMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktHotMovieFromJson()
        {
            TraktHotMovie? hotMovie = await TestUtility.DeserializeJsonAsync<TraktHotMovie>("Movies\\hotmovie.json");

            hotMovie.ShouldNotBeNull();
            hotMovie.ListCount.ShouldBe(120U);

            hotMovie.Title.ShouldBe("Deadpool & Wolverine");
            hotMovie.Year.ShouldBe(2024U);

            hotMovie.IDs.ShouldNotBeNull();
            hotMovie.IDs.Trakt.ShouldBe(395672U);
            hotMovie.IDs.Slug.ShouldBe("deadpool-wolverine-2024");
            hotMovie.IDs.IMDB.ShouldBe("tt6263850");
            hotMovie.IDs.TMDB.ShouldBe(533535U);
            hotMovie.IDs.HasAnyID.ShouldBe(true);
            hotMovie.IDs.BestID.ShouldBe("deadpool-wolverine-2024");

            hotMovie.ToString().ShouldBe("Deadpool & Wolverine (2024)");

            hotMovie.Tagline.ShouldBe("Come together.");
            hotMovie.Overview.ShouldBe("A listless Wade Wilson toils away in civilian life with his days as the morally flexible mercenary, Deadpool, behind him.");

#if NET7_0_OR_GREATER
            hotMovie.Released.ShouldBe(TestUtility.ParseDate("2024-07-26"));
#else
            hotMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z"));
#endif
            hotMovie.Runtime.ShouldBe(128U);
            hotMovie.Country.ShouldBe("us");
            hotMovie.Trailer.ShouldBe("https://youtube.com/watch?v=Idh8n5XuYIA");
            hotMovie.Homepage.ShouldBe("http://www.marvel.com/movies/deadpool-and-wolverine");
            hotMovie.Status.ShouldBe(TraktMovieStatus.Released);
            hotMovie.Rating.ShouldBe(8.244876693296284f);
            hotMovie.Votes.ShouldBe(5758U);
            hotMovie.CommentCount.ShouldBe(159U);
            hotMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z"));
            hotMovie.Language.ShouldBe("en");
            hotMovie.Languages.ShouldNotBeNull();
            hotMovie.Languages.Count.ShouldBe(1);
            hotMovie.Languages.ShouldBe(["en"], Case.Sensitive);

            hotMovie.Genres.ShouldNotBeNull();
            hotMovie.Genres.Count.ShouldBe(4);
            hotMovie.Genres.ShouldBe(["comedy", "superhero", "science-fiction", "action"], Case.Sensitive);

            hotMovie.Certification.ShouldBe("R");
        }
    }
}
