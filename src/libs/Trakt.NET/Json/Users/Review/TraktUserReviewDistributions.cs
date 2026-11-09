namespace TraktNET
{
    /// <summary>Represents review play count distributions per time slot.</summary>
    public record class TraktUserReviewDistributions
    {
        /// <summary>Gets or sets play counts per ISO week of the last year.</summary>
        public List<uint>? Weekly { get; set; }

        /// <summary>Gets or sets play counts per calendar month.</summary>
        public List<uint>? Monthly { get; set; }

        /// <summary>Gets or sets play counts per weekday (starting on the user's week start day).</summary>
        public List<uint>? Days { get; set; }

        /// <summary>Gets or sets play counts per hour of the day.</summary>
        public List<uint>? Hourly { get; set; }

        /// <summary>Gets or sets play counts per day of the month (Month in Review only).</summary>
        public List<uint>? Daily { get; set; }

        /// <summary>
        /// Gets or sets play counts per calendar year (All-time Review only).
        /// <para>See also <seealso cref="TraktUserReviewYearlyPlayCount" />.</para>
        /// </summary>
        public List<TraktUserReviewYearlyPlayCount>? Yearly { get; set; }
    }
}
