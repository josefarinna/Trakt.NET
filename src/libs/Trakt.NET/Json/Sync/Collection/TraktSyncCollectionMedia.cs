namespace TraktNET
{
    /// <summary>A Trakt collection item, containing a movie, show, or episode and collection information about it.</summary>
    public record class TraktSyncCollectionMedia
    {
        /// <summary>Gets or sets the object type, which this collection item contains. See also <seealso cref="TraktSyncItemType" />.</summary>
        public TraktSyncItemType? Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSyncItemType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSyncItemType.Show" />.
        /// May also be set, if <see cref="Type" /> is <see cref="TraktSyncItemType.Episode" />.
        /// <para>See also <seealso cref="TraktShow" />.</para>
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktSyncItemType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>
        /// Gets or sets a list of collected seasons in the collected show, if <see cref="Type" /> is <see cref="TraktSyncItemType.Show" />.
        /// See also <seealso cref="TraktSyncCollectionShowSeason" />.
        /// </summary>
        public List<TraktSyncCollectionShowSeason>? Seasons { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie or episode was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie or episode was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the show was last collected.</summary>
        public DateTime? LastCollectedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the show was last updated.</summary>
        public DateTime? LastUpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets a list of streaming services where the collected item is available.
        /// See also <seealso cref="TraktSyncCollectionAvailableOn" />.
        /// </summary>
        public List<TraktSyncCollectionAvailableOn>? AvailableOn { get; set; }
    }
}
