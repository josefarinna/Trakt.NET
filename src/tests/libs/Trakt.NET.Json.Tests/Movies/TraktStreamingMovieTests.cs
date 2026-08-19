using Shouldly;

namespace TraktNET.Json.Movies
{
    public sealed class TraktStreamingMovieTests
    {
        [Fact]
        public void TestTraktStreamingMovieConstructor()
        {
            var streamingMovie = new TraktStreamingMovie();

            streamingMovie.Rank.ShouldBeNull();
            streamingMovie.Delta.ShouldBeNull();
            streamingMovie.Title.ShouldBeNull();
            streamingMovie.Year.ShouldBeNull();
            streamingMovie.IDs.ShouldBeNull();
            streamingMovie.Tagline.ShouldBeNull();
            streamingMovie.Overview.ShouldBeNull();
            streamingMovie.Released.ShouldBeNull();
            streamingMovie.Runtime.ShouldBeNull();
            streamingMovie.Country.ShouldBeNull();
            streamingMovie.Trailer.ShouldBeNull();
            streamingMovie.Homepage.ShouldBeNull();
            streamingMovie.Status.ShouldBeNull();
            streamingMovie.Rating.ShouldBeNull();
            streamingMovie.Votes.ShouldBeNull();
            streamingMovie.CommentCount.ShouldBeNull();
            streamingMovie.UpdatedAt.ShouldBeNull();
            streamingMovie.Language.ShouldBeNull();
            streamingMovie.Languages.ShouldBeNull();
            streamingMovie.AvailableTranslations.ShouldBeNull();
            streamingMovie.Genres.ShouldBeNull();
            streamingMovie.Certification.ShouldBeNull();

            streamingMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktStreamingMovieFromJson()
        {
            TraktStreamingMovie? streamingMovie = await TestUtility.DeserializeJsonAsync<TraktStreamingMovie>("Movies\\streamingmovie.json");

            streamingMovie.ShouldNotBeNull();
            streamingMovie.Rank.ShouldBe(1);
            streamingMovie.Delta.ShouldBe(2);

            streamingMovie.Title.ShouldBe("Deadpool & Wolverine");
            streamingMovie.Year.ShouldBe(2024U);

            streamingMovie.IDs.ShouldNotBeNull();
            streamingMovie.IDs.Trakt.ShouldBe(395672U);
            streamingMovie.IDs.Slug.ShouldBe("deadpool-wolverine-2024");
            streamingMovie.IDs.IMDB.ShouldBe("tt6263850");
            streamingMovie.IDs.TMDB.ShouldBe(533535U);
            streamingMovie.IDs.HasAnyID.ShouldBe(true);
            streamingMovie.IDs.BestID.ShouldBe("deadpool-wolverine-2024");

            streamingMovie.ToString().ShouldBe("Deadpool & Wolverine (2024)");

            streamingMovie.Tagline.ShouldBe("Come together.");
            streamingMovie.Overview.ShouldBe("A listless Wade Wilson toils away in civilian life with his days as the morally flexible mercenary, Deadpool, behind him.");

#if NET7_0_OR_GREATER
            streamingMovie.Released.ShouldBe(TestUtility.ParseDate("2024-07-26"));
#else
            streamingMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z"));
#endif
            streamingMovie.Runtime.ShouldBe(128U);
            streamingMovie.Country.ShouldBe("us");
            streamingMovie.Trailer.ShouldBe("https://youtube.com/watch?v=Idh8n5XuYIA");
            streamingMovie.Homepage.ShouldBe("http://www.marvel.com/movies/deadpool-and-wolverine");
            streamingMovie.Status.ShouldBe(TraktMovieStatus.Released);
            streamingMovie.Rating.ShouldBe(8.244876693296284f);
            streamingMovie.Votes.ShouldBe(5758U);
            streamingMovie.CommentCount.ShouldBe(159U);
            streamingMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z"));
            streamingMovie.Language.ShouldBe("en");
            streamingMovie.Languages.ShouldNotBeNull();
            streamingMovie.Languages.Count.ShouldBe(1);
            streamingMovie.Languages.ShouldBe(["en"], Case.Sensitive);

            streamingMovie.Genres.ShouldNotBeNull();
            streamingMovie.Genres.Count.ShouldBe(4);
            streamingMovie.Genres.ShouldBe(["comedy", "superhero", "science-fiction", "action"], Case.Sensitive);

            streamingMovie.Certification.ShouldBe("R");
        }
    }
}
