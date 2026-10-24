namespace TraktNET.Json.Movies
{
    public sealed class TraktCollectionMovieTests
    {
        [Fact]
        public void TestTraktCollectionMovieConstructor()
        {
            var collectionMovie = new TraktCollectionMovie();

            collectionMovie.Movie.ShouldBeNull();
            collectionMovie.Title.ShouldBeNull();
            collectionMovie.Year.ShouldBeNull();
            collectionMovie.IDs.ShouldBeNull();
            collectionMovie.Tagline.ShouldBeNull();
            collectionMovie.Overview.ShouldBeNull();
            collectionMovie.Released.ShouldBeNull();
            collectionMovie.Runtime.ShouldBeNull();
            collectionMovie.Country.ShouldBeNull();
            collectionMovie.Trailer.ShouldBeNull();
            collectionMovie.Homepage.ShouldBeNull();
            collectionMovie.Status.ShouldBeNull();
            collectionMovie.Rating.ShouldBeNull();
            collectionMovie.Votes.ShouldBeNull();
            collectionMovie.Colors.ShouldBeNull();
            collectionMovie.CommentCount.ShouldBeNull();
            collectionMovie.UpdatedAt.ShouldBeNull();
            collectionMovie.Language.ShouldBeNull();
            collectionMovie.Languages.ShouldBeNull();
            collectionMovie.AvailableTranslations.ShouldBeNull();
            collectionMovie.Genres.ShouldBeNull();
            collectionMovie.Subgenres.ShouldBeNull();
            collectionMovie.Certification.ShouldBeNull();
            collectionMovie.AfterCredits.ShouldBeNull();
            collectionMovie.DuringCredits.ShouldBeNull();
            collectionMovie.Images.ShouldBeNull();
            collectionMovie.OriginalTitle.ShouldBeNull();
            collectionMovie.SocialIDs.ShouldBeNull();

            collectionMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktCollectionMoviePropertiesWithNullMovie()
        {
            var collectionMovie = new TraktCollectionMovie
            {
                Title = "Deadpool & Wolverine",
                Year = 2024U,
                IDs = new TraktMovieIDs { Trakt = 395672U },
                Tagline = "Come together.",
                Overview = "Overview",
#if NET7_0_OR_GREATER
                Released = TestUtility.ParseDate("2024-07-26"),
#else
                Released = TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z"),
#endif
                Runtime = 128U,
                Country = "us",
                Trailer = "https://youtube.com/watch?v=Idh8n5XuYIA",
                Homepage = "http://www.marvel.com/movies/deadpool-and-wolverine",
                Status = TraktMovieStatus.Released,
                Rating = 8.24f,
                Votes = 5758U,
                Colors = new TraktColors { Poster = ["#E50914"] },
                CommentCount = 159U,
                UpdatedAt = TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z"),
                Language = "en",
                Languages = ["en"],
                AvailableTranslations = ["en", "es"],
                Genres = ["comedy", "action"],
                Subgenres = ["buddy-comedy"],
                Certification = "R",
                AfterCredits = true,
                DuringCredits = true,
                Images = new TraktMovieImages { Poster = ["poster.jpg"] },
                OriginalTitle = "Deadpool & Wolverine",
                SocialIDs = new TraktMovieSocialIDs { Twitter = "deadpoolmovie" }
            };

            collectionMovie.Movie.ShouldBeNull();
            collectionMovie.Title.ShouldBeNull();
            collectionMovie.Year.ShouldBeNull();
            collectionMovie.IDs.ShouldBeNull();
            collectionMovie.Tagline.ShouldBeNull();
            collectionMovie.Overview.ShouldBeNull();
            collectionMovie.Released.ShouldBeNull();
            collectionMovie.Runtime.ShouldBeNull();
            collectionMovie.Country.ShouldBeNull();
            collectionMovie.Trailer.ShouldBeNull();
            collectionMovie.Homepage.ShouldBeNull();
            collectionMovie.Status.ShouldBeNull();
            collectionMovie.Rating.ShouldBeNull();
            collectionMovie.Votes.ShouldBeNull();
            collectionMovie.Colors.ShouldBeNull();
            collectionMovie.CommentCount.ShouldBeNull();
            collectionMovie.UpdatedAt.ShouldBeNull();
            collectionMovie.Language.ShouldBeNull();
            collectionMovie.Languages.ShouldBeNull();
            collectionMovie.AvailableTranslations.ShouldBeNull();
            collectionMovie.Genres.ShouldBeNull();
            collectionMovie.Subgenres.ShouldBeNull();
            collectionMovie.Certification.ShouldBeNull();
            collectionMovie.AfterCredits.ShouldBeNull();
            collectionMovie.DuringCredits.ShouldBeNull();
            collectionMovie.Images.ShouldBeNull();
            collectionMovie.OriginalTitle.ShouldBeNull();
            collectionMovie.SocialIDs.ShouldBeNull();

            collectionMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktCollectionMovieProperties()
        {
            var ids = new TraktMovieIDs { Trakt = 395672U, Slug = "deadpool-wolverine-2024" };
            var colors = new TraktColors { Poster = ["#E50914", "#FFD700"] };
            var images = new TraktMovieImages { Poster = ["poster.jpg"] };
            var socialIds = new TraktMovieSocialIDs { Twitter = "deadpoolmovie", Facebook = "DeadpoolMovie" };
            DateTime updatedAt = TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z");
#if NET7_0_OR_GREATER
            DateOnly released = TestUtility.ParseDate("2024-07-26");
#else
            DateTime released = TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z");
#endif

            var collectionMovie = new TraktCollectionMovie
            {
                Movie = new TraktMovie()
            };

            collectionMovie.Title = "Deadpool & Wolverine";
            collectionMovie.Year = 2024U;
            collectionMovie.IDs = ids;
            collectionMovie.Tagline = "Come together.";
            collectionMovie.Overview = "Overview";
            collectionMovie.Released = released;
            collectionMovie.Runtime = 128U;
            collectionMovie.Country = "us";
            collectionMovie.Trailer = "https://youtube.com/watch?v=Idh8n5XuYIA";
            collectionMovie.Homepage = "http://www.marvel.com/movies/deadpool-and-wolverine";
            collectionMovie.Status = TraktMovieStatus.Released;
            collectionMovie.Rating = 8.24f;
            collectionMovie.Votes = 5758U;
            collectionMovie.Colors = colors;
            collectionMovie.CommentCount = 159U;
            collectionMovie.UpdatedAt = updatedAt;
            collectionMovie.Language = "en";
            collectionMovie.Languages = ["en"];
            collectionMovie.AvailableTranslations = ["en", "es"];
            collectionMovie.Genres = ["comedy", "action"];
            collectionMovie.Subgenres = ["buddy-comedy"];
            collectionMovie.Certification = "R";
            collectionMovie.AfterCredits = true;
            collectionMovie.DuringCredits = false;
            collectionMovie.Images = images;
            collectionMovie.OriginalTitle = "Deadpool & Wolverine";
            collectionMovie.SocialIDs = socialIds;

            collectionMovie.Movie.ShouldNotBeNull();
            collectionMovie.Title.ShouldBe("Deadpool & Wolverine");
            collectionMovie.Year.ShouldBe(2024U);
            collectionMovie.IDs.ShouldBe(ids);
            collectionMovie.Tagline.ShouldBe("Come together.");
            collectionMovie.Overview.ShouldBe("Overview");
            collectionMovie.Released.ShouldBe(released);
            collectionMovie.Runtime.ShouldBe(128U);
            collectionMovie.Country.ShouldBe("us");
            collectionMovie.Trailer.ShouldBe("https://youtube.com/watch?v=Idh8n5XuYIA");
            collectionMovie.Homepage.ShouldBe("http://www.marvel.com/movies/deadpool-and-wolverine");
            collectionMovie.Status.ShouldBe(TraktMovieStatus.Released);
            collectionMovie.Rating.ShouldBe(8.24f);
            collectionMovie.Votes.ShouldBe(5758U);
            collectionMovie.Colors.ShouldBe(colors);
            collectionMovie.CommentCount.ShouldBe(159U);
            collectionMovie.UpdatedAt.ShouldBe(updatedAt);
            collectionMovie.Language.ShouldBe("en");
            collectionMovie.Languages.ShouldBe(["en"]);
            collectionMovie.AvailableTranslations.ShouldBe(["en", "es"]);
            collectionMovie.Genres.ShouldBe(["comedy", "action"]);
            collectionMovie.Subgenres.ShouldBe(["buddy-comedy"]);
            collectionMovie.Certification.ShouldBe("R");
            collectionMovie.AfterCredits.ShouldBe(true);
            collectionMovie.DuringCredits.ShouldBe(false);
            collectionMovie.Images.ShouldBe(images);
            collectionMovie.OriginalTitle.ShouldBe("Deadpool & Wolverine");
            collectionMovie.SocialIDs.ShouldBe(socialIds);

            collectionMovie.ToString().ShouldBe("Deadpool & Wolverine (2024)");
        }

        [Fact]
        public async Task TestTraktCollectionMovieFromJsonMinimal()
        {
            TraktCollectionMovie? collectionMovie = await TestUtility.DeserializeJsonAsync<TraktCollectionMovie>("Movies\\collectionmovie_minimal.json");

            collectionMovie.ShouldNotBeNull();
            collectionMovie.Movie.ShouldNotBeNull();

            collectionMovie.Title.ShouldBe("Deadpool & Wolverine");
            collectionMovie.Year.ShouldBe(2024U);

            collectionMovie.IDs.ShouldNotBeNull();
            collectionMovie.IDs.Trakt.ShouldBe(395672U);
            collectionMovie.IDs.Slug.ShouldBe("deadpool-wolverine-2024");
            collectionMovie.IDs.IMDB.ShouldBe("tt6263850");
            collectionMovie.IDs.TMDB.ShouldBe(533535U);
            collectionMovie.IDs.HasAnyID.ShouldBe(true);
            collectionMovie.IDs.BestID.ShouldBe("deadpool-wolverine-2024");

            collectionMovie.ToString().ShouldBe("Deadpool & Wolverine (2024)");
        }

        [Fact]
        public async Task TestTraktCollectionMovieFromJson()
        {
            TraktCollectionMovie? collectionMovie = await TestUtility.DeserializeJsonAsync<TraktCollectionMovie>("Movies\\collectionmovie.json");

            collectionMovie.ShouldNotBeNull();
            collectionMovie.Movie.ShouldNotBeNull();

            collectionMovie.Title.ShouldBe("Deadpool & Wolverine");
            collectionMovie.Year.ShouldBe(2024U);

            collectionMovie.IDs.ShouldNotBeNull();
            collectionMovie.IDs.Trakt.ShouldBe(395672U);
            collectionMovie.IDs.Slug.ShouldBe("deadpool-wolverine-2024");
            collectionMovie.IDs.IMDB.ShouldBe("tt6263850");
            collectionMovie.IDs.TMDB.ShouldBe(533535U);
            collectionMovie.IDs.HasAnyID.ShouldBe(true);
            collectionMovie.IDs.BestID.ShouldBe("deadpool-wolverine-2024");

            collectionMovie.ToString().ShouldBe("Deadpool & Wolverine (2024)");

            collectionMovie.Tagline.ShouldBe("Come together.");
            collectionMovie.Overview.ShouldBe("A listless Wade Wilson toils away in civilian life with his days as the morally "
                + "flexible mercenary, Deadpool, behind him.");

#if NET7_0_OR_GREATER
            collectionMovie.Released.ShouldBe(TestUtility.ParseDate("2024-07-26"));
#else
            collectionMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z"));
#endif
            collectionMovie.Runtime.ShouldBe(128U);
            collectionMovie.Country.ShouldBe("us");
            collectionMovie.Trailer.ShouldBe("https://youtube.com/watch?v=Idh8n5XuYIA");
            collectionMovie.Homepage.ShouldBe("http://www.marvel.com/movies/deadpool-and-wolverine");
            collectionMovie.Status.ShouldBe(TraktMovieStatus.Released);
            collectionMovie.Rating.ShouldBe(8.244876693296284f);
            collectionMovie.Votes.ShouldBe(5758U);

            collectionMovie.Colors.ShouldNotBeNull();
            collectionMovie.Colors.Poster.ShouldNotBeNull();
            collectionMovie.Colors.Poster.Count.ShouldBe(2);
            collectionMovie.Colors.Poster.ShouldBe(["#E50914", "#FFD700"], Case.Sensitive);

            collectionMovie.CommentCount.ShouldBe(159U);
            collectionMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z"));
            collectionMovie.Language.ShouldBe("en");

            collectionMovie.Languages.ShouldNotBeNull();
            collectionMovie.Languages.Count.ShouldBe(1);
            collectionMovie.Languages.ShouldBe(["en"], Case.Sensitive);

            collectionMovie.AvailableTranslations.ShouldNotBeNull();
            collectionMovie.AvailableTranslations.Count.ShouldBe(31);
            collectionMovie.AvailableTranslations.ShouldBe([
                "ar", "bg", "cs", "de", "el", "en", "es", "fa", "fr", "he", "hu", "id", "it", "ja", "ka", "kk",
                "ko", "lt", "nl", "pl", "pt", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            collectionMovie.Genres.ShouldNotBeNull();
            collectionMovie.Genres.Count.ShouldBe(4);
            collectionMovie.Genres.ShouldBe([
                "comedy", "superhero", "science-fiction", "action"
            ], Case.Sensitive);

            collectionMovie.Subgenres.ShouldNotBeNull();
            collectionMovie.Subgenres.Count.ShouldBe(2);
            collectionMovie.Subgenres.ShouldBe(["buddy-comedy", "multiverse"], Case.Sensitive);

            collectionMovie.Certification.ShouldBe("R");
            collectionMovie.AfterCredits.ShouldBe(true);
            collectionMovie.DuringCredits.ShouldBe(true);

            collectionMovie.Images.ShouldNotBeNull();
            collectionMovie.Images.Fanart.ShouldBe(["walter-r2.trakt.tv/images/movies/000/395/672/fanarts/medium/fanart.jpg.webp"]);
            collectionMovie.Images.Poster.ShouldBe(["walter-r2.trakt.tv/images/movies/000/395/672/posters/thumb/poster.jpg.webp"]);
            collectionMovie.Images.Logo.ShouldBe(["walter-r2.trakt.tv/images/movies/000/395/672/logos/medium/logo.png.webp"]);
            collectionMovie.Images.Clearart.ShouldBe(["walter-r2.trakt.tv/images/movies/000/395/672/cleararts/medium/clearart.png.webp"]);
            collectionMovie.Images.Banner.ShouldBe(["walter-r2.trakt.tv/images/movies/000/395/672/banners/medium/banner.jpg.webp"]);
            collectionMovie.Images.Thumb.ShouldBe(["walter-r2.trakt.tv/images/movies/000/395/672/thumbs/medium/thumb.jpg.webp"]);

            collectionMovie.OriginalTitle.ShouldBe("Deadpool & Wolverine");

            collectionMovie.SocialIDs.ShouldNotBeNull();
            collectionMovie.SocialIDs.Twitter.ShouldBe("deadpoolmovie");
            collectionMovie.SocialIDs.Facebook.ShouldBe("DeadpoolMovie");
            collectionMovie.SocialIDs.Instagram.ShouldBe("deadpoolmovie");
            collectionMovie.SocialIDs.Wikipedia.ShouldBe("https://en.wikipedia.org/wiki/Deadpool_%26_Wolverine");
        }

        [Fact]
        public async Task TestTraktCollectionMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktCollectionMovie>? collectionMovies = await TestUtility.DeserializeJsonListAsync<TraktCollectionMovie>("Movies\\collectionmovies_minimal.json");

            collectionMovies.ShouldNotBeNull();
            collectionMovies.Count.ShouldBe(2);

            TraktCollectionMovie collectionMovie = collectionMovies[0];
            collectionMovie.ShouldNotBeNull();
            collectionMovie.Title.ShouldBe("Deadpool & Wolverine");
            collectionMovie.Year.ShouldBe(2024U);
            collectionMovie.IDs.ShouldNotBeNull();
            collectionMovie.IDs.Trakt.ShouldBe(395672U);
            collectionMovie.IDs.Slug.ShouldBe("deadpool-wolverine-2024");
            collectionMovie.IDs.IMDB.ShouldBe("tt6263850");
            collectionMovie.IDs.TMDB.ShouldBe(533535U);
            collectionMovie.ToString().ShouldBe("Deadpool & Wolverine (2024)");

            // --------------------------------------------------------------------------------------------

            collectionMovie = collectionMovies[1];
            collectionMovie.ShouldNotBeNull();
            collectionMovie.Title.ShouldBe("Kingdom of the Planet of the Apes");
            collectionMovie.Year.ShouldBe(2024U);
            collectionMovie.IDs.ShouldNotBeNull();
            collectionMovie.IDs.Trakt.ShouldBe(488280U);
            collectionMovie.IDs.Slug.ShouldBe("kingdom-of-the-planet-of-the-apes-2024");
            collectionMovie.IDs.IMDB.ShouldBe("tt11389872");
            collectionMovie.IDs.TMDB.ShouldBe(653346U);
            collectionMovie.ToString().ShouldBe("Kingdom of the Planet of the Apes (2024)");
        }

        [Fact]
        public async Task TestTraktCollectionMoviesFromJson()
        {
            IReadOnlyList<TraktCollectionMovie>? collectionMovies = await TestUtility.DeserializeJsonListAsync<TraktCollectionMovie>("Movies\\collectionmovies.json");

            collectionMovies.ShouldNotBeNull();
            collectionMovies.Count.ShouldBe(2);

            TraktCollectionMovie collectionMovie = collectionMovies[0];
            collectionMovie.ShouldNotBeNull();
            collectionMovie.Title.ShouldBe("Deadpool & Wolverine");
            collectionMovie.Year.ShouldBe(2024U);
            collectionMovie.IDs.ShouldNotBeNull();
            collectionMovie.IDs.Trakt.ShouldBe(395672U);
            collectionMovie.Tagline.ShouldBe("Come together.");
            collectionMovie.Runtime.ShouldBe(128U);
            collectionMovie.Country.ShouldBe("us");
            collectionMovie.Status.ShouldBe(TraktMovieStatus.Released);
            collectionMovie.Colors.ShouldNotBeNull();
            collectionMovie.Colors.Poster.ShouldNotBeNull();
            collectionMovie.Colors.Poster.ShouldBe(["#E50914", "#FFD700"], Case.Sensitive);
            collectionMovie.Subgenres.ShouldNotBeNull();
            collectionMovie.Subgenres.ShouldBe(["buddy-comedy", "multiverse"], Case.Sensitive);
            collectionMovie.AfterCredits.ShouldBe(true);
            collectionMovie.DuringCredits.ShouldBe(true);
            collectionMovie.OriginalTitle.ShouldBe("Deadpool & Wolverine");
            collectionMovie.SocialIDs.ShouldNotBeNull();
            collectionMovie.SocialIDs.Twitter.ShouldBe("deadpoolmovie");

            // --------------------------------------------------------------------------------------------

            collectionMovie = collectionMovies[1];
            collectionMovie.ShouldNotBeNull();
            collectionMovie.Title.ShouldBe("Kingdom of the Planet of the Apes");
            collectionMovie.Year.ShouldBe(2024U);
            collectionMovie.IDs.ShouldNotBeNull();
            collectionMovie.IDs.Trakt.ShouldBe(488280U);
            collectionMovie.Tagline.ShouldBe("No one can stop the reign.");
            collectionMovie.Runtime.ShouldBe(145U);
            collectionMovie.Country.ShouldBe("us");
            collectionMovie.Status.ShouldBe(TraktMovieStatus.Released);
            collectionMovie.Colors.ShouldNotBeNull();
            collectionMovie.Colors.Poster.ShouldNotBeNull();
            collectionMovie.Colors.Poster.ShouldBe(["#2E4A36", "#8A9A86"], Case.Sensitive);
            collectionMovie.Subgenres.ShouldNotBeNull();
            collectionMovie.Subgenres.ShouldBe(["post-apocalyptic", "survival"], Case.Sensitive);
            collectionMovie.AfterCredits.ShouldBe(false);
            collectionMovie.DuringCredits.ShouldBe(false);
            collectionMovie.OriginalTitle.ShouldBe("Kingdom of the Planet of the Apes");
            collectionMovie.SocialIDs.ShouldNotBeNull();
            collectionMovie.SocialIDs.Twitter.ShouldBe("apesmovies");
        }
    }
}
