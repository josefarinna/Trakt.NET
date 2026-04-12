namespace TraktNET
{
    /// <summary>A collection of Trakt user limits.</summary>
    public record class TraktUserLimits
    {
        /// <summary>
        /// Gets or sets the user's list limits.
        /// See also <seealso cref="TraktUserListLimits" />.
        /// </summary>
        public TraktUserListLimits? List { get; set; }

        /// <summary>
        /// Gets or sets the user's watchlist limits.
        /// See also <seealso cref="TraktUserWatchlistLimits" />.
        /// </summary>
        public TraktUserWatchlistLimits? Watchlist { get; set; }

        /// <summary>
        /// Gets or sets the user's favorites limits.
        /// See also <seealso cref="TraktUserFavoritesLimits" />.
        /// </summary>
        public TraktUserFavoritesLimits? Favorites { get; set; }

        /// <summary>
        /// Gets or sets the user's search limits.
        /// See also <seealso cref="TraktUserSearchLimits" />.
        /// </summary>
        public TraktUserSearchLimits? Search { get; set; }

        /// <summary>
        /// Gets or sets the user's collection limits.
        /// See also <seealso cref="TraktUserCollectionLimits" />.
        /// </summary>
        public TraktUserCollectionLimits? Collection { get; set; }

        /// <summary>
        /// Gets or sets the user's notes limits.
        /// See also <seealso cref="TraktUserNotesLimits" />.
        /// </summary>
        public TraktUserNotesLimits? Notes { get; set; }

        /// <summary>
        /// Gets or sets the user's saved filters limits.
        /// See also <seealso cref="TraktUserSavedFiltersLimits" />.
        /// </summary>
        public TraktUserSavedFiltersLimits? SavedFilters { get; set; }

        /// <summary>
        /// Gets or sets the user's recommendations limits.
        /// See also <seealso cref="TraktUserRecommendationsLimits" />.
        /// </summary>
        public TraktUserRecommendationsLimits? Recommendations { get; set; }

    }
}
