using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktCommentObjectTypeTests
    {
        [Fact]
        public void TestTraktCommentObjectTypeToJson()
        {
            TraktCommentObjectType.Unspecified.ToJson().ShouldBeNull();
            TraktCommentObjectType.Movie.ToJson().ShouldBe("movie");
            TraktCommentObjectType.Show.ToJson().ShouldBe("show");
            TraktCommentObjectType.Season.ToJson().ShouldBe("season");
            TraktCommentObjectType.Episode.ToJson().ShouldBe("episode");
            TraktCommentObjectType.List.ToJson().ShouldBe("list");
            TraktCommentObjectType.All.ToJson().ShouldBe("all");
            ((TraktCommentObjectType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktCommentObjectTypeFromJson()
        {
            "unspecified".ToTraktCommentObjectType().ShouldBe(TraktCommentObjectType.Unspecified);
            "movie".ToTraktCommentObjectType().ShouldBe(TraktCommentObjectType.Movie);
            "show".ToTraktCommentObjectType().ShouldBe(TraktCommentObjectType.Show);
            "season".ToTraktCommentObjectType().ShouldBe(TraktCommentObjectType.Season);
            "episode".ToTraktCommentObjectType().ShouldBe(TraktCommentObjectType.Episode);
            "list".ToTraktCommentObjectType().ShouldBe(TraktCommentObjectType.List);
            "all".ToTraktCommentObjectType().ShouldBe(TraktCommentObjectType.All);

            string? nullValue = null;
            nullValue.ToTraktCommentObjectType().ShouldBe(TraktCommentObjectType.Unspecified);
            "invalid".ToTraktCommentObjectType().ShouldBe(TraktCommentObjectType.Unspecified);
            "".ToTraktCommentObjectType().ShouldBe(TraktCommentObjectType.Unspecified);
        }

        [Fact]
        public void TestTraktCommentObjectTypeToURI()
        {
            TraktCommentObjectType.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktCommentObjectType.Movie.ToURI().ShouldBe("movies");
            TraktCommentObjectType.Show.ToURI().ShouldBe("shows");
            TraktCommentObjectType.Season.ToURI().ShouldBe("seasons");
            TraktCommentObjectType.Episode.ToURI().ShouldBe("episodes");
            TraktCommentObjectType.List.ToURI().ShouldBe("lists");
            TraktCommentObjectType.All.ToURI().ShouldBe("all");
            ((TraktCommentObjectType)99).ToURI().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktCommentObjectTypeAsPathParameter()
        {
            TraktCommentObjectType.Unspecified.AsPathParameter().ShouldBe(string.Empty);
            TraktCommentObjectType.Movie.AsPathParameter().ShouldBe("movies");
            TraktCommentObjectType.Show.AsPathParameter().ShouldBe("shows");
            TraktCommentObjectType.Season.AsPathParameter().ShouldBe("seasons");
            TraktCommentObjectType.Episode.AsPathParameter().ShouldBe("episodes");
            TraktCommentObjectType.List.AsPathParameter().ShouldBe("lists");
            TraktCommentObjectType.All.AsPathParameter().ShouldBe("all");
            ((TraktCommentObjectType)99).AsPathParameter().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktCommentObjectTypeDisplayName()
        {
            TraktCommentObjectType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktCommentObjectType.Movie.DisplayName().ShouldBe("Movie");
            TraktCommentObjectType.Show.DisplayName().ShouldBe("Show");
            TraktCommentObjectType.Season.DisplayName().ShouldBe("Season");
            TraktCommentObjectType.Episode.DisplayName().ShouldBe("Episode");
            TraktCommentObjectType.List.DisplayName().ShouldBe("List");
            TraktCommentObjectType.All.DisplayName().ShouldBe("All");
            ((TraktCommentObjectType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktCommentObjectTypeJsonConverter()
        {
            var converter = new TraktCommentObjectTypeJsonConverter();
            converter.CanConvert(typeof(TraktCommentObjectType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktCommentObjectType.Movie, options).ShouldBe("\"movie\"");
            JsonSerializer.Deserialize<TraktCommentObjectType>("\"movie\"", options).ShouldBe(TraktCommentObjectType.Movie);
            JsonSerializer.Deserialize<TraktCommentObjectType>("\"\"", options).ShouldBe(TraktCommentObjectType.Unspecified);
        }
    }
}
