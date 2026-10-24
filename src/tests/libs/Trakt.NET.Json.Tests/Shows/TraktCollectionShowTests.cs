namespace TraktNET.Json.Shows
{
    public sealed class TraktCollectionShowTests
    {
        [Fact]
        public void TestTraktCollectionShowConstructor()
        {
            var collectionShow = new TraktCollectionShow();

            collectionShow.Show.ShouldBeNull();
            collectionShow.Title.ShouldBeNull();
            collectionShow.Year.ShouldBeNull();
            collectionShow.IDs.ShouldBeNull();
            collectionShow.Tagline.ShouldBeNull();
            collectionShow.Overview.ShouldBeNull();
            collectionShow.FirstAired.ShouldBeNull();
            collectionShow.LastAired.ShouldBeNull();
            collectionShow.Airs.ShouldBeNull();
            collectionShow.Runtime.ShouldBeNull();
            collectionShow.TotalRuntime.ShouldBeNull();
            collectionShow.Certification.ShouldBeNull();
            collectionShow.Network.ShouldBeNull();
            collectionShow.Country.ShouldBeNull();
            collectionShow.Trailer.ShouldBeNull();
            collectionShow.Homepage.ShouldBeNull();
            collectionShow.Status.ShouldBeNull();
            collectionShow.Ending.ShouldBeNull();
            collectionShow.Rating.ShouldBeNull();
            collectionShow.Votes.ShouldBeNull();
            collectionShow.Colors.ShouldBeNull();
            collectionShow.CommentCount.ShouldBeNull();
            collectionShow.UpdatedAt.ShouldBeNull();
            collectionShow.Language.ShouldBeNull();
            collectionShow.Languages.ShouldBeNull();
            collectionShow.AvailableTranslations.ShouldBeNull();
            collectionShow.Genres.ShouldBeNull();
            collectionShow.Subgenres.ShouldBeNull();
            collectionShow.Images.ShouldBeNull();
            collectionShow.AiredEpisodes.ShouldBeNull();
            collectionShow.OriginalTitle.ShouldBeNull();
            collectionShow.SocialIDs.ShouldBeNull();

            collectionShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktCollectionShowPropertiesWithNullShow()
        {
            var collectionShow = new TraktCollectionShow
            {
                Title = "Game of Thrones",
                Year = 2011U,
                IDs = new TraktShowIDs { Trakt = 1390U },
                Tagline = "Winter is coming.",
                Overview = "Overview",
                FirstAired = TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"),
                LastAired = TestUtility.ParseUTCDateTime("2019-05-20T01:00:00.000Z"),
                Airs = new TraktShowAirs { Day = TraktDayOfWeek.Sunday },
                Runtime = 57U,
                TotalRuntime = 4161U,
                Certification = "TV-MA",
                Network = "HBO",
                Country = "us",
                Trailer = "https://youtube.com/watch?v=KPLWWIOCOOQ",
                Homepage = "http://www.hbo.com/game-of-thrones",
                Status = TraktShowStatus.Ended,
                Ending = TraktShowEnding.Concluded,
                Rating = 8.93f,
                Votes = 129108U,
                Colors = new TraktColors { Poster = ["#1D262D"] },
                CommentCount = 414U,
                UpdatedAt = TestUtility.ParseUTCDateTime("2024-03-23T06:26:48.000Z"),
                Language = "en",
                Languages = ["en"],
                AvailableTranslations = ["en", "es"],
                Genres = ["fantasy", "drama"],
                Subgenres = ["sword-and-sorcery"],
                Images = new TraktShowImages { Poster = ["poster.jpg"] },
                AiredEpisodes = 73U,
                OriginalTitle = "Game of Thrones",
                SocialIDs = new TraktShowSocialIDs { Twitter = "GameOfThrones" }
            };

            collectionShow.Show.ShouldBeNull();
            collectionShow.Title.ShouldBeNull();
            collectionShow.Year.ShouldBeNull();
            collectionShow.IDs.ShouldBeNull();
            collectionShow.Tagline.ShouldBeNull();
            collectionShow.Overview.ShouldBeNull();
            collectionShow.FirstAired.ShouldBeNull();
            collectionShow.LastAired.ShouldBeNull();
            collectionShow.Airs.ShouldBeNull();
            collectionShow.Runtime.ShouldBeNull();
            collectionShow.TotalRuntime.ShouldBeNull();
            collectionShow.Certification.ShouldBeNull();
            collectionShow.Network.ShouldBeNull();
            collectionShow.Country.ShouldBeNull();
            collectionShow.Trailer.ShouldBeNull();
            collectionShow.Homepage.ShouldBeNull();
            collectionShow.Status.ShouldBeNull();
            collectionShow.Ending.ShouldBeNull();
            collectionShow.Rating.ShouldBeNull();
            collectionShow.Votes.ShouldBeNull();
            collectionShow.Colors.ShouldBeNull();
            collectionShow.CommentCount.ShouldBeNull();
            collectionShow.UpdatedAt.ShouldBeNull();
            collectionShow.Language.ShouldBeNull();
            collectionShow.Languages.ShouldBeNull();
            collectionShow.AvailableTranslations.ShouldBeNull();
            collectionShow.Genres.ShouldBeNull();
            collectionShow.Subgenres.ShouldBeNull();
            collectionShow.Images.ShouldBeNull();
            collectionShow.AiredEpisodes.ShouldBeNull();
            collectionShow.OriginalTitle.ShouldBeNull();
            collectionShow.SocialIDs.ShouldBeNull();

            collectionShow.ToString().ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktCollectionShowProperties()
        {
            var ids = new TraktShowIDs { Trakt = 1390U, Slug = "game-of-thrones" };
            var airs = new TraktShowAirs { Day = TraktDayOfWeek.Sunday, Timezone = "America/New_York" };
            var colors = new TraktColors { Poster = ["#1D262D", "#C5A059"] };
            var images = new TraktShowImages { Poster = ["poster.jpg"] };
            var socialIds = new TraktShowSocialIDs { Twitter = "GameOfThrones", Facebook = "GameOfThrones" };
            DateTime firstAired = TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z");
            DateTime lastAired = TestUtility.ParseUTCDateTime("2019-05-20T01:00:00.000Z");
            DateTime updatedAt = TestUtility.ParseUTCDateTime("2024-03-23T06:26:48.000Z");

            var collectionShow = new TraktCollectionShow
            {
                Show = new TraktShow(),
                Title = "Game of Thrones",
                Year = 2011U,
                IDs = ids,
                Tagline = "Winter is coming.",
                Overview = "Seven noble families fight for control of the mythical land of Westeros.",
                FirstAired = firstAired,
                LastAired = lastAired,
                Airs = airs,
                Runtime = 57U,
                TotalRuntime = 4161U,
                Certification = "TV-MA",
                Network = "HBO",
                Country = "us",
                Trailer = "https://youtube.com/watch?v=KPLWWIOCOOQ",
                Homepage = "http://www.hbo.com/game-of-thrones",
                Status = TraktShowStatus.Ended,
                Ending = TraktShowEnding.Concluded,
                Rating = 8.93f,
                Votes = 129108U,
                Colors = colors,
                CommentCount = 414U,
                UpdatedAt = updatedAt,
                Language = "en",
                Languages = ["en"],
                AvailableTranslations = ["en", "es"],
                Genres = ["fantasy", "drama"],
                Subgenres = ["sword-and-sorcery"],
                Images = images,
                AiredEpisodes = 73U,
                OriginalTitle = "Game of Thrones",
                SocialIDs = socialIds
            };

            collectionShow.Show.ShouldNotBeNull();
            collectionShow.Title.ShouldBe("Game of Thrones");
            collectionShow.Year.ShouldBe(2011U);
            collectionShow.IDs.ShouldBe(ids);
            collectionShow.Tagline.ShouldBe("Winter is coming.");
            collectionShow.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros.");
            collectionShow.FirstAired.ShouldBe(firstAired);
            collectionShow.LastAired.ShouldBe(lastAired);
            collectionShow.Airs.ShouldBe(airs);
            collectionShow.Runtime.ShouldBe(57U);
            collectionShow.TotalRuntime.ShouldBe(4161U);
            collectionShow.Certification.ShouldBe("TV-MA");
            collectionShow.Network.ShouldBe("HBO");
            collectionShow.Country.ShouldBe("us");
            collectionShow.Trailer.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            collectionShow.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            collectionShow.Status.ShouldBe(TraktShowStatus.Ended);
            collectionShow.Ending.ShouldBe(TraktShowEnding.Concluded);
            collectionShow.Rating.ShouldBe(8.93f);
            collectionShow.Votes.ShouldBe(129108U);
            collectionShow.Colors.ShouldBe(colors);
            collectionShow.CommentCount.ShouldBe(414U);
            collectionShow.UpdatedAt.ShouldBe(updatedAt);
            collectionShow.Language.ShouldBe("en");
            collectionShow.Languages.ShouldBe(["en"]);
            collectionShow.AvailableTranslations.ShouldBe(["en", "es"]);
            collectionShow.Genres.ShouldBe(["fantasy", "drama"]);
            collectionShow.Subgenres.ShouldBe(["sword-and-sorcery"]);
            collectionShow.Images.ShouldBe(images);
            collectionShow.AiredEpisodes.ShouldBe(73U);
            collectionShow.OriginalTitle.ShouldBe("Game of Thrones");
            collectionShow.SocialIDs.ShouldBe(socialIds);

            collectionShow.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktCollectionShowFromJsonMinimal()
        {
            TraktCollectionShow? collectionShow = await TestUtility.DeserializeJsonAsync<TraktCollectionShow>("Shows\\collectionshow_minimal.json");

            collectionShow.ShouldNotBeNull();
            collectionShow.Show.ShouldNotBeNull();

            collectionShow.Title.ShouldBe("Game of Thrones");
            collectionShow.Year.ShouldBe(2011U);

            collectionShow.IDs.ShouldNotBeNull();
            collectionShow.IDs.Trakt.ShouldBe(1390U);
            collectionShow.IDs.Slug.ShouldBe("game-of-thrones");
            collectionShow.IDs.TVDB.ShouldBe(121361U);
            collectionShow.IDs.IMDB.ShouldBe("tt0944947");
            collectionShow.IDs.TMDB.ShouldBe(1399U);
            collectionShow.IDs.HasAnyID.ShouldBe(true);
            collectionShow.IDs.BestID.ShouldBe("game-of-thrones");

            collectionShow.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktCollectionShowFromJson()
        {
            TraktCollectionShow? collectionShow = await TestUtility.DeserializeJsonAsync<TraktCollectionShow>("Shows\\collectionshow.json");

            collectionShow.ShouldNotBeNull();
            collectionShow.Show.ShouldNotBeNull();

            collectionShow.Title.ShouldBe("Game of Thrones");
            collectionShow.Year.ShouldBe(2011U);

            collectionShow.IDs.ShouldNotBeNull();
            collectionShow.IDs.Trakt.ShouldBe(1390U);
            collectionShow.IDs.Slug.ShouldBe("game-of-thrones");
            collectionShow.IDs.TVDB.ShouldBe(121361U);
            collectionShow.IDs.IMDB.ShouldBe("tt0944947");
            collectionShow.IDs.TMDB.ShouldBe(1399U);
            collectionShow.IDs.HasAnyID.ShouldBe(true);
            collectionShow.IDs.BestID.ShouldBe("game-of-thrones");

            collectionShow.ToString().ShouldBe("Game of Thrones (2011)");

            collectionShow.Tagline.ShouldBe("Winter is coming.");
            collectionShow.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros.");
            collectionShow.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            collectionShow.LastAired.ShouldBe(TestUtility.ParseUTCDateTime("2019-05-20T01:00:00.000Z"));
            collectionShow.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-23T06:26:48.000Z"));

            collectionShow.Airs.ShouldNotBeNull();
            collectionShow.Airs.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            collectionShow.Airs.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            collectionShow.Airs.Time.ShouldBe("21:00");
#endif
            collectionShow.Airs.Timezone.ShouldBe("America/New_York");

            collectionShow.Runtime.ShouldBe(57U);
            collectionShow.TotalRuntime.ShouldBe(4161U);
            collectionShow.Certification.ShouldBe("TV-MA");
            collectionShow.Network.ShouldBe("HBO");
            collectionShow.Country.ShouldBe("us");
            collectionShow.Trailer.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            collectionShow.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            collectionShow.Status.ShouldBe(TraktShowStatus.Ended);
            collectionShow.Ending.ShouldBe(TraktShowEnding.Concluded);
            collectionShow.Rating.ShouldBe(8.933884809616755f);
            collectionShow.Votes.ShouldBe(129108U);

            collectionShow.Colors.ShouldNotBeNull();
            collectionShow.Colors.Poster.ShouldNotBeNull();
            collectionShow.Colors.Poster.Count.ShouldBe(2);
            collectionShow.Colors.Poster.ShouldBe(["#1D262D", "#C5A059"], Case.Sensitive);

            collectionShow.CommentCount.ShouldBe(414U);
            collectionShow.Language.ShouldBe("en");

            collectionShow.Languages.ShouldNotBeNull();
            collectionShow.Languages.Count.ShouldBe(1);
            collectionShow.Languages.ShouldBe(["en"], Case.Sensitive);

            collectionShow.AvailableTranslations.ShouldNotBeNull();
            collectionShow.AvailableTranslations.Count.ShouldBe(48);
            collectionShow.AvailableTranslations.ShouldBe([
                "ar", "be", "bg", "bs", "ca", "cs", "da", "de", "el", "en", "eo", "es", "et", "fa", "fi",
                "fr", "he", "hr", "hu", "id", "is", "it", "ja", "ka", "ko", "lb", "lt", "lv", "ml", "nl",
                "no", "pl", "pt", "ro", "ru", "sk", "sl", "so", "sr", "sv", "ta", "th", "tr", "tw", "uk",
                "uz", "vi", "zh"
            ], Case.Sensitive);

            collectionShow.Genres.ShouldNotBeNull();
            collectionShow.Genres.Count.ShouldBe(4);
            collectionShow.Genres.ShouldBe([
                "fantasy", "drama", "action", "adventure"
            ], Case.Sensitive);

            collectionShow.Subgenres.ShouldNotBeNull();
            collectionShow.Subgenres.Count.ShouldBe(2);
            collectionShow.Subgenres.ShouldBe(["sword-and-sorcery", "political-drama"], Case.Sensitive);

            collectionShow.Images.ShouldNotBeNull();
            collectionShow.Images.Fanart.ShouldBe(["walter-r2.trakt.tv/images/shows/000/001/390/fanarts/medium/76d5df8aed.jpg.webp"]);
            collectionShow.Images.Poster.ShouldBe(["walter-r2.trakt.tv/images/shows/000/001/390/posters/thumb/93df9cd612.jpg.webp"]);
            collectionShow.Images.Logo.ShouldBe(["walter-r2.trakt.tv/images/shows/000/001/390/logos/medium/13b614ad43.png.webp"]);
            collectionShow.Images.Clearart.ShouldBe(["walter-r2.trakt.tv/images/shows/000/001/390/cleararts/medium/5cbde9e647.png.webp"]);
            collectionShow.Images.Banner.ShouldBe(["walter-r2.trakt.tv/images/shows/000/001/390/banners/medium/9fefff703d.jpg.webp"]);
            collectionShow.Images.Thumb.ShouldBe(["walter-r2.trakt.tv/images/shows/000/001/390/thumbs/medium/7beccbd5a1.jpg.webp"]);

            collectionShow.AiredEpisodes.ShouldBe(73U);
            collectionShow.OriginalTitle.ShouldBe("Game of Thrones");

            collectionShow.SocialIDs.ShouldNotBeNull();
            collectionShow.SocialIDs.Twitter.ShouldBe("GameOfThrones");
            collectionShow.SocialIDs.Facebook.ShouldBe("GameOfThrones");
            collectionShow.SocialIDs.Instagram.ShouldBe("gameofthrones");
            collectionShow.SocialIDs.Wikipedia.ShouldBe("https://en.wikipedia.org/wiki/Game_of_Thrones");
        }

        [Fact]
        public async Task TestTraktCollectionShowsFromJsonMinimal()
        {
            IReadOnlyList<TraktCollectionShow>? collectionShows = await TestUtility.DeserializeJsonListAsync<TraktCollectionShow>("Shows\\collectionshows_minimal.json");

            collectionShows.ShouldNotBeNull();
            collectionShows.Count.ShouldBe(2);

            TraktCollectionShow collectionShow = collectionShows[0];
            collectionShow.ShouldNotBeNull();
            collectionShow.Title.ShouldBe("Game of Thrones");
            collectionShow.Year.ShouldBe(2011U);
            collectionShow.IDs.ShouldNotBeNull();
            collectionShow.IDs.Trakt.ShouldBe(1390U);
            collectionShow.IDs.Slug.ShouldBe("game-of-thrones");
            collectionShow.ToString().ShouldBe("Game of Thrones (2011)");

            // --------------------------------------------------------------------------------------------

            collectionShow = collectionShows[1];
            collectionShow.ShouldNotBeNull();
            collectionShow.Title.ShouldBe("The Pitt");
            collectionShow.Year.ShouldBe(2025U);
            collectionShow.IDs.ShouldNotBeNull();
            collectionShow.IDs.Trakt.ShouldBe(232884U);
            collectionShow.IDs.Slug.ShouldBe("the-pitt");
            collectionShow.ToString().ShouldBe("The Pitt (2025)");
        }

        [Fact]
        public async Task TestTraktCollectionShowsFromJson()
        {
            IReadOnlyList<TraktCollectionShow>? collectionShows = await TestUtility.DeserializeJsonListAsync<TraktCollectionShow>("Shows\\collectionshows.json");

            collectionShows.ShouldNotBeNull();
            collectionShows.Count.ShouldBe(2);

            TraktCollectionShow collectionShow = collectionShows[0];
            collectionShow.ShouldNotBeNull();
            collectionShow.Title.ShouldBe("Game of Thrones");
            collectionShow.Year.ShouldBe(2011U);
            collectionShow.Status.ShouldBe(TraktShowStatus.Ended);
            collectionShow.Ending.ShouldBe(TraktShowEnding.Concluded);
            collectionShow.TotalRuntime.ShouldBe(4161U);
            collectionShow.Colors.ShouldNotBeNull();
            collectionShow.Colors.Poster.ShouldNotBeNull();
            collectionShow.Colors.Poster.ShouldBe(["#1D262D", "#C5A059"], Case.Sensitive);
            collectionShow.Subgenres.ShouldNotBeNull();
            collectionShow.Subgenres.ShouldBe(["sword-and-sorcery", "political-drama"], Case.Sensitive);
            collectionShow.OriginalTitle.ShouldBe("Game of Thrones");
            collectionShow.SocialIDs.ShouldNotBeNull();
            collectionShow.SocialIDs.Twitter.ShouldBe("GameOfThrones");

            // --------------------------------------------------------------------------------------------

            collectionShow = collectionShows[1];
            collectionShow.ShouldNotBeNull();
            collectionShow.Title.ShouldBe("The Pitt");
            collectionShow.Year.ShouldBe(2025U);
            collectionShow.Status.ShouldBe(TraktShowStatus.ReturningSeries);
            collectionShow.Ending.ShouldBeNull();
            collectionShow.Runtime.ShouldBe(48U);
            collectionShow.TotalRuntime.ShouldBe(720U);
            collectionShow.Colors.ShouldNotBeNull();
            collectionShow.Colors.Poster.ShouldNotBeNull();
            collectionShow.Colors.Poster.ShouldBe(["#0B1C2C", "#5A8FB8"], Case.Sensitive);
            collectionShow.Subgenres.ShouldNotBeNull();
            collectionShow.Subgenres.ShouldBe(["medical-drama"], Case.Sensitive);
            collectionShow.OriginalTitle.ShouldBe("The Pitt");
            collectionShow.SocialIDs.ShouldNotBeNull();
            collectionShow.SocialIDs.Twitter.ShouldBe("ThePittMax");
        }
    }
}
