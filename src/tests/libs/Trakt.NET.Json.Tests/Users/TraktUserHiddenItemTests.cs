namespace TraktNET.Json.Users
{
    public sealed class TraktUserHiddenItemTests
    {
        [Fact]
        public void TestTraktUserHiddenItemDefaultConstructor()
        {
            var hiddenItem = new TraktUserHiddenItem();

            hiddenItem.HiddenAt.ShouldBeNull();
            hiddenItem.Type.ShouldBeNull();
            hiddenItem.Movie.ShouldBeNull();
            hiddenItem.Show.ShouldBeNull();
            hiddenItem.Season.ShouldBeNull();
            hiddenItem.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserHiddenItemWithTypeMovieJson()
        {
            TraktUserHiddenItem? hiddenItem = await TestUtility.DeserializeJsonAsync<TraktUserHiddenItem>("Users\\userhiddenitem_movie.json");

            hiddenItem.ShouldNotBeNull();
            hiddenItem.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            hiddenItem.Type.ShouldBe(TraktHiddenItemType.Movie);
            hiddenItem.Movie.ShouldNotBeNull();
            hiddenItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            hiddenItem.Movie.Year.ShouldBe(2015U);
            hiddenItem.Movie.IDs.ShouldNotBeNull();
            hiddenItem.Movie.IDs.Trakt.ShouldBe(94024U);
            hiddenItem.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            hiddenItem.Movie.IDs.IMDB.ShouldBe("tt2488496");
            hiddenItem.Movie.IDs.TMDB.ShouldBe(140607U);
            hiddenItem.Show.ShouldBeNull();
            hiddenItem.Season.ShouldBeNull();
            hiddenItem.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserHiddenItemWithTypeShowJson()
        {
            TraktUserHiddenItem? hiddenItem = await TestUtility.DeserializeJsonAsync<TraktUserHiddenItem>("Users\\userhiddenitem_show.json");

            hiddenItem.ShouldNotBeNull();
            hiddenItem.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            hiddenItem.Type.ShouldBe(TraktHiddenItemType.Show);
            hiddenItem.Show.ShouldNotBeNull();
            hiddenItem.Show.Title.ShouldBe("Game of Thrones");
            hiddenItem.Show.Year.ShouldBe(2011U);
            hiddenItem.Show.IDs.ShouldNotBeNull();
            hiddenItem.Show.IDs.Trakt.ShouldBe(1390U);
            hiddenItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            hiddenItem.Show.IDs.TVDB.ShouldBe(121361U);
            hiddenItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            hiddenItem.Show.IDs.TMDB.ShouldBe(1399U);
            hiddenItem.Movie.ShouldBeNull();
            hiddenItem.Season.ShouldBeNull();
            hiddenItem.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserHiddenItemWithTypeSeasonJson()
        {
            TraktUserHiddenItem? hiddenItem = await TestUtility.DeserializeJsonAsync<TraktUserHiddenItem>("Users\\userhiddenitem_season.json");

            hiddenItem.ShouldNotBeNull();
            hiddenItem.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            hiddenItem.Type.ShouldBe(TraktHiddenItemType.Season);
            hiddenItem.Season.ShouldNotBeNull();
            hiddenItem.Season.Number.ShouldBe(1U);
            hiddenItem.Season.IDs.ShouldNotBeNull();
            hiddenItem.Season.IDs.Trakt.ShouldBe(61430U);
            hiddenItem.Season.IDs.TVDB.ShouldBe(279121U);
            hiddenItem.Season.IDs.TMDB.ShouldBe(60523U);
            hiddenItem.Movie.ShouldBeNull();
            hiddenItem.Show.ShouldBeNull();
            hiddenItem.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserHiddenItemWithTypeUserJson()
        {
            TraktUserHiddenItem? hiddenItem = await TestUtility.DeserializeJsonAsync<TraktUserHiddenItem>("Users\\userhiddenitem_user.json");

            hiddenItem.ShouldNotBeNull();
            hiddenItem.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            hiddenItem.Type.ShouldBe(TraktHiddenItemType.User);
            hiddenItem.User.ShouldNotBeNull();
            hiddenItem.User.Username.ShouldBe("sean");
            hiddenItem.User.Private.ShouldBe(false);
            hiddenItem.User.Name.ShouldBe("Sean Rudford");
            hiddenItem.User.VIP.ShouldBe(true);
            hiddenItem.User.VIPEP.ShouldBe(true);
            hiddenItem.User.IDs.ShouldNotBeNull();
            hiddenItem.User.IDs.Slug.ShouldBe("sean");
            hiddenItem.User.IDs.UUID.ShouldBe("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            hiddenItem.Movie.ShouldBeNull();
            hiddenItem.Show.ShouldBeNull();
            hiddenItem.Season.ShouldBeNull();
        }
    }
}
