namespace TraktNET
{
    /// <summary>Represents watched titles per decade in an all-time review.</summary>
    public record class TraktUserReviewDecadeCount
    {
        /// <summary>Gets or sets the decade.</summary>
        public uint? Decade { get; set; }

        /// <summary>Gets or sets the title count.</summary>
        public uint? Count { get; set; }
    }
}
