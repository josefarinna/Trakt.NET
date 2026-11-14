using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktAwardMediaTypeTests
    {
        [Fact]
        public void TestTraktAwardMediaTypeToJson()
        {
            TraktAwardMediaType.Unspecified.ToJson().ShouldBeNull();
            TraktAwardMediaType.Movie.ToJson().ShouldBe("movie");
            TraktAwardMediaType.Show.ToJson().ShouldBe("show");
            ((TraktAwardMediaType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktAwardMediaTypeFromJson()
        {
            "unspecified".ToTraktAwardMediaType().ShouldBe(TraktAwardMediaType.Unspecified);
            "movie".ToTraktAwardMediaType().ShouldBe(TraktAwardMediaType.Movie);
            "show".ToTraktAwardMediaType().ShouldBe(TraktAwardMediaType.Show);

            string? nullValue = null;
            nullValue.ToTraktAwardMediaType().ShouldBe(TraktAwardMediaType.Unspecified);
            "invalid".ToTraktAwardMediaType().ShouldBe(TraktAwardMediaType.Unspecified);
            "".ToTraktAwardMediaType().ShouldBe(TraktAwardMediaType.Unspecified);
        }

        [Fact]
        public void TestTraktAwardMediaTypeDisplayName()
        {
            TraktAwardMediaType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktAwardMediaType.Movie.DisplayName().ShouldBe("Movie");
            TraktAwardMediaType.Show.DisplayName().ShouldBe("Show");
            ((TraktAwardMediaType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktAwardMediaTypeJsonConverter()
        {
            var converter = new TraktAwardMediaTypeJsonConverter();
            converter.CanConvert(typeof(TraktAwardMediaType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktAwardMediaType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktAwardMediaType>("\"movie\"", options).ShouldBe(TraktAwardMediaType.Movie);
            JsonSerializer.Deserialize<TraktAwardMediaType>("\"\"", options).ShouldBe(TraktAwardMediaType.Unspecified);
        }
    }
}
