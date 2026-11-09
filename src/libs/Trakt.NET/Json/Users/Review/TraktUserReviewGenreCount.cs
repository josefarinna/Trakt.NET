namespace TraktNET
{
    /// <summary>Represents genre counts for a media type in a review period.</summary>
    public record class TraktUserReviewGenreCount
    {
        /// <summary>Gets or sets the sum of all genre counts.</summary>
        public uint? ItemCount { get; set; }

        /// <summary>
        /// Gets or sets the list of genres and their counts.
        /// <para>See also <seealso cref="TraktUserReviewGenreItem" />.</para>
        /// </summary>
        public List<TraktUserReviewGenreItem>? Genres { get; set; }
    }
}
