using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A collection of <see cref="TraktCertification" />s.</summary>
    public record class TraktCertifications
    {
        /// <summary>The certifications for the country code "us". See also <seealso cref="TraktCertification" />.</summary>
        [JsonPropertyName("us")]
        public List<TraktCertification>? US { get; set; }
    }
}
