namespace TraktNET.Json.Watchlist
{
    public sealed class TraktWatchlistItemTests
    {
        [Fact]
        public void TestTraktWatchlistItemDefaultConstructor()
        {
            var watchlistItem = new TraktWatchlistItem();

            watchlistItem.Id.ShouldBeNull();
            watchlistItem.Rank.ShouldBeNull();
            watchlistItem.ListedAt.ShouldBeNull();
            watchlistItem.Notes.ShouldBeNull();
            watchlistItem.Type.ShouldBeNull();
            watchlistItem.Movie.ShouldBeNull();
            watchlistItem.Show.ShouldBeNull();
            watchlistItem.Season.ShouldBeNull();
            watchlistItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchlistItemWithTypeMovieFromMinimalJson()
        {
            TraktWatchlistItem? watchlistItem = await TestUtility.DeserializeJsonAsync<TraktWatchlistItem>("Watchlist\\watchlistitemmovie_minimal.json");

            watchlistItem.ShouldNotBeNull();
            watchlistItem.Id.ShouldBe(101U);
            watchlistItem.Rank.ShouldBe(1);
            watchlistItem.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            watchlistItem.Notes.ShouldBe("list item notes");
            watchlistItem.Type.ShouldBe(TraktSyncItemType.Movie);
            watchlistItem.Movie.ShouldNotBeNull();
            watchlistItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            watchlistItem.Movie.Year.ShouldBe(2015U);
            watchlistItem.Movie.IDs.ShouldNotBeNull();
            watchlistItem.Movie.IDs.Trakt.ShouldBe(94024U);
            watchlistItem.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            watchlistItem.Movie.IDs.IMDB.ShouldBe("tt2488496");
            watchlistItem.Movie.IDs.TMDB.ShouldBe(140607U);
            watchlistItem.Movie.Tagline.ShouldBeNullOrEmpty();
            watchlistItem.Movie.Overview.ShouldBeNullOrEmpty();
            watchlistItem.Movie.Released.ShouldBeNull();
            watchlistItem.Movie.Runtime.ShouldBeNull();
            watchlistItem.Movie.UpdatedAt.ShouldBeNull();
            watchlistItem.Movie.Trailer.ShouldBeNullOrEmpty();
            watchlistItem.Movie.Homepage.ShouldBeNullOrEmpty();
            watchlistItem.Movie.Rating.ShouldBeNull();
            watchlistItem.Movie.Votes.ShouldBeNull();
            watchlistItem.Movie.Language.ShouldBeNullOrEmpty();
            watchlistItem.Movie.AvailableTranslations.ShouldBeNull();
            watchlistItem.Movie.Genres.ShouldBeNull();
            watchlistItem.Movie.Certification.ShouldBeNullOrEmpty();
            watchlistItem.Show.ShouldBeNull();
            watchlistItem.Season.ShouldBeNull();
            watchlistItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchlistItemWithTypeShowFromMinimalJson()
        {
            TraktWatchlistItem? watchlistItem = await TestUtility.DeserializeJsonAsync<TraktWatchlistItem>("Watchlist\\watchlistitemshow_minimal.json");

            watchlistItem.ShouldNotBeNull();
            watchlistItem.Id.ShouldBe(101U);
            watchlistItem.Rank.ShouldBe(1);
            watchlistItem.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            watchlistItem.Notes.ShouldBe("list item notes");
            watchlistItem.Type.ShouldBe(TraktSyncItemType.Show);
            watchlistItem.Movie.ShouldBeNull();
            watchlistItem.Show.ShouldNotBeNull();
            watchlistItem.Show.Title.ShouldBe("Game of Thrones");
            watchlistItem.Show.Year.ShouldBe(2011U);
            watchlistItem.Show.Airs.ShouldBeNull();
            watchlistItem.Show.AvailableTranslations.ShouldBeNull();
            watchlistItem.Show.IDs.ShouldNotBeNull();
            watchlistItem.Show.IDs.Trakt.ShouldBe(1390U);
            watchlistItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            watchlistItem.Show.IDs.TVDB.ShouldBe(121361U);
            watchlistItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            watchlistItem.Show.IDs.TMDB.ShouldBe(1399U);
            watchlistItem.Show.Genres.ShouldBeNull();
            watchlistItem.Show.Overview.ShouldBeNullOrEmpty();
            watchlistItem.Show.FirstAired.ShouldBeNull();
            watchlistItem.Show.Runtime.ShouldBeNull();
            watchlistItem.Show.Certification.ShouldBeNullOrEmpty();
            watchlistItem.Show.Network.ShouldBeNullOrEmpty();
            watchlistItem.Show.Country.ShouldBeNullOrEmpty();
            watchlistItem.Show.UpdatedAt.ShouldBeNull();
            watchlistItem.Show.Trailer.ShouldBeNullOrEmpty();
            watchlistItem.Show.Homepage.ShouldBeNullOrEmpty();
            watchlistItem.Show.Status.ShouldBeNull();
            watchlistItem.Show.Rating.ShouldBeNull();
            watchlistItem.Show.Votes.ShouldBeNull();
            watchlistItem.Show.Language.ShouldBeNullOrEmpty();
            watchlistItem.Show.AiredEpisodes.ShouldBeNull();
            watchlistItem.Season.ShouldBeNull();
            watchlistItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchlistItemWithTypeSeasonFromMinimalJson()
        {
            TraktWatchlistItem? watchlistItem = await TestUtility.DeserializeJsonAsync<TraktWatchlistItem>("Watchlist\\watchlistitemseason_minimal.json");

            watchlistItem.ShouldNotBeNull();
            watchlistItem.Id.ShouldBe(101U);
            watchlistItem.Rank.ShouldBe(1);
            watchlistItem.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            watchlistItem.Notes.ShouldBe("list item notes");
            watchlistItem.Type.ShouldBe(TraktSyncItemType.Season);
            watchlistItem.Movie.ShouldBeNull();
            watchlistItem.Show.ShouldBeNull();
            watchlistItem.Season.ShouldNotBeNull();
            watchlistItem.Season.Number.ShouldBe(1U);
            watchlistItem.Season.IDs.ShouldNotBeNull();
            watchlistItem.Season.IDs.Trakt.ShouldBe(61430U);
            watchlistItem.Season.IDs.TVDB.ShouldBe(279121U);
            watchlistItem.Season.IDs.TMDB.ShouldBe(60523U);
            watchlistItem.Season.Rating.ShouldBeNull();
            watchlistItem.Season.Votes.ShouldBeNull();
            watchlistItem.Season.EpisodeCount.ShouldBeNull();
            watchlistItem.Season.AiredEpisodes.ShouldBeNull();
            watchlistItem.Season.Overview.ShouldBeNullOrEmpty();
            watchlistItem.Season.FirstAired.ShouldBeNull();
            watchlistItem.Season.Episodes.ShouldBeNull();
            watchlistItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchlistItemWithTypeEpisodeFromMinimalJson()
        {
            TraktWatchlistItem? watchlistItem = await TestUtility.DeserializeJsonAsync<TraktWatchlistItem>("Watchlist\\watchlistitemepisode_minimal.json");

            watchlistItem.ShouldNotBeNull();
            watchlistItem.Id.ShouldBe(101U);
            watchlistItem.Rank.ShouldBe(1);
            watchlistItem.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            watchlistItem.Notes.ShouldBe("list item notes");
            watchlistItem.Type.ShouldBe(TraktSyncItemType.Episode);
            watchlistItem.Movie.ShouldBeNull();
            watchlistItem.Show.ShouldNotBeNull();
            watchlistItem.Show.Title.ShouldBe("Game of Thrones");
            watchlistItem.Show.Year.ShouldBe(2011U);
            watchlistItem.Show.Airs.ShouldBeNull();
            watchlistItem.Show.AvailableTranslations.ShouldBeNull();
            watchlistItem.Show.IDs.ShouldNotBeNull();
            watchlistItem.Show.IDs.Trakt.ShouldBe(1390U);
            watchlistItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            watchlistItem.Show.IDs.TVDB.ShouldBe(121361U);
            watchlistItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            watchlistItem.Show.IDs.TMDB.ShouldBe(1399U);
            watchlistItem.Show.Genres.ShouldBeNull();
            watchlistItem.Show.Overview.ShouldBeNullOrEmpty();
            watchlistItem.Show.FirstAired.ShouldBeNull();
            watchlistItem.Show.Runtime.ShouldBeNull();
            watchlistItem.Show.Certification.ShouldBeNullOrEmpty();
            watchlistItem.Show.Network.ShouldBeNullOrEmpty();
            watchlistItem.Show.Country.ShouldBeNullOrEmpty();
            watchlistItem.Show.UpdatedAt.ShouldBeNull();
            watchlistItem.Show.Trailer.ShouldBeNullOrEmpty();
            watchlistItem.Show.Homepage.ShouldBeNullOrEmpty();
            watchlistItem.Show.Status.ShouldBeNull();
            watchlistItem.Show.Rating.ShouldBeNull();
            watchlistItem.Show.Votes.ShouldBeNull();
            watchlistItem.Show.Language.ShouldBeNullOrEmpty();
            watchlistItem.Show.AiredEpisodes.ShouldBeNull();
            watchlistItem.Season.ShouldBeNull();
            watchlistItem.Episode.ShouldNotBeNull();
            watchlistItem.Episode.Season.ShouldBe(1U);
            watchlistItem.Episode.Number.ShouldBe(1U);
            watchlistItem.Episode.Title.ShouldBe("Winter Is Coming");
            watchlistItem.Episode.IDs.ShouldNotBeNull();
            watchlistItem.Episode.IDs.Trakt.ShouldBe(73640U);
            watchlistItem.Episode.IDs.TVDB.ShouldBe(3254641U);
            watchlistItem.Episode.IDs.IMDB.ShouldBe("tt1480055");
            watchlistItem.Episode.IDs.TMDB.ShouldBe(63056U);
            watchlistItem.Episode.NumberAbsolute.ShouldBeNull();
            watchlistItem.Episode.Overview.ShouldBeNullOrEmpty();
            watchlistItem.Episode.Runtime.ShouldBeNull();
            watchlistItem.Episode.Rating.ShouldBeNull();
            watchlistItem.Episode.Votes.ShouldBeNull();
            watchlistItem.Episode.FirstAired.ShouldBeNull();
            watchlistItem.Episode.UpdatedAt.ShouldBeNull();
            watchlistItem.Episode.AvailableTranslations.ShouldBeNull();
            watchlistItem.Episode.Translations.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchlistItemWithTypeMovieFromFullJson()
        {
            TraktWatchlistItem? watchlistItem = await TestUtility.DeserializeJsonAsync<TraktWatchlistItem>("Watchlist\\watchlistitemmovie.json");

            watchlistItem.ShouldNotBeNull();
            watchlistItem.Id.ShouldBe(101U);
            watchlistItem.Rank.ShouldBe(1);
            watchlistItem.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            watchlistItem.Notes.ShouldBe("list item notes");
            watchlistItem.Type.ShouldBe(TraktSyncItemType.Movie);
            watchlistItem.Movie.ShouldNotBeNull();
            watchlistItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            watchlistItem.Movie.Year.ShouldBe(2015U);
            watchlistItem.Movie.IDs.ShouldNotBeNull();
            watchlistItem.Movie.IDs.Trakt.ShouldBe(94024U);
            watchlistItem.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            watchlistItem.Movie.IDs.IMDB.ShouldBe("tt2488496");
            watchlistItem.Movie.IDs.TMDB.ShouldBe(140607U);
            watchlistItem.Movie.Tagline.ShouldBe("Every generation has a story.");
            watchlistItem.Movie.Overview.ShouldBe("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
#if NET7_0_OR_GREATER
            watchlistItem.Movie.Released.ShouldBe(TestUtility.ParseDate("2015-12-18"));
#else
            watchlistItem.Movie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2015-12-18T00:00:00.000Z"));
#endif
            watchlistItem.Movie.Runtime.ShouldBe(136U);
            watchlistItem.Movie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-03-31T09:01:59Z"));
            watchlistItem.Movie.Trailer.ShouldBe("http://youtube.com/watch?v=uwa7N0ShN2U");
            watchlistItem.Movie.Homepage.ShouldBe("http://www.starwars.com/films/star-wars-episode-vii");
            watchlistItem.Movie.Rating.ShouldBe(8.31988f);
            watchlistItem.Movie.Votes.ShouldBe(9338U);
            watchlistItem.Movie.Language.ShouldBe("en");
            watchlistItem.Movie.AvailableTranslations.ShouldNotBeNull();
            watchlistItem.Movie.AvailableTranslations.Count.ShouldBe(4);
            watchlistItem.Movie.AvailableTranslations.ShouldBe(["en", "de", "en", "it"]);
            watchlistItem.Movie.Genres.ShouldNotBeNull();
            watchlistItem.Movie.Genres.Count.ShouldBe(4);
            watchlistItem.Movie.Genres.ShouldBe(["action", "adventure", "fantasy", "science-fiction"]);
            watchlistItem.Movie.Certification.ShouldBe("PG-13");
            watchlistItem.Show.ShouldBeNull();
            watchlistItem.Season.ShouldBeNull();
            watchlistItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchlistItemWithTypeShowFromFullJson()
        {
            TraktWatchlistItem? watchlistItem = await TestUtility.DeserializeJsonAsync<TraktWatchlistItem>("Watchlist\\watchlistitemshow.json");

            watchlistItem.ShouldNotBeNull();
            watchlistItem.Id.ShouldBe(101U);
            watchlistItem.Rank.ShouldBe(1);
            watchlistItem.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            watchlistItem.Notes.ShouldBe("list item notes");
            watchlistItem.Type.ShouldBe(TraktSyncItemType.Show);
            watchlistItem.Movie.ShouldBeNull();
            watchlistItem.Show.ShouldNotBeNull();
            watchlistItem.Show.Title.ShouldBe("Game of Thrones");
            watchlistItem.Show.Year.ShouldBe(2011U);
            watchlistItem.Show.Airs.ShouldNotBeNull();
            watchlistItem.Show.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            watchlistItem.Show.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            watchlistItem.Show.Airs.Time.ShouldBe("21:00");
#endif
            watchlistItem.Show.Airs.Timezone.ShouldBe("America/New_York");
            watchlistItem.Show.AvailableTranslations.ShouldNotBeNull();
            watchlistItem.Show.AvailableTranslations.Count.ShouldBe(4);
            watchlistItem.Show.AvailableTranslations.ShouldBe(["en", "fr", "it", "de"]);
            watchlistItem.Show.IDs.ShouldNotBeNull();
            watchlistItem.Show.IDs.Trakt.ShouldBe(1390U);
            watchlistItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            watchlistItem.Show.IDs.TVDB.ShouldBe(121361U);
            watchlistItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            watchlistItem.Show.IDs.TMDB.ShouldBe(1399U);
            watchlistItem.Show.Genres.ShouldNotBeNull();
            watchlistItem.Show.Genres.Count.ShouldBe(5);
            watchlistItem.Show.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"]);
            watchlistItem.Show.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            watchlistItem.Show.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T07:00:00Z"));
            watchlistItem.Show.Runtime.ShouldBe(60U);
            watchlistItem.Show.Certification.ShouldBe("TV-MA");
            watchlistItem.Show.Network.ShouldBe("HBO");
            watchlistItem.Show.Country.ShouldBe("us");
            watchlistItem.Show.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T10:39:11Z"));
            watchlistItem.Show.Trailer.ShouldBe("http://youtube.com/watch?v=F9Bo89m2f6g");
            watchlistItem.Show.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            watchlistItem.Show.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            watchlistItem.Show.Rating.ShouldBe(9.38327f);
            watchlistItem.Show.Votes.ShouldBe(44773U);
            watchlistItem.Show.Language.ShouldBe("en");
            watchlistItem.Show.AiredEpisodes.ShouldBe(50U);
            watchlistItem.Season.ShouldBeNull();
            watchlistItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchlistItemWithTypeSeasonFromFullJson()
        {
            TraktWatchlistItem? watchlistItem = await TestUtility.DeserializeJsonAsync<TraktWatchlistItem>("Watchlist\\watchlistitemseason.json");

            watchlistItem.ShouldNotBeNull();
            watchlistItem.Id.ShouldBe(101U);
            watchlistItem.Rank.ShouldBe(1);
            watchlistItem.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            watchlistItem.Notes.ShouldBe("list item notes");
            watchlistItem.Type.ShouldBe(TraktSyncItemType.Season);
            watchlistItem.Movie.ShouldBeNull();
            watchlistItem.Show.ShouldBeNull();
            watchlistItem.Season.ShouldNotBeNull();
            watchlistItem.Season.Number.ShouldBe(1U);
            watchlistItem.Season.IDs.ShouldNotBeNull();
            watchlistItem.Season.IDs.Trakt.ShouldBe(61430U);
            watchlistItem.Season.IDs.TVDB.ShouldBe(279121U);
            watchlistItem.Season.IDs.TMDB.ShouldBe(60523U);
            watchlistItem.Season.Rating.ShouldBe(8.57053f);
            watchlistItem.Season.Votes.ShouldBe(794U);
            watchlistItem.Season.EpisodeCount.ShouldBe(23U);
            watchlistItem.Season.AiredEpisodes.ShouldBe(23U);
            watchlistItem.Season.Overview.ShouldBe("Text text text");
            watchlistItem.Season.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-08T00:00:00.000Z"));
            watchlistItem.Season.Episodes.ShouldNotBeNull();
            watchlistItem.Season.Episodes.Count.ShouldBe(2);

            var episodes = watchlistItem.Season.Episodes.ToArray();

            episodes[0].ShouldNotBeNull();
            episodes[0].Season.ShouldBe(1U);
            episodes[0].Number.ShouldBe(1U);
            episodes[0].Title.ShouldBe("Winter Is Coming");
            episodes[0].IDs.ShouldNotBeNull();
            episodes[0].IDs!.Trakt.ShouldBe(73640U);
            episodes[0].IDs!.TVDB.ShouldBe(3254641U);
            episodes[0].IDs!.IMDB.ShouldBe("tt1480055");
            episodes[0].IDs!.TMDB.ShouldBe(63056U);
            episodes[0].NumberAbsolute.ShouldBeNull();
            episodes[0].Overview.ShouldBeNullOrEmpty();
            episodes[0].Runtime.ShouldBeNull();
            episodes[0].Rating.ShouldBeNull();
            episodes[0].Votes.ShouldBeNull();
            episodes[0].FirstAired.ShouldBeNull();
            episodes[0].UpdatedAt.ShouldBeNull();
            episodes[0].AvailableTranslations.ShouldBeNull();
            episodes[0].Translations.ShouldBeNull();

            episodes[1].ShouldNotBeNull();
            episodes[1].Season.ShouldBe(1U);
            episodes[1].Number.ShouldBe(2U);
            episodes[1].Title.ShouldBe("The Kingsroad");
            episodes[1].IDs.ShouldNotBeNull();
            episodes[1].IDs!.Trakt.ShouldBe(74138U);
            episodes[1].IDs!.TVDB.ShouldBe(3436411U);
            episodes[1].IDs!.IMDB.ShouldBe("tt1668746");
            episodes[1].IDs!.TMDB.ShouldBe(63141U);
            episodes[1].NumberAbsolute.ShouldBeNull();
            episodes[1].Overview.ShouldBeNullOrEmpty();
            episodes[1].Runtime.ShouldBeNull();
            episodes[1].Rating.ShouldBeNull();
            episodes[1].Votes.ShouldBeNull();
            episodes[1].FirstAired.ShouldBeNull();
            episodes[1].UpdatedAt.ShouldBeNull();
            episodes[1].AvailableTranslations.ShouldBeNull();
            episodes[1].Translations.ShouldBeNull();

            watchlistItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchlistItemWithTypeEpisodeFromFullJson()
        {
            TraktWatchlistItem? watchlistItem = await TestUtility.DeserializeJsonAsync<TraktWatchlistItem>("Watchlist\\watchlistitemepisode.json");

            watchlistItem.ShouldNotBeNull();
            watchlistItem.Id.ShouldBe(101U);
            watchlistItem.Rank.ShouldBe(1);
            watchlistItem.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            watchlistItem.Notes.ShouldBe("list item notes");
            watchlistItem.Type.ShouldBe(TraktSyncItemType.Episode);
            watchlistItem.Movie.ShouldBeNull();
            watchlistItem.Show.ShouldNotBeNull();
            watchlistItem.Show.Title.ShouldBe("Game of Thrones");
            watchlistItem.Show.Year.ShouldBe(2011U);
            watchlistItem.Show.Airs.ShouldNotBeNull();
            watchlistItem.Show.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            watchlistItem.Show.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            watchlistItem.Show.Airs.Time.ShouldBe("21:00");
#endif
            watchlistItem.Show.Airs.Timezone.ShouldBe("America/New_York");
            watchlistItem.Show.AvailableTranslations.ShouldNotBeNull();
            watchlistItem.Show.AvailableTranslations.Count.ShouldBe(4);
            watchlistItem.Show.AvailableTranslations.ShouldBe(["en", "fr", "it", "de"]);
            watchlistItem.Show.IDs.ShouldNotBeNull();
            watchlistItem.Show.IDs.Trakt.ShouldBe(1390U);
            watchlistItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            watchlistItem.Show.IDs.TVDB.ShouldBe(121361U);
            watchlistItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            watchlistItem.Show.IDs.TMDB.ShouldBe(1399U);
            watchlistItem.Show.Genres.ShouldNotBeNull();
            watchlistItem.Show.Genres.Count.ShouldBe(5);
            watchlistItem.Show.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"]);
            watchlistItem.Show.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            watchlistItem.Show.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T07:00:00Z"));
            watchlistItem.Show.Runtime.ShouldBe(60U);
            watchlistItem.Show.Certification.ShouldBe("TV-MA");
            watchlistItem.Show.Network.ShouldBe("HBO");
            watchlistItem.Show.Country.ShouldBe("us");
            watchlistItem.Show.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T10:39:11Z"));
            watchlistItem.Show.Trailer.ShouldBe("http://youtube.com/watch?v=F9Bo89m2f6g");
            watchlistItem.Show.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            watchlistItem.Show.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            watchlistItem.Show.Rating.ShouldBe(9.38327f);
            watchlistItem.Show.Votes.ShouldBe(44773U);
            watchlistItem.Show.Language.ShouldBe("en");
            watchlistItem.Show.AiredEpisodes.ShouldBe(50U);
            watchlistItem.Season.ShouldBeNull();
            watchlistItem.Episode.ShouldNotBeNull();
            watchlistItem.Episode.Season.ShouldBe(1U);
            watchlistItem.Episode.Number.ShouldBe(1U);
            watchlistItem.Episode.Title.ShouldBe("Winter Is Coming");
            watchlistItem.Episode.IDs.ShouldNotBeNull();
            watchlistItem.Episode.IDs.Trakt.ShouldBe(73640U);
            watchlistItem.Episode.IDs.TVDB.ShouldBe(3254641U);
            watchlistItem.Episode.IDs.IMDB.ShouldBe("tt1480055");
            watchlistItem.Episode.IDs.TMDB.ShouldBe(63056U);
            watchlistItem.Episode.NumberAbsolute.ShouldBe(50U);
            watchlistItem.Episode.Overview.ShouldBe("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            watchlistItem.Episode.Runtime.ShouldBe(55U);
            watchlistItem.Episode.Rating.ShouldBe(9.0f);
            watchlistItem.Episode.Votes.ShouldBe(111U);
            watchlistItem.Episode.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            watchlistItem.Episode.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-08-29T23:16:39.000Z"));
            watchlistItem.Episode.AvailableTranslations.ShouldNotBeNull();
            watchlistItem.Episode.AvailableTranslations.Count.ShouldBe(2);
            watchlistItem.Episode.AvailableTranslations.ShouldBe(["en", "es"]);
            watchlistItem.Episode.Translations.ShouldNotBeNull();
            watchlistItem.Episode.Translations.Count.ShouldBe(2);

            var translations = watchlistItem.Episode.Translations.ToArray();

            translations[0].ShouldNotBeNull();
            translations[0].Title.ShouldBe("Winter Is Coming");
            translations[0].Overview.ShouldBe("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].Language.ShouldBe("en");

            translations[1].ShouldNotBeNull();
            translations[1].Title.ShouldBe("Se acerca el invierno");
            translations[1].Overview.ShouldBe("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].Language.ShouldBe("es");
        }
    }
}
