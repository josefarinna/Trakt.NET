using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents the payload to poll for an authorization token for a device.</summary>
    public record class TraktAuthorizationPollPost
    {
        private string? _code;

        /// <summary>Gets or sets the device instance.</summary>
        [JsonIgnore]
        public TraktDevice? Device { get; set; }

        /// <summary>Gets or sets the device code.</summary>
        [JsonPropertyName("code")]
        public string? Code
        {
            get => Device?.DeviceCode ?? _code;
            set => _code = value;
        }

        /// <summary>Gets or sets the client ID.</summary>
        [JsonPropertyName("client_id")]
        public string? ClientId { get; set; }

        /// <summary>Gets or sets the client secret.</summary>
        [JsonPropertyName("client_secret")]
        public string? ClientSecret { get; set; }

        /// <summary>Validates the post data.</summary>
        public void Validate()
        {
            if (Device == null)
                throw new TraktRequestValidationException(nameof(Device), "device must not be null");

            if (Device.IsExpiredUnused)
                throw new TraktRequestValidationException(nameof(Device), "device code expired unused");

            if (!Device.IsValid)
                throw new TraktRequestValidationException(nameof(Device), "device not valid");

            ArgumentValidator.ThrowIfNullOrWhiteSpace(Device.DeviceCode, "device code not valid", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientId, "client id not valid", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(ClientSecret, "client secret not valid", true);
        }
    }
}

