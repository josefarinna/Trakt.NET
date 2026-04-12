namespace TraktNET.Json.Users
{
    public sealed class TraktFavoriteTests
    {
        [Fact]
        public void TestTraktFavoriteDefaultConstructor()
        {
            var favorite = new TraktFavorite();

            favorite.ID.ShouldBeNull();
            favorite.Rank.ShouldBeNull();
            favorite.ListedAt.ShouldBeNull();
            favorite.Type.ShouldBeNull();
            favorite.Notes.ShouldBeNull();
            favorite.Movie.ShouldBeNull();
            favorite.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktFavoriteFromJsonWithMovie()
        {
            TraktFavorite? favorite = await TestUtility.DeserializeJsonAsync<TraktFavorite>("Users\\favoritemovie.json");

            favorite.ShouldNotBeNull();
            favorite.ID.ShouldBe(101U);
            favorite.Rank.ShouldBe(1U);
            favorite.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            favorite.Type.ShouldBe(TraktFavoriteObjectType.Movie);
            favorite.Notes.ShouldBe("Daft Punk really knocks it out of the park on the soundtrack.");
            favorite.Movie.ShouldNotBeNull();
            favorite.Movie.Title.ShouldBe("TRON: Legacy");
            favorite.Movie.Year.ShouldBe(2010U);
            favorite.Movie.IDs.ShouldNotBeNull();
            favorite.Movie.IDs.Trakt.ShouldBe(1U);
            favorite.Movie.IDs.Slug.ShouldBe("tron-legacy-2010");
            favorite.Movie.IDs.IMDB.ShouldBe("tt1104001");
            favorite.Movie.IDs.TMDB.ShouldBe(20526U);
            favorite.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktFavoriteFromJsonWithShow()
        {
            TraktFavorite? favorite = await TestUtility.DeserializeJsonAsync<TraktFavorite>("Users\\favoriteshow.json");

            favorite.ShouldNotBeNull();
            favorite.ID.ShouldBe(102U);
            favorite.Rank.ShouldBe(1U);
            favorite.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            favorite.Type.ShouldBe(TraktFavoriteObjectType.Show);
            favorite.Notes.ShouldBe("Atmospheric for days.");
            favorite.Movie.ShouldBeNull();
            favorite.Show.ShouldNotBeNull();
            favorite.Show.Title.ShouldBe("The Walking Dead");
            favorite.Show.Year.ShouldBe(2010U);
            favorite.Show.IDs.ShouldNotBeNull();
            favorite.Show.IDs.Trakt.ShouldBe(2U);
            favorite.Show.IDs.Slug.ShouldBe("the-walking-dead");
            favorite.Show.IDs.TVDB.ShouldBe(153021U);
            favorite.Show.IDs.IMDB.ShouldBe("tt1520211");
            favorite.Show.IDs.TMDB.ShouldBe(1402U);
        }
    }
}
