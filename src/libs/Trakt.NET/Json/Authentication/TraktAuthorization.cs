using System.Text.Json.Serialization;

namespace TraktNET
{
    public record class TraktAuthorization
    {
        public string? AccessToken { get; set; }

        public string? RefreshToken { get; set; }

        public TraktAccessTokenType? TokenType { get; set; }

        public TraktAccessScope? Scope { get; set; }

        public ulong? CreatedAt { get; set; }

        public uint? ExpiresIn { get; set; }

        [JsonIgnore]
        public ulong CreatedAtTimestamp => CreatedAt ?? 0;

        [JsonIgnore]
        public uint ExpiresInSeconds => ExpiresIn ?? 0;

        [JsonIgnore]
        public DateTime CreatedAtDateTime
            => CreatedAtTimestamp > 0 ? new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(CreatedAtTimestamp) : default;

        [JsonIgnore]
        public bool IsExpired => !IsValid || (!IgnoreExpiration && CreatedAtDateTime.AddSeconds(ExpiresInSeconds) <= DateTime.UtcNow);

        [JsonIgnore]
        public bool IsValid => !string.IsNullOrWhiteSpace(AccessToken) && !AccessToken!.ContainsSpace();

        [JsonIgnore]
        public bool IsRefreshPossible => !string.IsNullOrEmpty(RefreshToken) && !RefreshToken!.ContainsSpace();

        [JsonIgnore]
        public bool IgnoreExpiration { get; set; }

        public override string ToString()
        {
            string value = IsValid ? AccessToken! : "no valid access token";
            value += IsExpired ? " (expired)" : $" (valid until {CreatedAtDateTime.AddSeconds(ExpiresInSeconds)})";
            return value;
        }

        public static TraktAuthorization CreateWith(string? accessToken, string? refreshToken = null)
        {
            TraktAuthorization authorization = CreateWith(DateTime.UtcNow, accessToken, refreshToken);
            authorization.IgnoreExpiration = true;
            return authorization;
        }

        public static TraktAuthorization CreateWith(uint expiresInSeconds, string? accessToken, string? refreshToken = null)
            => CreateWith(DateTime.UtcNow, expiresInSeconds, accessToken, refreshToken);

        public static TraktAuthorization CreateWith(DateTime createdAt, string? accessToken, string? refreshToken = null)
        {
            TraktAuthorization authorization = CreateWith(createdAt, 7776000, accessToken, refreshToken);
            authorization.IgnoreExpiration = true;
            return authorization;
        }

        public static TraktAuthorization CreateWith(DateTime createdAt, uint expiresInSeconds, string? accessToken, string? refreshToken = null)
            => new()
            {
                AccessToken = accessToken ?? string.Empty,
                RefreshToken = refreshToken ?? string.Empty,
                ExpiresIn = expiresInSeconds,
                CreatedAt = CalculateTimestamp(createdAt),
                Scope = TraktAccessScope.Public,
                TokenType = TraktAccessTokenType.Bearer
            };

        private static ulong CalculateTimestamp(DateTime createdAt) => (ulong)new DateTimeOffset(createdAt).ToUnixTimeSeconds();
    }
}
