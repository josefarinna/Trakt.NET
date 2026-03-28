namespace TraktNET
{
    /// <summary>
    /// A Trakt history post, containing all movies, shows, seasons and / or episodes,
    /// which should be added to the user's history.
    /// </summary>
    public record class TraktSyncHistoryPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostMovie" />s.
        /// <para>Each <see cref="TraktSyncHistoryPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncHistoryPostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostShow" />s.
        /// <para>Each <see cref="TraktSyncHistoryPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncHistoryPostShow>? Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostSeason" />s.
        /// <para>Each <see cref="TraktSyncHistoryPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncHistoryPostSeason>? Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryPostEpisode" />s.
        /// <para>Each <see cref="TraktSyncHistoryPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncHistoryPostEpisode>? Episodes { get; set; }

        public virtual void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;
            bool bHasNoSeasons = Seasons == null || Seasons.Count == 0;
            bool bHasNoEpisodes = Episodes == null || Episodes.Count == 0;

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes)
                throw new TraktPostValidationException("no history items set");
        }
    }
}
