using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktCalendarMediaTypeTests
    {
        [Fact]
        public void TestTraktCalendarMediaTypeToJson()
        {
            TraktCalendarMediaType.Unspecified.ToJson().ShouldBeNull();
            TraktCalendarMediaType.Movie.ToJson().ShouldBe("movie");
            TraktCalendarMediaType.Show.ToJson().ShouldBe("show");
            ((TraktCalendarMediaType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktCalendarMediaTypeFromJson()
        {
            "unspecified".ToTraktCalendarMediaType().ShouldBe(TraktCalendarMediaType.Unspecified);
            "movie".ToTraktCalendarMediaType().ShouldBe(TraktCalendarMediaType.Movie);
            "show".ToTraktCalendarMediaType().ShouldBe(TraktCalendarMediaType.Show);

            string? nullValue = null;
            nullValue.ToTraktCalendarMediaType().ShouldBe(TraktCalendarMediaType.Unspecified);
            "invalid".ToTraktCalendarMediaType().ShouldBe(TraktCalendarMediaType.Unspecified);
            "".ToTraktCalendarMediaType().ShouldBe(TraktCalendarMediaType.Unspecified);
        }

        [Fact]
        public void TestTraktCalendarMediaTypeDisplayName()
        {
            TraktCalendarMediaType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktCalendarMediaType.Movie.DisplayName().ShouldBe("Movie");
            TraktCalendarMediaType.Show.DisplayName().ShouldBe("Show");
            ((TraktCalendarMediaType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktCalendarMediaTypeJsonConverter()
        {
            var converter = new TraktCalendarMediaTypeJsonConverter();
            converter.CanConvert(typeof(TraktCalendarMediaType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktCalendarMediaType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktCalendarMediaType>("\"movie\"", options).ShouldBe(TraktCalendarMediaType.Movie);
            JsonSerializer.Deserialize<TraktCalendarMediaType>("\"\"", options).ShouldBe(TraktCalendarMediaType.Unspecified);
        }
    }
}
