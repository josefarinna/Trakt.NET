using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktSyncItemTypeTests
    {
        [Fact]
        public void TestTraktSyncItemTypeToJson()
        {
            TraktSyncItemType.Unspecified.ToJson().ShouldBeNull();
            TraktSyncItemType.Movie.ToJson().ShouldBe("movie");
            TraktSyncItemType.Show.ToJson().ShouldBe("show");
            TraktSyncItemType.Season.ToJson().ShouldBe("season");
            TraktSyncItemType.Episode.ToJson().ShouldBe("episode");
            TraktSyncItemType.All.ToJson().ShouldBe("all");
            ((TraktSyncItemType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktSyncItemTypeFromJson()
        {
            "unspecified".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Unspecified);
            "movie".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Movie);
            "show".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Show);
            "season".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Season);
            "episode".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Episode);
            "all".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.All);

            string? nullValue = null;
            nullValue.ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Unspecified);
            "invalid".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Unspecified);
            "".ToTraktSyncItemType().ShouldBe(TraktSyncItemType.Unspecified);
        }

        [Fact]
        public void TestTraktSyncItemTypeDisplayName()
        {
            TraktSyncItemType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSyncItemType.Movie.DisplayName().ShouldBe("Movie");
            TraktSyncItemType.Show.DisplayName().ShouldBe("Show");
            TraktSyncItemType.Season.DisplayName().ShouldBe("Season");
            TraktSyncItemType.Episode.DisplayName().ShouldBe("Episode");
            TraktSyncItemType.All.DisplayName().ShouldBe("All");
            ((TraktSyncItemType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktSyncItemTypeJsonConverter()
        {
            var converter = new TraktSyncItemTypeJsonConverter();
            converter.CanConvert(typeof(TraktSyncItemType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSyncItemType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktSyncItemType>("\"movie\"", options).ShouldBe(TraktSyncItemType.Movie);
            JsonSerializer.Deserialize<TraktSyncItemType>("\"\"", options).ShouldBe(TraktSyncItemType.Unspecified);
        }
    }
}
