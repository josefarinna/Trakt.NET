namespace TraktNET
{
    /// <summary>Represents globally most played titles on Trakt in an all-time review.</summary>
    public record class TraktUserReviewAllTimeGlobalTop
    {
        /// <summary>
        /// Gets or sets the most played shows.
        /// <para>See also <seealso cref="TraktUserReviewGlobalTopShow" />.</para>
        /// </summary>
        public List<TraktUserReviewGlobalTopShow>? Shows { get; set; }

        /// <summary>
        /// Gets or sets the most played movies.
        /// <para>See also <seealso cref="TraktUserReviewGlobalTopMovie" />.</para>
        /// </summary>
        public List<TraktUserReviewGlobalTopMovie>? Movies { get; set; }
    }
}
