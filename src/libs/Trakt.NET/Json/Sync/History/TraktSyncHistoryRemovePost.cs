namespace TraktNET
{
    /// <summary>
    /// A Trakt history remove post, containing all movies, shows, seasons, episodes and / or history ids,
    /// which should be removed from the user's history.
    /// </summary>
    public record class TraktSyncHistoryRemovePost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryRemovePostMovie" />s.
        /// <para>Each <see cref="TraktSyncHistoryRemovePostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncHistoryRemovePostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryRemovePostShow" />s.
        /// <para>Each <see cref="TraktSyncHistoryRemovePostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncHistoryRemovePostShow>? Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryRemovePostSeason" />s.
        /// <para>Each <see cref="TraktSyncHistoryRemovePostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncHistoryRemovePostSeason>? Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncHistoryRemovePostEpisode" />s.
        /// <para>Each <see cref="TraktSyncHistoryRemovePostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncHistoryRemovePostEpisode>? Episodes { get; set; }

        /// <summary>An optional list of history ids, which should be removed.</summary>
        public List<ulong>? HistoryIds { get; set; }

        public virtual void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;
            bool bHasNoSeasons = Seasons == null || Seasons.Count == 0;
            bool bHasNoEpisodes = Episodes == null || Episodes.Count == 0;
            bool bHasNoHistoryIds = HistoryIds == null || HistoryIds.Count == 0;

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes && bHasNoHistoryIds)
                throw new TraktPostValidationException("no history items set");
        }
    }
}
