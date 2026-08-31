using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents the payload to retrieve an authorization token with an authorization code.</summary>
    public record class TraktAuthorizationPost
    {
        /// <summary>Gets or sets the authorization code.</summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; }

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
        public string GrantType { get; set; } = "authorization_code";

        /// <summary>Validates the post data.</summary>
        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(Code, "code not valid", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientId, "client id not valid", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientSecret, "client secret not valid", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(RedirectUri, "redirect uri not valid", true);
        }
    }
}

