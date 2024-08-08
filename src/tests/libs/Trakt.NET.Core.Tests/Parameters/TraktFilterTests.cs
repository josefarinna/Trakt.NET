namespace TraktNET.Paramters
{
    public sealed class TraktFilterTests
    {
        [Fact]
        public void TestTraktFilterConstructor()
        {
            var filter = new TraktFilter();

            filter.Query.Should().BeNull();
            filter.Year.Should().BeNull();
            filter.Years.Should().BeNull();
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.StudioIds.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.Votes.Should().BeNull();
            filter.TMDBRatings.Should().BeNull();
            filter.TMDBVotes.Should().BeNull();
            filter.IMDBRatings.Should().BeNull();
            filter.IMDBVotes.Should().BeNull();
            filter.RottenTomatoesMeters.Should().BeNull();
            filter.RottenTomatoesUserMeters.Should().BeNull();
            filter.Metascores.Should().BeNull();
            filter.Certifications.Should().BeNull();
            filter.NetworkIds.Should().BeNull();
            filter.Status.Should().BeNull();
            filter.EpisodeTypes.Should().BeNull();
        }

        [Fact]
        public void TestTraktFilterToStringEmpty()
        {
            var filter = new TraktFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringQuery()
        {
            var filter = new TraktFilter
            {
                Query = "testquery"
            };

            filter.ToString().Should().Be("query=testquery");

            filter = new TraktFilter
            {
                Query = string.Empty
            };

            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringYear()
        {
            var filter = new TraktFilter
            {
                Year = 2024
            };

            filter.ToString().Should().Be("years=2024");
        }

        [Fact]
        public void TestTraktFilterToStringYears()
        {
            var filter = new TraktFilter
            {
                Years = new Range<uint>(2020, 2024)
            };

            filter.ToString().Should().Be("years=2020-2024");

            filter = new TraktFilter
            {
                Years = new Range<uint>(2024, 2020)
            };

            filter.ToString().Should().Be("years=2020-2024");
        }

        [Fact]
        public void TestTraktFilterToStringGenres()
        {
            var filter = new TraktFilter
            {
                Genres = ["action", "drama"]
            };

            filter.ToString().Should().Be("genres=action,drama");

            filter = new TraktFilter
            {
                Genres = []
            };

            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringLanguages()
        {
            var filter = new TraktFilter
            {
                Languages = ["en", "de"]
            };

            filter.ToString().Should().Be("languages=en,de");

            filter = new TraktFilter
            {
                Languages = []
            };

            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringCountries()
        {
            var filter = new TraktFilter
            {
                Countries = ["us", "de"]
            };

            filter.ToString().Should().Be("countries=us,de");

            filter = new TraktFilter
            {
                Countries = []
            };

            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringRuntimes()
        {
            var filter = new TraktFilter
            {
                Runtimes = new Range<uint>(70, 90)
            };

            filter.ToString().Should().Be("runtimes=70-90");

            filter = new TraktFilter
            {
                Runtimes = new Range<uint>(90, 70)
            };

            filter.ToString().Should().Be("runtimes=70-90");
        }

        [Fact]
        public void TestTraktFilterToStringStudioIds()
        {
            var filter = new TraktFilter
            {
                StudioIds = [7, 8, 9]
            };

            filter.ToString().Should().Be("studio_ids=7,8,9");

            filter = new TraktFilter
            {
                StudioIds = []
            };

            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringRatings()
        {
            var filter = new TraktFilter
            {
                Ratings = new Range<uint>(70, 90)
            };

            filter.ToString().Should().Be("ratings=70-90");

            filter = new TraktFilter
            {
                Ratings = new Range<uint>(90, 70)
            };

            filter.ToString().Should().Be("ratings=70-90");
        }

        [Fact]
        public void TestTraktFilterToStringVotes()
        {
            var filter = new TraktFilter
            {
                Votes = new Range<uint>(2000, 5000)
            };

            filter.ToString().Should().Be("votes=2000-5000");

            filter = new TraktFilter
            {
                Votes = new Range<uint>(5000, 2000)
            };

            filter.ToString().Should().Be("votes=2000-5000");
        }

        [Fact]
        public void TestTraktFilterToStringTMDBRatings()
        {
            var filter = new TraktFilter
            {
                TMDBRatings = new Range<float>(5.5f, 10.0f)
            };

            filter.ToString().Should().Be("tmdb_ratings=5.5-10");

            filter = new TraktFilter
            {
                TMDBRatings = new Range<float>(10.0f, 5.5f)
            };

            filter.ToString().Should().Be("tmdb_ratings=5.5-10");
        }

        [Fact]
        public void TestTraktFilterToStringTMDBVotes()
        {
            var filter = new TraktFilter
            {
                TMDBVotes = new Range<uint>(2000, 5000)
            };

            filter.ToString().Should().Be("tmdb_votes=2000-5000");

            filter = new TraktFilter
            {
                TMDBVotes = new Range<uint>(5000, 2000)
            };

            filter.ToString().Should().Be("tmdb_votes=2000-5000");
        }

        [Fact]
        public void TestTraktFilterToStringIMDBRatings()
        {
            var filter = new TraktFilter
            {
                IMDBRatings = new Range<float>(5.5f, 10.0f)
            };

            filter.ToString().Should().Be("imdb_ratings=5.5-10");

            filter = new TraktFilter
            {
                IMDBRatings = new Range<float>(10.0f, 5.5f)
            };

            filter.ToString().Should().Be("imdb_ratings=5.5-10");
        }

        [Fact]
        public void TestTraktFilterToStringIMDBVotes()
        {
            var filter = new TraktFilter
            {
                IMDBVotes = new Range<uint>(2000, 5000)
            };

            filter.ToString().Should().Be("imdb_votes=2000-5000");

            filter = new TraktFilter
            {
                IMDBVotes = new Range<uint>(5000, 2000)
            };

            filter.ToString().Should().Be("imdb_votes=2000-5000");
        }

        [Fact]
        public void TestTraktFilterToStringRottenTomatoesMeters()
        {
            var filter = new TraktFilter
            {
                RottenTomatoesMeters = new Range<uint>(70, 90)
            };

            filter.ToString().Should().Be("rt_meters=70-90");

            filter = new TraktFilter
            {
                RottenTomatoesMeters = new Range<uint>(90, 70)
            };

            filter.ToString().Should().Be("rt_meters=70-90");
        }

        [Fact]
        public void TestTraktFilterToStringRottenTomatoesUserMeters()
        {
            var filter = new TraktFilter
            {
                RottenTomatoesUserMeters = new Range<uint>(70, 90)
            };

            filter.ToString().Should().Be("rt_user_meters=70-90");

            filter = new TraktFilter
            {
                RottenTomatoesUserMeters = new Range<uint>(90, 70)
            };

            filter.ToString().Should().Be("rt_user_meters=70-90");
        }

        [Fact]
        public void TestTraktFilterToStringMetascores()
        {
            var filter = new TraktFilter
            {
                Metascores = new Range<float>(5.5f, 10.0f)
            };

            filter.ToString().Should().Be("metascores=5.5-10");

            filter = new TraktFilter
            {
                Metascores = new Range<float>(10.0f, 5.5f)
            };

            filter.ToString().Should().Be("metascores=5.5-10");
        }

        [Fact]
        public void TestTraktFilterToStringCertifications()
        {
            var filter = new TraktFilter
            {
                Certifications = ["R", "tv-pg"]
            };

            filter.ToString().Should().Be("certifications=R,tv-pg");

            filter = new TraktFilter
            {
                Certifications = []
            };

            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringNetworkIds()
        {
            var filter = new TraktFilter
            {
                NetworkIds = [7, 8, 9]
            };

            filter.ToString().Should().Be("network_ids=7,8,9");
        }

        [Fact]
        public void TestTraktFilterToStringStatus()
        {
            var filter = new TraktFilter
            {
                Status = [TraktShowStatus.Ended, TraktShowStatus.Planned]
            };

            filter.ToString().Should().Be("status=ended,planned");

            filter = new TraktFilter
            {
                Status = [TraktShowStatus.Unspecified, TraktShowStatus.Planned]
            };

            filter.ToString().Should().Be("status=planned");

            filter = new TraktFilter
            {
                Status = []
            };

            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void TestTraktFilterToStringEpisodeTypes()
        {
            var filter = new TraktFilter
            {
                EpisodeTypes = [TraktEpisodeType.SeriesPremiere, TraktEpisodeType.SeasonPremiere]
            };

            filter.ToString().Should().Be("episode_types=series_premiere,season_premiere");

            filter = new TraktFilter
            {
                EpisodeTypes = [TraktEpisodeType.Unspecified, TraktEpisodeType.SeasonPremiere]
            };

            filter.ToString().Should().Be("episode_types=season_premiere");

            filter = new TraktFilter
            {
                EpisodeTypes = []
            };

            filter.ToString().Should().NotBeNull().And.BeEmpty();
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
                StudioIds = [7, 8, 9],
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
                NetworkIds = [7, 8, 9],
                Status = [TraktShowStatus.Ended, TraktShowStatus.Planned],
                EpisodeTypes = [TraktEpisodeType.SeriesPremiere, TraktEpisodeType.SeasonPremiere]
            };

            filter.ToString().Should().Be("query=testquery&years=2020-2024&genres=action,drama&languages=en,de"
                + "&countries=us,de&runtimes=70-90&studio_ids=7,8,9&ratings=70-90&votes=2000-5000&tmdb_ratings=5.5-10"
                + "&tmdb_votes=2000-5000&imdb_ratings=5.5-10&imdb_votes=2000-5000&rt_meters=70-90&rt_user_meters=70-90"
                + "&metascores=5.5-10&certifications=R,tv-pg&network_ids=7,8,9&status=ended,planned"
                + "&episode_types=series_premiere,season_premiere");
        }
    }
}
