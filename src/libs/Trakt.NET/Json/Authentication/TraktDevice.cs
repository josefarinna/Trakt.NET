using System.Text.Json.Serialization;

namespace TraktNET
{
    public record class TraktDevice
    {
        public string? DeviceCode { get; set; }

        public string? UserCode { get; set; }

        public string? VerificationUrl { get; set; }

        public uint? ExpiresIn { get; set; }

        public uint? Interval { get; set; }

        [JsonIgnore]
        public uint ExpiresInSeconds => ExpiresIn ?? 0;

        [JsonIgnore]
        public uint IntervalInSeconds => Interval ?? 0;

        [JsonIgnore]
        public DateTime CreatedAt { get; }

        [JsonIgnore]
        public bool IsExpiredUnused => CreatedAt.AddSeconds(ExpiresInSeconds) <= DateTime.UtcNow;

        [JsonIgnore]
        public bool IsValid => !string.IsNullOrWhiteSpace(DeviceCode) && !string.IsNullOrWhiteSpace(UserCode)
            && !string.IsNullOrWhiteSpace(VerificationUrl) && !IsExpiredUnused && IntervalInSeconds > 0;

        public TraktDevice() => CreatedAt = DateTime.UtcNow;

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
