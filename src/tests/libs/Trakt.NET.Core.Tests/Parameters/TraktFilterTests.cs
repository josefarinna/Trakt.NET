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
            filter.ExcludeEpisodeTypes.ShouldBeNull();
            filter.IgnoreWatched.ShouldBeNull();
            filter.IgnoreCollected.ShouldBeNull();
            filter.IgnoreWatchlisted.ShouldBeNull();
            filter.StartDate.ShouldBeNull();
            filter.EndDate.ShouldBeNull();
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
                EpisodeTypes = [TraktEpisodeType.Unspecified]
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();

            filter = new TraktFilter
            {
                EpisodeTypes = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringExcludeEpisodeTypes()
        {
            var filter = new TraktFilter
            {
                ExcludeEpisodeTypes = [TraktEpisodeType.SeasonFinale, TraktEpisodeType.SeriesFinale]
            };

            filter.ToString().ShouldBe("episode_types=-season_finale,-series_finale");

            filter = new TraktFilter
            {
                ExcludeEpisodeTypes = [TraktEpisodeType.Unspecified, TraktEpisodeType.SeasonFinale]
            };

            filter.ToString().ShouldBe("episode_types=-season_finale");

            filter = new TraktFilter
            {
                ExcludeEpisodeTypes = [TraktEpisodeType.Unspecified]
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();

            filter = new TraktFilter
            {
                ExcludeEpisodeTypes = []
            };

            filter.ToString().ShouldNotBeNull();
            filter.ToString()!.ShouldBeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringEpisodeTypesAndExcludeEpisodeTypes()
        {
            var filter = new TraktFilter
            {
                EpisodeTypes = [TraktEpisodeType.SeriesPremiere, TraktEpisodeType.SeasonPremiere],
                ExcludeEpisodeTypes = [TraktEpisodeType.SeasonFinale, TraktEpisodeType.SeriesFinale]
            };

            filter.ToString().ShouldBe("episode_types=series_premiere,season_premiere,-season_finale,-series_finale");
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
                ExcludeEpisodeTypes = [TraktEpisodeType.SeasonFinale, TraktEpisodeType.SeriesFinale],
                IgnoreWatched = true,
                IgnoreCollected = true,
                IgnoreWatchlisted = true,
                StartDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Utc)
            };

            filter.ToString().ShouldBe("query=testquery&years=2020-2024&genres=action,drama&languages=en,de"
                + "&countries=us,de&runtimes=70-90&studio_ids=7,8,9&ratings=70-90&votes=2000-5000&tmdb_ratings=5.5-10"
                + "&tmdb_votes=2000-5000&imdb_ratings=5.5-10&imdb_votes=2000-5000&rt_meters=70-90&rt_user_meters=70-90"
                + "&metascores=5.5-10&certifications=R,tv-pg&network_ids=7,8,9&status=ended,planned"
                + "&episode_types=series_premiere,season_premiere,-season_finale,-series_finale&ignore_watched=true&ignore_collected=true"
                + "&ignore_watchlisted=true&start_date=2024-01-01&end_date=2024-12-31");
        }
    }
}
