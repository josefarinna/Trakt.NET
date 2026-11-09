using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Represents progress through a curated top list in an all-time review.</summary>
    public record class TraktUserReviewListProgress
    {
        /// <summary>Gets or sets the list id.</summary>
        [JsonPropertyName("id")]
        public uint? ID { get; set; }

        /// <summary>Gets or sets the site name.</summary>
        public string? Site { get; set; }

        /// <summary>Gets or sets the list title.</summary>
        public string? Title { get; set; }

        /// <summary>Gets or sets the logo URL, if available.</summary>
        public string? Logo { get; set; }

        /// <summary>Gets or sets the total number of items in the list.</summary>
        public uint? Total { get; set; }

        /// <summary>Gets or sets the number of watched items in the list.</summary>
        public uint? Watched { get; set; }

        /// <summary>Gets or sets the watched percentage.</summary>
        public uint? Percentage { get; set; }
    }
}
