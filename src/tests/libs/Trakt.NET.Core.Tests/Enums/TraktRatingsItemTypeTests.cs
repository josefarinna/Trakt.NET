using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktRatingsItemTypeTests
    {
        [Fact]
        public void TestTraktRatingsItemTypeToJson()
        {
            TraktRatingsItemType.Unspecified.ToJson().ShouldBeNull();
            TraktRatingsItemType.Movie.ToJson().ShouldBe("movie");
            TraktRatingsItemType.Show.ToJson().ShouldBe("show");
            TraktRatingsItemType.Season.ToJson().ShouldBe("season");
            TraktRatingsItemType.Episode.ToJson().ShouldBe("episode");
            TraktRatingsItemType.All.ToJson().ShouldBe("all");
            ((TraktRatingsItemType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktRatingsItemTypeFromJson()
        {
            "unspecified".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Unspecified);
            "movie".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Movie);
            "show".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Show);
            "season".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Season);
            "episode".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Episode);
            "all".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.All);

            string? nullValue = null;
            nullValue.ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Unspecified);
            "invalid".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Unspecified);
            "".ToTraktRatingsItemType().ShouldBe(TraktRatingsItemType.Unspecified);
        }

        [Fact]
        public void TestTraktRatingsItemTypeDisplayName()
        {
            TraktRatingsItemType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktRatingsItemType.Movie.DisplayName().ShouldBe("Movie");
            TraktRatingsItemType.Show.DisplayName().ShouldBe("Show");
            TraktRatingsItemType.Season.DisplayName().ShouldBe("Season");
            TraktRatingsItemType.Episode.DisplayName().ShouldBe("Episode");
            TraktRatingsItemType.All.DisplayName().ShouldBe("All");
            ((TraktRatingsItemType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktRatingsItemTypeJsonConverter()
        {
            var converter = new TraktRatingsItemTypeJsonConverter();
            converter.CanConvert(typeof(TraktRatingsItemType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktRatingsItemType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktRatingsItemType>("\"movie\"", options).ShouldBe(TraktRatingsItemType.Movie);
            JsonSerializer.Deserialize<TraktRatingsItemType>("\"\"", options).ShouldBe(TraktRatingsItemType.Unspecified);
        }
    }
}
