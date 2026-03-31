namespace TraktNET.Json.Watched
{
    public sealed class TraktWatchedShowTests
    {
        [Fact]
        public void TestTraktWatchedShowDefaultConstructor()
        {
            var watchedShow = new TraktWatchedShow();

            watchedShow.Plays.ShouldBeNull();
            watchedShow.LastWatchedAt.ShouldBeNull();
            watchedShow.LastUpdatedAt.ShouldBeNull();
            watchedShow.ResetAt.ShouldBeNull();
            watchedShow.Show.ShouldBeNull();
            watchedShow.Seasons.ShouldBeNull();

            watchedShow.Title.ShouldBeNullOrEmpty();
            watchedShow.Year.ShouldBeNull();
            watchedShow.Airs.ShouldBeNull();
            watchedShow.AvailableTranslations.ShouldBeNull();
            watchedShow.IDs.ShouldBeNull();
            watchedShow.Genres.ShouldBeNull();
            watchedShow.Overview.ShouldBeNullOrEmpty();
            watchedShow.Tagline.ShouldBeNullOrEmpty();
            watchedShow.FirstAired.ShouldBeNull();
            watchedShow.Runtime.ShouldBeNull();
            watchedShow.Certification.ShouldBeNullOrEmpty();
            watchedShow.Network.ShouldBeNullOrEmpty();
            watchedShow.Country.ShouldBeNullOrEmpty();
            watchedShow.UpdatedAt.ShouldBeNull();
            watchedShow.Trailer.ShouldBeNullOrEmpty();
            watchedShow.Homepage.ShouldBeNullOrEmpty();
            watchedShow.Status.ShouldBeNull();
            watchedShow.Rating.ShouldBeNull();
            watchedShow.Votes.ShouldBeNull();
            watchedShow.Language.ShouldBeNullOrEmpty();
            watchedShow.AiredEpisodes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktWatchedShowFromMinimalJson()
        {
            TraktWatchedShow? watchedShow = await TestUtility.DeserializeJsonAsync<TraktWatchedShow>("Watched\\watchedshow_minimal.json");

            watchedShow.ShouldNotBeNull();
            watchedShow.Plays.ShouldBe(20U);
            watchedShow.LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-07-14T01:00:00.000Z"));
            watchedShow.LastUpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-07-14T01:00:00.000Z"));
            watchedShow.ResetAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-07-14T01:00:00.000Z"));

            watchedShow.Show.ShouldNotBeNull();
            watchedShow.Show.Title.ShouldBe("Game of Thrones");
            watchedShow.Show.Year.ShouldBe(2011U);
            watchedShow.Show.Airs.ShouldBeNull();
            watchedShow.Show.AvailableTranslations.ShouldBeNull();
            watchedShow.Show.IDs.ShouldNotBeNull();
            watchedShow.Show.IDs.Trakt.ShouldBe(1390U);
            watchedShow.Show.IDs.Slug.ShouldBe("game-of-thrones");
            watchedShow.Show.IDs.TVDB.ShouldBe(121361U);
            watchedShow.Show.IDs.IMDB.ShouldBe("tt0944947");
            watchedShow.Show.IDs.TMDB.ShouldBe(1399U);
            watchedShow.Show.Genres.ShouldBeNull();
            watchedShow.Show.Overview.ShouldBeNullOrEmpty();
            watchedShow.Show.Tagline.ShouldBeNullOrEmpty();
            watchedShow.Show.FirstAired.ShouldBeNull();
            watchedShow.Show.Runtime.ShouldBeNull();
            watchedShow.Show.Certification.ShouldBeNullOrEmpty();
            watchedShow.Show.Network.ShouldBeNullOrEmpty();
            watchedShow.Show.Country.ShouldBeNullOrEmpty();
            watchedShow.Show.UpdatedAt.ShouldBeNull();
            watchedShow.Show.Trailer.ShouldBeNullOrEmpty();
            watchedShow.Show.Homepage.ShouldBeNullOrEmpty();
            watchedShow.Show.Status.ShouldBeNull();
            watchedShow.Show.Rating.ShouldBeNull();
            watchedShow.Show.Votes.ShouldBeNull();
            watchedShow.Show.Language.ShouldBeNullOrEmpty();
            watchedShow.Show.AiredEpisodes.ShouldBeNull();

            watchedShow.Title.ShouldBe("Game of Thrones");
            watchedShow.Year.ShouldBe(2011U);
            watchedShow.Airs.ShouldBeNull();
            watchedShow.AvailableTranslations.ShouldBeNull();
            watchedShow.IDs.ShouldNotBeNull();
            watchedShow.IDs.Trakt.ShouldBe(1390U);
            watchedShow.IDs.Slug.ShouldBe("game-of-thrones");
            watchedShow.IDs.TVDB.ShouldBe(121361U);
            watchedShow.IDs.IMDB.ShouldBe("tt0944947");
            watchedShow.IDs.TMDB.ShouldBe(1399U);
            watchedShow.Genres.ShouldBeNull();
            watchedShow.Overview.ShouldBeNullOrEmpty();
            watchedShow.Tagline.ShouldBeNullOrEmpty();
            watchedShow.FirstAired.ShouldBeNull();
            watchedShow.Runtime.ShouldBeNull();
            watchedShow.Certification.ShouldBeNullOrEmpty();
            watchedShow.Network.ShouldBeNullOrEmpty();
            watchedShow.Country.ShouldBeNullOrEmpty();
            watchedShow.UpdatedAt.ShouldBeNull();
            watchedShow.Trailer.ShouldBeNullOrEmpty();
            watchedShow.Homepage.ShouldBeNullOrEmpty();
            watchedShow.Status.ShouldBeNull();
            watchedShow.Rating.ShouldBeNull();
            watchedShow.Votes.ShouldBeNull();
            watchedShow.Language.ShouldBeNullOrEmpty();
            watchedShow.AiredEpisodes.ShouldBeNull();

            watchedShow.Seasons.ShouldNotBeNull();
            watchedShow.Seasons.Count.ShouldBe(2);

            var seasons = watchedShow.Seasons.ToArray();

            // Season 1
            seasons[0].ShouldNotBeNull();
            seasons[0].Number.ShouldBe(1U);
            seasons[0].Episodes.ShouldNotBeNull();
            seasons[0].Episodes!.Count.ShouldBe(2);

            // Episodes of Season 1
            var episodesSeason1 = seasons[0].Episodes!.ToArray();

            episodesSeason1[0].ShouldNotBeNull();
            episodesSeason1[0].Number.ShouldBe(1U);
            episodesSeason1[0].Plays.ShouldBe(5U);
            episodesSeason1[0].LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            episodesSeason1[1].ShouldNotBeNull();
            episodesSeason1[1].Number.ShouldBe(2U);
            episodesSeason1[1].Plays.ShouldBe(5U);
            episodesSeason1[1].LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            // Season 2
            seasons[1].ShouldNotBeNull();
            seasons[1].Number.ShouldBe(2U);
            seasons[1].Episodes.ShouldNotBeNull();
            seasons[1].Episodes!.Count.ShouldBe(2);

            // Episodes of Season 2
            var episodesSeason2 = seasons[1].Episodes!.ToArray();

            episodesSeason2[0].ShouldNotBeNull();
            episodesSeason2[0].Number.ShouldBe(1U);
            episodesSeason2[0].Plays.ShouldBe(5U);
            episodesSeason2[0].LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            episodesSeason2[1].ShouldNotBeNull();
            episodesSeason2[1].Number.ShouldBe(2U);
            episodesSeason2[1].Plays.ShouldBe(5U);
            episodesSeason2[1].LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
        }

        [Fact]
        public async Task TestTraktWatchedShowFromFullJson()
        {
            TraktWatchedShow? watchedShow = await TestUtility.DeserializeJsonAsync<TraktWatchedShow>("Watched\\watchedshow.json");

            watchedShow.ShouldNotBeNull();
            watchedShow.Plays.ShouldBe(20U);
            watchedShow.LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-07-14T01:00:00.000Z"));
            watchedShow.LastUpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-07-14T01:00:00.000Z"));
            watchedShow.ResetAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-07-14T01:00:00.000Z"));

            watchedShow.Show.ShouldNotBeNull();
            watchedShow.Show.Title.ShouldBe("Game of Thrones");
            watchedShow.Show.Year.ShouldBe(2011U);
            watchedShow.Show.Airs.ShouldNotBeNull();
            watchedShow.Show.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            watchedShow.Show.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            watchedShow.Show.Airs.Time.ShouldBe("21:00");
#endif
            watchedShow.Show.Airs.Timezone.ShouldBe("America/New_York");
            watchedShow.Show.AvailableTranslations.ShouldNotBeNull();
            watchedShow.Show.AvailableTranslations.Count.ShouldBe(4);
            watchedShow.Show.AvailableTranslations.ShouldBe(["en", "fr", "it", "de"]);
            watchedShow.Show.IDs.ShouldNotBeNull();
            watchedShow.Show.IDs.Trakt.ShouldBe(1390U);
            watchedShow.Show.IDs.Slug.ShouldBe("game-of-thrones");
            watchedShow.Show.IDs.TVDB.ShouldBe(121361U);
            watchedShow.Show.IDs.IMDB.ShouldBe("tt0944947");
            watchedShow.Show.IDs.TMDB.ShouldBe(1399U);
            watchedShow.Show.Genres.ShouldNotBeNull();
            watchedShow.Show.Genres.Count.ShouldBe(5);
            watchedShow.Show.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"]);
            watchedShow.Show.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            watchedShow.Show.Tagline.ShouldBe("Winter Is Coming");
            watchedShow.Show.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T07:00:00Z"));
            watchedShow.Show.Runtime.ShouldBe(60U);
            watchedShow.Show.Certification.ShouldBe("TV-MA");
            watchedShow.Show.Network.ShouldBe("HBO");
            watchedShow.Show.Country.ShouldBe("us");
            watchedShow.Show.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T10:39:11Z"));
            watchedShow.Show.Trailer.ShouldBe("http://youtube.com/watch?v=F9Bo89m2f6g");
            watchedShow.Show.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            watchedShow.Show.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            watchedShow.Show.Rating.ShouldBe(9.38327f);
            watchedShow.Show.Votes.ShouldBe(44773U);
            watchedShow.Show.Language.ShouldBe("en");
            watchedShow.Show.AiredEpisodes.ShouldBe(50U);

            watchedShow.Title.ShouldBe("Game of Thrones");
            watchedShow.Year.ShouldBe(2011U);
            watchedShow.Airs.ShouldNotBeNull();
            watchedShow.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            watchedShow.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            watchedShow.Airs.Time.ShouldBe("21:00");
#endif
            watchedShow.Airs.Timezone.ShouldBe("America/New_York");
            watchedShow.AvailableTranslations.ShouldNotBeNull();
            watchedShow.AvailableTranslations.Count.ShouldBe(4);
            watchedShow.AvailableTranslations.ShouldBe(["en", "fr", "it", "de"]);
            watchedShow.IDs.ShouldNotBeNull();
            watchedShow.IDs.Trakt.ShouldBe(1390U);
            watchedShow.IDs.Slug.ShouldBe("game-of-thrones");
            watchedShow.IDs.TVDB.ShouldBe(121361U);
            watchedShow.IDs.IMDB.ShouldBe("tt0944947");
            watchedShow.IDs.TMDB.ShouldBe(1399U);
            watchedShow.Genres.ShouldNotBeNull();
            watchedShow.Genres.Count.ShouldBe(5);
            watchedShow.Genres.ShouldBe(["drama", "fantasy", "science-fiction", "action", "adventure"]);
            watchedShow.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            watchedShow.Tagline.ShouldBe("Winter Is Coming");
            watchedShow.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-17T07:00:00Z"));
            watchedShow.Runtime.ShouldBe(60U);
            watchedShow.Certification.ShouldBe("TV-MA");
            watchedShow.Network.ShouldBe("HBO");
            watchedShow.Country.ShouldBe("us");
            watchedShow.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-04-06T10:39:11Z"));
            watchedShow.Trailer.ShouldBe("http://youtube.com/watch?v=F9Bo89m2f6g");
            watchedShow.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            watchedShow.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            watchedShow.Rating.ShouldBe(9.38327f);
            watchedShow.Votes.ShouldBe(44773U);
            watchedShow.Language.ShouldBe("en");
            watchedShow.AiredEpisodes.ShouldBe(50U);

            watchedShow.Seasons.ShouldNotBeNull();
            watchedShow.Seasons.Count.ShouldBe(2);

            var seasons = watchedShow.Seasons.ToArray();

            // Season 1
            seasons[0].ShouldNotBeNull();
            seasons[0].Number.ShouldBe(1U);
            seasons[0].Episodes.ShouldNotBeNull();
            seasons[0].Episodes!.Count.ShouldBe(2);

            // Episodes of Season 1
            var episodesSeason1 = seasons[0].Episodes!.ToArray();

            episodesSeason1[0].ShouldNotBeNull();
            episodesSeason1[0].Number.ShouldBe(1U);
            episodesSeason1[0].Plays.ShouldBe(5U);
            episodesSeason1[0].LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            episodesSeason1[1].ShouldNotBeNull();
            episodesSeason1[1].Number.ShouldBe(2U);
            episodesSeason1[1].Plays.ShouldBe(5U);
            episodesSeason1[1].LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            // Season 2
            seasons[1].ShouldNotBeNull();
            seasons[1].Number.ShouldBe(2U);
            seasons[1].Episodes.ShouldNotBeNull();
            seasons[1].Episodes!.Count.ShouldBe(2);

            // Episodes of Season 2
            var episodesSeason2 = seasons[1].Episodes!.ToArray();

            episodesSeason2[0].ShouldNotBeNull();
            episodesSeason2[0].Number.ShouldBe(1U);
            episodesSeason2[0].Plays.ShouldBe(5U);
            episodesSeason2[0].LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            episodesSeason2[1].ShouldNotBeNull();
            episodesSeason2[1].Number.ShouldBe(2U);
            episodesSeason2[1].Plays.ShouldBe(5U);
            episodesSeason2[1].LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
        }
    }
}
