namespace TraktNET
{
    /// <summary>Contains information about a user's social activity item.</summary>
    public record class TraktUserActivity
    {
        /// <summary>Gets or sets the activity ID.</summary>
        public ulong? Id { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the activity occurred.</summary>
        public DateTime? ActivityAt { get; set; }

        /// <summary>Gets or sets the action string for the activity.</summary>
        public string? Action { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this activity item contains.
        /// See also <seealso cref="TraktSyncItemType" />.
        /// </summary>
        public TraktSyncItemType? Type { get; set; }

        /// <summary>
        /// Gets or sets the user who performed the activity.
        /// See also <seealso cref="TraktUser" />.
        /// </summary>
        public TraktUser? User { get; set; }

        /// <summary>Gets or sets the user rating, if applicable.</summary>
        public uint? UserRating { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktSyncItemType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        public TraktMovie? Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktSyncItemType.Show" /> or <see cref="TraktSyncItemType.Episode" /> or <see cref="TraktSyncItemType.Season" />.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        public TraktShow? Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktSyncItemType.Season" /> or <see cref="TraktSyncItemType.Episode" />.
        /// See also <seealso cref="TraktSeason" />.
        /// </summary>
        public TraktSeason? Season { get; set; }

        /// <summary>
        /// Gets or sets the episode, if <see cref="Type" /> is <see cref="TraktSyncItemType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// </summary>
        public TraktEpisode? Episode { get; set; }

        /// <summary>
        /// Gets or sets the list, if applicable.
        /// See also <seealso cref="TraktList" />.
        /// </summary>
        public TraktList? List { get; set; }

        /// <summary>
        /// Gets or sets the comment, if applicable.
        /// See also <seealso cref="TraktComment" />.
        /// </summary>
        public TraktComment? Comment { get; set; }
    }
}
