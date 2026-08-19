using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktHiddenItemTypeTests
    {
        [Fact]
        public void TestTraktHiddenItemTypeToJson()
        {
            TraktHiddenItemType.Unspecified.ToJson().ShouldBeNull();
            TraktHiddenItemType.Movie.ToJson().ShouldBe("movie");
            TraktHiddenItemType.Show.ToJson().ShouldBe("show");
            TraktHiddenItemType.Season.ToJson().ShouldBe("season");
            TraktHiddenItemType.User.ToJson().ShouldBe("user");
            ((TraktHiddenItemType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktHiddenItemTypeFromJson()
        {
            "unspecified".ToTraktHiddenItemType().ShouldBe(TraktHiddenItemType.Unspecified);
            "movie".ToTraktHiddenItemType().ShouldBe(TraktHiddenItemType.Movie);
            "show".ToTraktHiddenItemType().ShouldBe(TraktHiddenItemType.Show);
            "season".ToTraktHiddenItemType().ShouldBe(TraktHiddenItemType.Season);
            "user".ToTraktHiddenItemType().ShouldBe(TraktHiddenItemType.User);

            string? nullValue = null;
            nullValue.ToTraktHiddenItemType().ShouldBe(TraktHiddenItemType.Unspecified);
            "invalid".ToTraktHiddenItemType().ShouldBe(TraktHiddenItemType.Unspecified);
            "".ToTraktHiddenItemType().ShouldBe(TraktHiddenItemType.Unspecified);
        }

        [Fact]
        public void TestTraktHiddenItemTypeDisplayName()
        {
            TraktHiddenItemType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktHiddenItemType.Movie.DisplayName().ShouldBe("Movie");
            TraktHiddenItemType.Show.DisplayName().ShouldBe("Show");
            TraktHiddenItemType.Season.DisplayName().ShouldBe("Season");
            TraktHiddenItemType.User.DisplayName().ShouldBe("User");
            ((TraktHiddenItemType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktHiddenItemTypeJsonConverter()
        {
            var converter = new TraktHiddenItemTypeJsonConverter();
            converter.CanConvert(typeof(TraktHiddenItemType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktHiddenItemType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktHiddenItemType>("\"movie\"", options).ShouldBe(TraktHiddenItemType.Movie);
            JsonSerializer.Deserialize<TraktHiddenItemType>("\"\"", options).ShouldBe(TraktHiddenItemType.Unspecified);
        }
    }
}
