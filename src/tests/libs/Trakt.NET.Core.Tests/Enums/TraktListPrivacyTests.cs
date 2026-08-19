using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktListPrivacyTests
    {
        [Fact]
        public void TestTraktListPrivacyToJson()
        {
            TraktListPrivacy.Unspecified.ToJson().ShouldBeNull();
            TraktListPrivacy.Private.ToJson().ShouldBe("private");
            TraktListPrivacy.Link.ToJson().ShouldBe("link");
            TraktListPrivacy.Friends.ToJson().ShouldBe("friends");
            TraktListPrivacy.Public.ToJson().ShouldBe("public");
            ((TraktListPrivacy)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktListPrivacyFromJson()
        {
            "unspecified".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Unspecified);
            "private".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Private);
            "link".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Link);
            "friends".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Friends);
            "public".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Public);

            string? nullValue = null;
            nullValue.ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Unspecified);
            "invalid".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Unspecified);
            "".ToTraktListPrivacy().ShouldBe(TraktListPrivacy.Unspecified);
        }

        [Fact]
        public void TestTraktListPrivacyDisplayName()
        {
            TraktListPrivacy.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktListPrivacy.Private.DisplayName().ShouldBe("Private");
            TraktListPrivacy.Link.DisplayName().ShouldBe("Link");
            TraktListPrivacy.Friends.DisplayName().ShouldBe("Friends");
            TraktListPrivacy.Public.DisplayName().ShouldBe("Public");
            ((TraktListPrivacy)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktListPrivacyJsonConverter()
        {
            var converter = new TraktListPrivacyJsonConverter();
            converter.CanConvert(typeof(TraktListPrivacy)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktListPrivacy.Private, options).ShouldBe("\"private\"");
            JsonSerializer.Deserialize<TraktListPrivacy>("\"private\"", options).ShouldBe(TraktListPrivacy.Private);
            JsonSerializer.Deserialize<TraktListPrivacy>("\"\"", options).ShouldBe(TraktListPrivacy.Unspecified);
        }
    }
}
