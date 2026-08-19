using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktCommentTypeTests
    {
        [Fact]
        public void TestTraktCommentTypeToJson()
        {
            TraktCommentType.Unspecified.ToJson().ShouldBeNull();
            TraktCommentType.Review.ToJson().ShouldBe("reviews");
            TraktCommentType.Shout.ToJson().ShouldBe("shouts");
            TraktCommentType.All.ToJson().ShouldBe("all");
            ((TraktCommentType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktCommentTypeFromJson()
        {
            "unspecified".ToTraktCommentType().ShouldBe(TraktCommentType.Unspecified);
            "reviews".ToTraktCommentType().ShouldBe(TraktCommentType.Review);
            "shouts".ToTraktCommentType().ShouldBe(TraktCommentType.Shout);
            "all".ToTraktCommentType().ShouldBe(TraktCommentType.All);

            string? nullValue = null;
            nullValue.ToTraktCommentType().ShouldBe(TraktCommentType.Unspecified);
            "invalid".ToTraktCommentType().ShouldBe(TraktCommentType.Unspecified);
            "".ToTraktCommentType().ShouldBe(TraktCommentType.Unspecified);
        }

        [Fact]
        public void TestTraktCommentTypeDisplayName()
        {
            TraktCommentType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktCommentType.Review.DisplayName().ShouldBe("Review");
            TraktCommentType.Shout.DisplayName().ShouldBe("Shout");
            TraktCommentType.All.DisplayName().ShouldBe("All");
            ((TraktCommentType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktCommentTypeJsonConverter()
        {
            var converter = new TraktCommentTypeJsonConverter();
            converter.CanConvert(typeof(TraktCommentType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktCommentType.Review, options).ShouldBe("\"reviews\"");
            JsonSerializer.Deserialize<TraktCommentType>("\"reviews\"", options).ShouldBe(TraktCommentType.Review);
            JsonSerializer.Deserialize<TraktCommentType>("\"\"", options).ShouldBe(TraktCommentType.Unspecified);
        }
    }
}
