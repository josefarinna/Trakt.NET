using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktUserLikeTypeTests
    {
        [Fact]
        public void TestTraktUserLikeTypeToJson()
        {
            TraktUserLikeType.Unspecified.ToJson().ShouldBeNull();
            TraktUserLikeType.Comment.ToJson().ShouldBe("comment");
            TraktUserLikeType.List.ToJson().ShouldBe("list");
            ((TraktUserLikeType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktUserLikeTypeFromJson()
        {
            "unspecified".ToTraktUserLikeType().ShouldBe(TraktUserLikeType.Unspecified);
            "comment".ToTraktUserLikeType().ShouldBe(TraktUserLikeType.Comment);
            "list".ToTraktUserLikeType().ShouldBe(TraktUserLikeType.List);

            string? nullValue = null;
            nullValue.ToTraktUserLikeType().ShouldBe(TraktUserLikeType.Unspecified);
            "invalid".ToTraktUserLikeType().ShouldBe(TraktUserLikeType.Unspecified);
            "".ToTraktUserLikeType().ShouldBe(TraktUserLikeType.Unspecified);
        }

        [Fact]
        public void TestTraktUserLikeTypeDisplayName()
        {
            TraktUserLikeType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktUserLikeType.Comment.DisplayName().ShouldBe("Comment");
            TraktUserLikeType.List.DisplayName().ShouldBe("List");
            ((TraktUserLikeType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktUserLikeTypeJsonConverter()
        {
            var converter = new TraktUserLikeTypeJsonConverter();
            converter.CanConvert(typeof(TraktUserLikeType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktUserLikeType.Comment, options).ShouldBe("\"comment\"");
            JsonSerializer.Deserialize<TraktUserLikeType>("\"comment\"", options).ShouldBe(TraktUserLikeType.Comment);
            JsonSerializer.Deserialize<TraktUserLikeType>("\"\"", options).ShouldBe(TraktUserLikeType.Unspecified);
        }
    }
}
