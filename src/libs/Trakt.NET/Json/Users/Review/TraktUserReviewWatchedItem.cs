namespace TraktNET
{
    /// <summary>Represents a watched movie or episode in a review period.</summary>
    public record class TraktUserReviewWatchedItem
    {
        /// <summary>Gets or sets the UTC datetime when the item was watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>
        /// Gets or sets the type of the watched item.
        /// <para>See also <seealso cref="TraktSyncItemType" />.</para>
        /// </summary>
        public TraktSyncItemType? Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSyncItemType.Movie" />.
        /// <para>See also <seealso cref="TraktMovie" />.</para>
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSyncItemType.Episode" />.
        /// <para>See also <seealso cref="TraktShow" />.</para>
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktSyncItemType.Episode" />.
        /// <para>See also <seealso cref="TraktEpisode" />.</para>
        /// </summary>
        public TraktEpisode? Episode { get; set; }
    }
}
