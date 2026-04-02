namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncFavoritesPostTests
    {
        [Fact]
        public void TestTraktSyncFavoritesPostDefaultConstructor()
        {
            var syncFavoritesPost = new TraktSyncFavoritesPost();

            syncFavoritesPost.Movies.ShouldBeNull();
            syncFavoritesPost.Shows.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncFavoritesPostFromJson()
        {
            TraktSyncFavoritesPost? syncFavoritesPost = await TestUtility.DeserializeJsonAsync<TraktSyncFavoritesPost>("Syncs\\Favorites\\syncfavoritespost.json");

            syncFavoritesPost.ShouldNotBeNull();

            syncFavoritesPost.Movies.ShouldNotBeNull();
            syncFavoritesPost.Movies.Count.ShouldBe(2);

            TraktSyncFavoritesPostMovie[] postMovies = [.. syncFavoritesPost.Movies];

            postMovies[0].Title.ShouldBe("Batman Begins");
            postMovies[0].Year.ShouldBe(2005U);
            postMovies[0].IDs.ShouldNotBeNull();
            postMovies[0].IDs!.Trakt.ShouldBe(1U);
            postMovies[0].IDs!.Slug.ShouldBe("batman-begins-2005");
            postMovies[0].IDs!.IMDB.ShouldBe("tt0372784");
            postMovies[0].IDs!.TMDB.ShouldBe(272U);
            postMovies[0].Notes.ShouldBe("One of Chritian Bale's most iconic roles.");

            postMovies[1].Title.ShouldBeNull();
            postMovies[1].Year.ShouldBeNull();
            postMovies[1].IDs.ShouldNotBeNull();
            postMovies[1].IDs!.Trakt.ShouldBeNull();
            postMovies[1].IDs!.Slug.ShouldBeNull();
            postMovies[1].IDs!.IMDB.ShouldBe("tt0000111");
            postMovies[1].IDs!.TMDB.ShouldBeNull();
            postMovies[1].Notes.ShouldBeNull();

            syncFavoritesPost.Shows.ShouldNotBeNull();
            syncFavoritesPost.Shows.Count.ShouldBe(2);

            TraktSyncFavoritesPostShow[] postShows = [.. syncFavoritesPost.Shows];

            postShows[0].Title.ShouldBe("Breaking Bad");
            postShows[0].Year.ShouldBe(2008U);
            postShows[0].IDs.ShouldNotBeNull();
            postShows[0].IDs!.Trakt.ShouldBe(1U);
            postShows[0].IDs!.Slug.ShouldBe("breaking-bad");
            postShows[0].IDs!.TVDB.ShouldBe(81189U);
            postShows[0].IDs!.IMDB.ShouldBe("tt0903747");
            postShows[0].IDs!.TMDB.ShouldBe(1396U);
            postShows[0].Notes.ShouldBe("I AM THE DANGER!");

            postShows[1].Title.ShouldBe("The Walking Dead");
            postShows[1].Year.ShouldBe(2010U);
            postShows[1].IDs.ShouldNotBeNull();
            postShows[1].IDs!.Trakt.ShouldBe(2U);
            postShows[1].IDs!.Slug.ShouldBe("the-walking-dead");
            postShows[1].IDs!.TVDB.ShouldBe(153021U);
            postShows[1].IDs!.IMDB.ShouldBe("tt1520211");
            postShows[1].IDs!.TMDB.ShouldBe(1402U);
            postShows[1].Notes.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSyncFavoritesPostValidate()
        {
            var syncFavoritesPost = new TraktSyncFavoritesPost();

            // movies = null, shows = null
            Action act = () => syncFavoritesPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null
            syncFavoritesPost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty
            syncFavoritesPost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty
            syncFavoritesPost.Movies.Add(new TraktSyncFavoritesPostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item
            syncFavoritesPost.Movies.Clear();
            syncFavoritesPost.Shows.Add(new TraktSyncFavoritesPostShow());
            act.ShouldNotThrow();
        }
    }
}
