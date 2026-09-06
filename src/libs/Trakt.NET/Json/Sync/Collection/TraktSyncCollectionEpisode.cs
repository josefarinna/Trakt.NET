namespace TraktNET
{
    /// <summary>A Trakt collected episode, containing an episode, show, and collection information about it.</summary>
    public record class TraktSyncCollectionEpisode
    {
        /// <summary>Gets or sets the object type. See also <seealso cref="TraktSyncItemType" />.</summary>
        public TraktSyncItemType? Type { get; set; }

        /// <summary>Gets or sets the episode. See also <seealso cref="TraktEpisode" />.</summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>Gets or sets the show. See also <seealso cref="TraktShow" />.</summary>
        public TraktShow? Show { get; set; }

        /// <summary>Gets or sets the UTC datetime when the episode was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime when the episode was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets a list of streaming services where the collected item is available.
        /// See also <seealso cref="TraktSyncCollectionAvailableOn" />.
        /// </summary>
        public List<TraktSyncCollectionAvailableOn>? AvailableOn { get; set; }

        /// <summary>Gets a string representation of the episode.</summary>
        /// <returns>A string representation of the episode.</returns>
        public override string ToString()
        {
            if (Episode != null)
            {
                return Episode.ToString();
            }

            return string.Empty;
        }
    }
}
