namespace TraktNET.Json.Lists
{
    public sealed partial class TraktListItemTests
    {
        [Fact]
        public async Task TestListItemMovieMinimalFromJson()
        {
            TraktListItem? item = await TestUtility.DeserializeJsonAsync<TraktListItem>("Lists\\listtypemovie_minimal.json");

            item.ShouldNotBeNull();
            item.Id.ShouldBe(101U);
            item.Rank.ShouldBe(1U);
            item.ListedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            item.Notes.ShouldBe("list item notes");
            item.Type.ShouldBe(TraktListItemType.Movie);

            item.Movie.ShouldNotBeNull();
            item.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            item.Movie.Year.ShouldBe(2015U);
            item.Movie.IDs.ShouldNotBeNull();
            item.Movie.IDs.Trakt.ShouldBe(94024U);
            item.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            item.Movie.IDs.IMDB.ShouldBe("tt2488496");
            item.Movie.IDs.TMDB.ShouldBe(140607U);
        }

        [Fact]
        public async Task TestListItemMovieFromJson()
        {
            TraktListItem? item = await TestUtility.DeserializeJsonAsync<TraktListItem>("Lists\\listtypemovie.json");

            item.ShouldNotBeNull();
            item.Type.ShouldBe(TraktListItemType.Movie);
            item.Movie.ShouldNotBeNull();

            item.Movie.Tagline.ShouldBe("Every generation has a story.");
            item.Movie.Overview.ShouldBe("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
#if NET7_0_OR_GREATER
            item.Movie.Released.ShouldBe(TestUtility.ParseDate("2015-12-18"));
#else
            item.Movie.Released.ShouldBe(DateTime.Parse("2015-12-18", System.Globalization.CultureInfo.InvariantCulture));
#endif
            item.Movie.Runtime.ShouldBe(136U);
            item.Movie.Trailer.ShouldBe("http://youtube.com/watch?v=uwa7N0ShN2U");
            item.Movie.Homepage.ShouldBe("http://www.starwars.com/films/star-wars-episode-vii");
            item.Movie.Rating.ShouldBe(8.31988f);
            item.Movie.Votes.ShouldBe(9338U);
            item.Movie.Language.ShouldBe("en");
            item.Movie.Certification.ShouldBe("PG-13");

            item.Movie.AvailableTranslations.ShouldNotBeNull();
            item.Movie.AvailableTranslations!.Count.ShouldBe(4);
            item.Movie.Genres.ShouldNotBeNull();
            item.Movie.Genres.Count.ShouldBe(4);
        }

        [Fact]
        public async Task TestListItemShowMinimalFromJson()
        {
            TraktListItem? item = await TestUtility.DeserializeJsonAsync<TraktListItem>("Lists\\listtypeshow_minimal.json");

            item.ShouldNotBeNull();
            item.Id.ShouldBe(101U);
            item.Type.ShouldBe(TraktListItemType.Show);

            item.Show.ShouldNotBeNull();
            item.Show.Title.ShouldBe("Game of Thrones");
            item.Show.Year.ShouldBe(2011U);
            item.Show.IDs.ShouldNotBeNull();
            item.Show.IDs.Trakt.ShouldBe(1390U);
        }

        [Fact]
        public async Task TestListItemShowFromJson()
        {
            TraktListItem? item = await TestUtility.DeserializeJsonAsync<TraktListItem>("Lists\\listtypeshow.json");

            item.ShouldNotBeNull();
            item.Type.ShouldBe(TraktListItemType.Show);
            item.Show.ShouldNotBeNull();

            item.Show.Title.ShouldBe("Game of Thrones");
            item.Show.Runtime.ShouldBe(60U);
            item.Show.Network.ShouldBe("HBO");
            item.Show.Country.ShouldBe("us");
            item.Show.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            item.Show.Rating.ShouldBe(9.38327f);
            item.Show.Votes.ShouldBe(44773U);
            item.Show.AiredEpisodes.ShouldBe(50U);

            item.Show.Airs.ShouldNotBeNull();
            item.Show.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            item.Show.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            item.Show.Airs.Time.ShouldBe("21:00");
#endif
            item.Show.Airs.Timezone.ShouldBe("America/New_York");
        }

        [Fact]
        public async Task TestListItemSeasonMinimalFromJson()
        {
            TraktListItem? item = await TestUtility.DeserializeJsonAsync<TraktListItem>("Lists\\listtypeseason_minimal.json");

            item.ShouldNotBeNull();
            item.Id.ShouldBe(101U);
            item.Type.ShouldBe(TraktListItemType.Season);

            item.Season.ShouldNotBeNull();
            item.Season.Number.ShouldBe(1U);
            item.Season.IDs.ShouldNotBeNull();
            item.Season.IDs.Trakt.ShouldBe(61430U);
            item.Season.IDs.TVDB.ShouldBe(279121U);
            item.Season.IDs.TMDB.ShouldBe(60523U);
        }

        [Fact]
        public async Task TestListItemSeasonFromJson()
        {
            TraktListItem? item = await TestUtility.DeserializeJsonAsync<TraktListItem>("Lists\\listtypeseason.json");

            item.ShouldNotBeNull();
            item.Type.ShouldBe(TraktListItemType.Season);
            item.Season.ShouldNotBeNull();

            item.Season.Rating.ShouldBe(8.57053f);
            item.Season.Votes.ShouldBe(794U);
            item.Season.EpisodeCount.ShouldBe(23U);
            item.Season.AiredEpisodes.ShouldBe(23U);
            item.Season.Overview.ShouldBe("Text text text");
            item.Season.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-08T00:00:00.000Z"));

            item.Season.Episodes.ShouldNotBeNull();
            item.Season.Episodes.Count.ShouldBe(2);
            item.Season.Episodes[0].Title.ShouldBe("Winter Is Coming");
            item.Season.Episodes[0].IDs!.Trakt.ShouldBe(73640U);
        }

        [Fact]
        public async Task TestListItemEpisodeMinimalFromJson()
        {
            TraktListItem? item = await TestUtility.DeserializeJsonAsync<TraktListItem>("Lists\\listtypeepisode_minimal.json");

            item.ShouldNotBeNull();
            item.Id.ShouldBe(101U);
            item.Type.ShouldBe(TraktListItemType.Episode);

            item.Episode.ShouldNotBeNull();
            item.Episode.Season.ShouldBe(1U);
            item.Episode.Number.ShouldBe(1U);
            item.Episode.Title.ShouldBe("Winter Is Coming");
            item.Episode.IDs.ShouldNotBeNull();
            item.Episode.IDs!.Trakt.ShouldBe(73640U);

            item.Show.ShouldNotBeNull();
            item.Show.Title.ShouldBe("Game of Thrones");
            item.Show.IDs!.Trakt.ShouldBe(1390U);
        }

        [Fact]
        public async Task TestListItemEpisodeFromJson()
        {
            TraktListItem? item = await TestUtility.DeserializeJsonAsync<TraktListItem>("Lists\\listtypeepisode.json");

            item.ShouldNotBeNull();
            item.Type.ShouldBe(TraktListItemType.Episode);
            item.Episode.ShouldNotBeNull();

            item.Episode.NumberAbsolute.ShouldBe(50U);
            item.Episode.Rating.ShouldBe(9.0f);
            item.Episode.Votes.ShouldBe(111U);
            item.Episode.Runtime.ShouldBe(55U);

            item.Episode.AvailableTranslations.ShouldNotBeNull();
            item.Episode.AvailableTranslations!.Count.ShouldBe(2);

            item.Episode.Translations.ShouldNotBeNull();
            item.Episode.Translations.Count.ShouldBe(2);
            item.Episode.Translations[0].Title.ShouldBe("Winter Is Coming");
            item.Episode.Translations[0].Language.ShouldBe("en");
        }

        [Fact]
        public async Task TestListItemPersonMinimalFromJson()
        {
            TraktListItem? item = await TestUtility.DeserializeJsonAsync<TraktListItem>("Lists\\listtypeperson_minimal.json");

            item.ShouldNotBeNull();
            item.Id.ShouldBe(101U);
            item.Type.ShouldBe(TraktListItemType.Person);

            item.Person.ShouldNotBeNull();
            item.Person.Name.ShouldBe("Bryan Cranston");
            item.Person.IDs.ShouldNotBeNull();
            item.Person.IDs.Trakt.ShouldBe(297737U);
            item.Person.IDs.IMDB.ShouldBe("nm0186505");
        }

        [Fact]
        public async Task TestListItemPersonFromJson()
        {
            TraktListItem? item = await TestUtility.DeserializeJsonAsync<TraktListItem>("Lists\\listtypeperson.json");

            item.ShouldNotBeNull();
            item.Type.ShouldBe(TraktListItemType.Person);
            item.Person.ShouldNotBeNull();

            item.Person.Biography.ShouldNotBeNullOrEmpty();
#if NET7_0_OR_GREATER
            item.Person.Birthday.ShouldBe(TestUtility.ParseDate("1956-03-07"));
            item.Person.Death.ShouldBe(TestUtility.ParseDate("2016-04-06"));
#else
            item.Person.Birthday.ShouldBe(DateTime.Parse("1956-03-07", System.Globalization.CultureInfo.InvariantCulture));
            item.Person.Death.ShouldBe(DateTime.Parse("2016-04-06", System.Globalization.CultureInfo.InvariantCulture));
#endif
            item.Person.Birthplace.ShouldBe("San Fernando Valley, California, USA");
            item.Person.Homepage.ShouldBe("http://www.bryancranston.com/");
        }
    }
}
