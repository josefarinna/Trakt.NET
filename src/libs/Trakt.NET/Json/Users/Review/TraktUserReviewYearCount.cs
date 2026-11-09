namespace TraktNET
{
    /// <summary>Represents watched titles per release year in an all-time review.</summary>
    public record class TraktUserReviewYearCount
    {
        /// <summary>Gets or sets the release year.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets the title count.</summary>
        public uint? Count { get; set; }
    }
}
