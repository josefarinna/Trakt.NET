using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents a network or production company in a review period.</summary>
    public record class TraktUserReviewCompany
    {
        /// <summary>Gets or sets the company id.</summary>
        [JsonPropertyName("id")]
        public uint? ID { get; set; }

        /// <summary>Gets or sets the company name.</summary>
        public string? Name { get; set; }

        /// <summary>Gets or sets the number of watched titles.</summary>
        public uint? Count { get; set; }

        /// <summary>Gets or sets the company image URL, if available.</summary>
        public string? ImageUrl { get; set; }

        /// <summary>Gets or sets the hex brand color.</summary>
        public string? Color { get; set; }
    }
}
