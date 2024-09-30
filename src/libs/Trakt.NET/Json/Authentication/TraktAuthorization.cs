using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt authorization response, which contains information, such as access token and refresh token.</summary>
    public record class TraktAuthorization
    {
        /// <summary>The access token.</summary>
        public string? AccessToken { get; set; }

        /// <summary>The refresh token. Use this to exchange it for a new access token.</summary>
        public string? RefreshToken { get; set; }

        /// <summary>The token type. See also <seealso cref="TraktAccessTokenType" />.</summary>
        public TraktAccessTokenType? TokenType { get; set; }

        /// <summary>The token scope. See also <seealso cref="TraktAccessScope" />.</summary>
        public TraktAccessScope? Scope { get; set; }

        /// <summary>The timestamp, when this token was created.</summary>
        public ulong? CreatedAt { get; set; }

        /// <summary>The seconds, after which this authorization will expire.</summary>
        public uint? ExpiresIn { get; set; }

        /// <summary>The timestamp, when this token was created.</summary>
        [JsonIgnore]
        public ulong CreatedAtTimestamp => CreatedAt ?? 0;

        /// <summary>The seconds, after which this authorization will expire.</summary>
        [JsonIgnore]
        public uint ExpiresInSeconds => ExpiresIn ?? 0;

        /// <summary>Returns the UTC DateTime, when this authorization information was created.</summary>
        [JsonIgnore]
        public DateTime CreatedAtDateTime
            => CreatedAtTimestamp > 0 ? new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(CreatedAtTimestamp) : default;

        /// <summary>
        /// Returns, whether this authorization information is expired.
        /// <para>
        /// Returns false, if <see cref="IsValid" /> returns false, or, if the authorization information is expired.
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool IsExpired => !IsValid || (!IgnoreExpiration && CreatedAtDateTime.AddSeconds(ExpiresInSeconds) <= DateTime.UtcNow);

        /// <summary>
        /// Returns, whether this authorization information is valid.
        /// <para>
        /// Returns false, if <see cref="AccessToken" /> is null, empty or contains spaces.
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool IsValid => !string.IsNullOrWhiteSpace(AccessToken) && !AccessToken!.ContainsSpace();

        /// <summary>
        /// Returns, whether this authorization information can be refreshed with a refresh token.
        /// <para>
        /// Returns false, if <see cref="RefreshToken" /> is null, empty or contains spaces.
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool IsRefreshPossible => !string.IsNullOrEmpty(RefreshToken) && !RefreshToken!.ContainsSpace();

        /// <summary>Gets or sets, whether token expiration should be ignored.</summary>
        [JsonIgnore]
        public bool IgnoreExpiration { get; set; }

        /// <summary>Gets a string representation of the authorization token.</summary>
        /// <returns>A string representation of the authorization token.</returns>
        public override string ToString()
        {
            string value = IsValid ? AccessToken! : "no valid access token";
            value += IsExpired ? " (expired)" : $" (valid until {CreatedAtDateTime.AddSeconds(ExpiresInSeconds)})";
            return value;
        }

        /// <summary>Gets a string representation of the access token in the Bearer: <access-token> format.</summary>
        /// <returns>A string representation of the access token in the Bearer: <access-token> format.</returns>
        public string AsBearerToken() => $"Bearer: {AccessToken ?? "invalid access token"}";

        /// <summary>Creates a new <see cref="TraktAuthorization" /> instance with the given values.</summary>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(string? accessToken, string? refreshToken = null)
        {
            TraktAuthorization authorization = CreateWith(DateTime.UtcNow, accessToken, refreshToken);
            authorization.IgnoreExpiration = true;
            return authorization;
        }

        /// <summary>Creates a new <see cref="TraktAuthorization" /> instance with the given values.</summary>
        /// <param name="expiresInSeconds">The seconds, after which the given access token will expire.</param>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(uint expiresInSeconds, string? accessToken, string? refreshToken = null)
            => CreateWith(DateTime.UtcNow, expiresInSeconds, accessToken, refreshToken);

        /// <summary>
        /// Creates a new <see cref="TraktAuthorization" /> instance with the given values.
        /// <see cref="ExpiresInSeconds" /> of the created <see cref="TraktAuthorization" /> instance will have the default
        /// value of 3600 * 24 * 90 seconds, equal to 90 days.
        /// </summary>
        /// <param name="createdAt">The datetime, when the given access token was created. Will be converted to UTC datetime.</param>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
        public static TraktAuthorization CreateWith(DateTime createdAt, string? accessToken, string? refreshToken = null)
        {
            TraktAuthorization authorization = CreateWith(createdAt, 7776000, accessToken, refreshToken);
            authorization.IgnoreExpiration = true;
            return authorization;
        }

        /// <summary>Creates a new <see cref="TraktAuthorization" /> instance with the given values.</summary>
        /// <param name="createdAt">The datetime, when the given access token was created. Will be converted to UTC datetime.</param>
        /// <param name="expiresInSeconds">The seconds, after which the given access token will expire.</param>
        /// <param name="accessToken">The access token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <param name="refreshToken">The optional refresh token for the new <see cref="TraktAuthorization" /> instance.</param>
        /// <returns>A new <see cref="TraktAuthorization" /> instance with the given values.</returns>
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
