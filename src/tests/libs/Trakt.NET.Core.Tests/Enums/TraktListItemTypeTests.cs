using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktListItemTypeTests
    {
        [Fact]
        public void TestTraktListItemTypeToJson()
        {
            TraktListItemType.Unspecified.ToJson().ShouldBeNull();
            TraktListItemType.Movie.ToJson().ShouldBe("movie");
            TraktListItemType.Show.ToJson().ShouldBe("show");
            TraktListItemType.Season.ToJson().ShouldBe("season");
            TraktListItemType.Episode.ToJson().ShouldBe("episode");
            TraktListItemType.Person.ToJson().ShouldBe("person");
            TraktListItemType.List.ToJson().ShouldBe("list");
            ((TraktListItemType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktListItemTypeFromJson()
        {
            "unspecified".ToTraktListItemType().ShouldBe(TraktListItemType.Unspecified);
            "movie".ToTraktListItemType().ShouldBe(TraktListItemType.Movie);
            "show".ToTraktListItemType().ShouldBe(TraktListItemType.Show);
            "season".ToTraktListItemType().ShouldBe(TraktListItemType.Season);
            "episode".ToTraktListItemType().ShouldBe(TraktListItemType.Episode);
            "person".ToTraktListItemType().ShouldBe(TraktListItemType.Person);
            "list".ToTraktListItemType().ShouldBe(TraktListItemType.List);

            string? nullValue = null;
            nullValue.ToTraktListItemType().ShouldBe(TraktListItemType.Unspecified);
            "invalid".ToTraktListItemType().ShouldBe(TraktListItemType.Unspecified);
            "".ToTraktListItemType().ShouldBe(TraktListItemType.Unspecified);
        }

        [Fact]
        public void TestTraktListItemTypeDisplayName()
        {
            TraktListItemType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktListItemType.Movie.DisplayName().ShouldBe("Movie");
            TraktListItemType.Show.DisplayName().ShouldBe("Show");
            TraktListItemType.Season.DisplayName().ShouldBe("Season");
            TraktListItemType.Episode.DisplayName().ShouldBe("Episode");
            TraktListItemType.Person.DisplayName().ShouldBe("Person");
            TraktListItemType.List.DisplayName().ShouldBe("List");
            ((TraktListItemType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktListItemTypeJsonConverter()
        {
            var converter = new TraktListItemTypeJsonConverter();
            converter.CanConvert(typeof(TraktListItemType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktListItemType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktListItemType>("\"movie\"", options).ShouldBe(TraktListItemType.Movie);
            JsonSerializer.Deserialize<TraktListItemType>("\"\"", options).ShouldBe(TraktListItemType.Unspecified);
        }
    }
}
