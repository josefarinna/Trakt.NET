namespace TraktNET
{
    /// <summary>Represents play counts for a specific year in an all-time review.</summary>
    public record class TraktUserReviewYearlyPlayCount
    {
        /// <summary>Gets or sets the calendar year.</summary>
        public uint? Year { get; set; }

        /// <summary>Gets or sets the play count.</summary>
        public uint? Count { get; set; }
    }
}
