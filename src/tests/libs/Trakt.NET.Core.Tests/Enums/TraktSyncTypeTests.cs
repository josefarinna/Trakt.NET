using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktSyncTypeTests
    {
        [Fact]
        public void TestTraktSyncTypeToJson()
        {
            TraktSyncType.Unspecified.ToJson().ShouldBeNull();
            TraktSyncType.Movie.ToJson().ShouldBe("movie");
            TraktSyncType.Episode.ToJson().ShouldBe("episode");
            ((TraktSyncType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktSyncTypeFromJson()
        {
            "unspecified".ToTraktSyncType().ShouldBe(TraktSyncType.Unspecified);
            "movie".ToTraktSyncType().ShouldBe(TraktSyncType.Movie);
            "episode".ToTraktSyncType().ShouldBe(TraktSyncType.Episode);

            string? nullValue = null;
            nullValue.ToTraktSyncType().ShouldBe(TraktSyncType.Unspecified);
            "invalid".ToTraktSyncType().ShouldBe(TraktSyncType.Unspecified);
            "".ToTraktSyncType().ShouldBe(TraktSyncType.Unspecified);
        }

        [Fact]
        public void TestTraktSyncTypeToURI()
        {
            TraktSyncType.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktSyncType.Movie.ToURI().ShouldBe("movies");
            TraktSyncType.Episode.ToURI().ShouldBe("episodes");
            ((TraktSyncType)99).ToURI().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktSyncTypeAsPathParameter()
        {
            TraktSyncType.Unspecified.AsPathParameter().ShouldBe(string.Empty);
            TraktSyncType.Movie.AsPathParameter().ShouldBe("movies");
            TraktSyncType.Episode.AsPathParameter().ShouldBe("episodes");
            ((TraktSyncType)99).AsPathParameter().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktSyncTypeDisplayName()
        {
            TraktSyncType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktSyncType.Movie.DisplayName().ShouldBe("Movie");
            TraktSyncType.Episode.DisplayName().ShouldBe("Episode");
            ((TraktSyncType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktSyncTypeJsonConverter()
        {
            var converter = new TraktSyncTypeJsonConverter();
            converter.CanConvert(typeof(TraktSyncType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktSyncType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktSyncType>("\"movie\"", options).ShouldBe(TraktSyncType.Movie);
            JsonSerializer.Deserialize<TraktSyncType>("\"\"", options).ShouldBe(TraktSyncType.Unspecified);
        }
    }
}
