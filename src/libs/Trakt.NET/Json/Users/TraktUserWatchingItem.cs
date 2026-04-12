namespace TraktNET
{
    /// <summary>Contains information about a movie or an episode a Trakt user is currently watching.</summary>
    public record class TraktUserWatchingItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie or episode started.</summary>
        public DateTime? StartedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie or episode expires.</summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the action type for the movie or episode.
        /// See also <seealso cref="TraktHistoryActionType" />.
        /// </summary>
        public TraktHistoryActionType? Action { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this watching item contains.
        /// See also <seealso cref="TraktSyncType" />.
        /// </summary>
        public TraktSyncType? Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSyncType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSyncType.Episode" />.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktSyncType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }
    }
}
