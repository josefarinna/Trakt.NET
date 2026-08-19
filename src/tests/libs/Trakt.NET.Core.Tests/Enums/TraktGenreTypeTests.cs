using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktGenreTypeTests
    {
        [Fact]
        public void TestTraktGenreTypeToJson()
        {
            TraktGenreType.Unspecified.ToJson().ShouldBeNull();
            TraktGenreType.Movies.ToJson().ShouldBe("movies");
            TraktGenreType.Shows.ToJson().ShouldBe("shows");
            ((TraktGenreType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktGenreTypeFromJson()
        {
            "unspecified".ToTraktGenreType().ShouldBe(TraktGenreType.Unspecified);
            "movies".ToTraktGenreType().ShouldBe(TraktGenreType.Movies);
            "shows".ToTraktGenreType().ShouldBe(TraktGenreType.Shows);

            string? nullValue = null;
            nullValue.ToTraktGenreType().ShouldBe(TraktGenreType.Unspecified);
            "invalid".ToTraktGenreType().ShouldBe(TraktGenreType.Unspecified);
            "".ToTraktGenreType().ShouldBe(TraktGenreType.Unspecified);
        }

        [Fact]
        public void TestTraktGenreTypeDisplayName()
        {
            TraktGenreType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktGenreType.Movies.DisplayName().ShouldBe("Movies");
            TraktGenreType.Shows.DisplayName().ShouldBe("Shows");
            ((TraktGenreType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktGenreTypeJsonConverter()
        {
            var converter = new TraktGenreTypeJsonConverter();
            converter.CanConvert(typeof(TraktGenreType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktGenreType.Movies, options).ShouldBe("\"movies\"");
            JsonSerializer.Deserialize<TraktGenreType>("\"movies\"", options).ShouldBe(TraktGenreType.Movies);
            JsonSerializer.Deserialize<TraktGenreType>("\"\"", options).ShouldBe(TraktGenreType.Unspecified);
        }
    }
}
