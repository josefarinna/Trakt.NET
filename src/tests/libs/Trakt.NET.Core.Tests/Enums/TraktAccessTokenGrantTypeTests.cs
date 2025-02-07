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
        }

        [Fact]
        public void TestTraktAccessTokenGrantTypeFromJson()
        {
            "unspecified".ToTraktAccessTokenGrantType().ShouldBe(TraktAccessTokenGrantType.Unspecified);
            "authorization_code".ToTraktAccessTokenGrantType().ShouldBe(TraktAccessTokenGrantType.AuthorizationCode);
            "refresh_token".ToTraktAccessTokenGrantType().ShouldBe(TraktAccessTokenGrantType.RefreshToken);

            string? nullValue = null;
            nullValue.ToTraktAccessTokenGrantType().ShouldBe(TraktAccessTokenGrantType.Unspecified);
        }

        [Fact]
        public void TestTraktAccessTokenGrantTypeDisplayName()
        {
            TraktAccessTokenGrantType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TraktAccessTokenGrantType.AuthorizationCode.DisplayName().ShouldBe("Authorization Code");
            TraktAccessTokenGrantType.RefreshToken.DisplayName().ShouldBe("Refresh Token");
        }
    }
}
