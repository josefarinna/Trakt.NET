namespace TraktNET
{
    /// <summary>Represents country breakdown data for a specific media type in a review period.</summary>
    public record class TraktUserReviewCountryGroup
    {
        /// <summary>Gets or sets the total count of distinct countries.</summary>
        public uint? CountryCount { get; set; }

        /// <summary>
        /// Gets or sets the list of country breakdown entries.
        /// <para>See also <seealso cref="TraktUserReviewCountry" />.</para>
        /// </summary>
        public IReadOnlyList<TraktUserReviewCountry>? Countries { get; set; }
    }
}
