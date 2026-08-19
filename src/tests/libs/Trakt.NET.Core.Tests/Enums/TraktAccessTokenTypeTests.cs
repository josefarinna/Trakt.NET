using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktAccessTokenTypeTests
    {
        [Fact]
        public void TestTraktAccessTokenTypeToJson()
        {
            TraktAccessTokenType.Unspecified.ToJson().ShouldBeNull();
            TraktAccessTokenType.Bearer.ToJson().ShouldBe("bearer");
            ((TraktAccessTokenType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktAccessTokenTypeFromJson()
        {
            "unspecified".ToTraktAccessTokenType().ShouldBe(TraktAccessTokenType.Unspecified);
            "bearer".ToTraktAccessTokenType().ShouldBe(TraktAccessTokenType.Bearer);

            string? nullValue = null;
            nullValue.ToTraktAccessTokenType().ShouldBe(TraktAccessTokenType.Unspecified);
            "invalid".ToTraktAccessTokenType().ShouldBe(TraktAccessTokenType.Unspecified);
            "".ToTraktAccessTokenType().ShouldBe(TraktAccessTokenType.Unspecified);
        }

        [Fact]
        public void TestTraktAccessTokenTypeDisplayName()
        {
            TraktAccessTokenType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktAccessTokenType.Bearer.DisplayName().ShouldBe("Bearer");
            ((TraktAccessTokenType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktAccessTokenTypeJsonConverter()
        {
            var converter = new TraktAccessTokenTypeJsonConverter();
            converter.CanConvert(typeof(TraktAccessTokenType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktAccessTokenType.Bearer, options).ShouldBe("\"bearer\"");
            JsonSerializer.Deserialize<TraktAccessTokenType>("\"bearer\"", options).ShouldBe(TraktAccessTokenType.Bearer);
            JsonSerializer.Deserialize<TraktAccessTokenType>("\"\"", options).ShouldBe(TraktAccessTokenType.Unspecified);
        }
    }
}
