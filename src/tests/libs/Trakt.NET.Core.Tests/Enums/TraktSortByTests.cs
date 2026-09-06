using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktSortByTests
    {
        [Fact]
        public void TestTraktSortByToJson()
        {
            TraktSortBy.Unspecified.ToJson().ShouldBeNull();
            TraktSortBy.Rank.ToJson().ShouldBe("rank");
            TraktSortBy.Added.ToJson().ShouldBe("added");
            TraktSortBy.Title.ToJson().ShouldBe("title");
            TraktSortBy.Released.ToJson().ShouldBe("released");
            TraktSortBy.Runtime.ToJson().ShouldBe("runtime");
            TraktSortBy.Popularity.ToJson().ShouldBe("popularity");
            TraktSortBy.Percentage.ToJson().ShouldBe("percentage");
            TraktSortBy.IMDBRating.ToJson().ShouldBe("imdb_rating");
            TraktSortBy.TMDBRating.ToJson().ShouldBe("tmdb_rating");
            TraktSortBy.RTTomatoMeter.ToJson().ShouldBe("rt_tomatometer");
            TraktSortBy.RTAudience.ToJson().ShouldBe("rt_audience");
            TraktSortBy.Metascore.ToJson().ShouldBe("metascore");
            TraktSortBy.Votes.ToJson().ShouldBe("votes");
            TraktSortBy.IMDBVotes.ToJson().ShouldBe("imdb_votes");
            TraktSortBy.TMDBVotes.ToJson().ShouldBe("tmdb_votes");
            TraktSortBy.MyRating.ToJson().ShouldBe("my_rating");
            TraktSortBy.Random.ToJson().ShouldBe("random");
            TraktSortBy.Watched.ToJson().ShouldBe("watched");
            TraktSortBy.Collected.ToJson().ShouldBe("collected");
            ((TraktSortBy)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktSortByFromJson()
        {
            "unspecified".ToTraktSortBy().ShouldBe(TraktSortBy.Unspecified);
            "rank".ToTraktSortBy().ShouldBe(TraktSortBy.Rank);
            "added".ToTraktSortBy().ShouldBe(TraktSortBy.Added);
            "title".ToTraktSortBy().ShouldBe(TraktSortBy.Title);
            "released".ToTraktSortBy().ShouldBe(TraktSortBy.Released);
            "runtime".ToTraktSortBy().ShouldBe(TraktSortBy.Runtime);
            "popularity".ToTraktSortBy().ShouldBe(TraktSortBy.Popularity);
            "percentage".ToTraktSortBy().ShouldBe(TraktSortBy.Percentage);
            "imdb_rating".ToTraktSortBy().ShouldBe(TraktSortBy.IMDBRating);
            "tmdb_rating".ToTraktSortBy().ShouldBe(TraktSortBy.TMDBRating);
            "rt_tomatometer".ToTraktSortBy().ShouldBe(TraktSortBy.RTTomatoMeter);
            "rt_audience".ToTraktSortBy().ShouldBe(TraktSortBy.RTAudience);
            "metascore".ToTraktSortBy().ShouldBe(TraktSortBy.Metascore);
            "votes".ToTraktSortBy().ShouldBe(TraktSortBy.Votes);
            "imdb_votes".ToTraktSortBy().ShouldBe(TraktSortBy.IMDBVotes);
            "tmdb_votes".ToTraktSortBy().ShouldBe(TraktSortBy.TMDBVotes);
            "my_rating".ToTraktSortBy().ShouldBe(TraktSortBy.MyRating);
            "random".ToTraktSortBy().ShouldBe(TraktSortBy.Random);
            "watched".ToTraktSortBy().ShouldBe(TraktSortBy.Watched);
            "collected".ToTraktSortBy().ShouldBe(TraktSortBy.Collected);

            string? nullValue = null;
            nullValue.ToTraktSortBy().ShouldBe(TraktSortBy.Unspecified);
            "invalid".ToTraktSortBy().ShouldBe(TraktSortBy.Unspecified);
            "".ToTraktSortBy().ShouldBe(TraktSortBy.Unspecified);
        }

        [Fact]
        public void TestTraktSortByToURI()
        {
            TraktSortBy.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktSortBy.Rank.ToURI().ShouldBe("rank");
            TraktSortBy.Added.ToURI().ShouldBe("added");
            TraktSortBy.Title.ToURI().ShouldBe("title");
            TraktSortBy.Released.ToURI().ShouldBe("released");
            TraktSortBy.Runtime.ToURI().ShouldBe("runtime");
            TraktSortBy.Popularity.ToURI().ShouldBe("popularity");
            TraktSortBy.Percentage.ToURI().ShouldBe("percentage");
            TraktSortBy.IMDBRating.ToURI().ShouldBe("imdb_rating");
            TraktSortBy.TMDBRating.ToURI().ShouldBe("tmdb_rating");
            TraktSortBy.RTTomatoMeter.ToURI().ShouldBe("rt_tomatometer");
            TraktSortBy.RTAudience.ToURI().ShouldBe("rt_audience");
            TraktSortBy.Metascore.ToURI().ShouldBe("metascore");
            TraktSortBy.Votes.ToURI().ShouldBe("votes");
            TraktSortBy.IMDBVotes.ToURI().ShouldBe("imdb_votes");
            TraktSortBy.TMDBVotes.ToURI().ShouldBe("tmdb_votes");
            TraktSortBy.MyRating.ToURI().ShouldBe("my_rating");
            TraktSortBy.Random.ToURI().ShouldBe("random");
            TraktSortBy.Watched.ToURI().ShouldBe("watched");
            TraktSortBy.Collected.ToURI().ShouldBe("collected");
            ((TraktSortBy)99).ToURI().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktSortByDisplayName()
        {
            TraktSortBy.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSortBy.Rank.DisplayName().ShouldBe("Rank");
            TraktSortBy.Added.DisplayName().ShouldBe("Added");
            TraktSortBy.Title.DisplayName().ShouldBe("Title");
            TraktSortBy.Released.DisplayName().ShouldBe("Released");
            TraktSortBy.Runtime.DisplayName().ShouldBe("Runtime");
            TraktSortBy.Popularity.DisplayName().ShouldBe("Popularity");
            TraktSortBy.Percentage.DisplayName().ShouldBe("Percentage");
            TraktSortBy.IMDBRating.DisplayName().ShouldBe("IMDB Rating");
            TraktSortBy.TMDBRating.DisplayName().ShouldBe("TMDB Rating");
            TraktSortBy.RTTomatoMeter.DisplayName().ShouldBe("RT TomatoMeter");
            TraktSortBy.RTAudience.DisplayName().ShouldBe("RT Audience");
            TraktSortBy.Metascore.DisplayName().ShouldBe("Metascore");
            TraktSortBy.Votes.DisplayName().ShouldBe("Votes");
            TraktSortBy.IMDBVotes.DisplayName().ShouldBe("IDMB Votes");
            TraktSortBy.TMDBVotes.DisplayName().ShouldBe("TMDB Votes");
            TraktSortBy.MyRating.DisplayName().ShouldBe("My Rating");
            TraktSortBy.Random.DisplayName().ShouldBe("Random");
            TraktSortBy.Watched.DisplayName().ShouldBe("Watched");
            TraktSortBy.Collected.DisplayName().ShouldBe("Collected");
            ((TraktSortBy)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktSortByJsonConverter()
        {
            var converter = new TraktSortByJsonConverter();
            converter.CanConvert(typeof(TraktSortBy)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSortBy.Rank, options).ShouldBe("\"rank\"");
            JsonSerializer.Deserialize<TraktSortBy>("\"rank\"", options).ShouldBe(TraktSortBy.Rank);
            JsonSerializer.Deserialize<TraktSortBy>("\"\"", options).ShouldBe(TraktSortBy.Unspecified);
        }
    }
}
