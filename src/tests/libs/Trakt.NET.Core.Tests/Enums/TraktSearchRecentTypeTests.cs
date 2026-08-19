using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktSearchRecentTypeTests
    {
        [Fact]
        public void TestTraktSearchRecentTypeToJson()
        {
            TraktSearchRecentType.Unspecified.ToJson().ShouldBeNull();
            TraktSearchRecentType.Movie.ToJson().ShouldBe("movies");
            TraktSearchRecentType.Show.ToJson().ShouldBe("shows");
            TraktSearchRecentType.Person.ToJson().ShouldBe("people");
            TraktSearchRecentType.List.ToJson().ShouldBe("lists");
            ((TraktSearchRecentType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktSearchRecentTypeFromJson()
        {
            "unspecified".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Unspecified);
            "movies".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Movie);
            "shows".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Show);
            "people".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Person);
            "lists".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.List);

            string? nullValue = null;
            nullValue.ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Unspecified);
            "invalid".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Unspecified);
            "".ToTraktSearchRecentType().ShouldBe(TraktSearchRecentType.Unspecified);
        }

        [Fact]
        public void TestTraktSearchRecentTypeDisplayName()
        {
            TraktSearchRecentType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSearchRecentType.Movie.DisplayName().ShouldBe("Movies");
            TraktSearchRecentType.Show.DisplayName().ShouldBe("Shows");
            TraktSearchRecentType.Person.DisplayName().ShouldBe("People");
            TraktSearchRecentType.List.DisplayName().ShouldBe("Lists");
            ((TraktSearchRecentType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktSearchRecentTypeJsonConverter()
        {
            var converter = new TraktSearchRecentTypeJsonConverter();
            converter.CanConvert(typeof(TraktSearchRecentType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSearchRecentType.Movie, options).ShouldBe("\"movies\"");
            JsonSerializer.Deserialize<TraktSearchRecentType>("\"movies\"", options).ShouldBe(TraktSearchRecentType.Movie);
            JsonSerializer.Deserialize<TraktSearchRecentType>("\"\"", options).ShouldBe(TraktSearchRecentType.Unspecified);
        }
    }
}
