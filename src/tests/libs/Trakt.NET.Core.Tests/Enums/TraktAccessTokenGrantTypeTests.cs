namespace TraktNET.Enums
{
    public sealed class TraktAccessTokenGrantTypeTests
    {
        [Fact]
        public void TestTraktAccessTokenGrantTypeToJson()
        {
            TraktAccessTokenGrantType.Unspecified.ToJson().Should().BeNull();
            TraktAccessTokenGrantType.AuthorizationCode.ToJson().Should().Be("authorization_code");
            TraktAccessTokenGrantType.RefreshToken.ToJson().Should().Be("refresh_token");
        }

        [Fact]
        public void TestTraktAccessTokenGrantTypeFromJson()
        {
            "unspecified".ToTraktAccessTokenGrantType().Should().Be(TraktAccessTokenGrantType.Unspecified);
            "authorization_code".ToTraktAccessTokenGrantType().Should().Be(TraktAccessTokenGrantType.AuthorizationCode);
            "refresh_token".ToTraktAccessTokenGrantType().Should().Be(TraktAccessTokenGrantType.RefreshToken);

            string? nullValue = null;
            nullValue.ToTraktAccessTokenGrantType().Should().Be(TraktAccessTokenGrantType.Unspecified);
        }

        [Fact]
        public void TestTraktAccessTokenGrantTypeDisplayName()
        {
            TraktAccessTokenGrantType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktAccessTokenGrantType.AuthorizationCode.DisplayName().Should().Be("Authorization Code");
            TraktAccessTokenGrantType.RefreshToken.DisplayName().Should().Be("Refresh Token");
        }
    }
}
