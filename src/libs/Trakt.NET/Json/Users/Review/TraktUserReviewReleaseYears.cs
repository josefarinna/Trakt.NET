namespace TraktNET
{
    /// <summary>Represents watched titles per release year and decade for a media type.</summary>
    public record class TraktUserReviewReleaseYears
    {
        /// <summary>
        /// Gets or sets the release years breakdown.
        /// <para>See also <seealso cref="TraktUserReviewYearCount" />.</para>
        /// </summary>
        public List<TraktUserReviewYearCount>? Years { get; set; }

        /// <summary>
        /// Gets or sets the decades breakdown.
        /// <para>See also <seealso cref="TraktUserReviewDecadeCount" />.</para>
        /// </summary>
        public List<TraktUserReviewDecadeCount>? Decades { get; set; }
    }
}
