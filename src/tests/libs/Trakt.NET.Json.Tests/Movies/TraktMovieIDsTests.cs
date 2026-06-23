namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieIDsTests
    {
        [Fact]
        public void TestTraktMovieIDsConstructor()
        {
            var movieIDs = new TraktMovieIDs();

            movieIDs.Trakt.ShouldBeNull();
            movieIDs.Slug.ShouldBeNull();
            movieIDs.IMDB.ShouldBeNull();
            movieIDs.TMDB.ShouldBeNull();

            movieIDs.HasAnyID.ShouldBe(false);
            movieIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktMovieIDsHasAnyId()
        {
            var movieIDs = new TraktMovieIDs { Trakt = 1 };
            movieIDs.HasAnyID.ShouldBeTrue();

            movieIDs = new TraktMovieIDs { Trakt = 0 };
            movieIDs.HasAnyID.ShouldBeFalse();

            movieIDs = new TraktMovieIDs { Slug = "slug" };
            movieIDs.HasAnyID.ShouldBeTrue();

            movieIDs = new TraktMovieIDs { IMDB = "imdb" };
            movieIDs.HasAnyID.ShouldBeTrue();

            movieIDs = new TraktMovieIDs { TMDB = 1 };
            movieIDs.HasAnyID.ShouldBeTrue();

            movieIDs = new TraktMovieIDs { TMDB = 0 };
            movieIDs.HasAnyID.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktMovieIDsGetBestID()
        {
            var movieIDs = new TraktMovieIDs();

            string bestID = movieIDs.BestID;
            bestID.ShouldNotBeNull();

            movieIDs = new TraktMovieIDs { Trakt = 1 };

            bestID = movieIDs.BestID;
            bestID.ShouldBe("1");

            movieIDs = new TraktMovieIDs { Trakt = 0 };

            bestID = movieIDs.BestID;
            bestID.ShouldBe("");

            movieIDs = new TraktMovieIDs { Slug = "slug" };

            bestID = movieIDs.BestID;
            bestID.ShouldBe("slug");

            movieIDs = new TraktMovieIDs { IMDB = "imdb" };

            bestID = movieIDs.BestID;
            bestID.ShouldBe("imdb");

            movieIDs = new TraktMovieIDs { TMDB = 1 };

            bestID = movieIDs.BestID;
            bestID.ShouldBe("1");

            movieIDs = new TraktMovieIDs { TMDB = 0 };

            bestID = movieIDs.BestID;
            bestID.ShouldBe("");

            movieIDs = new TraktMovieIDs
            {
                Slug = "slug",
                Trakt = 1,
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = movieIDs.BestID;
            bestID.ShouldBe("slug");

            movieIDs = new TraktMovieIDs
            {
                Trakt = 1,
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = movieIDs.BestID;
            bestID.ShouldBe("1");

            movieIDs = new TraktMovieIDs
            {
                IMDB = "imdb",
                TMDB = 1
            };

            bestID = movieIDs.BestID;
            bestID.ShouldBe("imdb");

            movieIDs = new TraktMovieIDs
            {
                TMDB = 1
            };

            bestID = movieIDs.BestID;
            bestID.ShouldBe("1");
        }

        [Fact]
        public async Task TestTraktMovieIDsFromJson()
        {
            TraktMovieIDs? movieIDs = await TestUtility.DeserializeJsonAsync<TraktMovieIDs>("Movies\\movieids.json");

            movieIDs.ShouldNotBeNull();

            movieIDs!.Trakt.ShouldBe(293990U);
            movieIDs!.Slug.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
            movieIDs!.IMDB.ShouldBe("tt6791350");
            movieIDs!.TMDB.ShouldBe(447365U);

            movieIDs!.HasAnyID.ShouldBe(true);
            movieIDs!.BestID.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
        }
    }
}
