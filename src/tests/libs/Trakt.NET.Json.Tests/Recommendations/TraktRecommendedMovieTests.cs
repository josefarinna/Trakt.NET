namespace TraktNET.Json.Recommendations
{
    public sealed class TraktRecommendedMovieTests
    {
        [Fact]
        public void TestTraktRecommendedMovieDefaultConstructor()
        {
            var recommendedMovie = new TraktRecommendedMovie();

            recommendedMovie.Title.ShouldBeNullOrEmpty();
            recommendedMovie.Year.ShouldBeNull();
            recommendedMovie.IDs.ShouldBeNull();
            recommendedMovie.Tagline.ShouldBeNullOrEmpty();
            recommendedMovie.Overview.ShouldBeNullOrEmpty();
            recommendedMovie.Released.ShouldBeNull();
            recommendedMovie.Runtime.ShouldBeNull();
            recommendedMovie.UpdatedAt.ShouldBeNull();
            recommendedMovie.Trailer.ShouldBeNullOrEmpty();
            recommendedMovie.Homepage.ShouldBeNullOrEmpty();
            recommendedMovie.Rating.ShouldBeNull();
            recommendedMovie.Votes.ShouldBeNull();
            recommendedMovie.Language.ShouldBeNullOrEmpty();
            recommendedMovie.AvailableTranslations.ShouldBeNull();
            recommendedMovie.Genres.ShouldBeNull();
            recommendedMovie.Certification.ShouldBeNullOrEmpty();
            recommendedMovie.Country.ShouldBeNullOrEmpty();
            recommendedMovie.Status.ShouldBeNull();
            recommendedMovie.FavoritedBy.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRecommendedMovieFromJson()
        {
            TraktRecommendedMovie? recommendedMovie = await TestUtility.DeserializeJsonAsync<TraktRecommendedMovie>("Recommendations\\recommendedmovie.json");

            recommendedMovie.ShouldNotBeNull();
            recommendedMovie.Title.ShouldBe("Star Wars: The Force Awakens");
            recommendedMovie.Year.ShouldBe(2015U);
            recommendedMovie.IDs.ShouldNotBeNull();
            recommendedMovie.IDs.Trakt.ShouldBe(94024U);
            recommendedMovie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            recommendedMovie.IDs.IMDB.ShouldBe("tt2488496");
            recommendedMovie.IDs.TMDB.ShouldBe(140607U);
            recommendedMovie.Tagline.ShouldBe("Every generation has a story.");
            recommendedMovie.Overview.ShouldBe("Thirty years after defeating the Galactic Empire,...");
#if NET7_0_OR_GREATER
            recommendedMovie.Released.ShouldBe(TestUtility.ParseDate("2015-12-18"));
#else
            recommendedMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2015-12-18T00:00:00.000Z"));
#endif
            recommendedMovie.Runtime.ShouldBe(136U);
            recommendedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-03-31T09:01:59Z"));
            recommendedMovie.Trailer.ShouldBe("http://youtube.com/watch?v=uwa7N0ShN2U");
            recommendedMovie.Homepage.ShouldBe("http://www.starwars.com/films/star-wars-episode-vii");
            recommendedMovie.Rating.ShouldBe(8.31988f);
            recommendedMovie.Votes.ShouldBe(9338U);
            recommendedMovie.Language.ShouldBe("en");
            recommendedMovie.AvailableTranslations.ShouldNotBeNull();
            recommendedMovie.AvailableTranslations.Count.ShouldBe(4);
            recommendedMovie.AvailableTranslations.ShouldBe(["en", "de", "en", "it"]);
            recommendedMovie.Genres.ShouldNotBeNull();
            recommendedMovie.Genres.Count.ShouldBe(4);
            recommendedMovie.Genres.ShouldBe(["action", "adventure", "fantasy", "science-fiction"]);
            recommendedMovie.Certification.ShouldBe("PG-13");
            recommendedMovie.Country.ShouldBe("us");
            recommendedMovie.Status.ShouldBe(TraktMovieStatus.Released);

            recommendedMovie.FavoritedBy.ShouldNotBeNull();
            recommendedMovie.FavoritedBy.Count.ShouldBe(1);

            TraktFavoritedBy favoritedBy = recommendedMovie.FavoritedBy.First();

            favoritedBy.ShouldNotBeNull();
            favoritedBy.User.ShouldNotBeNull();
            favoritedBy.User.Username.ShouldBe("sean");
            favoritedBy.User.Private.ShouldBe(false);
            favoritedBy.User.Name.ShouldBe("Sean Rudford");
            favoritedBy.User.VIP.ShouldBe(true);
            favoritedBy.User.VIPEP.ShouldBe(true);
            favoritedBy.User.IDs.ShouldNotBeNull();
            favoritedBy.User.IDs.Slug.ShouldBe("sean");
            favoritedBy.User.IDs.UUID.ShouldBe("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            favoritedBy.User.JoinedAt.ShouldBe(TestUtility.ParseUTCDateTime("2010-09-25T17:49:25.000Z"));
            favoritedBy.User.Location.ShouldBe("SF");
            favoritedBy.User.About.ShouldBe("I have all your cassette tapes.");
            favoritedBy.User.Gender.ShouldBe(TraktGender.Male);
            favoritedBy.User.Age.ShouldBe(35U);
            favoritedBy.User.Images.ShouldNotBeNull();
            favoritedBy.User.Images.Avatar.ShouldNotBeNull();
            favoritedBy.User.Images.Avatar.Full.ShouldBe("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            favoritedBy.User.VIPOG.ShouldBe(true);
            favoritedBy.User.VIPYears.ShouldBe(5U);
            favoritedBy.User.VIPCoverImage.ShouldBe("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            favoritedBy.Notes.ShouldBe("Favorited because ...");
        }
    }
}
