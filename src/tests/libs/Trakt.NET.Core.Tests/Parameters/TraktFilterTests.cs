namespace TraktNET.Paramters
{
    public sealed class TraktFilterTests
    {
        [Fact]
        public void TestTraktFilterConstructor()
        {
            var filter = new TraktFilter();

            filter.Query.ShouldBeNull();
            filter.Year.ShouldBeNull();
            filter.Years.ShouldBeNull();
            filter.Genres.ShouldBeNull();
            filter.Languages.ShouldBeNull();
            filter.Countries.ShouldBeNull();
            filter.Runtimes.ShouldBeNull();
            filter.StudioIDs.ShouldBeNull();
            filter.Ratings.ShouldBeNull();
            filter.Votes.ShouldBeNull();
            filter.TMDBRatings.ShouldBeNull();
            filter.TMDBVotes.ShouldBeNull();
            filter.IMDBRatings.ShouldBeNull();
            filter.IMDBVotes.ShouldBeNull();
            filter.RottenTomatoesMeters.ShouldBeNull();
            filter.RottenTomatoesUserMeters.ShouldBeNull();
            filter.Metascores.ShouldBeNull();
            filter.Certifications.ShouldBeNull();
            filter.NetworkIDs.ShouldBeNull();
            filter.Status.ShouldBeNull();
            filter.EpisodeTypes.ShouldBeNull();
            filter.Hide.ShouldBeNull();
            filter.IgnoreWatched.ShouldBeNull();
            filter.IgnoreCollected.ShouldBeNull();
            filter.IgnoreWatchlisted.ShouldBeNull();
            filter.StartDate.ShouldBeNull();
            filter.EndDate.ShouldBeNull();
            filter.ParentalNudity.ShouldBeNull();
            filter.ParentalViolence.ShouldBeNull();
            filter.ParentalProfanity.ShouldBeNull();
            filter.ParentalAlcohol.ShouldBeNull();
            filter.ParentalFrightening.ShouldBeNull();
            filter.ParentalIncludeUnrated.ShouldBeNull();
            filter.Studios.ShouldBeNull();
            filter.People.ShouldBeNull();
            filter.PeopleOperator.ShouldBeNull();
            filter.PeopleRole.ShouldBeNull();
            filter.ReleasedWithinDays.ShouldBeNull();
            filter.Theme.ShouldBeNull();
        }

        [Fact]
        public void TestTraktFilterToStringEmpty()
        {
            var filter = new TraktFilter();

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringQuery()
        {
            var filter = new TraktFilter
            {
                Query = "testquery"
            };

            filter.ToString().ShouldBe("query=testquery");

            filter = new TraktFilter
            {
                Query = string.Empty
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringYear()
        {
            var filter = new TraktFilter
            {
                Year = 2024
            };

            filter.ToString().ShouldBe("years=2024");
        }

        [Fact]
        public void TestTraktFilterToStringYears()
        {
            var filter = new TraktFilter
            {
                Years = new Range<uint>(2020, 2024)
            };

            filter.ToString().ShouldBe("years=2020-2024");

            filter = new TraktFilter
            {
                Years = new Range<uint>(2024, 2020)
            };

            filter.ToString().ShouldBe("years=2020-2024");
        }

        [Fact]
        public void TestTraktFilterToStringGenres()
        {
            var filter = new TraktFilter
            {
                Genres = ["action", "drama"]
            };

            filter.ToString().ShouldBe("genres=action,drama");

            filter = new TraktFilter
            {
                Genres = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringSubgenres()
        {
            var filter = new TraktFilter
            {
                Subgenres = ["action", "drama"]
            };

            filter.ToString().ShouldBe("subgenres=action,drama");

            filter = new TraktFilter
            {
                Subgenres = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringLanguages()
        {
            var filter = new TraktFilter
            {
                Languages = ["en", "de"]
            };

            filter.ToString().ShouldBe("languages=en,de");

            filter = new TraktFilter
            {
                Languages = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringCountries()
        {
            var filter = new TraktFilter
            {
                Countries = ["us", "de"]
            };

            filter.ToString().ShouldBe("countries=us,de");

            filter = new TraktFilter
            {
                Countries = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringRuntimes()
        {
            var filter = new TraktFilter
            {
                Runtimes = new Range<uint>(70, 90)
            };

            filter.ToString().ShouldBe("runtimes=70-90");

            filter = new TraktFilter
            {
                Runtimes = new Range<uint>(90, 70)
            };

            filter.ToString().ShouldBe("runtimes=70-90");
        }

        [Fact]
        public void TestTraktFilterToStringStudioIDs()
        {
            var filter = new TraktFilter
            {
                StudioIDs = [7, 8, 9]
            };

            filter.ToString().ShouldBe("studio_ids=7,8,9");

            filter = new TraktFilter
            {
                StudioIDs = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringRatings()
        {
            var filter = new TraktFilter
            {
                Ratings = new Range<uint>(70, 90)
            };

            filter.ToString().ShouldBe("ratings=70-90");

            filter = new TraktFilter
            {
                Ratings = new Range<uint>(90, 70)
            };

            filter.ToString().ShouldBe("ratings=70-90");
        }

        [Fact]
        public void TestTraktFilterToStringVotes()
        {
            var filter = new TraktFilter
            {
                Votes = new Range<uint>(2000, 5000)
            };

            filter.ToString().ShouldBe("votes=2000-5000");

            filter = new TraktFilter
            {
                Votes = new Range<uint>(5000, 2000)
            };

            filter.ToString().ShouldBe("votes=2000-5000");
        }

        [Fact]
        public void TestTraktFilterToStringTMDBRatings()
        {
            var filter = new TraktFilter
            {
                TMDBRatings = new Range<float>(5.5f, 10.0f)
            };

            filter.ToString().ShouldBe("tmdb_ratings=5.5-10");

            filter = new TraktFilter
            {
                TMDBRatings = new Range<float>(10.0f, 5.5f)
            };

            filter.ToString().ShouldBe("tmdb_ratings=5.5-10");
        }

        [Fact]
        public void TestTraktFilterToStringTMDBVotes()
        {
            var filter = new TraktFilter
            {
                TMDBVotes = new Range<uint>(2000, 5000)
            };

            filter.ToString().ShouldBe("tmdb_votes=2000-5000");

            filter = new TraktFilter
            {
                TMDBVotes = new Range<uint>(5000, 2000)
            };

            filter.ToString().ShouldBe("tmdb_votes=2000-5000");
        }

        [Fact]
        public void TestTraktFilterToStringIMDBRatings()
        {
            var filter = new TraktFilter
            {
                IMDBRatings = new Range<float>(5.5f, 10.0f)
            };

            filter.ToString().ShouldBe("imdb_ratings=5.5-10");

            filter = new TraktFilter
            {
                IMDBRatings = new Range<float>(10.0f, 5.5f)
            };

            filter.ToString().ShouldBe("imdb_ratings=5.5-10");
        }

        [Fact]
        public void TestTraktFilterToStringIMDBVotes()
        {
            var filter = new TraktFilter
            {
                IMDBVotes = new Range<uint>(2000, 5000)
            };

            filter.ToString().ShouldBe("imdb_votes=2000-5000");

            filter = new TraktFilter
            {
                IMDBVotes = new Range<uint>(5000, 2000)
            };

            filter.ToString().ShouldBe("imdb_votes=2000-5000");
        }

        [Fact]
        public void TestTraktFilterToStringRottenTomatoesMeters()
        {
            var filter = new TraktFilter
            {
                RottenTomatoesMeters = new Range<uint>(70, 90)
            };

            filter.ToString().ShouldBe("rt_meters=70-90");

            filter = new TraktFilter
            {
                RottenTomatoesMeters = new Range<uint>(90, 70)
            };

            filter.ToString().ShouldBe("rt_meters=70-90");
        }

        [Fact]
        public void TestTraktFilterToStringRottenTomatoesUserMeters()
        {
            var filter = new TraktFilter
            {
                RottenTomatoesUserMeters = new Range<uint>(70, 90)
            };

            filter.ToString().ShouldBe("rt_user_meters=70-90");

            filter = new TraktFilter
            {
                RottenTomatoesUserMeters = new Range<uint>(90, 70)
            };

            filter.ToString().ShouldBe("rt_user_meters=70-90");
        }

        [Fact]
        public void TestTraktFilterToStringMetascores()
        {
            var filter = new TraktFilter
            {
                Metascores = new Range<float>(5.5f, 10.0f)
            };

            filter.ToString().ShouldBe("metascores=5.5-10");

            filter = new TraktFilter
            {
                Metascores = new Range<float>(10.0f, 5.5f)
            };

            filter.ToString().ShouldBe("metascores=5.5-10");
        }

        [Fact]
        public void TestTraktFilterToStringCertifications()
        {
            var filter = new TraktFilter
            {
                Certifications = ["R", "tv-pg"]
            };

            filter.ToString().ShouldBe("certifications=R,tv-pg");

            filter = new TraktFilter
            {
                Certifications = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringNetworkIDs()
        {
            var filter = new TraktFilter
            {
                NetworkIDs = [7, 8, 9]
            };

            filter.ToString().ShouldBe("network_ids=7,8,9");
        }

        [Fact]
        public void TestTraktFilterToStringStatus()
        {
            var filter = new TraktFilter
            {
                Status = [TraktShowStatus.Ended, TraktShowStatus.Planned]
            };

            filter.ToString().ShouldBe("status=ended,planned");

            filter = new TraktFilter
            {
                Status = [TraktShowStatus.Unspecified, TraktShowStatus.Planned]
            };

            filter.ToString().ShouldBe("status=planned");

            filter = new TraktFilter
            {
                Status = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringEpisodeTypes()
        {
            var filter = new TraktFilter
            {
                EpisodeTypes = [TraktEpisodeType.SeriesPremiere, TraktEpisodeType.SeasonPremiere]
            };

            filter.ToString().ShouldBe("episode_types=series_premiere,season_premiere");

            filter = new TraktFilter
            {
                EpisodeTypes = [TraktEpisodeType.Unspecified, TraktEpisodeType.SeasonPremiere]
            };

            filter.ToString().ShouldBe("episode_types=season_premiere");

            filter = new TraktFilter
            {
                EpisodeTypes = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringHide()
        {
            var filter = new TraktFilter
            {
                Hide = TraktFilterHide.Unwatched
            };

            filter.ToString().ShouldBe("hide=unwatched");

            filter = new TraktFilter
            {
                Hide = TraktFilterHide.NoReleaseDate
            };

            filter.ToString().ShouldBe("hide=noreleasedate");

            filter = new TraktFilter
            {
                Hide = TraktFilterHide.NoNotes
            };

            filter.ToString().ShouldBe("hide=nonotes");

            filter = new TraktFilter
            {
                Hide = TraktFilterHide.Unspecified
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringIgnoreFlags()
        {
            var filter = new TraktFilter
            {
                IgnoreWatched = true,
                IgnoreCollected = true,
                IgnoreWatchlisted = true
            };
            filter.ToString().ShouldBe("ignore_watched=true&ignore_collected=true&ignore_watchlisted=true");
        }

        [Fact]
        public void TestTraktFilterToStringDates()
        {
            var filter = new TraktFilter
            {
                StartDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Utc)
            };
            filter.ToString().ShouldBe("start_date=2024-01-01&end_date=2024-12-31");
        }

        [Fact]
        public void TestTraktFilterToStringParentalNudity()
        {
            var filter = new TraktFilter
            {
                ParentalNudity = new Range<uint>(0, 1)
            };

            filter.ToString().ShouldBe("parental_nudity=0-1");

            filter = new TraktFilter
            {
                ParentalNudity = new Range<uint>(1, 0)
            };

            filter.ToString().ShouldBe("parental_nudity=0-1");
        }

        [Fact]
        public void TestTraktFilterToStringParentalViolence()
        {
            var filter = new TraktFilter
            {
                ParentalViolence = new Range<uint>(1, 2)
            };

            filter.ToString().ShouldBe("parental_violence=1-2");

            filter = new TraktFilter
            {
                ParentalViolence = new Range<uint>(2, 1)
            };

            filter.ToString().ShouldBe("parental_violence=1-2");
        }

        [Fact]
        public void TestTraktFilterToStringParentalProfanity()
        {
            var filter = new TraktFilter
            {
                ParentalProfanity = new Range<uint>(0, 3)
            };

            filter.ToString().ShouldBe("parental_profanity=0-3");

            filter = new TraktFilter
            {
                ParentalProfanity = new Range<uint>(3, 0)
            };

            filter.ToString().ShouldBe("parental_profanity=0-3");
        }

        [Fact]
        public void TestTraktFilterToStringParentalAlcohol()
        {
            var filter = new TraktFilter
            {
                ParentalAlcohol = new Range<uint>(2, 3)
            };

            filter.ToString().ShouldBe("parental_alcohol=2-3");

            filter = new TraktFilter
            {
                ParentalAlcohol = new Range<uint>(3, 2)
            };

            filter.ToString().ShouldBe("parental_alcohol=2-3");
        }

        [Fact]
        public void TestTraktFilterToStringParentalFrightening()
        {
            var filter = new TraktFilter
            {
                ParentalFrightening = new Range<uint>(1, 3)
            };

            filter.ToString().ShouldBe("parental_frightening=1-3");

            filter = new TraktFilter
            {
                ParentalFrightening = new Range<uint>(3, 1)
            };

            filter.ToString().ShouldBe("parental_frightening=1-3");
        }

        [Fact]
        public void TestTraktFilterToStringParentalIncludeUnrated()
        {
            var filter = new TraktFilter
            {
                ParentalIncludeUnrated = true
            };

            filter.ToString().ShouldBe("parental_include_unrated=true");

            filter = new TraktFilter
            {
                ParentalIncludeUnrated = false
            };

            filter.ToString().ShouldBe("parental_include_unrated=false");
        }

        [Fact]
        public void TestTraktFilterToStringStudios()
        {
            var filter = new TraktFilter
            {
                Studios = ["warner-bros-pictures", "universal-pictures"]
            };

            filter.ToString().ShouldBe("studios=warner-bros-pictures,universal-pictures");

            filter = new TraktFilter
            {
                Studios = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringPeople()
        {
            var filter = new TraktFilter
            {
                People = ["christopher-nolan", "tom-hardy"]
            };

            filter.ToString().ShouldBe("people=christopher-nolan,tom-hardy");

            filter = new TraktFilter
            {
                People = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringPeopleOperator()
        {
            var filter = new TraktFilter
            {
                PeopleOperator = TraktFilterOperator.And
            };

            filter.ToString().ShouldBe("people_operator=and");

            filter = new TraktFilter
            {
                PeopleOperator = TraktFilterOperator.Or
            };

            filter.ToString().ShouldBe("people_operator=or");

            filter = new TraktFilter
            {
                PeopleOperator = TraktFilterOperator.Unspecified
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringPeopleRole()
        {
            var filter = new TraktFilter
            {
                PeopleRole = TraktPeopleRole.Directing
            };

            filter.ToString().ShouldBe("people_role=directing");

            filter = new TraktFilter
            {
                PeopleRole = TraktPeopleRole.Cast
            };

            filter.ToString().ShouldBe("people_role=cast");

            filter = new TraktFilter
            {
                PeopleRole = TraktPeopleRole.Unspecified
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringReleasedWithinDays()
        {
            var filter = new TraktFilter
            {
                ReleasedWithinDays = 30
            };

            filter.ToString().ShouldBe("released_within_days=30");
        }

        [Fact]
        public void TestTraktFilterToStringTheme()
        {
            var filter = new TraktFilter
            {
                Theme = "halloween"
            };

            filter.ToString().ShouldBe("theme=halloween");

            filter = new TraktFilter
            {
                Theme = string.Empty
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringAllValues()
        {
            var filter = new TraktFilter
            {
                Query = "testquery",
                Years = new Range<uint>(2020, 2024),
                Genres = ["action", "drama"],
                Languages = ["en", "de"],
                Countries = ["us", "de"],
                Runtimes = new Range<uint>(70, 90),
                StudioIDs = [7, 8, 9],
                Ratings = new Range<uint>(70, 90),
                Votes = new Range<uint>(2000, 5000),
                TMDBRatings = new Range<float>(5.5f, 10.0f),
                TMDBVotes = new Range<uint>(2000, 5000),
                IMDBRatings = new Range<float>(5.5f, 10.0f),
                IMDBVotes = new Range<uint>(2000, 5000),
                RottenTomatoesMeters = new Range<uint>(70, 90),
                RottenTomatoesUserMeters = new Range<uint>(70, 90),
                Metascores = new Range<float>(5.5f, 10.0f),
                Certifications = ["R", "tv-pg"],
                NetworkIDs = [7, 8, 9],
                Status = [TraktShowStatus.Ended, TraktShowStatus.Planned],
                EpisodeTypes = [TraktEpisodeType.SeriesPremiere, TraktEpisodeType.SeasonPremiere],
                Hide = TraktFilterHide.Unwatched,
                IgnoreWatched = true,
                IgnoreCollected = true,
                IgnoreWatchlisted = true,
                StartDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                ParentalNudity = new Range<uint>(0, 1),
                ParentalViolence = new Range<uint>(1, 2),
                ParentalProfanity = new Range<uint>(0, 3),
                ParentalAlcohol = new Range<uint>(2, 3),
                ParentalFrightening = new Range<uint>(1, 3),
                ParentalIncludeUnrated = true,
                Studios = ["warner-bros-pictures", "universal-pictures"],
                People = ["christopher-nolan", "tom-hardy"],
                PeopleOperator = TraktFilterOperator.And,
                PeopleRole = TraktPeopleRole.Directing,
                ReleasedWithinDays = 30,
                Theme = "halloween"
            };

            filter.ToString().ShouldBe("query=testquery&years=2020-2024&genres=action,drama&languages=en,de"
                + "&countries=us,de&runtimes=70-90&studio_ids=7,8,9&ratings=70-90&votes=2000-5000&tmdb_ratings=5.5-10"
                + "&tmdb_votes=2000-5000&imdb_ratings=5.5-10&imdb_votes=2000-5000&rt_meters=70-90&rt_user_meters=70-90"
                + "&metascores=5.5-10&certifications=R,tv-pg&network_ids=7,8,9&status=ended,planned"
                + "&episode_types=series_premiere,season_premiere&hide=unwatched&ignore_watched=true&ignore_collected=true"
                + "&ignore_watchlisted=true&start_date=2024-01-01&end_date=2024-12-31"
                + "&parental_nudity=0-1&parental_violence=1-2&parental_profanity=0-3&parental_alcohol=2-3&parental_frightening=1-3"
                + "&parental_include_unrated=true&studios=warner-bros-pictures,universal-pictures"
                + "&people=christopher-nolan,tom-hardy&people_operator=and&people_role=directing&released_within_days=30"
                + "&theme=halloween");
        }
    }
}
