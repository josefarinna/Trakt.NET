namespace TraktNET
{
    /// <summary>Represents statistical counts for a review period.</summary>
    public record class TraktUserReviewStatItem
    {
        /// <summary>Gets or sets the total count.</summary>
        public uint? Total { get; set; }

        /// <summary>Gets or sets the yearly count.</summary>
        public uint? Yearly { get; set; }

        /// <summary>Gets or sets the monthly count.</summary>
        public uint? Monthly { get; set; }

        /// <summary>Gets or sets the weekly count.</summary>
        public uint? Weekly { get; set; }

        /// <summary>Gets or sets the daily count.</summary>
        public uint? Daily { get; set; }
    }
}
