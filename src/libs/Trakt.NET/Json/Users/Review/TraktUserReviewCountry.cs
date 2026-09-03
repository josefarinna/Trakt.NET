namespace TraktNET
{
    /// <summary>Represents a production country and watch count in a review period.</summary>
    public record class TraktUserReviewCountry
    {
        /// <summary>Gets or sets the 2-character country code.</summary>
        public string? Country { get; set; }

        /// <summary>Gets or sets the watch count for this country.</summary>
        public uint? Count { get; set; }
    }
}
