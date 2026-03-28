namespace TraktNET
{
    /// <summary>Contains information about a Trakt playback progress, including the corresponding movie or episode.</summary>
    public record class TraktSyncPlaybackProgressItem
    {
        /// <summary>Gets or sets the id of this progress item.</summary>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets a value between 0 and 100 representing the watched progress percentage
        /// of the movie or episode.
        /// </summary>
        public float? Progress { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the watched movie or episode was paused.</summary>
        public DateTime? PausedAt { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this progress item contains.
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
