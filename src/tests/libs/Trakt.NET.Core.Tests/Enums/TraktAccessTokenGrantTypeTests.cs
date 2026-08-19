using System.Text.Json;

namespace TraktNET.Enums
{
    public sealed class TraktAccessTokenGrantTypeTests
    {
        [Fact]
        public void TestTraktAccessTokenGrantTypeToJson()
        {
            TraktAccessTokenGrantType.Unspecified.ToJson().ShouldBeNull();
            TraktAccessTokenGrantType.AuthorizationCode.ToJson().ShouldBe("authorization_code");
            TraktAccessTokenGrantType.RefreshToken.ToJson().ShouldBe("refresh_token");
            ((TraktAccessTokenGrantType)99).ToJson().ShouldBeNull();
        }

        [Fact]
        public void TestTraktAccessTokenGrantTypeFromJson()
        {
            "unspecified".ToTraktAccessTokenGrantType().ShouldBe(TraktAccessTokenGrantType.Unspecified);
            "authorization_code".ToTraktAccessTokenGrantType().ShouldBe(TraktAccessTokenGrantType.AuthorizationCode);
            "refresh_token".ToTraktAccessTokenGrantType().ShouldBe(TraktAccessTokenGrantType.RefreshToken);

            string? nullValue = null;
            nullValue.ToTraktAccessTokenGrantType().ShouldBe(TraktAccessTokenGrantType.Unspecified);
            "invalid".ToTraktAccessTokenGrantType().ShouldBe(TraktAccessTokenGrantType.Unspecified);
            "".ToTraktAccessTokenGrantType().ShouldBe(TraktAccessTokenGrantType.Unspecified);
        }

        [Fact]
        public void TestTraktAccessTokenGrantTypeDisplayName()
        {
            TraktAccessTokenGrantType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktAccessTokenGrantType.AuthorizationCode.DisplayName().ShouldBe("Authorization Code");
            TraktAccessTokenGrantType.RefreshToken.DisplayName().ShouldBe("Refresh Token");
            ((TraktAccessTokenGrantType)99).DisplayName().ShouldBe("99");
        }

        [Fact]
        public void TestTraktAccessTokenGrantTypeJsonConverter()
        {
            var converter = new TraktAccessTokenGrantTypeJsonConverter();
            converter.CanConvert(typeof(TraktAccessTokenGrantType)).ShouldBeTrue();
            converter.CanConvert(typeof(int)).ShouldBeFalse();

            var options = new JsonSerializerOptions
            {
                Converters = { converter }
            };

            JsonSerializer.Serialize(TraktAccessTokenGrantType.AuthorizationCode, options).ShouldBe("\"authorization_code\"");
            JsonSerializer.Deserialize<TraktAccessTokenGrantType>("\"authorization_code\"", options).ShouldBe(TraktAccessTokenGrantType.AuthorizationCode);
            JsonSerializer.Deserialize<TraktAccessTokenGrantType>("\"\"", options).ShouldBe(TraktAccessTokenGrantType.Unspecified);
        }
    }
}
