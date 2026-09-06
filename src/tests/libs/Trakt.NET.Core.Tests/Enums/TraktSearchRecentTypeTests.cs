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
        public void TestTraktSearchRecentTypeToURI()
        {
            TraktSearchRecentType.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktSearchRecentType.Movie.ToURI().ShouldBe("movies");
            TraktSearchRecentType.Show.ToURI().ShouldBe("shows");
            TraktSearchRecentType.Person.ToURI().ShouldBe("people");
            TraktSearchRecentType.List.ToURI().ShouldBe("lists");
            ((TraktSearchRecentType)99).ToURI().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktSearchRecentTypeAsPathParameter()
        {
            TraktSearchRecentType.Unspecified.AsPathParameter().ShouldBe(string.Empty);
            TraktSearchRecentType.Movie.AsPathParameter().ShouldBe("movies");
            TraktSearchRecentType.Show.AsPathParameter().ShouldBe("shows");
            TraktSearchRecentType.Person.AsPathParameter().ShouldBe("people");
            TraktSearchRecentType.List.AsPathParameter().ShouldBe("lists");
            ((TraktSearchRecentType)99).AsPathParameter().ShouldBe(string.Empty);
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
