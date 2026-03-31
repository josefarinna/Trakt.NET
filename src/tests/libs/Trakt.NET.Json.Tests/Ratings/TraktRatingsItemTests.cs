namespace TraktNET.Json.Ratings
{
    public sealed class TraktRatingsItemTests
    {
        [Fact]
        public void TestTraktRatingsItemDefaultConstructor()
        {
            var ratingsItem = new TraktRatingsItem();

            ratingsItem.Rating.ShouldBeNull();
            ratingsItem.RatedAt.ShouldBeNull();
            ratingsItem.Type.ShouldBeNull();
            ratingsItem.Movie.ShouldBeNull();
            ratingsItem.Show.ShouldBeNull();
            ratingsItem.Season.ShouldBeNull();
            ratingsItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRatingsItemWithTypeMovieFromMinimalJson()
        {
            TraktRatingsItem? ratingsItem = await TestUtility.DeserializeJsonAsync<TraktRatingsItem>("Ratings\\ratingsitemmovie_minimal.json");

            ratingsItem.ShouldNotBeNull();
            ratingsItem.Rating.ShouldBe(10);
            ratingsItem.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            ratingsItem.Type.ShouldBe(TraktRatingsItemType.Movie);
            ratingsItem.Movie.ShouldNotBeNull();
            ratingsItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            ratingsItem.Movie.Year.ShouldBe(2015U);
            ratingsItem.Movie.IDs.ShouldNotBeNull();
            ratingsItem.Movie.IDs.Trakt.ShouldBe(94024U);
            ratingsItem.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            ratingsItem.Movie.IDs.IMDB.ShouldBe("tt2488496");
            ratingsItem.Movie.IDs.TMDB.ShouldBe(140607U);
            ratingsItem.Movie.Tagline.ShouldBeNullOrEmpty();
            ratingsItem.Movie.Overview.ShouldBeNullOrEmpty();
            ratingsItem.Movie.Released.ShouldBeNull();
            ratingsItem.Movie.Runtime.ShouldBeNull();
            ratingsItem.Movie.UpdatedAt.ShouldBeNull();
            ratingsItem.Movie.Trailer.ShouldBeNullOrEmpty();
            ratingsItem.Movie.Homepage.ShouldBeNullOrEmpty();
            ratingsItem.Movie.Rating.ShouldBeNull();
            ratingsItem.Movie.Votes.ShouldBeNull();
            ratingsItem.Movie.Language.ShouldBeNullOrEmpty();
            ratingsItem.Movie.AvailableTranslations.ShouldBeNull();
            ratingsItem.Movie.Genres.ShouldBeNull();
            ratingsItem.Movie.Certification.ShouldBeNullOrEmpty();
            ratingsItem.Show.ShouldBeNull();
            ratingsItem.Season.ShouldBeNull();
            ratingsItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRatingsItemWithTypeShowFromMinimalJson()
        {
            TraktRatingsItem? ratingsItem = await TestUtility.DeserializeJsonAsync<TraktRatingsItem>("Ratings\\ratingsitemshow_minimal.json");

            ratingsItem.ShouldNotBeNull();
            ratingsItem.Rating.ShouldBe(9);
            ratingsItem.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            ratingsItem.Type.ShouldBe(TraktRatingsItemType.Show);
            ratingsItem.Movie.ShouldBeNull();
            ratingsItem.Show.ShouldNotBeNull();
            ratingsItem.Show.Title.ShouldBe("Game of Thrones");
            ratingsItem.Show.Year.ShouldBe(2011U);
            ratingsItem.Show.Airs.ShouldBeNull();
            ratingsItem.Show.AvailableTranslations.ShouldBeNull();
            ratingsItem.Show.IDs.ShouldNotBeNull();
            ratingsItem.Show.IDs.Trakt.ShouldBe(1390U);
            ratingsItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            ratingsItem.Show.IDs.TVDB.ShouldBe(121361U);
            ratingsItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            ratingsItem.Show.IDs.TMDB.ShouldBe(1399U);
            ratingsItem.Show.Genres.ShouldBeNull();
            ratingsItem.Show.Overview.ShouldBeNullOrEmpty();
            ratingsItem.Show.FirstAired.ShouldBeNull();
            ratingsItem.Show.Runtime.ShouldBeNull();
            ratingsItem.Show.Certification.ShouldBeNullOrEmpty();
            ratingsItem.Show.Network.ShouldBeNullOrEmpty();
            ratingsItem.Show.Country.ShouldBeNullOrEmpty();
            ratingsItem.Show.UpdatedAt.ShouldBeNull();
            ratingsItem.Show.Trailer.ShouldBeNullOrEmpty();
            ratingsItem.Show.Homepage.ShouldBeNullOrEmpty();
            ratingsItem.Show.Status.ShouldBeNull();
            ratingsItem.Show.Rating.ShouldBeNull();
            ratingsItem.Show.Votes.ShouldBeNull();
            ratingsItem.Show.Language.ShouldBeNullOrEmpty();
            ratingsItem.Show.AiredEpisodes.ShouldBeNull();
            ratingsItem.Season.ShouldBeNull();
            ratingsItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRatingsItemWithTypeSeasonFromMinimalJson()
        {
            TraktRatingsItem? ratingsItem = await TestUtility.DeserializeJsonAsync<TraktRatingsItem>("Ratings\\ratingsitemseason_minimal.json");

            ratingsItem.ShouldNotBeNull();
            ratingsItem.Rating.ShouldBe(8);
            ratingsItem.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            ratingsItem.Type.ShouldBe(TraktRatingsItemType.Season);
            ratingsItem.Movie.ShouldBeNull();
            ratingsItem.Show.ShouldBeNull();
            ratingsItem.Season.ShouldNotBeNull();
            ratingsItem.Season.Number.ShouldBe(1U);
            ratingsItem.Season.IDs.ShouldNotBeNull();
            ratingsItem.Season.IDs.Trakt.ShouldBe(61430U);
            ratingsItem.Season.IDs.TVDB.ShouldBe(279121U);
            ratingsItem.Season.IDs.TMDB.ShouldBe(60523U);
            ratingsItem.Season.Rating.ShouldBeNull();
            ratingsItem.Season.Votes.ShouldBeNull();
            ratingsItem.Season.EpisodeCount.ShouldBeNull();
            ratingsItem.Season.AiredEpisodes.ShouldBeNull();
            ratingsItem.Season.Overview.ShouldBeNullOrEmpty();
            ratingsItem.Season.FirstAired.ShouldBeNull();
            ratingsItem.Season.Episodes.ShouldBeNull();
            ratingsItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRatingsItemWithTypeEpisodeFromMinimalJson()
        {
            TraktRatingsItem? ratingsItem = await TestUtility.DeserializeJsonAsync<TraktRatingsItem>("Ratings\\ratingsitemepisode_minimal.json");

            ratingsItem.ShouldNotBeNull();
            ratingsItem.Rating.ShouldBe(7);
            ratingsItem.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            ratingsItem.Type.ShouldBe(TraktRatingsItemType.Episode);
            ratingsItem.Movie.ShouldBeNull();
            ratingsItem.Show.ShouldNotBeNull();
            ratingsItem.Show.Title.ShouldBe("Game of Thrones");
            ratingsItem.Show.Year.ShouldBe(2011U);
            ratingsItem.Show.Airs.ShouldBeNull();
            ratingsItem.Show.AvailableTranslations.ShouldBeNull();
            ratingsItem.Show.IDs.ShouldNotBeNull();
            ratingsItem.Show.IDs.Trakt.ShouldBe(1390U);
            ratingsItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            ratingsItem.Show.IDs.TVDB.ShouldBe(121361U);
            ratingsItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            ratingsItem.Show.IDs.TMDB.ShouldBe(1399U);
            ratingsItem.Show.Genres.ShouldBeNull();
            ratingsItem.Show.Overview.ShouldBeNullOrEmpty();
            ratingsItem.Show.FirstAired.ShouldBeNull();
            ratingsItem.Show.Runtime.ShouldBeNull();
            ratingsItem.Show.Certification.ShouldBeNullOrEmpty();
            ratingsItem.Show.Network.ShouldBeNullOrEmpty();
            ratingsItem.Show.Country.ShouldBeNullOrEmpty();
            ratingsItem.Show.UpdatedAt.ShouldBeNull();
            ratingsItem.Show.Trailer.ShouldBeNullOrEmpty();
            ratingsItem.Show.Homepage.ShouldBeNullOrEmpty();
            ratingsItem.Show.Status.ShouldBeNull();
            ratingsItem.Show.Rating.ShouldBeNull();
            ratingsItem.Show.Votes.ShouldBeNull();
            ratingsItem.Show.Language.ShouldBeNullOrEmpty();
            ratingsItem.Show.AiredEpisodes.ShouldBeNull();
            ratingsItem.Season.ShouldBeNull();
            ratingsItem.Episode.ShouldNotBeNull();
            ratingsItem.Episode.Season.ShouldBe(1U);
            ratingsItem.Episode.Number.ShouldBe(1U);
            ratingsItem.Episode.Title.ShouldBe("Winter Is Coming");
            ratingsItem.Episode.IDs.ShouldNotBeNull();
            ratingsItem.Episode.IDs.Trakt.ShouldBe(73640U);
            ratingsItem.Episode.IDs.TVDB.ShouldBe(3254641U);
            ratingsItem.Episode.IDs.IMDB.ShouldBe("tt1480055");
            ratingsItem.Episode.IDs.TMDB.ShouldBe(63056U);
            ratingsItem.Episode.NumberAbsolute.ShouldBeNull();
            ratingsItem.Episode.Overview.ShouldBeNullOrEmpty();
            ratingsItem.Episode.Runtime.ShouldBeNull();
            ratingsItem.Episode.Rating.ShouldBeNull();
            ratingsItem.Episode.Votes.ShouldBeNull();
            ratingsItem.Episode.FirstAired.ShouldBeNull();
            ratingsItem.Episode.UpdatedAt.ShouldBeNull();
            ratingsItem.Episode.AvailableTranslations.ShouldBeNull();
            ratingsItem.Episode.Translations.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRatingsItemWithTypeMovieFromFullJson()
        {
            TraktRatingsItem? ratingsItem = await TestUtility.DeserializeJsonAsync<TraktRatingsItem>("Ratings\\ratingsitemmovie.json");

            ratingsItem.ShouldNotBeNull();
            ratingsItem.Rating.ShouldBe(10);
            ratingsItem.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            ratingsItem.Type.ShouldBe(TraktRatingsItemType.Movie);
            ratingsItem.Movie.ShouldNotBeNull();
            ratingsItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            ratingsItem.Movie.Year.ShouldBe(2015U);
            ratingsItem.Movie.IDs.ShouldNotBeNull();
            ratingsItem.Movie.IDs.Trakt.ShouldBe(94024U);
            ratingsItem.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            ratingsItem.Movie.IDs.IMDB.ShouldBe("tt2488496");
            ratingsItem.Movie.IDs.TMDB.ShouldBe(140607U);
            ratingsItem.Movie.Tagline.ShouldBe("Every generation has a story.");
            ratingsItem.Movie.Overview.ShouldBe("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
#if NET7_0_OR_GREATER
            ratingsItem.Movie.Released.ShouldBe(TestUtility.ParseDate("2015-12-18"));
#else
            ratingsItem.Movie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2015-12-18T00:00:00.000Z"));
#endif
            ratingsItem.Movie.Runtime.ShouldBe(136U);
            ratingsItem.Movie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-03-31T09:01:59Z"));
            ratingsItem.Movie.Trailer.ShouldBe("http://youtube.com/watch?v=uwa7N0ShN2U");
            ratingsItem.Movie.Homepage.ShouldBe("http://www.starwars.com/films/star-wars-episode-vii");
            ratingsItem.Movie.Rating.ShouldBe(8.31988f);
            ratingsItem.Movie.Votes.ShouldBe(9338U);
            ratingsItem.Movie.Language.ShouldBe("en");
            ratingsItem.Movie.AvailableTranslations.ShouldNotBeNull();
            ratingsItem.Movie.AvailableTranslations.Count.ShouldBe(4);
            ratingsItem.Movie.AvailableTranslations.ShouldBe(["en", "de", "en", "it"]);
            ratingsItem.Movie.Genres.ShouldNotBeNull();
            ratingsItem.Movie.Genres.Count.ShouldBe(4);
            ratingsItem.Movie.Genres.ShouldBe(["action", "adventure", "fantasy", "science-fiction"]);
            ratingsItem.Movie.Certification.ShouldBe("PG-13");
            ratingsItem.Show.ShouldBeNull();
            ratingsItem.Season.ShouldBeNull();
            ratingsItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRatingsItemWithTypeShowFromFullJson()
        {
            TraktRatingsItem? ratingsItem = await TestUtility.DeserializeJsonAsync<TraktRatingsItem>("Ratings\\ratingsitemshow.json");

            ratingsItem.ShouldNotBeNull();
            ratingsItem.Rating.ShouldBe(9);
            ratingsItem.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            ratingsItem.Type.ShouldBe(TraktRatingsItemType.Show);
            ratingsItem.Movie.ShouldBeNull();
            ratingsItem.Show.ShouldNotBeNull();
            ratingsItem.Show.Title.ShouldBe("Game of Thrones");
            ratingsItem.Show.Year.ShouldBe(2011U);
            ratingsItem.Show.Airs.ShouldNotBeNull();
            ratingsItem.Show.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            ratingsItem.Show.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            ratingsItem.Show.Airs.Time.ShouldBe("21:00");
#endif
            ratingsItem.Show.Airs.Timezone.ShouldBe("America/New_York");
            ratingsItem.Show.AvailableTranslations.ShouldNotBeNull();
            ratingsItem.Show.AvailableTranslations.Count.ShouldBe(4);
            ratingsItem.Show.AvailableTranslations.ShouldBe(["en", "fr", "it", "de"]);
            ratingsItem.Show.IDs.ShouldNotBeNull();
            ratingsItem.Show.IDs.Trakt.ShouldBe(1390U);
            ratingsItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            ratingsItem.Show.IDs.TVDB.ShouldBe(121361U);
            ratingsItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            ratingsItem.Show.IDs.TMDB.ShouldBe(1399U);
            ratingsItem.Show.Genres.ShouldNotBeNull();
            ratingsItem.Show.Genres.Count.ShouldBe(5);
            ratingsItem.Show.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"]);
            ratingsItem.Show.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            ratingsItem.Show.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T07:00:00Z"));
            ratingsItem.Show.Runtime.ShouldBe(60U);
            ratingsItem.Show.Certification.ShouldBe("TV-MA");
            ratingsItem.Show.Network.ShouldBe("HBO");
            ratingsItem.Show.Country.ShouldBe("us");
            ratingsItem.Show.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T10:39:11Z"));
            ratingsItem.Show.Trailer.ShouldBe("http://youtube.com/watch?v=F9Bo89m2f6g");
            ratingsItem.Show.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            ratingsItem.Show.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            ratingsItem.Show.Rating.ShouldBe(9.38327f);
            ratingsItem.Show.Votes.ShouldBe(44773U);
            ratingsItem.Show.Language.ShouldBe("en");
            ratingsItem.Show.AiredEpisodes.ShouldBe(50U);
            ratingsItem.Season.ShouldBeNull();
            ratingsItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRatingsItemWithTypeSeasonFromFullJson()
        {
            TraktRatingsItem? ratingsItem = await TestUtility.DeserializeJsonAsync<TraktRatingsItem>("Ratings\\ratingsitemseason.json");

            ratingsItem.ShouldNotBeNull();
            ratingsItem.Rating.ShouldBe(8);
            ratingsItem.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            ratingsItem.Type.ShouldBe(TraktRatingsItemType.Season);
            ratingsItem.Movie.ShouldBeNull();
            ratingsItem.Show.ShouldBeNull();
            ratingsItem.Season.ShouldNotBeNull();
            ratingsItem.Season.Number.ShouldBe(1U);
            ratingsItem.Season.IDs.ShouldNotBeNull();
            ratingsItem.Season.IDs.Trakt.ShouldBe(61430U);
            ratingsItem.Season.IDs.TVDB.ShouldBe(279121U);
            ratingsItem.Season.IDs.TMDB.ShouldBe(60523U);
            ratingsItem.Season.Rating.ShouldBe(8.57053f);
            ratingsItem.Season.Votes.ShouldBe(794U);
            ratingsItem.Season.EpisodeCount.ShouldBe(23U);
            ratingsItem.Season.AiredEpisodes.ShouldBe(23U);
            ratingsItem.Season.Overview.ShouldBe("Text text text");
            ratingsItem.Season.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-08T00:00:00.000Z"));
            ratingsItem.Season.Episodes.ShouldNotBeNull();
            ratingsItem.Season.Episodes.Count.ShouldBe(2);

            var episodes = ratingsItem.Season.Episodes.ToArray();

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

            ratingsItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRatingsItemWithTypeEpisodeFromFullJson()
        {
            TraktRatingsItem? ratingsItem = await TestUtility.DeserializeJsonAsync<TraktRatingsItem>("Ratings\\ratingsitemepisode.json");

            ratingsItem.ShouldNotBeNull();
            ratingsItem.Rating.ShouldBe(7);
            ratingsItem.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            ratingsItem.Type.ShouldBe(TraktRatingsItemType.Episode);
            ratingsItem.Movie.ShouldBeNull();
            ratingsItem.Show.ShouldNotBeNull();
            ratingsItem.Show.Title.ShouldBe("Game of Thrones");
            ratingsItem.Show.Year.ShouldBe(2011U);
            ratingsItem.Show.Airs.ShouldNotBeNull();
            ratingsItem.Show.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            ratingsItem.Show.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            ratingsItem.Show.Airs.Time.ShouldBe("21:00");
#endif
            ratingsItem.Show.Airs.Timezone.ShouldBe("America/New_York");
            ratingsItem.Show.AvailableTranslations.ShouldNotBeNull();
            ratingsItem.Show.AvailableTranslations.Count.ShouldBe(4);
            ratingsItem.Show.AvailableTranslations.ShouldBe(["en", "fr", "it", "de"]);
            ratingsItem.Show.IDs.ShouldNotBeNull();
            ratingsItem.Show.IDs.Trakt.ShouldBe(1390U);
            ratingsItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            ratingsItem.Show.IDs.TVDB.ShouldBe(121361U);
            ratingsItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            ratingsItem.Show.IDs.TMDB.ShouldBe(1399U);
            ratingsItem.Show.Genres.ShouldNotBeNull();
            ratingsItem.Show.Genres.Count.ShouldBe(5);
            ratingsItem.Show.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"]);
            ratingsItem.Show.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            ratingsItem.Show.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T07:00:00Z"));
            ratingsItem.Show.Runtime.ShouldBe(60U);
            ratingsItem.Show.Certification.ShouldBe("TV-MA");
            ratingsItem.Show.Network.ShouldBe("HBO");
            ratingsItem.Show.Country.ShouldBe("us");
            ratingsItem.Show.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T10:39:11Z"));
            ratingsItem.Show.Trailer.ShouldBe("http://youtube.com/watch?v=F9Bo89m2f6g");
            ratingsItem.Show.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            ratingsItem.Show.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            ratingsItem.Show.Rating.ShouldBe(9.38327f);
            ratingsItem.Show.Votes.ShouldBe(44773U);
            ratingsItem.Show.Language.ShouldBe("en");
            ratingsItem.Show.AiredEpisodes.ShouldBe(50U);
            ratingsItem.Season.ShouldBeNull();
            ratingsItem.Episode.ShouldNotBeNull();
            ratingsItem.Episode.Season.ShouldBe(1U);
            ratingsItem.Episode.Number.ShouldBe(1U);
            ratingsItem.Episode.Title.ShouldBe("Winter Is Coming");
            ratingsItem.Episode.IDs.ShouldNotBeNull();
            ratingsItem.Episode.IDs.Trakt.ShouldBe(73640U);
            ratingsItem.Episode.IDs.TVDB.ShouldBe(3254641U);
            ratingsItem.Episode.IDs.IMDB.ShouldBe("tt1480055");
            ratingsItem.Episode.IDs.TMDB.ShouldBe(63056U);
            ratingsItem.Episode.NumberAbsolute.ShouldBe(50U);
            ratingsItem.Episode.Overview.ShouldBe("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            ratingsItem.Episode.Runtime.ShouldBe(55U);
            ratingsItem.Episode.Rating.ShouldBe(9.0f);
            ratingsItem.Episode.Votes.ShouldBe(111U);
            ratingsItem.Episode.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            ratingsItem.Episode.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-08-29T23:16:39.000Z"));
            ratingsItem.Episode.AvailableTranslations.ShouldNotBeNull();
            ratingsItem.Episode.AvailableTranslations.Count.ShouldBe(2);
            ratingsItem.Episode.AvailableTranslations.ShouldBe(["en", "es"]);
            ratingsItem.Episode.Translations.ShouldNotBeNull();
            ratingsItem.Episode.Translations.Count.ShouldBe(2);

            var translations = ratingsItem.Episode.Translations.ToArray();

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
