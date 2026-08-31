using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents the payload to revoke an authorization token.</summary>
    public record class TraktAuthorizationRevokePost
    {
        /// <summary>Gets or sets the token to revoke.</summary>
        [JsonPropertyName("token")]
        public string? Token { get; set; }

        /// <summary>Gets or sets the client ID.</summary>
        [JsonPropertyName("client_id")]
        public string? ClientId { get; set; }

        /// <summary>Gets or sets the client secret.</summary>
        [JsonPropertyName("client_secret")]
        public string? ClientSecret { get; set; }

        /// <summary>Validates the post data.</summary>
        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(Token, "access token not valid", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientId, "client id not valid", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientSecret, "client secret not valid", true);
        }
    }
}

