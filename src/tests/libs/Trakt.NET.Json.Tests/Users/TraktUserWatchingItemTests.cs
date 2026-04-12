namespace TraktNET.Json.Users
{
    public sealed class TraktUserWatchingItemTests
    {
        [Fact]
        public void TestTraktUserWatchingItemDefaultConstructor()
        {
            var watchingItem = new TraktUserWatchingItem();

            watchingItem.StartedAt.ShouldBeNull();
            watchingItem.ExpiresAt.ShouldBeNull();
            watchingItem.Action.ShouldBeNull();
            watchingItem.Type.ShouldBeNull();
            watchingItem.Movie.ShouldBeNull();
            watchingItem.Show.ShouldBeNull();
            watchingItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserWatchingItemWithTypeMovieFromMinimalJson()
        {
            TraktUserWatchingItem? watchingItem = await TestUtility.DeserializeJsonAsync<TraktUserWatchingItem>("Users\\userwatching_movie_minimal.json");

            watchingItem.ShouldNotBeNull();
            watchingItem.StartedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T06:44:02.000Z"));
            watchingItem.ExpiresAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T08:36:02.000Z"));
            watchingItem.Action.ShouldBe(TraktHistoryActionType.Checkin);
            watchingItem.Type.ShouldBe(TraktSyncType.Movie);
            watchingItem.Movie.ShouldNotBeNull();
            watchingItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            watchingItem.Movie.Year.ShouldBe(2015U);
            watchingItem.Movie.IDs.ShouldNotBeNull();
            watchingItem.Movie.IDs.Trakt.ShouldBe(94024U);
            watchingItem.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            watchingItem.Movie.IDs.IMDB.ShouldBe("tt2488496");
            watchingItem.Movie.IDs.TMDB.ShouldBe(140607U);
            watchingItem.Movie.Tagline.ShouldBeNullOrEmpty();
            watchingItem.Movie.Overview.ShouldBeNullOrEmpty();
            watchingItem.Movie.Released.ShouldBeNull();
            watchingItem.Movie.Runtime.ShouldBeNull();
            watchingItem.Movie.UpdatedAt.ShouldBeNull();
            watchingItem.Movie.Trailer.ShouldBeNullOrEmpty();
            watchingItem.Movie.Homepage.ShouldBeNullOrEmpty();
            watchingItem.Movie.Rating.ShouldBeNull();
            watchingItem.Movie.Votes.ShouldBeNull();
            watchingItem.Movie.Language.ShouldBeNullOrEmpty();
            watchingItem.Movie.AvailableTranslations.ShouldBeNull();
            watchingItem.Movie.Genres.ShouldBeNull();
            watchingItem.Movie.Certification.ShouldBeNullOrEmpty();
            watchingItem.Show.ShouldBeNull();
            watchingItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserWatchingItemWithTypeEpisodeFromMinimalJson()
        {
            TraktUserWatchingItem? watchingItem = await TestUtility.DeserializeJsonAsync<TraktUserWatchingItem>("Users\\userwatching_episode_minimal.json");

            watchingItem.ShouldNotBeNull();
            watchingItem.StartedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T06:44:02.000Z"));
            watchingItem.ExpiresAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T08:36:02.000Z"));
            watchingItem.Action.ShouldBe(TraktHistoryActionType.Checkin);
            watchingItem.Type.ShouldBe(TraktSyncType.Episode);
            watchingItem.Movie.ShouldBeNull();
            watchingItem.Show.ShouldNotBeNull();
            watchingItem.Show.Title.ShouldBe("Game of Thrones");
            watchingItem.Show.Year.ShouldBe(2011U);
            watchingItem.Show.Airs.ShouldBeNull();
            watchingItem.Show.AvailableTranslations.ShouldBeNull();
            watchingItem.Show.IDs.ShouldNotBeNull();
            watchingItem.Show.IDs.Trakt.ShouldBe(1390U);
            watchingItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            watchingItem.Show.IDs.TVDB.ShouldBe(121361U);
            watchingItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            watchingItem.Show.IDs.TMDB.ShouldBe(1399U);
            watchingItem.Show.Genres.ShouldBeNull();
            watchingItem.Show.Overview.ShouldBeNullOrEmpty();
            watchingItem.Show.FirstAired.ShouldBeNull();
            watchingItem.Show.Runtime.ShouldBeNull();
            watchingItem.Show.Certification.ShouldBeNullOrEmpty();
            watchingItem.Show.Network.ShouldBeNullOrEmpty();
            watchingItem.Show.Country.ShouldBeNullOrEmpty();
            watchingItem.Show.UpdatedAt.ShouldBeNull();
            watchingItem.Show.Trailer.ShouldBeNullOrEmpty();
            watchingItem.Show.Homepage.ShouldBeNullOrEmpty();
            watchingItem.Show.Status.ShouldBeNull();
            watchingItem.Show.Rating.ShouldBeNull();
            watchingItem.Show.Votes.ShouldBeNull();
            watchingItem.Show.Language.ShouldBeNullOrEmpty();
            watchingItem.Show.AiredEpisodes.ShouldBeNull();
            watchingItem.Episode.ShouldNotBeNull();
            watchingItem.Episode.Season.ShouldBe(1U);
            watchingItem.Episode.Number.ShouldBe(1U);
            watchingItem.Episode.Title.ShouldBe("Winter Is Coming");
            watchingItem.Episode.IDs.ShouldNotBeNull();
            watchingItem.Episode.IDs.Trakt.ShouldBe(73640U);
            watchingItem.Episode.IDs.TVDB.ShouldBe(3254641U);
            watchingItem.Episode.IDs.IMDB.ShouldBe("tt1480055");
            watchingItem.Episode.IDs.TMDB.ShouldBe(63056U);
            watchingItem.Episode.NumberAbsolute.ShouldBeNull();
            watchingItem.Episode.Overview.ShouldBeNullOrEmpty();
            watchingItem.Episode.Runtime.ShouldBeNull();
            watchingItem.Episode.Rating.ShouldBeNull();
            watchingItem.Episode.Votes.ShouldBeNull();
            watchingItem.Episode.FirstAired.ShouldBeNull();
            watchingItem.Episode.UpdatedAt.ShouldBeNull();
            watchingItem.Episode.AvailableTranslations.ShouldBeNull();
            watchingItem.Episode.Translations.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserWatchingItemWithTypeMovieFromFullJson()
        {
            TraktUserWatchingItem? watchingItem = await TestUtility.DeserializeJsonAsync<TraktUserWatchingItem>("Users\\userwatching_movie.json");

            watchingItem.ShouldNotBeNull();
            watchingItem.StartedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T06:44:02.000Z"));
            watchingItem.ExpiresAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T08:36:02.000Z" ));
            watchingItem.Action.ShouldBe(TraktHistoryActionType.Checkin);
            watchingItem.Type.ShouldBe(TraktSyncType.Movie);
            watchingItem.Movie.ShouldNotBeNull();
            watchingItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            watchingItem.Movie.Year.ShouldBe(2015U);
            watchingItem.Movie.IDs.ShouldNotBeNull();
            watchingItem.Movie.IDs.Trakt.ShouldBe(94024U);
            watchingItem.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            watchingItem.Movie.IDs.IMDB.ShouldBe("tt2488496");
            watchingItem.Movie.IDs.TMDB.ShouldBe(140607U);
            watchingItem.Movie.Tagline.ShouldBe("Every generation has a story.");
            watchingItem.Movie.Overview.ShouldBe("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
#if NET7_0_OR_GREATER
            watchingItem.Movie.Released.ShouldBe(TestUtility.ParseDate("2015-12-18"));
#else
            watchingItem.Movie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2015-12-18T00:00:00.000Z"));
#endif
            watchingItem.Movie.Runtime.ShouldBe(136U);
            watchingItem.Movie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-03-31T09:01:59Z"));
            watchingItem.Movie.Trailer.ShouldBe("http://youtube.com/watch?v=uwa7N0ShN2U");
            watchingItem.Movie.Homepage.ShouldBe("http://www.starwars.com/films/star-wars-episode-vii");
            watchingItem.Movie.Rating.ShouldBe(8.31988f);
            watchingItem.Movie.Votes.ShouldBe(9338U);
            watchingItem.Movie.Language.ShouldBe("en");
            watchingItem.Movie.AvailableTranslations.ShouldNotBeNull();
            watchingItem.Movie.AvailableTranslations.Count.ShouldBe(4);
            watchingItem.Movie.AvailableTranslations.ShouldBe(["en", "de", "en", "it"]);
            watchingItem.Movie.Genres.ShouldNotBeNull();
            watchingItem.Movie.Genres.Count.ShouldBe(4);
            watchingItem.Movie.Genres.ShouldBe(["action", "adventure", "fantasy", "science-fiction"]);
            watchingItem.Movie.Certification.ShouldBe("PG-13");
            watchingItem.Show.ShouldBeNull();
            watchingItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserWatchingItemWithTypeEpisodeFromFullJson()
        {
            TraktUserWatchingItem? watchingItem = await TestUtility.DeserializeJsonAsync<TraktUserWatchingItem>("Users\\userwatching_episode.json");

            watchingItem.ShouldNotBeNull();
            watchingItem.StartedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T06:44:02.000Z"));
            watchingItem.ExpiresAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-23T08:36:02.000Z"));
            watchingItem.Action.ShouldBe(TraktHistoryActionType.Checkin);
            watchingItem.Type.ShouldBe(TraktSyncType.Episode);
            watchingItem.Movie.ShouldBeNull();
            watchingItem.Show.ShouldNotBeNull();
            watchingItem.Show.Title.ShouldBe("Game of Thrones");
            watchingItem.Show.Year.ShouldBe(2011U);
            watchingItem.Show.Airs.ShouldNotBeNull();
            watchingItem.Show.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            watchingItem.Show.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            watchingItem.Show.Airs.Time.ShouldBe("21:00");
#endif
            watchingItem.Show.Airs.Timezone.ShouldBe("America/New_York");
            watchingItem.Show.AvailableTranslations.ShouldNotBeNull();
            watchingItem.Show.AvailableTranslations.Count.ShouldBe(4);
            watchingItem.Show.AvailableTranslations.ShouldBe(["en", "fr", "it", "de"]);
            watchingItem.Show.IDs.ShouldNotBeNull();
            watchingItem.Show.IDs.Trakt.ShouldBe(1390U);
            watchingItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            watchingItem.Show.IDs.TVDB.ShouldBe(121361U);
            watchingItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            watchingItem.Show.IDs.TMDB.ShouldBe(1399U);
            watchingItem.Show.Genres.ShouldNotBeNull();
            watchingItem.Show.Genres.Count.ShouldBe(5);
            watchingItem.Show.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"]);
            watchingItem.Show.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            watchingItem.Show.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T07:00:00Z"));
            watchingItem.Show.Runtime.ShouldBe(60U);
            watchingItem.Show.Certification.ShouldBe("TV-MA");
            watchingItem.Show.Network.ShouldBe("HBO");
            watchingItem.Show.Country.ShouldBe("us");
            watchingItem.Show.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T10:39:11Z"));
            watchingItem.Show.Trailer.ShouldBe("http://youtube.com/watch?v=F9Bo89m2f6g");
            watchingItem.Show.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            watchingItem.Show.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            watchingItem.Show.Rating.ShouldBe(9.38327f);
            watchingItem.Show.Votes.ShouldBe(44773U);
            watchingItem.Show.Language.ShouldBe("en");
            watchingItem.Show.AiredEpisodes.ShouldBe(50U);
            watchingItem.Episode.ShouldNotBeNull();
            watchingItem.Episode.Season.ShouldBe(1U);
            watchingItem.Episode.Number.ShouldBe(1U);
            watchingItem.Episode.Title.ShouldBe("Winter Is Coming");
            watchingItem.Episode.IDs.ShouldNotBeNull();
            watchingItem.Episode.IDs.Trakt.ShouldBe(73640U);
            watchingItem.Episode.IDs.TVDB.ShouldBe(3254641U);
            watchingItem.Episode.IDs.IMDB.ShouldBe("tt1480055");
            watchingItem.Episode.IDs.TMDB.ShouldBe(63056U);
            watchingItem.Episode.NumberAbsolute.ShouldBe(50U);
            watchingItem.Episode.Overview.ShouldBe("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            watchingItem.Episode.Runtime.ShouldBe(55U);
            watchingItem.Episode.Rating.ShouldBe(9.0f);
            watchingItem.Episode.Votes.ShouldBe(111U);
            watchingItem.Episode.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            watchingItem.Episode.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-08-29T23:16:39.000Z"));
            watchingItem.Episode.AvailableTranslations.ShouldNotBeNull();
            watchingItem.Episode.AvailableTranslations.Count.ShouldBe(2);
            watchingItem.Episode.AvailableTranslations.ShouldBe(["en", "es"]);
            watchingItem.Episode.Translations.ShouldNotBeNull();
            watchingItem.Episode.Translations.Count.ShouldBe(2);

            TraktEpisodeTranslation[] translations = [.. watchingItem.Episode.Translations];

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
