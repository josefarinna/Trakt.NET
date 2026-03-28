namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncPlaybackProgressItemTests
    {
        [Fact]
        public void TestTraktSyncPlaybackProgressItemDefaultConstructor()
        {
            var playbackProgressItem = new TraktSyncPlaybackProgressItem();

            playbackProgressItem.Id.ShouldBe(0U);
            playbackProgressItem.Progress.ShouldBeNull();
            playbackProgressItem.PausedAt.ShouldBeNull();
            playbackProgressItem.Type.ShouldBeNull();
            playbackProgressItem.Movie.ShouldBeNull();
            playbackProgressItem.Episode.ShouldBeNull();
            playbackProgressItem.Show.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncPlaybackProgressItemWithTypeMovieFromMinimalJson()
        {
            TraktSyncPlaybackProgressItem? playbackProgressItem = await TestUtility.DeserializeJsonAsync<TraktSyncPlaybackProgressItem>("Syncs\\Playback\\syncplaybackmovie_minimal.json");

            playbackProgressItem.ShouldNotBeNull();
            playbackProgressItem.Id.ShouldBe(37U);
            playbackProgressItem.Progress.ShouldBe(65.5f);
            playbackProgressItem.PausedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-01-25T22:01:32.000Z"));
            playbackProgressItem.Type.ShouldBe(TraktSyncType.Movie);
            playbackProgressItem.Movie.ShouldNotBeNull();
            playbackProgressItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            playbackProgressItem.Movie.Year.ShouldBe(2015U);
            playbackProgressItem.Movie.IDs.ShouldNotBeNull();
            playbackProgressItem.Movie.IDs.Trakt.ShouldBe(94024U);
            playbackProgressItem.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            playbackProgressItem.Movie.IDs.IMDB.ShouldBe("tt2488496");
            playbackProgressItem.Movie.IDs.TMDB.ShouldBe(140607U);
            playbackProgressItem.Movie.Tagline.ShouldBeNullOrEmpty();
            playbackProgressItem.Movie.Overview.ShouldBeNullOrEmpty();
            playbackProgressItem.Movie.Released.ShouldBeNull();
            playbackProgressItem.Movie.Runtime.ShouldBeNull();
            playbackProgressItem.Movie.UpdatedAt.ShouldBeNull();
            playbackProgressItem.Movie.Trailer.ShouldBeNullOrEmpty();
            playbackProgressItem.Movie.Homepage.ShouldBeNullOrEmpty();
            playbackProgressItem.Movie.Rating.ShouldBeNull();
            playbackProgressItem.Movie.Votes.ShouldBeNull();
            playbackProgressItem.Movie.Language.ShouldBeNullOrEmpty();
            playbackProgressItem.Movie.AvailableTranslations.ShouldBeNull();
            playbackProgressItem.Movie.Genres.ShouldBeNull();
            playbackProgressItem.Movie.Certification.ShouldBeNullOrEmpty();
            playbackProgressItem.Show.ShouldBeNull();
            playbackProgressItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncPlaybackProgressItemWithTypeEpisodeFromMinimalJson()
        {
            TraktSyncPlaybackProgressItem? playbackProgressItem = await TestUtility.DeserializeJsonAsync<TraktSyncPlaybackProgressItem>("Syncs\\Playback\\syncplaybackepisode_minimal.json");

            playbackProgressItem.ShouldNotBeNull();
            playbackProgressItem.Id.ShouldBe(37U);
            playbackProgressItem.Progress.ShouldBe(65.5f);
            playbackProgressItem.PausedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-01-25T22:01:32.000Z"));
            playbackProgressItem.Type.ShouldBe(TraktSyncType.Episode);
            playbackProgressItem.Episode.ShouldNotBeNull();
            playbackProgressItem.Episode.Season.ShouldBe(1U);
            playbackProgressItem.Episode.Number.ShouldBe(1U);
            playbackProgressItem.Episode.Title.ShouldBe("Winter Is Coming");
            playbackProgressItem.Episode.IDs.ShouldNotBeNull();
            playbackProgressItem.Episode.IDs.Trakt.ShouldBe(73640U);
            playbackProgressItem.Episode.IDs.TVDB.ShouldBe(3254641U);
            playbackProgressItem.Episode.IDs.IMDB.ShouldBe("tt1480055");
            playbackProgressItem.Episode.IDs.TMDB.ShouldBe(63056U);
            playbackProgressItem.Episode.NumberAbsolute.ShouldBeNull();
            playbackProgressItem.Episode.Overview.ShouldBeNullOrEmpty();
            playbackProgressItem.Episode.Runtime.ShouldBeNull();
            playbackProgressItem.Episode.Rating.ShouldBeNull();
            playbackProgressItem.Episode.Votes.ShouldBeNull();
            playbackProgressItem.Episode.FirstAired.ShouldBeNull();
            playbackProgressItem.Episode.UpdatedAt.ShouldBeNull();
            playbackProgressItem.Episode.AvailableTranslations.ShouldBeNull();
            playbackProgressItem.Episode.Translations.ShouldBeNull();
            playbackProgressItem.Show.ShouldNotBeNull();
            playbackProgressItem.Show.Title.ShouldBe("Game of Thrones");
            playbackProgressItem.Show.Year.ShouldBe(2011U);
            playbackProgressItem.Show.Airs.ShouldBeNull();
            playbackProgressItem.Show.AvailableTranslations.ShouldBeNull();
            playbackProgressItem.Show.IDs.ShouldNotBeNull();
            playbackProgressItem.Show.IDs.Trakt.ShouldBe(1390U);
            playbackProgressItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            playbackProgressItem.Show.IDs.TVDB.ShouldBe(121361U);
            playbackProgressItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            playbackProgressItem.Show.IDs.TMDB.ShouldBe(1399U);
            playbackProgressItem.Show.Genres.ShouldBeNull();
            playbackProgressItem.Show.Overview.ShouldBeNullOrEmpty();
            playbackProgressItem.Show.FirstAired.ShouldBeNull();
            playbackProgressItem.Show.Runtime.ShouldBeNull();
            playbackProgressItem.Show.Certification.ShouldBeNullOrEmpty();
            playbackProgressItem.Show.Network.ShouldBeNullOrEmpty();
            playbackProgressItem.Show.Country.ShouldBeNullOrEmpty();
            playbackProgressItem.Show.UpdatedAt.ShouldBeNull();
            playbackProgressItem.Show.Trailer.ShouldBeNullOrEmpty();
            playbackProgressItem.Show.Homepage.ShouldBeNullOrEmpty();
            playbackProgressItem.Show.Status.ShouldBeNull();
            playbackProgressItem.Show.Rating.ShouldBeNull();
            playbackProgressItem.Show.Votes.ShouldBeNull();
            playbackProgressItem.Show.Language.ShouldBeNullOrEmpty();
            playbackProgressItem.Show.AiredEpisodes.ShouldBeNull();
            playbackProgressItem.Movie.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncPlaybackProgressItemWithTypeMovieFromFullJson()
        {
            TraktSyncPlaybackProgressItem? playbackProgressItem = await TestUtility.DeserializeJsonAsync<TraktSyncPlaybackProgressItem>("Syncs\\Playback\\syncplaybackmovie.json");

            playbackProgressItem.ShouldNotBeNull();
            playbackProgressItem.Id.ShouldBe(37U);
            playbackProgressItem.Progress.ShouldBe(65.5f);
            playbackProgressItem.PausedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-01-25T22:01:32.000Z"));
            playbackProgressItem.Type.ShouldBe(TraktSyncType.Movie);
            playbackProgressItem.Movie.ShouldNotBeNull();
            playbackProgressItem.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            playbackProgressItem.Movie.Year.ShouldBe(2015U);
            playbackProgressItem.Movie.IDs.ShouldNotBeNull();
            playbackProgressItem.Movie.IDs.Trakt.ShouldBe(94024U);
            playbackProgressItem.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            playbackProgressItem.Movie.IDs.IMDB.ShouldBe("tt2488496");
            playbackProgressItem.Movie.IDs.TMDB.ShouldBe(140607U);
            playbackProgressItem.Movie.Tagline.ShouldBe("Every generation has a story.");
            playbackProgressItem.Movie.Overview.ShouldBe("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
#if NET7_0_OR_GREATER
            playbackProgressItem.Movie.Released.ShouldBe(TestUtility.ParseDate("2015-12-18"));
#else
            playbackProgressItem.Movie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2015-12-18T00:00:00.000Z"));
#endif
            playbackProgressItem.Movie.Runtime.ShouldBe(136U);
            playbackProgressItem.Movie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-03-31T09:01:59Z"));
            playbackProgressItem.Movie.Trailer.ShouldBe("http://youtube.com/watch?v=uwa7N0ShN2U");
            playbackProgressItem.Movie.Homepage.ShouldBe("http://www.starwars.com/films/star-wars-episode-vii");
            playbackProgressItem.Movie.Rating.ShouldBe(8.31988F);
            playbackProgressItem.Movie.Votes.ShouldBe(9338U);
            playbackProgressItem.Movie.Language.ShouldBe("en");
            playbackProgressItem.Movie.AvailableTranslations.ShouldNotBeNull();
            playbackProgressItem.Movie.AvailableTranslations.Count.ShouldBe(4);
            playbackProgressItem.Movie.AvailableTranslations.ShouldBe(["en", "de", "en", "it"]);
            playbackProgressItem.Movie.Genres.ShouldNotBeNull();
            playbackProgressItem.Movie.Genres.Count.ShouldBe(4);
            playbackProgressItem.Movie.Genres.ShouldBe(["action", "adventure", "fantasy", "science-fiction"]);
            playbackProgressItem.Movie.Certification.ShouldBe("PG-13");
            playbackProgressItem.Show.ShouldBeNull();
            playbackProgressItem.Episode.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncPlaybackProgressItemWithTypeEpisodeFromFullJson()
        {
            TraktSyncPlaybackProgressItem? playbackProgressItem = await TestUtility.DeserializeJsonAsync<TraktSyncPlaybackProgressItem>("Syncs\\Playback\\syncplaybackepisode.json");

            playbackProgressItem.ShouldNotBeNull();
            playbackProgressItem.Id.ShouldBe(37U);
            playbackProgressItem.Progress.ShouldBe(65.5f);
            playbackProgressItem.PausedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-01-25T22:01:32.000Z"));
            playbackProgressItem.Type.ShouldBe(TraktSyncType.Episode);
            playbackProgressItem.Episode.ShouldNotBeNull();
            playbackProgressItem.Episode.Season.ShouldBe(1U);
            playbackProgressItem.Episode.Number.ShouldBe(1U);
            playbackProgressItem.Episode.Title.ShouldBe("Winter Is Coming");
            playbackProgressItem.Episode.IDs.ShouldNotBeNull();
            playbackProgressItem.Episode.IDs.Trakt.ShouldBe(73640U);
            playbackProgressItem.Episode.IDs.TVDB.ShouldBe(3254641U);
            playbackProgressItem.Episode.IDs.IMDB.ShouldBe("tt1480055");
            playbackProgressItem.Episode.IDs.TMDB.ShouldBe(63056U);
            playbackProgressItem.Episode.NumberAbsolute.ShouldBe(50U);
            playbackProgressItem.Episode.Overview.ShouldBe("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            playbackProgressItem.Episode.Runtime.ShouldBe(55U);
            playbackProgressItem.Episode.Rating.ShouldBe(9.0F);
            playbackProgressItem.Episode.Votes.ShouldBe(111U);
            playbackProgressItem.Episode.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            playbackProgressItem.Episode.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-08-29T23:16:39.000Z"));
            playbackProgressItem.Episode.AvailableTranslations.ShouldNotBeNull();
            playbackProgressItem.Episode.AvailableTranslations.Count.ShouldBe(2);
            playbackProgressItem.Episode.AvailableTranslations.ShouldBe(["en", "es"]);
            playbackProgressItem.Episode.Translations.ShouldNotBeNull();
            playbackProgressItem.Episode.Translations.Count.ShouldBe(2);

            var translations = playbackProgressItem.Episode.Translations.ToArray();

            translations[0].ShouldNotBeNull();
            translations[0].Title.ShouldBe("Winter Is Coming");
            translations[0].Overview.ShouldBe("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].Language.ShouldBe("en");

            translations[1].ShouldNotBeNull();
            translations[1].Title.ShouldBe("Se acerca el invierno");
            translations[1].Overview.ShouldBe("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].Language.ShouldBe("es");

            playbackProgressItem.Show.ShouldNotBeNull();
            playbackProgressItem.Show.Title.ShouldBe("Game of Thrones");
            playbackProgressItem.Show.Year.ShouldBe(2011U);
            playbackProgressItem.Show.Airs.ShouldNotBeNull();
            playbackProgressItem.Show.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            playbackProgressItem.Show.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            playbackProgressItem.Show.Airs.Time.ShouldBe("21:00");
#endif
            playbackProgressItem.Show.Airs.Timezone.ShouldBe("America/New_York");
            playbackProgressItem.Show.AvailableTranslations.ShouldNotBeNull();
            playbackProgressItem.Show.AvailableTranslations.Count.ShouldBe(4);
            playbackProgressItem.Show.AvailableTranslations.ShouldBe(["en", "fr", "it", "de"]);
            playbackProgressItem.Show.IDs.ShouldNotBeNull();
            playbackProgressItem.Show.IDs.Trakt.ShouldBe(1390U);
            playbackProgressItem.Show.IDs.Slug.ShouldBe("game-of-thrones");
            playbackProgressItem.Show.IDs.TVDB.ShouldBe(121361U);
            playbackProgressItem.Show.IDs.IMDB.ShouldBe("tt0944947");
            playbackProgressItem.Show.IDs.TMDB.ShouldBe(1399U);
            playbackProgressItem.Show.Genres.ShouldNotBeNull();
            playbackProgressItem.Show.Genres.Count.ShouldBe(5);
            playbackProgressItem.Show.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"]);
            playbackProgressItem.Show.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            playbackProgressItem.Show.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T07:00:00Z"));
            playbackProgressItem.Show.Runtime.ShouldBe(60U);
            playbackProgressItem.Show.Certification.ShouldBe("TV-MA");
            playbackProgressItem.Show.Network.ShouldBe("HBO");
            playbackProgressItem.Show.Country.ShouldBe("us");
            playbackProgressItem.Show.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T10:39:11Z"));
            playbackProgressItem.Show.Trailer.ShouldBe("http://youtube.com/watch?v=F9Bo89m2f6g");
            playbackProgressItem.Show.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            playbackProgressItem.Show.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            playbackProgressItem.Show.Rating.ShouldBe(9.38327f);
            playbackProgressItem.Show.Votes.ShouldBe(44773U);
            playbackProgressItem.Show.Language.ShouldBe("en");
            playbackProgressItem.Show.AiredEpisodes.ShouldBe(50U);

            playbackProgressItem.Movie.ShouldBeNull();
        }
    }
}
