using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents the payload to generate a device code.</summary>
    public record class TraktDevicePost
    {
        /// <summary>Gets or sets the client ID.</summary>
        [JsonPropertyName("client_id")]
        public string? ClientId { get; set; }

        /// <summary>Validates the post data.</summary>
        public void Validate()
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientId, "client id not valid", true);
        }
    }
}

