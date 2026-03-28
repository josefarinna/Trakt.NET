namespace TraktNET
{
    /// <summary>
    /// A Trakt ratings post, containing all movies, shows, seasons and / or episodes,
    /// which should be added to the user's ratings.
    /// </summary>
    public record class TraktSyncRatingsPost
    {
        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostMovie" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsPostMovie>? Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostShow" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsPostShow>? Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostSeason" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsPostSeason>? Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostEpisode" />s.
        /// <para>Each <see cref="TraktSyncRatingsPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public List<TraktSyncRatingsPostEpisode>? Episodes { get; set; }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || Movies.Count == 0;
            bool bHasNoShows = Shows == null || Shows.Count == 0;
            bool bHasNoSeasons = Seasons == null || Seasons.Count == 0;
            bool bHasNoEpisodes = Episodes == null || Episodes.Count == 0;

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes)
                throw new TraktPostValidationException("no ratings items set");
        }
    }
}
