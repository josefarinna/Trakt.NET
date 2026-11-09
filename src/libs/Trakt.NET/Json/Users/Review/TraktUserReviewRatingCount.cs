namespace TraktNET
{
    /// <summary>Represents rating counts for a specific star rating (1 to 10) in an all-time review.</summary>
    public record class TraktUserReviewRatingCount
    {
        /// <summary>Gets or sets the star rating (1 to 10).</summary>
        public uint? Rating { get; set; }

        /// <summary>Gets or sets the rating count.</summary>
        public uint? Count { get; set; }
    }
}
