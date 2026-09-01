namespace TraktNET
{
    /// <summary>A collection of Trakt user statistics.</summary>
    public record class TraktUserStatistics
    {
        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for movies.
        /// See also <seealso cref="TraktUserMoviesStatistics" />.
        /// </summary>
        public TraktUserMoviesStatistics? Movies { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for shows.
        /// See also <seealso cref="TraktUserShowsStatistics" />.
        /// </summary>
        public TraktUserShowsStatistics? Shows { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for seasons.
        /// See also <seealso cref="TraktUserSeasonsStatistics" />.
        /// </summary>
        public TraktUserSeasonsStatistics? Seasons { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for episodes.
        /// See also <seealso cref="TraktUserEpisodesStatistics" />.
        /// </summary>
        public TraktUserEpisodesStatistics? Episodes { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics about an user's network.
        /// See also <seealso cref="TraktUserNetworkStatistics" />.
        /// </summary>
        public TraktUserNetworkStatistics? Network { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for ratings.
        /// See also <seealso cref="TraktUserRatingsStatistics" />.
        /// </summary>
        public TraktUserRatingsStatistics? Ratings { get; set; }

        /// <summary>
        /// Gets or sets a collection of Trakt user statistics for progress.
        /// See also <seealso cref="TraktUserProgressStatistics" />.
        /// </summary>
        public TraktUserProgressStatistics? Progress { get; set; }

        /// <summary>Gets or sets the number of lists an user has created.</summary>
        public uint? Lists { get; set; }

        /// <summary>Gets or sets the total number of minutes an user has watched.</summary>
        public uint? TotalMinutes { get; set; }

        /// <summary>Gets or sets the total number of plays an user has.</summary>
        public uint? TotalPlays { get; set; }
    }
}
