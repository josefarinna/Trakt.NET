namespace TraktNET
{
    /// <summary>Represents a recommended popular unwatched show in a review period.</summary>
    public record class TraktUserReviewThanksShow
    {
        /// <summary>
        /// Gets or sets the show.
        /// <para>See also <seealso cref="TraktShow" />.</para>
        /// </summary>
        public TraktShow? Show { get; set; }
    }
}
