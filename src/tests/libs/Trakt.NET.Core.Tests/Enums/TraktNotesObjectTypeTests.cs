using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktNotesObjectTypeTests
    {
        [Fact]
        public void TestTraktNotesObjectTypeToJson()
        {
            TraktNotesObjectType.Unspecified.ToJson().ShouldBeNull();
            TraktNotesObjectType.All.ToJson().ShouldBe("all");
            TraktNotesObjectType.Movie.ToJson().ShouldBe("movie");
            TraktNotesObjectType.Show.ToJson().ShouldBe("show");
            TraktNotesObjectType.Season.ToJson().ShouldBe("season");
            TraktNotesObjectType.Episode.ToJson().ShouldBe("episode");
            TraktNotesObjectType.Person.ToJson().ShouldBe("person");
            TraktNotesObjectType.History.ToJson().ShouldBe("history");
            TraktNotesObjectType.Collection.ToJson().ShouldBe("collection");
            TraktNotesObjectType.Rating.ToJson().ShouldBe("rating");
            ((TraktNotesObjectType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktNotesObjectTypeFromJson()
        {
            "unspecified".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Unspecified);
            "all".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.All);
            "movie".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Movie);
            "show".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Show);
            "season".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Season);
            "episode".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Episode);
            "person".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Person);
            "history".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.History);
            "collection".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Collection);
            "rating".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Rating);

            string? nullValue = null;
            nullValue.ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Unspecified);
            "invalid".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Unspecified);
            "".ToTraktNotesObjectType().ShouldBe(TraktNotesObjectType.Unspecified);
        }

        [Fact]
        public void TestTraktNotesObjectTypeToURI()
        {
            TraktNotesObjectType.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktNotesObjectType.All.ToURI().ShouldBe("all");
            TraktNotesObjectType.Movie.ToURI().ShouldBe("movies");
            TraktNotesObjectType.Show.ToURI().ShouldBe("shows");
            TraktNotesObjectType.Season.ToURI().ShouldBe("seasons");
            TraktNotesObjectType.Episode.ToURI().ShouldBe("episodes");
            TraktNotesObjectType.Person.ToURI().ShouldBe("people");
            TraktNotesObjectType.History.ToURI().ShouldBe("history");
            TraktNotesObjectType.Collection.ToURI().ShouldBe("collection");
            TraktNotesObjectType.Rating.ToURI().ShouldBe("ratings");
            ((TraktNotesObjectType)99).ToURI().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktNotesObjectTypeDisplayName()
        {
            TraktNotesObjectType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktNotesObjectType.All.DisplayName().ShouldBe("All");
            TraktNotesObjectType.Movie.DisplayName().ShouldBe("Movie");
            TraktNotesObjectType.Show.DisplayName().ShouldBe("Show");
            TraktNotesObjectType.Season.DisplayName().ShouldBe("Season");
            TraktNotesObjectType.Episode.DisplayName().ShouldBe("Episode");
            TraktNotesObjectType.Person.DisplayName().ShouldBe("Person");
            TraktNotesObjectType.History.DisplayName().ShouldBe("History");
            TraktNotesObjectType.Collection.DisplayName().ShouldBe("Collection");
            TraktNotesObjectType.Rating.DisplayName().ShouldBe("Rating");
            ((TraktNotesObjectType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktNotesObjectTypeJsonConverter()
        {
            var converter = new TraktNotesObjectTypeJsonConverter();
            converter.CanConvert(typeof(TraktNotesObjectType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktNotesObjectType.All, options).ShouldBe("\"all\"");
            JsonSerializer.Deserialize<TraktNotesObjectType>("\"all\"", options).ShouldBe(TraktNotesObjectType.All);
            JsonSerializer.Deserialize<TraktNotesObjectType>("\"\"", options).ShouldBe(TraktNotesObjectType.Unspecified);
        }
    }
}
