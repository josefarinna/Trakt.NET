using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktFavoriteObjectTypeTests
    {
        [Fact]
        public void TestTraktFavoriteObjectTypeToJson()
        {
            TraktFavoriteObjectType.Unspecified.ToJson().ShouldBeNull();
            TraktFavoriteObjectType.Media.ToJson().ShouldBe("media");
            TraktFavoriteObjectType.Movie.ToJson().ShouldBe("movie");
            TraktFavoriteObjectType.Show.ToJson().ShouldBe("show");
            ((TraktFavoriteObjectType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktFavoriteObjectTypeFromJson()
        {
            "unspecified".ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Unspecified);
            "media".ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Media);
            "movie".ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Movie);
            "show".ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Show);

            string? nullValue = null;
            nullValue.ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Unspecified);
            "invalid".ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Unspecified);
            "".ToTraktFavoriteObjectType().ShouldBe(TraktFavoriteObjectType.Unspecified);
        }

        [Fact]
        public void TestTraktFavoriteObjectTypeToURI()
        {
            TraktFavoriteObjectType.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktFavoriteObjectType.Media.ToURI().ShouldBe("media");
            TraktFavoriteObjectType.Movie.ToURI().ShouldBe("movies");
            TraktFavoriteObjectType.Show.ToURI().ShouldBe("shows");
            ((TraktFavoriteObjectType)99).ToURI().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktFavoriteObjectTypeDisplayName()
        {
            TraktFavoriteObjectType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktFavoriteObjectType.Media.DisplayName().ShouldBe("Media");
            TraktFavoriteObjectType.Movie.DisplayName().ShouldBe("Movie");
            TraktFavoriteObjectType.Show.DisplayName().ShouldBe("Show");
            ((TraktFavoriteObjectType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktFavoriteObjectTypeJsonConverter()
        {
            var converter = new TraktFavoriteObjectTypeJsonConverter();
            converter.CanConvert(typeof(TraktFavoriteObjectType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktFavoriteObjectType.Media, options).ShouldBe("\"media\"");
            JsonSerializer.Serialize(TraktFavoriteObjectType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktFavoriteObjectType>("\"media\"", options).ShouldBe(TraktFavoriteObjectType.Media);
            JsonSerializer.Deserialize<TraktFavoriteObjectType>("\"movie\"", options).ShouldBe(TraktFavoriteObjectType.Movie);
            JsonSerializer.Deserialize<TraktFavoriteObjectType>("\"\"", options).ShouldBe(TraktFavoriteObjectType.Unspecified);
        }
    }
}
