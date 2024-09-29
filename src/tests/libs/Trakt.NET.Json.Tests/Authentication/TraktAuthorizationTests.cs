namespace TraktNET.Json.Authentication
{
    public sealed class TraktAuthorizationTests
    {
        private const uint EXPIRES_IN_SECONDS = 7776000;
        private const string ACCESS_TOKEN = "accessToken";
        private const string REFRESH_TOKEN = "refreshToken";
        private readonly DateTime CreatedAt = new(2017, 2, 23, 22, 42, 21, DateTimeKind.Utc);

        [Fact]
        public void TestTraktAuthorizationConstructor()
        {
            var authorization = new TraktAuthorization();

            authorization.AccessToken.Should().BeNull();
            authorization.RefreshToken.Should().BeNull();
            authorization.ExpiresIn.Should().BeNull();
            authorization.ExpiresInSeconds.Should().Be(0U);
            authorization.CreatedAt.Should().BeNull();
            authorization.CreatedAtTimestamp.Should().Be(0UL);
            authorization.CreatedAtDateTime.Should().Be(default);
            authorization.Scope.Should().BeNull();
            authorization.TokenType.Should().BeNull();
            authorization.IsExpired.Should().BeTrue();
            authorization.IsValid.Should().BeFalse();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IgnoreExpiration.Should().BeFalse();

            authorization.AsBearerToken().Should().Be("Bearer: invalid access token");
        }

        [Fact]
        public async Task TestTraktAuthorizationFromJson()
        {
            TraktAuthorization? authorization = await TestUtility.DeserializeJsonAsync<TraktAuthorization>("Authentication\\authorization.json");

            authorization.Should().NotBeNull();

            authorization!.AccessToken.Should().Be("dbaf9757982a9e738f05d249b7b5b4a266b3a139049317c4909f2f263572c781");
            authorization!.RefreshToken.Should().Be("76ba4c5c75c96f6087f58a4de10be6c00b29ea1ddc3b2022ee2016d1363e3a7c");
            authorization!.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization!.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization!.CreatedAt.Should().Be(1487889741UL);
            authorization!.CreatedAtTimestamp.Should().Be(1487889741UL);
            authorization!.CreatedAtDateTime.Should().Be(CreatedAt);
            authorization!.Scope.Should().Be(TraktAccessScope.Public);
            authorization!.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization!.IsExpired.Should().BeTrue();
            authorization!.IsValid.Should().BeTrue();
            authorization!.IsRefreshPossible.Should().BeTrue();
            authorization!.IgnoreExpiration.Should().BeFalse();

            authorization!.AsBearerToken().Should().Be("Bearer: dbaf9757982a9e738f05d249b7b5b4a266b3a139049317c4909f2f263572c781");
        }

        [Fact]
        public void TestTraktAuthorizationIsValid()
        {
            var authorization = new TraktAuthorization();

            authorization.IsValid.Should().BeFalse();

            authorization.AccessToken = string.Empty;
            authorization.IsValid.Should().BeFalse();

            authorization.AccessToken = "access token";
            authorization.IsValid.Should().BeFalse();

            authorization.AccessToken = "accessToken";
            authorization.IsValid.Should().BeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationIsRefreshPossible()
        {
            var authorization = new TraktAuthorization();

            authorization.IsRefreshPossible.Should().BeFalse();

            authorization.RefreshToken = string.Empty;
            authorization.IsRefreshPossible.Should().BeFalse();

            authorization.RefreshToken = "refresh token";
            authorization.IsRefreshPossible.Should().BeFalse();

            authorization.RefreshToken = "refreshToken";
            authorization.IsRefreshPossible.Should().BeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationIsExpired()
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcNow = DateTime.UtcNow;

            long utcNowSeconds = utcNow.Ticks / TimeSpan.TicksPerSecond;
            long originSeconds = origin.Ticks / TimeSpan.TicksPerSecond;
            long differenceSeconds = utcNowSeconds - originSeconds;

            var authorization = new TraktAuthorization
            {
                CreatedAt = (ulong)differenceSeconds
            };

            authorization.IsExpired.Should().BeTrue();

            authorization.AccessToken = string.Empty;
            authorization.IsExpired.Should().BeTrue();

            authorization.AccessToken = "access token";
            authorization.IsExpired.Should().BeTrue();

            authorization.AccessToken = "accessToken";
            authorization.IsExpired.Should().BeTrue();

            authorization.ExpiresIn = 1;
            authorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationIsExpiredWithIgnoreExpiration()
        {
            var authorization = new TraktAuthorization
            {
                IgnoreExpiration = true,
                ExpiresIn = 0
            };

            authorization.IsExpired.Should().BeTrue();

            authorization.AccessToken = string.Empty;
            authorization.IsExpired.Should().BeTrue();

            authorization.AccessToken = "access token";
            authorization.IsExpired.Should().BeTrue();

            authorization.AccessToken = "accessToken";
            authorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationCreatedAtDateTime()
        {
            var authorization = new TraktAuthorization();

            authorization.CreatedAtDateTime.Should().Be(default);

            authorization.CreatedAt = 1487889741;
            authorization.CreatedAtDateTime.Should().Be(CreatedAt);
        }

        [Fact]
        public void TestTraktAuthorizationToString()
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcNow = DateTime.UtcNow;

            long utcNowSeconds = utcNow.Ticks / TimeSpan.TicksPerSecond;
            long originSeconds = origin.Ticks / TimeSpan.TicksPerSecond;
            long differenceSeconds = utcNowSeconds - originSeconds;

            var authorization = new TraktAuthorization();

            authorization.ToString().Should().Be("no valid access token (expired)");

            authorization.AccessToken = "accessToken";
            authorization.ToString().Should().Be($"{authorization.AccessToken} (expired)");

            authorization.CreatedAt = (ulong)differenceSeconds;
            authorization.CreatedAtDateTime.Should().Be(origin.AddSeconds(differenceSeconds));
            authorization.ExpiresIn = 600;
            authorization.ToString().Should().Be($"{authorization.AccessToken} (valid until {authorization.CreatedAtDateTime.AddSeconds(authorization.ExpiresInSeconds)})");
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithExpiresInAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(1000, ACCESS_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.ExpiresIn.Should().Be(1000);
            authorization.ExpiresInSeconds.Should().Be(1000);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithExpiresInAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(1000, ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            authorization.ExpiresIn.Should().Be(1000);
            authorization.ExpiresInSeconds.Should().Be(1000);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, ACCESS_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtExpiresInAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, 1000, ACCESS_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.ExpiresIn.Should().Be(1000);
            authorization.ExpiresInSeconds.Should().Be(1000);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtExpiresInAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, 1000, ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            authorization.ExpiresIn.Should().Be(1000);
            authorization.ExpiresInSeconds.Should().Be(1000);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithNullValues()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(null, REFRESH_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeTrue();
            authorization.IsValid.Should().BeFalse();
            authorization.IsRefreshPossible.Should().BeTrue();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, null, REFRESH_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.IsExpired.Should().BeTrue();
            authorization.IsValid.Should().BeFalse();
            authorization.IsRefreshPossible.Should().BeTrue();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, ACCESS_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, null, REFRESH_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeTrue();
            authorization.IsValid.Should().BeFalse();
            authorization.IsRefreshPossible.Should().BeTrue();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, ACCESS_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, EXPIRES_IN_SECONDS, null, REFRESH_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.IsExpired.Should().BeTrue();
            authorization.IsValid.Should().BeFalse();
            authorization.IsRefreshPossible.Should().BeTrue();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, EXPIRES_IN_SECONDS, ACCESS_TOKEN);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(ACCESS_TOKEN);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.ExpiresIn.Should().Be(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.Should().Be(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.IsExpired.Should().BeFalse();
            authorization.IsValid.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
        }

        private static ulong CalculateTimestamp(DateTime createdAt) => (ulong)new DateTimeOffset(createdAt).ToUnixTimeSeconds();
    }
}
