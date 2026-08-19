using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktIncludeRepliesTests
    {
        [Fact]
        public void TestTraktIncludeRepliesToJson()
        {
            TraktIncludeReplies.Unspecified.ToJson().ShouldBeNull();
            TraktIncludeReplies.True.ToJson().ShouldBe("true");
            TraktIncludeReplies.False.ToJson().ShouldBe("false");
            TraktIncludeReplies.Only.ToJson().ShouldBe("only");
            ((TraktIncludeReplies)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktIncludeRepliesFromJson()
        {
            "unspecified".ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.Unspecified);
            "true".ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.True);
            "false".ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.False);
            "only".ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.Only);

            string? nullValue = null;
            nullValue.ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.Unspecified);
            "invalid".ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.Unspecified);
            "".ToTraktIncludeReplies().ShouldBe(TraktIncludeReplies.Unspecified);
        }

        [Fact]
        public void TestTraktIncludeRepliesDisplayName()
        {
            TraktIncludeReplies.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktIncludeReplies.True.DisplayName().ShouldBe("True");
            TraktIncludeReplies.False.DisplayName().ShouldBe("False");
            TraktIncludeReplies.Only.DisplayName().ShouldBe("Only");
            ((TraktIncludeReplies)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktIncludeRepliesJsonConverter()
        {
            var converter = new TraktIncludeRepliesJsonConverter();
            converter.CanConvert(typeof(TraktIncludeReplies)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktIncludeReplies.True, options).ShouldBe("\"true\"");
            JsonSerializer.Deserialize<TraktIncludeReplies>("\"true\"", options).ShouldBe(TraktIncludeReplies.True);
            JsonSerializer.Deserialize<TraktIncludeReplies>("\"\"", options).ShouldBe(TraktIncludeReplies.Unspecified);
        }
    }
}
