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

            authorization.AccessToken.ShouldBeNull();
            authorization.RefreshToken.ShouldBeNull();
            authorization.ExpiresIn.ShouldBeNull();
            authorization.ExpiresInSeconds.ShouldBe(0U);
            authorization.CreatedAt.ShouldBeNull();
            authorization.CreatedAtTimestamp.ShouldBe(0UL);
            authorization.CreatedAtDateTime.ShouldBe(default);
            authorization.Scope.ShouldBeNull();
            authorization.TokenType.ShouldBeNull();
            authorization.IsExpired.ShouldBeTrue();
            authorization.IsValid.ShouldBeFalse();
            authorization.IsRefreshPossible.ShouldBeFalse();
            authorization.IgnoreExpiration.ShouldBeFalse();

            authorization.AsBearerToken().ShouldBe("Bearer: invalid access token");
        }

        [Fact]
        public async Task TestTraktAuthorizationFromJson()
        {
            TraktAuthorization? authorization = await TestUtility.DeserializeJsonAsync<TraktAuthorization>("Authentication\\authorization.json");

            authorization.ShouldNotBeNull();

            authorization.AccessToken.ShouldBe("dbaf9757982a9e738f05d249b7b5b4a266b3a139049317c4909f2f263572c781");
            authorization.RefreshToken.ShouldBe("76ba4c5c75c96f6087f58a4de10be6c00b29ea1ddc3b2022ee2016d1363e3a7c");
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(1487889741UL);
            authorization.CreatedAtTimestamp.ShouldBe(1487889741UL);
            authorization.CreatedAtDateTime.ShouldBe(CreatedAt);
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IsExpired.ShouldBeTrue();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeTrue();
            authorization.IgnoreExpiration.ShouldBeFalse();

            authorization.AsBearerToken().ShouldBe("Bearer: dbaf9757982a9e738f05d249b7b5b4a266b3a139049317c4909f2f263572c781");
        }

        [Fact]
        public void TestTraktAuthorizationIsValid()
        {
            var authorization = new TraktAuthorization();

            authorization.IsValid.ShouldBeFalse();

            authorization.AccessToken = string.Empty;
            authorization.IsValid.ShouldBeFalse();

            authorization.AccessToken = "access token";
            authorization.IsValid.ShouldBeFalse();

            authorization.AccessToken = "accessToken";
            authorization.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationIsRefreshPossible()
        {
            var authorization = new TraktAuthorization();

            authorization.IsRefreshPossible.ShouldBeFalse();

            authorization.RefreshToken = string.Empty;
            authorization.IsRefreshPossible.ShouldBeFalse();

            authorization.RefreshToken = "refresh token";
            authorization.IsRefreshPossible.ShouldBeFalse();

            authorization.RefreshToken = "refreshToken";
            authorization.IsRefreshPossible.ShouldBeTrue();
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

            authorization.IsExpired.ShouldBeTrue();

            authorization.AccessToken = string.Empty;
            authorization.IsExpired.ShouldBeTrue();

            authorization.AccessToken = "access token";
            authorization.IsExpired.ShouldBeTrue();

            authorization.AccessToken = "accessToken";
            authorization.IsExpired.ShouldBeTrue();

            authorization.ExpiresIn = 1;
            authorization.IsExpired.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationIsExpiredWithIgnoreExpiration()
        {
            var authorization = new TraktAuthorization
            {
                IgnoreExpiration = true,
                ExpiresIn = 0
            };

            authorization.IsExpired.ShouldBeTrue();

            authorization.AccessToken = string.Empty;
            authorization.IsExpired.ShouldBeTrue();

            authorization.AccessToken = "access token";
            authorization.IsExpired.ShouldBeTrue();

            authorization.AccessToken = "accessToken";
            authorization.IsExpired.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationCreatedAtDateTime()
        {
            var authorization = new TraktAuthorization();

            authorization.CreatedAtDateTime.ShouldBe(default);

            authorization.CreatedAt = 1487889741;
            authorization.CreatedAtDateTime.ShouldBe(CreatedAt);
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

            authorization.ToString().ShouldBe("no valid access token (expired)");

            authorization.AccessToken = "accessToken";
            authorization.ToString().ShouldBe($"{authorization.AccessToken} (expired)");

            authorization.CreatedAt = (ulong)differenceSeconds;
            authorization.CreatedAtDateTime.ShouldBe(origin.AddSeconds(differenceSeconds));
            authorization.ExpiresIn = 600;
            authorization.ToString().ShouldBe($"{authorization.AccessToken} (valid until {authorization.CreatedAtDateTime.AddSeconds(authorization.ExpiresInSeconds)})");
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeTrue();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeTrue();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithExpiresInAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(1000, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(1000U);
            authorization.ExpiresInSeconds.ShouldBe(1000U);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeFalse();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithExpiresInAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(1000, ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(1000U);
            authorization.ExpiresInSeconds.ShouldBe(1000U);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeFalse();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeTrue();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeTrue();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtExpiresInAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, 1000, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(1000U);
            authorization.ExpiresInSeconds.ShouldBe(1000U);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeFalse();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeFalse();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtExpiresInAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, 1000, ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(1000U);
            authorization.ExpiresInSeconds.ShouldBe(1000U);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeFalse();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeTrue();
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithNullValues()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(null, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldNotBeNull();
            authorization.AccessToken.ShouldBeEmpty();
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAtTimestamp.ShouldBeInRange(createdAtUtcNowTimestamp - 10, createdAtUtcNowTimestamp + 10);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeTrue();
            authorization.IsExpired.ShouldBeTrue();
            authorization.IsValid.ShouldBeFalse();
            authorization.IsRefreshPossible.ShouldBeTrue();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAtTimestamp.ShouldBeInRange(createdAtUtcNowTimestamp - 10, createdAtUtcNowTimestamp + 10);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeTrue();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeFalse();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, null, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldNotBeNull();
            authorization.AccessToken.ShouldBeEmpty();
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAtTimestamp.ShouldBeInRange(createdAtUtcNowTimestamp - 10, createdAtUtcNowTimestamp + 10);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeFalse();
            authorization.IsExpired.ShouldBeTrue();
            authorization.IsValid.ShouldBeFalse();
            authorization.IsRefreshPossible.ShouldBeTrue();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAtTimestamp.ShouldBeInRange(createdAtUtcNowTimestamp - 10, createdAtUtcNowTimestamp + 10);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeFalse();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeFalse();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, null, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldNotBeNull();
            authorization.AccessToken.ShouldBeEmpty();
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeTrue();
            authorization.IsExpired.ShouldBeTrue();
            authorization.IsValid.ShouldBeFalse();
            authorization.IsRefreshPossible.ShouldBeTrue();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeTrue();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeFalse();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, EXPIRES_IN_SECONDS, null, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldNotBeNull();
            authorization.AccessToken.ShouldBeEmpty();
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeFalse();
            authorization.IsExpired.ShouldBeTrue();
            authorization.IsValid.ShouldBeFalse();
            authorization.IsRefreshPossible.ShouldBeTrue();

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, EXPIRES_IN_SECONDS, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBeFalse();
            authorization.IsExpired.ShouldBeFalse();
            authorization.IsValid.ShouldBeTrue();
            authorization.IsRefreshPossible.ShouldBeFalse();
        }

        private static ulong CalculateTimestamp(DateTime createdAt) => (ulong)new DateTimeOffset(createdAt).ToUnixTimeSeconds();
    }
}
