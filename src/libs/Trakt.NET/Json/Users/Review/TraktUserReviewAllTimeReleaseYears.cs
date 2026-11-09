namespace TraktNET
{
    /// <summary>Represents watched titles per release year and decade for shows and movies.</summary>
    public record class TraktUserReviewAllTimeReleaseYears
    {
        /// <summary>
        /// Gets or sets release years breakdown for shows.
        /// <para>See also <seealso cref="TraktUserReviewReleaseYears" />.</para>
        /// </summary>
        public TraktUserReviewReleaseYears? Shows { get; set; }

        /// <summary>
        /// Gets or sets release years breakdown for movies.
        /// <para>See also <seealso cref="TraktUserReviewReleaseYears" />.</para>
        /// </summary>
        public TraktUserReviewReleaseYears? Movies { get; set; }
    }
}
