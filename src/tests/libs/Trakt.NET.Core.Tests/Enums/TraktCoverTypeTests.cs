using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktCoverTypeTests
    {
        [Fact]
        public void TestTraktCoverTypeToJson()
        {
            TraktCoverType.Unspecified.ToJson().ShouldBeNull();
            TraktCoverType.Movie.ToJson().ShouldBe("movie");
            TraktCoverType.Show.ToJson().ShouldBe("show");
            TraktCoverType.Episode.ToJson().ShouldBe("episode");
            ((TraktCoverType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktCoverTypeFromJson()
        {
            "unspecified".ToTraktCoverType().ShouldBe(TraktCoverType.Unspecified);
            "movie".ToTraktCoverType().ShouldBe(TraktCoverType.Movie);
            "show".ToTraktCoverType().ShouldBe(TraktCoverType.Show);
            "episode".ToTraktCoverType().ShouldBe(TraktCoverType.Episode);

            string? nullValue = null;
            nullValue.ToTraktCoverType().ShouldBe(TraktCoverType.Unspecified);
            "invalid".ToTraktCoverType().ShouldBe(TraktCoverType.Unspecified);
            "".ToTraktCoverType().ShouldBe(TraktCoverType.Unspecified);
        }

        [Fact]
        public void TestTraktCoverTypeDisplayName()
        {
            TraktCoverType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktCoverType.Movie.DisplayName().ShouldBe("Movie");
            TraktCoverType.Show.DisplayName().ShouldBe("Show");
            TraktCoverType.Episode.DisplayName().ShouldBe("Episode");
            ((TraktCoverType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktCoverTypeJsonConverter()
        {
            var converter = new TraktCoverTypeJsonConverter();
            converter.CanConvert(typeof(TraktCoverType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktCoverType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktCoverType>("\"movie\"", options).ShouldBe(TraktCoverType.Movie);
            JsonSerializer.Deserialize<TraktCoverType>("\"\"", options).ShouldBe(TraktCoverType.Unspecified);
        }
    }
}
