namespace TraktNET
{
    /// <summary>Represents country breakdown data for shows and movies in a review period.</summary>
    public record class TraktUserReviewCountries
    {
        /// <summary>
        /// Gets or sets the country breakdown for shows.
        /// <para>See also <seealso cref="TraktUserReviewCountryGroup" />.</para>
        /// </summary>
        public TraktUserReviewCountryGroup? Shows { get; set; }

        /// <summary>
        /// Gets or sets the country breakdown for movies.
        /// <para>See also <seealso cref="TraktUserReviewCountryGroup" />.</para>
        /// </summary>
        public TraktUserReviewCountryGroup? Movies { get; set; }
    }
}
