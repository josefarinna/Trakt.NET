using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents the payload to refresh an authorization token.</summary>
    public record class TraktAuthorizationRefreshPost
    {
        /// <summary>Gets or sets the refresh token.</summary>
        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }

        /// <summary>Gets or sets the client ID.</summary>
        [JsonPropertyName("client_id")]
        public string? ClientId { get; set; }

        /// <summary>Gets or sets the client secret.</summary>
        [JsonPropertyName("client_secret")]
        public string? ClientSecret { get; set; }

        /// <summary>Gets or sets the redirect URI.</summary>
        [JsonPropertyName("redirect_uri")]
        public string? RedirectUri { get; set; }

        /// <summary>Gets or sets the grant type.</summary>
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; } = "refresh_token";

        /// <summary>Validates the post data.</summary>
        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(RefreshToken, "refresh token not valid", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientId, "client id not valid", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientSecret, "client secret not valid", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(RedirectUri, "redirect uri not valid", true);
        }
    }
}

