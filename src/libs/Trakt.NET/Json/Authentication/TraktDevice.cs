using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents a Trakt device response.</summary>
    public record class TraktDevice
    {
        /// <summary>The actual device code.</summary>
        public string? DeviceCode { get; set; }

        /// <summary>The user code.</summary>
        public string? UserCode { get; set; }

        /// <summary>The verification URL.</summary>
        public string? VerificationUrl { get; set; }

        /// <summary>The seconds, after which this device will expire.</summary>
        public uint? ExpiresIn { get; set; }

        /// <summary>The interval, at which the access token should be polled.</summary>
        public uint? Interval { get; set; }

        /// <summary>The seconds, after which this device will expire.</summary>
        [JsonIgnore]
        public uint ExpiresInSeconds => ExpiresIn ?? 0;

        /// <summary>The interval, at which the access token should be polled.</summary>
        [JsonIgnore]
        public uint IntervalInSeconds => Interval ?? 0;

        /// <summary>The UTC DateTime, when this device was created.</summary>
        [JsonIgnore]
        public DateTime CreatedAt { get; }

        /// <summary>Gets, whether this device is expired without actually using it for polling for an access token.</summary>
        [JsonIgnore]
        public bool IsExpiredUnused => CreatedAt.AddSeconds(ExpiresInSeconds) <= DateTime.UtcNow;

        /// <summary>
        /// Returns, whether this device is valid.
        /// <para>
        /// A Trakt device is valid, as long as the actual <see cref="DeviceCode" />
        /// is neither null nor empty and as long as this device is not expired.<para />
        /// See also <seealso cref="ExpiresInSeconds" />.<para />
        /// See also <seealso cref="IsExpiredUnused" />.<para />
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool IsValid => !string.IsNullOrWhiteSpace(DeviceCode) && !string.IsNullOrWhiteSpace(UserCode)
            && !string.IsNullOrWhiteSpace(VerificationUrl) && !IsExpiredUnused && IntervalInSeconds > 0;

        public TraktDevice() => CreatedAt = DateTime.UtcNow;

        /// <summary>Gets a string representation of the device.</summary>
        /// <returns>A string representation of the device.</returns>
        public override string ToString()
        {
            string value = IsValid ? DeviceCode! : "no valid device code";
            value += IsExpiredUnused ? " (expired unused)" : $" (valid until {CreatedAt.AddSeconds(ExpiresInSeconds)})";
            return value;
        }

        [JsonIgnore]
        internal uint IntervalInMilliseconds => IntervalInSeconds * 1000;
    }
}
