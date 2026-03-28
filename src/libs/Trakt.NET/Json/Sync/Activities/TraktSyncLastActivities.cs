namespace TraktNET
{
    /// <summary>A collection of UTC datetimes of last activities.</summary>
    public record class TraktSyncLastActivities
    {
        /// <summary>Gets or sets the UTC datetime of the overall last activity.</summary>
        public DateTime? All { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for movies.
        /// See also <seealso cref="TraktSyncMoviesLastActivities" />.
        /// </summary>
        public TraktSyncMoviesLastActivities? Movies { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for episodes.
        /// See also <seealso cref="TraktSyncEpisodesLastActivities" />.
        /// </summary>
        public TraktSyncEpisodesLastActivities? Episodes { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for shows.
        /// See also <seealso cref="TraktSyncShowsLastActivities" />.
        /// </summary>
        public TraktSyncShowsLastActivities? Shows { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for seasons.
        /// See also <seealso cref="TraktSyncSeasonsLastActivities" />.
        /// </summary>
        public TraktSyncSeasonsLastActivities? Seasons { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for comments.
        /// See also <seealso cref="TraktSyncCommentsLastActivities" />.
        /// </summary>
        public TraktSyncCommentsLastActivities? Comments { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for lists.
        /// See also <seealso cref="TraktSyncListsLastActivities" />.
        /// </summary>
        public TraktSyncListsLastActivities? Lists { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for watchlists.
        /// See also <seealso cref="TraktSyncWatchlistLastActivities" />.
        /// </summary>
        public TraktSyncWatchlistLastActivities? Watchlist { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for favorites.
        /// See also <seealso cref="TraktSyncFavoritesLastActivities" />.
        /// </summary>
        public TraktSyncFavoritesLastActivities? Favorites { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for recommendations.
        /// See also <seealso cref="TraktSyncRecommendationsLastActivities" />.
        /// </summary>
        public TraktSyncRecommendationsLastActivities? Recommendations { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for collaborations.
        /// See also <seealso cref="TraktSyncCollaborationsLastActivities" />.
        /// </summary>
        public TraktSyncCollaborationsLastActivities? Collaborations { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for an account.
        /// See also <seealso cref="TraktSyncAccountLastActivities" />.
        /// </summary>
        public TraktSyncAccountLastActivities? Account { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for saved filters.
        /// See also <seealso cref="TraktSyncSavedFiltersLastActivities" />.
        /// </summary>
        public TraktSyncSavedFiltersLastActivities? SavedFilters { get; set; }

        /// <summary>
        /// Gets or sets a collection of UTC datetimes of last activities for notes.
        /// See also <seealso cref="TraktSyncNotesLastActivities" />.
        /// </summary>
        public TraktSyncNotesLastActivities? Notes { get; set; }
    }
}
