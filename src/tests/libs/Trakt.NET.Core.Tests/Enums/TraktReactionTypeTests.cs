using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktReactionTypeTests
    {
        [Fact]
        public void TestTraktReactionTypeToJson()
        {
            TraktReactionType.Unspecified.ToJson().ShouldBeNull();
            TraktReactionType.Like.ToJson().ShouldBe("like");
            TraktReactionType.Dislike.ToJson().ShouldBe("dislike");
            TraktReactionType.Love.ToJson().ShouldBe("love");
            TraktReactionType.Laugh.ToJson().ShouldBe("laugh");
            TraktReactionType.Shocked.ToJson().ShouldBe("shocked");
            TraktReactionType.Bravo.ToJson().ShouldBe("bravo");
            TraktReactionType.Spoiler.ToJson().ShouldBe("spoiler");
            ((TraktReactionType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktReactionTypeFromJson()
        {
            "unspecified".ToTraktReactionType().ShouldBe(TraktReactionType.Unspecified);
            "like".ToTraktReactionType().ShouldBe(TraktReactionType.Like);
            "dislike".ToTraktReactionType().ShouldBe(TraktReactionType.Dislike);
            "love".ToTraktReactionType().ShouldBe(TraktReactionType.Love);
            "laugh".ToTraktReactionType().ShouldBe(TraktReactionType.Laugh);
            "shocked".ToTraktReactionType().ShouldBe(TraktReactionType.Shocked);
            "bravo".ToTraktReactionType().ShouldBe(TraktReactionType.Bravo);
            "spoiler".ToTraktReactionType().ShouldBe(TraktReactionType.Spoiler);

            string? nullValue = null;
            nullValue.ToTraktReactionType().ShouldBe(TraktReactionType.Unspecified);
            "invalid".ToTraktReactionType().ShouldBe(TraktReactionType.Unspecified);
            "".ToTraktReactionType().ShouldBe(TraktReactionType.Unspecified);
        }

        [Fact]
        public void TestTraktReactionTypeToURI()
        {
            TraktReactionType.Unspecified.ToURI().ShouldBe(string.Empty);
            TraktReactionType.Like.ToURI().ShouldBe("like");
            TraktReactionType.Dislike.ToURI().ShouldBe("dislike");
            TraktReactionType.Love.ToURI().ShouldBe("love");
            TraktReactionType.Laugh.ToURI().ShouldBe("laugh");
            TraktReactionType.Shocked.ToURI().ShouldBe("shocked");
            TraktReactionType.Bravo.ToURI().ShouldBe("bravo");
            TraktReactionType.Spoiler.ToURI().ShouldBe("spoiler");
            ((TraktReactionType)99).ToURI().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktReactionTypeAsPathParameter()
        {
            TraktReactionType.Unspecified.AsPathParameter().ShouldBe(string.Empty);
            TraktReactionType.Like.AsPathParameter().ShouldBe("like");
            TraktReactionType.Dislike.AsPathParameter().ShouldBe("dislike");
            TraktReactionType.Love.AsPathParameter().ShouldBe("love");
            TraktReactionType.Laugh.AsPathParameter().ShouldBe("laugh");
            TraktReactionType.Shocked.AsPathParameter().ShouldBe("shocked");
            TraktReactionType.Bravo.AsPathParameter().ShouldBe("bravo");
            TraktReactionType.Spoiler.AsPathParameter().ShouldBe("spoiler");
            ((TraktReactionType)99).AsPathParameter().ShouldBe(string.Empty);
        }

        [Fact]
        public void TestTraktReactionTypeDisplayName()
        {
            TraktReactionType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktReactionType.Like.DisplayName().ShouldBe("Like");
            TraktReactionType.Dislike.DisplayName().ShouldBe("Dislike");
            TraktReactionType.Love.DisplayName().ShouldBe("Love");
            TraktReactionType.Laugh.DisplayName().ShouldBe("Laugh");
            TraktReactionType.Shocked.DisplayName().ShouldBe("Shocked");
            TraktReactionType.Bravo.DisplayName().ShouldBe("Bravo");
            TraktReactionType.Spoiler.DisplayName().ShouldBe("Spoiler");
            ((TraktReactionType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktReactionTypeJsonConverter()
        {
            var converter = new TraktReactionTypeJsonConverter();
            converter.CanConvert(typeof(TraktReactionType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktReactionType.Like, options).ShouldBe("\"like\"");
            JsonSerializer.Deserialize<TraktReactionType>("\"like\"", options).ShouldBe(TraktReactionType.Like);
            JsonSerializer.Deserialize<TraktReactionType>("\"\"", options).ShouldBe(TraktReactionType.Unspecified);
        }
    }
}
