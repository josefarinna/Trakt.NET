namespace TraktNET
{
    /// <summary>
    /// A Trakt watchlist post, containing all movies, shows, seasons and / or episodes,
    /// which should be added to the user's watchlist.
    /// </summary>
    public record class TraktSyncWatchlistPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncWatchlistPostMovie" />s.
        /// <para>Each <see cref="TraktSyncWatchlistPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncWatchlistPostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncWatchlistPostShow" />s.
        /// <para>Each <see cref="TraktSyncWatchlistPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncWatchlistPostShow>? Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncWatchlistPostSeason" />s.
        /// <para>Each <see cref="TraktSyncWatchlistPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncWatchlistPostSeason>? Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncWatchlistPostEpisode" />s.
        /// <para>Each <see cref="TraktSyncWatchlistPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncWatchlistPostEpisode>? Episodes { get; set; }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;
            bool bHasNoSeasons = Seasons == null || Seasons.Count == 0;
            bool bHasNoEpisodes = Episodes == null || Episodes.Count == 0;

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes)
                throw new TraktPostValidationException("no watchlist items set");
        }
    }
}
