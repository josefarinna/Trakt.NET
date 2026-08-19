using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktAccessScopeTests
    {
        [Fact]
        public void TestTraktAccessScopeToJson()
        {
            TraktAccessScope.Unspecified.ToJson().ShouldBeNull();
            TraktAccessScope.Private.ToJson().ShouldBe("private");
            TraktAccessScope.Friends.ToJson().ShouldBe("friends");
            TraktAccessScope.Public.ToJson().ShouldBe("public");
            ((TraktAccessScope)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktAccessScopeFromJson()
        {
            "unspecified".ToTraktAccessScope().ShouldBe(TraktAccessScope.Unspecified);
            "private".ToTraktAccessScope().ShouldBe(TraktAccessScope.Private);
            "friends".ToTraktAccessScope().ShouldBe(TraktAccessScope.Friends);
            "public".ToTraktAccessScope().ShouldBe(TraktAccessScope.Public);

            string? nullValue = null;
            nullValue.ToTraktAccessScope().ShouldBe(TraktAccessScope.Unspecified);
            "invalid".ToTraktAccessScope().ShouldBe(TraktAccessScope.Unspecified);
            "".ToTraktAccessScope().ShouldBe(TraktAccessScope.Unspecified);
        }

        [Fact]
        public void TestTraktAccessScopeDisplayName()
        {
            TraktAccessScope.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktAccessScope.Private.DisplayName().ShouldBe("Private");
            TraktAccessScope.Friends.DisplayName().ShouldBe("Friends");
            TraktAccessScope.Public.DisplayName().ShouldBe("Public");
            ((TraktAccessScope)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktAccessScopeJsonConverter()
        {
            var converter = new TraktAccessScopeJsonConverter();
            converter.CanConvert(typeof(TraktAccessScope)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktAccessScope.Private, options).ShouldBe("\"private\"");
            JsonSerializer.Deserialize<TraktAccessScope>("\"private\"", options).ShouldBe(TraktAccessScope.Private);
            JsonSerializer.Deserialize<TraktAccessScope>("\"\"", options).ShouldBe(TraktAccessScope.Unspecified);
        }
    }
}
